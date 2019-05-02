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

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomViewModel : ViewModelBase
    {
        private readonly AroUnitOfWork _uow;
        private readonly IMapper _mapper;
        private bool _loaded = false;

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
        }

        public void Save()
        {
            try
            {
                var data = CollectionActions.Actions.Where(s => s.Model.IsDirty);
                var list = _mapper.Map<IList<OperationRoomAction>>(data);
                foreach (var item in list)
                {
                    if (item.Id > 0)
                    {
                        _uow.OperationRoomRepository.Update(item);
                    }
                    else
                    {
                        _uow.OperationRoomRepository.Add(item);
                    }
                }
                _uow.Save();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba uložení", MessageBoxButton.OK, MessageBoxImage.Error);
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
                _uow.OperationRoomRepository.Remove(msg.Id);
                _uow.Save();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba smazání", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected void OnSelectedActionChanged()
        {

        }

        public void LoadData()
        {
            var data = _uow.OperationRoomRepository.Entities.ToList();
            var list = _mapper.Map<IList<OperationRoomActionViewModel>>(data);

            CollectionActions.LoadData(list);
            Stats.Load(list.Select(s => s.Model).ToList());
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
