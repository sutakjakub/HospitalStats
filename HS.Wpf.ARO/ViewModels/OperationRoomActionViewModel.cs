using HS.Data.Repositories;
using HS.Wpf.ARO.Models;
using HS.Wpf.Shared.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomActionViewModel
    {
        public virtual OperationRoomActionModel Model { get; set; }

        public virtual ComboBoxItem Q1Item { get; set; }
        public virtual ComboBoxItem Q2Item { get; set; }
        public virtual ComboBoxItem Q3Item { get; set; }
        public virtual ComboBoxItem Q4Item { get; set; }
        public virtual ComboBoxItem Q5Item { get; set; }


        public OperationRoomActionViewModel()
        {
        }

        public void OnModelChanged()
        {
            if (Model != null)
            {
                Q1Item = BooleanSource.GetByValue(Model.Q1);
                Q2Item = BooleanSource.GetByValue(Model.Q2);
                Q3Item = BooleanSource.GetByValue(Model.Q3);
                Q4Item = BooleanSource.GetByValue(Model.Q4);
                Q5Item = BooleanSource.GetByValue(Model.Q5);
            }
        }

        protected void InitModel(OperationRoomActionModel model)
        {
            if (model != null)
            {
                Q1Item = BooleanSource.GetByValue(model.Q1);
                Q2Item = BooleanSource.GetByValue(model.Q2);
                Q3Item = BooleanSource.GetByValue(model.Q3);
                Q4Item = BooleanSource.GetByValue(model.Q4);
                Q5Item = BooleanSource.GetByValue(model.Q5);
            }
        }
    }
}
