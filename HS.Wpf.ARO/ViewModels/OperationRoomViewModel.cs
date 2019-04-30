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

        public OperationRoomViewModel(IMapper mapper, AroUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            CollectionActions = ViewModelSource.Create(() => new OperationRoomCollectionActionsViewModel());
            Messenger.Default.Register<DeleteOrMessage>(this, Delete);
            //Messenger.Default.Register<SaveOrMessage>(this, Save);
        }

        public void Save()
        {
            try
            {
                var list = _mapper.Map<IList<OperationRoomAction>>(CollectionActions.Actions.Select(s => s.Model.IsDirty));
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
