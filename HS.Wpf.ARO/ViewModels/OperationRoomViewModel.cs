using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm;
using HS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AutoMapper;
using FizzWare.NBuilder;
using HS.Wpf.ARO.Models;
using HS.Wpf.ARO.Messages;
using HS.Data.Entitites.ARO;
using System.Windows;
using System.Threading;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using System.Data;
using Microsoft.Win32;
using ClosedXML.Excel;
using System.IO;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomViewModel : ViewModelBase
    {
        private readonly AroUnitOfWork _uow;
        private readonly IMapper _mapper;
        private bool _loaded = false;

        private readonly Notifier _notifier;

        public virtual OperationRoomCollectionActionsViewModel CollectionActions { get; set; }
        public virtual OperationRoomActionViewModel SelectedAction { get; set; }
        public virtual OperationRoomStatsViewModel Stats { get; set; }

        public virtual DateTime FromDate { get; set; }
        public virtual DateTime ToDate { get; set; }

        public OperationRoomViewModel(IMapper mapper, AroUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            CollectionActions = ViewModelSource.Create(() => new OperationRoomCollectionActionsViewModel());
            Messenger.Default.Register<DeleteOrMessage>(this, Delete);
            Messenger.Default.Register<ReCalculateSelectedOrActionMessage>(this, ReCalculate);

            Stats = ViewModelSource.Create(() => new OperationRoomStatsViewModel());

            var now = DateTime.Now.Date;
            FromDate = new DateTime(now.Year, 1, 1);
            ToDate = now;

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

        private void ReCalculate(object obj)
        {
            //SelectedAction.Model.EndEdit();
        }

        public void Save()
        {
            try
            {
                var models = CollectionActions.Actions.Where(s => s.Model.IsDirty).Select(s => s.Model);
                OperationRoomAction action;
                foreach (var model in models)
                {
                    if (model.Id > 0)
                    {
                        action = _uow.OperationRoomRepository.Entities.Single(s => s.Id == model.Id);
                        _mapper.Map(model, action);
                        _uow.OperationRoomRepository.Update(action);
                    }
                    else
                    {
                        action = _mapper.Map<OperationRoomAction>(model);
                        CollectionActions.LatestIssueDate = model.IssueDate;
                        _uow.OperationRoomRepository.Add(action);
                    }
                }
                _uow.Save();

                ShowSuccessWithTime("Data uložena.");
                LoadData(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba uložení", MessageBoxButton.OK, MessageBoxImage.Error);
                ShowErrorNotifyWithTime("Data se nepocedla uložit.");
            }
        }

        public void Add()
        {
            CollectionActions.AddEmptyAction();
        }

        public void Delete(DeleteOrMessage msg)
        {
            try
            {
                var result = MessageBox.Show("Opravdu chcete smazat položku?", "Smazání položky", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (msg.Id > 0)
                    {
                        _uow.OperationRoomRepository.Remove(msg.Id);
                        _uow.Save();

                        ShowSuccessWithTime("Data smazána.");
                        LoadData(false);
                    }
                    else
                    {
                        var entity = CollectionActions.Actions.FirstOrDefault(p => p.Model.Id == msg.Id);
                        CollectionActions.Actions.Remove(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba smazání", MessageBoxButton.OK, MessageBoxImage.Error);
                ShowErrorNotifyWithTime("Smazání položky se nepovedlo.");
            }
        }

        protected void OnSelectedActionChanged()
        {

        }

        public void LoadData(bool checkNotSavedData = true)
        {
            try
            {
                if (checkNotSavedData && CollectionActions != null && CollectionActions.Actions != null && CollectionActions.Actions.Any(s => s.Model.IsDirty))
                {
                    var result = MessageBox.Show("Nemáte uložená data. Chcete pokračovat", "Nemáte uložená data", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.No) return;
                }

                var data = _uow.OperationRoomRepository.Entities
                            .Where(p => p.IssueDate >= FromDate && p.IssueDate <= ToDate)
                            .Where(p => !p.IsDeleted)
                            .OrderByDescending(d => d.IssueDate);

                var list = _mapper.Map<IList<OperationRoomActionViewModel>>(data);
                CollectionActions.LoadData(list);
                Stats.Load(list.Select(s => s.Model).ToList());

                ShowInfoNotifyWithTime($"Načteno: {CollectionActions.Actions.Count} anestezií");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba načítání dat", MessageBoxButton.OK, MessageBoxImage.Error);
                ShowErrorNotifyWithTime("Data se nepovedla načíst.");
            }
        }

        public void ExportToExcel()
        {
            var collectionId = CollectionActions.Actions.Where(p => p.Model.Id > 0).Select(s => s.Model.Id);
            var list = _uow.OperationRoomRepository.Entities.Where(p => collectionId.Contains(p.Id)).ToList();

            var datatable = list.ToDataTable();

            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = $"data_{DateTime.Now.Date.ToString("yyyy_MM_dd")}_{Guid.NewGuid()}.xlsx"; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Excel (.xlsx)|*.xlsx"; // Filter files by extension

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string destination = dlg.FileName;

                using (var workbook = new XLWorkbook())
                {
                    try
                    {
                        workbook.Worksheets.Add(datatable, "Data");
                        workbook.SaveAs(destination);

                        ShowSuccessWithTime($"Export do excelu uložen do {destination}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Nepovedlo se exportovat do excelu.", MessageBoxButton.OK, MessageBoxImage.Error);
                        ShowErrorNotifyWithTime($"Export do excelu se nezdařil uložit do {destination}");
                    }

                }
            }
        }

        public void Loaded()
        {
            if (!_loaded)
            {
                _loaded = true;
                LoadData(false);
            }
        }

        private void ShowErrorNotifyWithTime(string msg)
        {
            _notifier.ShowError(CreateNotifyString(msg).ToString());
        }

        private void ShowInfoNotifyWithTime(string msg)
        {
            _notifier.ShowInformation(CreateNotifyString(msg).ToString());
        }

        private void ShowSuccessWithTime(string msg)
        {
            _notifier.ShowSuccess(CreateNotifyString(msg).ToString());
        }

        private StringBuilder CreateNotifyString(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(msg);
            sb.AppendLine($"Čas: {DateTime.Now.ToString("HH:mm:ss")}");

            return sb;
        }
    }

    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
