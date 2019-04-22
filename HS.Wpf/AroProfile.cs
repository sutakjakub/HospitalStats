using AutoMapper;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf
{
    public class AroProfile : Profile
    {
        public AroProfile()
        {
            CreateMap<ARO.Models.OperationRoomActionModel, Data.Entitites.ARO.OperationRoomAction>();
            CreateMap<Data.Entitites.ARO.OperationRoomAction, ARO.Models.OperationRoomActionModel>()
                .ConstructUsing((source, ctx) =>
                {
                    return ViewModelSource.Create(() => new ARO.Models.OperationRoomActionModel());
                });

            CreateMap<ARO.ViewModels.OperationRoomActionViewModel, Data.Entitites.ARO.OperationRoomAction>()
                .ConstructUsing((source, ctx) =>
                {
                    var model = ctx.Mapper.Map<Data.Entitites.ARO.OperationRoomAction>(source.Model);
                    return model;
                });

            CreateMap<Data.Entitites.ARO.OperationRoomAction, ARO.ViewModels.OperationRoomActionViewModel>()
                .ConstructUsing((source, ctx) =>
                {
                    var vm = ViewModelSource.Create(() => new ARO.ViewModels.OperationRoomActionViewModel());
                    vm.Model = ctx.Mapper.Map<ARO.Models.OperationRoomActionModel>(source);

                    return vm;
                });
        }
    }
}
