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

namespace HS.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string s = "";
            for (int i = 39; i < 50; i++)
            {
                sb.AppendLine(string.Format(@"<ColumnDefinition Width=&# Binding ElementName=Column{0}, Path=ActualWidth|& />", i));
            }
            s = sb.ToString();
            s = s.Replace("&", "\"");
            s = s.Replace("#", "{");
            s = s.Replace("|", "}");

            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs-CZ");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            using (var ctx = new HsDbContext())
            {
                ctx.Database.Initialize(true);
            }

            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AroProfile>();
            }).CreateMapper();

            AppCore.InitIoC();

            AppCore.IoC.RegisterInstance(mapper, new SingletonLifetimeManager());
            AppCore.IoC.RegisterType<AroUnitOfWork>(new PerResolveLifetimeManager());
            AppCore.IoC.RegisterType<ARO.ViewModels.MainViewModel>(new PerResolveLifetimeManager());

            MainWindow = new MainWindow();
            MainWindow.DataContext = ViewModelSource.Create(() => new MainWindowViewModel());
            MainWindow.Show();
        }
    }
}
