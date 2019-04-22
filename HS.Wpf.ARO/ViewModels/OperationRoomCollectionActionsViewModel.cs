using DevExpress.Mvvm;
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
        }

        public void LoadData(IList<OperationRoomActionViewModel> data)
        {
            //TODO: dispatcher
            Actions = new ObservableCollection<OperationRoomActionViewModel>(data);
        }
    }
}
