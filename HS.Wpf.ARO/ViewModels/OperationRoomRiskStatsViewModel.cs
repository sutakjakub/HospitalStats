using HS.Wpf.ARO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomRiskStatsViewModel
    {
        public virtual string Title { get; set; }

        /// <summary>
        /// Rizika - Rizika
        /// </summary>
        public virtual int Risks_Risks_SUM { get; set; }
        /// <summary>
        /// Rizika - RA
        /// </summary>
        public virtual int Risks_RA_SUM { get; set; }
        /// <summary>
        /// Rizika - pohotovost
        /// </summary>
        public virtual int Risks_Ups_SUM { get; set; }
        /// <summary>
        /// Rizika - kombinovaná anestezie
        /// </summary>
        public virtual int Risks_CombA_SUM { get; set; }
        /// <summary>
        /// Rizika - nad 65 let
        /// </summary>
        public virtual int Risks_Over65Years_SUM { get; set; }

        public virtual int TotalItemsCount { get; set; }

        public void Load(IList<OperationRoomActionModel> models, int risk)
        {
            if (risk >= 1 && risk <= 5)
            {
                TotalItemsCount = models.Count;
                var list = models.Where(p => p.Risks_Risks == risk);

                Title = $"Riziko {risk}";
                Risks_Risks_SUM = list.Count();
                Risks_RA_SUM = list.Count(s => s.Risks_RA);
                Risks_Ups_SUM = list.Count(s => s.Risks_Ups);
                Risks_CombA_SUM = list.Count(s => s.Risks_CombA);
                Risks_Over65Years_SUM = list.Count(s => s.Risks_Over65Years);
            }
            else
            {
                throw new ArgumentException($"Risk je mimo povolené hodnoty: {risk}", nameof(risk));
            }
        }
    }
}
