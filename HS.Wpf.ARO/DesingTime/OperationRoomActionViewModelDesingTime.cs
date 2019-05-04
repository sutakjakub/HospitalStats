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
            var gen = new RandomGenerator();

            Model = Builder<OperationRoomActionModel>.CreateNew()
                .With(p => p.Risks_Over65Years = gen.Boolean())
                .With(p => p.Risks_CombA = gen.Boolean())
                .With(p => p.Risks_RA = gen.Boolean())
                .With(p => p.Risks_Risks = gen.Next(1, 5))
                .With(p => p.Risks_Ups = gen.Boolean())
                .Build();
        }
    }
}
