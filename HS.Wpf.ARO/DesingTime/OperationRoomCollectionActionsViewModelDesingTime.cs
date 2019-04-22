using FizzWare.NBuilder;
using HS.Wpf.ARO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.DesingTime
{
    public class OperationRoomCollectionActionsViewModelDesingTime : OperationRoomCollectionActionsViewModel
    {
        public OperationRoomCollectionActionsViewModelDesingTime()
        {
            Actions = new ObservableCollection<OperationRoomActionViewModel>();

            Actions.Add(new OperationRoomActionViewModelDesingTime());
            Actions.Add(new OperationRoomActionViewModelDesingTime());
            Actions.Add(new OperationRoomActionViewModelDesingTime());
            Actions.Add(new OperationRoomActionViewModelDesingTime());
            Actions.Add(new OperationRoomActionViewModelDesingTime());
        }
    }
}
