using FizzWare.NBuilder;
using HS.Wpf.ARO.Models;
using HS.Wpf.ARO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.DesingTime
{
    public class OperationRoomActionViewModelDesingTime : OperationRoomActionViewModel
    {
        public OperationRoomActionViewModelDesingTime()
        {
            Model = Builder<OperationRoomActionModel>.CreateNew().Build();
            InitModel(Model);
        }
    }
}
