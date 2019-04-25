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
        }

        public void Create()
        {
        }

        public void Edit()
        { }

        public void Delete()
        {

        }

        protected void OnSelectedActionChanged()
        {

        }

        public void LoadData()
        {
            //vm.Model = ViewModelSource.Create(()=> new Models.OperationRoomActionModel());
            //vm.Model.Created = DateTime.Now;
            //vm.Model.

            //var data = _uow.OperationRoomRepository.Entities.ToList();
            //var list = _mapper.Map<IList<OperationRoomActionViewModel>>(data);

            
            var list = new List<OperationRoomActionViewModel>();
            var vm = ViewModelSource.Create(() => new OperationRoomActionViewModel());
            vm.Model =  Builder<OperationRoomActionModel>.CreateNew().Build();
            list.Add(vm);
            vm = ViewModelSource.Create(() => new OperationRoomActionViewModel());
            vm.Model = Builder<OperationRoomActionModel>.CreateNew().Build();
            list.Add(vm);
            vm = ViewModelSource.Create(() => new OperationRoomActionViewModel());
            vm.Model = Builder<OperationRoomActionModel>.CreateNew().Build();
            list.Add(vm);
            vm = ViewModelSource.Create(() => new OperationRoomActionViewModel());
            vm.Model = Builder<OperationRoomActionModel>.CreateNew().Build();
            list.Add(vm);
            vm = ViewModelSource.Create(() => new OperationRoomActionViewModel());
            vm.Model = Builder<OperationRoomActionModel>.CreateNew().Build();
            list.Add(vm);

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
