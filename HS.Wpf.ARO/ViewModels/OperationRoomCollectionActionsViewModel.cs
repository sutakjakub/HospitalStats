using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using HS.Wpf.ARO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomCollectionActionsViewModel : ViewModelBase
    {
        public virtual ObservableCollection<OperationRoomActionViewModel> Actions { get; set; }

        public OperationRoomCollectionActionsViewModel()
        {
            Actions = new ObservableCollection<OperationRoomActionViewModel>();
        }

        public void LoadData(IList<OperationRoomActionViewModel> data)
        {
            //TODO: dispatcher
            Actions = new ObservableCollection<OperationRoomActionViewModel>(data);
        }

        public void AddEmptyAction()
        {
            var vm = ViewModelSource.Create(() => new OperationRoomActionViewModel());
            vm.Model = ViewModelSource.Create(() => new OperationRoomActionModel(true));
            vm.YearBirthday = DateTime.Now.Year;
            vm.Model.SaveModelState();

            Actions.Insert(0, vm);
        }
    }
}
