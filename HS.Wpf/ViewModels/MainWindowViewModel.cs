using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace HS.Wpf.ViewModels
{
    public class MainWindowViewModel
    {
        public virtual object DataContextConcrete { get; set; }

        public MainWindowViewModel()
        {
            var vm = AppCore.IoC.Resolve<ARO.ViewModels.MainViewModel>();
            vm.SetViewModelByString("OperationRoom");

            DataContextConcrete = vm;
        }
    }
}
