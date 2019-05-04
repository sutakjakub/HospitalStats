using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm;
using HS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutoMapper;
using FizzWare.NBuilder;
using HS.Wpf.ARO.Models;
using HS.Wpf.ARO.Messages;
using HS.Data.Entitites.ARO;
using System.Windows;
using System.Threading;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomViewModel : ViewModelBase
    {
        private readonly AroUnitOfWork _uow;
        private readonly IMapper _mapper;
        private bool _loaded = false;

        private readonly Notifier _notifier;

        public virtual OperationRoomCollectionActionsViewModel CollectionActions { get; set; }
        public virtual OperationRoomActionViewModel SelectedAction { get; set; }
        public virtual OperationRoomStatsViewModel Stats { get; set; }

        public virtual DateTime FromDate { get; set; }
        public virtual DateTime ToDate { get; set; }

        public OperationRoomViewModel(IMapper mapper, AroUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            CollectionActions = ViewModelSource.Create(() => new OperationRoomCollectionActionsViewModel());
            Messenger.Default.Register<DeleteOrMessage>(this, Delete);

            Stats = ViewModelSource.Create(() => new OperationRoomStatsViewModel());

            var now = DateTime.Now.Date;
            FromDate = new DateTime(now.Year, now.Month, 1);
            ToDate = now;

            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 150);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(5),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        public void Save()
        {
            try
            {
                var models = CollectionActions.Actions.Where(s => s.Model.IsDirty).Select(s => s.Model);
                OperationRoomAction action;
                foreach (var model in models)
                {
                    if (model.Id > 0)
                    {
                        action = _uow.OperationRoomRepository.Entities.Single(s => s.Id == model.Id);
                        _mapper.Map(model, action);
                        _uow.OperationRoomRepository.Update(action);
                    }
                    else
                    {
                        action = _mapper.Map<OperationRoomAction>(model);
                        _uow.OperationRoomRepository.Add(action);
                    }
                }
                _uow.Save();

                _notifier.ShowSuccess("Data uložena.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba uložení", MessageBoxButton.OK, MessageBoxImage.Error);
                _notifier.ShowError("Data se nepocedla uložit.");
            }
        }

        public void Add()
        {
            CollectionActions.AddEmptyAction();
        }

        public void Delete(DeleteOrMessage msg)
        {
            try
            {
                var result = MessageBox.Show("Opravdu chcete smazat položku?", "Smazání položky", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (msg.Id > 0)
                    {
                        _uow.OperationRoomRepository.Remove(msg.Id);
                        _uow.Save();

                        _notifier.ShowSuccess("Data smazána.");
                        LoadData();
                    }
                    else
                    {
                        var entity = CollectionActions.Actions.FirstOrDefault(p => p.Model.Id == msg.Id);
                        CollectionActions.Actions.Remove(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba smazání", MessageBoxButton.OK, MessageBoxImage.Error);
                _notifier.ShowError("Smazání položky se nepovedlo.");
            }
        }

        protected void OnSelectedActionChanged()
        {

        }

        public void LoadData()
        {
            try
            {
                if (CollectionActions != null && CollectionActions.Actions != null && CollectionActions.Actions.Any(s => s.Model.IsDirty))
                {
                    var result = MessageBox.Show("Nemáte uložená data. Chcete pokračovat", "Nemáte uložená data", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.No) return;
                }

                var data = _uow.OperationRoomRepository.Entities
                            .Where(p => p.IssueDate >= FromDate && p.IssueDate <= ToDate)
                            .Where(p => !p.IsDeleted)
                            .OrderByDescending(d => d.IssueDate);

                var list = _mapper.Map<IList<OperationRoomActionViewModel>>(data);
                CollectionActions.LoadData(list);
                Stats.Load(list.Select(s => s.Model).ToList());

                _notifier.ShowInformation("Data načtena.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba načítání dat", MessageBoxButton.OK, MessageBoxImage.Error);
                _notifier.ShowError("Data se nepovedla načíst.");
            }
        }

        public void Loaded()
        {
            if (!_loaded)
            {
                _loaded = true;
                LoadData();
            }
        }
    }
}
