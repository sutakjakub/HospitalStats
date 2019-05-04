using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using Unity;

namespace HS.Wpf.ViewModels
{
    public class MainWindowViewModel
    {
        public virtual object DataContextConcrete { get; set; }
        private readonly Notifier _notifier;

        public MainWindowViewModel()
        {
            var vm = AppCore.IoC.Resolve<ARO.ViewModels.MainViewModel>();
            vm.SetViewModelByString("OperationRoom");

            DataContextConcrete = vm;

            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 150);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(5),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        public void BackupDatabase()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = $"hsDb_{DateTime.Now.Date.ToString("yyyy_MM_dd")}_{Guid.NewGuid()}.sqlite"; // Default file name
            dlg.DefaultExt = ".sqlite"; // Default file extension
            dlg.Filter = "SQLite database (.sqlite)|*.sqlite"; // Filter files by extension

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string destination = dlg.FileName;

                var source = System.AppDomain.CurrentDomain.BaseDirectory;
                source = Path.Combine(source, @"db\hsDb.sqlite");
                try
                {
                    File.Copy(source, destination);
                    _notifier.ShowSuccess($"Databáze úspěšně uložena do {destination}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Nepovedlo se zálohovat databázi.", MessageBoxButton.OK, MessageBoxImage.Error);
                    _notifier.ShowSuccess($"Databáze z cesty {source} se nepovedla uložit do {destination}");
                }
            }
        }
    }
}
