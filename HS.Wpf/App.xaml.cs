using HS.Data;
using HS.Data.Entitites.ARO;
using HS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity.Injection;
using Unity;
using Unity.Lifetime;
using AutoMapper;
using DevExpress.Mvvm.POCO;
using HS.Wpf.ViewModels;
using System.Globalization;
using System.Threading;
using System.Windows.Markup;
using System.Text;
using System.Diagnostics;

namespace HS.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs-CZ");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            //using (var ctx = new HsDbContext())
            //{

            //}

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AroProfile>();
            }).CreateMapper();

            AppCore.InitIoC();

            AppCore.IoC.RegisterInstance(mapper, new SingletonLifetimeManager());
            AppCore.IoC.RegisterType<AroUnitOfWork>(new PerResolveLifetimeManager());
            AppCore.IoC.RegisterType<ARO.ViewModels.MainViewModel>(new PerResolveLifetimeManager());

            if (false)
            {
                var uow = AppCore.IoC.Resolve<AroUnitOfWork>();

                ToConsole(uow.OperationRoomRepository.Entities);
                bool b;
                foreach (var item in uow.OperationRoomRepository.Entities.Where(p => p.IssueDate < new DateTime(2019, 03, 21)))
                {
                    b = item.Perf_CaRa;
                    item.Perf_CaRa = item.Perf_CaLm;
                    item.Perf_CaLm = b;

                    uow.OperationRoomRepository.Update(item);
                }

                uow.Save();

                ToConsole(uow.OperationRoomRepository.Entities);
            }

            MainWindow = new MainWindow();
            MainWindow.DataContext = ViewModelSource.Create(() => new MainWindowViewModel());
            MainWindow.Show();
        }

        private void ToConsole(IEnumerable<OperationRoomAction> entities)
        {
            foreach (var item in entities)
            {
                Trace.WriteLine($"{item.IssueDate} - CaRa:{item.Perf_CaRa} x CaLm:{item.Perf_CaLm}");
            }
        }
    }
}
