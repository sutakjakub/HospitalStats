﻿using DevExpress.Mvvm;
using HS.Data.Repositories;
using HS.Wpf.ARO.Messages;
using HS.Wpf.ARO.Models;
using HS.Wpf.Shared.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomActionViewModel
    {
        public virtual OperationRoomActionModel Model { get; set; }

        public OperationRoomActionViewModel()
        {
        }

        public void Delete()
        {
            Messenger.Default.Send(new DeleteOrMessage(Model.Id));
        }
    }
}
