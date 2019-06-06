using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using HS.Wpf.ARO.Messages;
using HS.Wpf.ARO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomCollectionActionsViewModel : ViewModelBase
    {
        public DateTime LatestIssueDate { get; set; }

        public virtual ObservableCollection<OperationRoomActionViewModel> Actions { get; set; }

        public OperationRoomCollectionActionsViewModel()
        {
            Actions = new ObservableCollection<OperationRoomActionViewModel>();
        }

        public void LoadData(IList<OperationRoomActionViewModel> data)
        {
            Actions = new ObservableCollection<OperationRoomActionViewModel>(data);
        }

        public void AddEmptyAction()
        {
            var vm = ViewModelSource.Create(() => new OperationRoomActionViewModel());
            vm.Model = ViewModelSource.Create(() => new OperationRoomActionModel(true));
            vm.Model.IssueDate = LatestIssueDate;
            vm.Model.Birthday = DateTime.Now.Date;
            vm.Model.SaveModelState();

            Actions.Insert(0, vm);
        }

        public void ReCalculate(DataGrid grid)
        {
            var item = (OperationRoomActionViewModel)grid.SelectedCells[0].Item;
            item.Model.EndEdit();
        }
    }
}
