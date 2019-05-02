using HS.Wpf.ARO.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.ViewModels
{
    public class OperationRoomStatsViewModel
    {
        private IList<OperationRoomActionModel> _models;
        public virtual SeriesCollection PatientsCollection { get; set; }

        #region properties
        /// <summary>
        /// Rizika - Rizika
        /// </summary>
        public virtual int Risks_Risks { get; set; }
        /// <summary>
        /// Rizika - RA
        /// </summary>
        public virtual int Risks_RA { get; set; }
        /// <summary>
        /// Rizika - pohotovost
        /// </summary>
        public virtual int Risks_Ups { get; set; }
        /// <summary>
        /// Rizika - kombinovaná anestezie
        /// </summary>
        public virtual int Risks_CombA { get; set; }
        /// <summary>
        /// Rizika - nad 65 let
        /// </summary>
        public virtual int Risks_Over65Years { get; set; }

        /// <summary>
        /// Statistika výkony - 1. celková anestezie z GA + OTI (intubace)
        /// </summary>
        public virtual int Perf_CaOti_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 2. celková anestezie CA + LM
        /// </summary>
        public virtual int Perf_CaLm_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 3. celkova + regionalni (kombinovana) CA + RA
        /// </summary>
        public virtual int Perf_CaRa_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 4. epiduralni anestezii CLEA
        /// </summary>
        public virtual int Perf_Clea_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 5. hrudni epiduralni anes. TAC
        /// </summary>
        public virtual int Perf_Tac_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 6) ve spinalni anestezii SAA
        /// </summary>
        public virtual int Perf_Saa_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 7) cervikalni blok C2-3
        /// </summary>
        public virtual int Perf_C23_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 8) suprakarikularni (nadklickove) - INF
        /// </summary>
        public virtual int Perf_Inf_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 9) aksilarni blok AXI
        /// </summary>
        public virtual int Perf_Axi_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 10) foot blok - FOOT 
        /// </summary>
        public virtual int Perf_Foot_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 11) analgosedace - ANALGO
        /// </summary>
        public virtual int Perf_Analgo_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 12) isch blok - ISCH
        /// </summary>
        public virtual int Perf_Isch_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 13) scalenicky blok - SCAL_BLOCK
        /// </summary>
        public virtual int Perf_ScalBlock_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 14) poplit blok - POPLIT_BLOCK
        /// </summary>
        public virtual int Perf_PoplitBlock_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 16) odeslano na ARO pacient
        /// </summary>
        public virtual int Perf_SendToAro_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 17) JDCH (jedno dennni chirurgie)
        /// </summary>
        public virtual int Perf_Jdch_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 18) anestezie nad 2 hodiny
        /// </summary>
        public virtual int Perf_MoreThan2Hours_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 20) v prubehu UPS (ustavni pohotovosti)
        /// </summary>
        public virtual int Perf_DuringUps_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 20) v prubehu UPS (ustavni pohotovosti) - nad 65 let
        /// </summary>
        public virtual int Perf_DuringUps_Over65Years_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 21) anes dohled
        /// </summary>
        public virtual int Perf_Control_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 22) biluminarni rourky - Cévní
        /// </summary>
        public virtual int Perf_BilumRourky_Cevni_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 22) biluminarni rourky - HYperhydróza
        /// </summary>
        public virtual int Perf_BilumRourky_Hyperhydroza_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice
        /// </summary>
        public virtual int Perf_Over65Years_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice
        /// </summary>
        public virtual int Perf_Over65Years_MoreThan2Hours_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice - regionální
        /// </summary>
        public virtual int Perf_Over65Years_Ra_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice - kombinovaná
        /// </summary>
        public virtual int Perf_Over65Years_Ca_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19
        /// </summary>
        public virtual int Perf_UpTo19Years_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19 - nad 2 hodiny
        /// </summary>
        public virtual int Perf_UpTo19Years_MoreThan2Hours_SUM { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19 - regionální
        /// </summary>
        public virtual int Perf_UpTo19Years_Ra_SUM { get; set; }

        /// <summary>
        /// Komplikace - 1) neplanovane prijeti na aro
        /// </summary>
        public virtual int Compl_UnplanedAro_SUM { get; set; }
        /// <summary>
        /// Komplikace - 2) poranneni pacienta behem anestezie
        /// </summary>
        public virtual int Compl_HurtDuringA_SUM { get; set; }
        /// <summary>
        /// Komplikace - 3) obtizna OTI (intubace)
        /// </summary>
        public virtual int Compl_Oti_SUM { get; set; }
        /// <summary>
        /// Komplikace - 4) neplanavova obtizna OTI
        /// </summary>
        public virtual int Compl_UnplanedOti_SUM { get; set; }
        /// <summary>
        /// Komplikace - 5) neuspesna intubace
        /// </summary>
        public virtual int Compl_FailedOti_SUM { get; set; }
        /// <summary>
        /// Komplikace - 6) selhani RA
        /// </summary>
        public virtual int Compl_FailedRa_SUM { get; set; }
        /// <summary>
        /// Komplikace - 7) punkce dury s unikem CCF
        /// </summary>
        public virtual int Compl_Ccf_SUM { get; set; }
        /// <summary>
        /// Komplikace - 8) mors in tabula
        /// </summary>
        public virtual int Compl_MorsInTabula_SUM { get; set; }
        /// <summary>
        /// Komplikace - 9) selhani anes pristroje
        /// </summary>
        public virtual int Compl_FailedMachine_SUM { get; set; }
        #endregion

        /// <summary>
        /// Anestezií celkem
        /// </summary>
        public virtual int Summary_Anes { get; set; }
        /// <summary>
        /// Regionálních anestezií celkem
        /// </summary>
        public virtual int Summary_RA_Anes { get; set; }

        /// <summary>
        /// Počet položek
        /// </summary>
        public virtual int TotalItemsCount { get; set; }


        public void Load(IList<OperationRoomActionModel> models)
        {
            _models = models ?? throw new ArgumentNullException(nameof(models));

            TotalItemsCount = _models.Count;
            Summary_Anes = TotalItemsCount; //stejný počewt jako položek

            LoadPieSeries();
            LoadPerf();
            LoadCompl();
            Load_Summary_RA_Anes();
        }

        private void Load_Summary_RA_Anes()
        {
            Summary_RA_Anes = Perf_Clea_SUM + Perf_Tac_SUM + Perf_Saa_SUM + Perf_C23_SUM + Perf_Inf_SUM + Perf_Axi_SUM + Perf_Foot_SUM + Perf_PoplitBlock_SUM + Perf_Isch_SUM + Perf_ScalBlock_SUM;
        }

        private void LoadCompl()
        {
            Compl_Ccf_SUM = _models.Count(s => s.Compl_Ccf);
            Compl_FailedMachine_SUM = _models.Count(s => s.Compl_FailedMachine);
            Compl_FailedOti_SUM = _models.Count(s => s.Compl_FailedOti);
            Compl_FailedRa_SUM = _models.Count(s => s.Compl_FailedRa);
            Compl_HurtDuringA_SUM = _models.Count(s => s.Compl_HurtDuringA);
            Compl_MorsInTabula_SUM = _models.Count(s => s.Compl_MorsInTabula);
            Compl_Oti_SUM = _models.Count(s => s.Compl_Oti);
            Compl_UnplanedAro_SUM = _models.Count(s => s.Compl_UnplanedAro);
            Compl_UnplanedOti_SUM = _models.Count(s => s.Compl_UnplanedOti);
        }

        private void LoadPerf()
        {
            Perf_Analgo_SUM = _models.Count(s=>s.Perf_Analgo);
            Perf_Axi_SUM = _models.Count(s => s.Perf_Axi);
            Perf_BilumRourky_Cevni_SUM = _models.Count(s => s.Perf_BilumRourky_Cevni);
            Perf_BilumRourky_Hyperhydroza_SUM = _models.Count(s => s.Perf_BilumRourky_Hyperhydroza);
            Perf_C23_SUM = _models.Count(s => s.Perf_C23);
            Perf_CaLm_SUM = _models.Count(s => s.Perf_CaLm);
            Perf_CaOti_SUM = _models.Count(s => s.Perf_CaOti);
            Perf_CaRa_SUM = _models.Count(s => s.Perf_CaRa);
            Perf_Clea_SUM = _models.Count(s => s.Perf_Clea);
            Perf_Control_SUM = _models.Count(s => s.Perf_Control);
            Perf_DuringUps_Over65Years_SUM = _models.Count(s => s.Perf_DuringUps_Over65Years);
            Perf_DuringUps_SUM = _models.Count(s => s.Perf_DuringUps);
            Perf_Foot_SUM = _models.Count(s => s.Perf_Foot);
            Perf_Inf_SUM = _models.Count(s => s.Perf_Inf);
            Perf_Isch_SUM = _models.Count(s => s.Perf_Isch);
            Perf_Jdch_SUM = _models.Count(s => s.Perf_Jdch);
            Perf_MoreThan2Hours_SUM = _models.Count(s => s.Perf_MoreThan2Hours);
            Perf_Over65Years_Ca_SUM = _models.Count(s => s.Perf_Over65Years_Ca);
            Perf_Over65Years_MoreThan2Hours_SUM = _models.Count(s => s.Perf_Over65Years_MoreThan2Hours);
            Perf_Over65Years_Ra_SUM = _models.Count(s => s.Perf_Over65Years_Ra);
            Perf_Over65Years_SUM = _models.Count(s => s.Perf_Over65Years);
            Perf_PoplitBlock_SUM = _models.Count(s => s.Perf_PoplitBlock);
            Perf_Saa_SUM = _models.Count(s => s.Perf_Saa);
            Perf_ScalBlock_SUM = _models.Count(s => s.Perf_ScalBlock);
            Perf_SendToAro_SUM = _models.Count(s => s.Perf_SendToAro);
            Perf_Tac_SUM = _models.Count(s => s.Perf_Tac);
            Perf_UpTo19Years_MoreThan2Hours_SUM = _models.Count(s => s.Perf_UpTo19Years_MoreThan2Hours);
            Perf_UpTo19Years_Ra_SUM = _models.Count(s => s.Perf_UpTo19Years_Ra);
            Perf_UpTo19Years_SUM = _models.Count(s => s.Perf_UpTo19Years);
        }

        private void LoadPieSeries()
        {
            PatientsCollection = new SeriesCollection();

            PieSeries ps = new PieSeries();
            ps.Title = "65+ let";
            ps.Values = new ChartValues<ObservableValue> { new ObservableValue(_models.Where(p => p.Perf_Over65Years).Count()) };
            ps.DataLabels = false;
            PatientsCollection.Add(ps);

            ps = new PieSeries();
            ps.Title = "0-19let";
            ps.Values = new ChartValues<ObservableValue> { new ObservableValue(_models.Where(p => p.Perf_UpTo19Years).Count()) };
            ps.DataLabels = false;
            PatientsCollection.Add(ps);

            ps = new PieSeries();
            ps.Title = "Ostatní";
            ps.Values = new ChartValues<ObservableValue> { new ObservableValue(_models.Where(p => !p.Perf_UpTo19Years && !p.Perf_UpTo19Years).Count()) };
            ps.DataLabels = false;
            PatientsCollection.Add(ps);
        }

    }
}
