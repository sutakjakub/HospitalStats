using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace HS.Wpf
{
    public static class AppCore
    {
        public static IUnityContainer IoC;

        public static void InitIoC()
        {
            IoC = new UnityContainer();
        }
    }
}
