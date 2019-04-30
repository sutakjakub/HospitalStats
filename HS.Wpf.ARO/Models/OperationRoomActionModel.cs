using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace HS.Wpf.ARO.Models
{
    public class OperationRoomActionModel : IEditableObject
    {
        private OperationRoomActionModel modelState;
        private bool _isNew;

        #region model properties
        public virtual int Id { get; set; }

        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual bool IsDeleted { get; set; }

        public virtual string Description { get; set; }
        public virtual DateTime IssueDate { get; set; }
        public virtual DateTime Birthday { get; set; }

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
        public virtual bool Perf_CaOti { get; set; }
        /// <summary>
        /// Statistika výkony - 2. celková anestezie CA + LM
        /// </summary>
        public virtual bool Perf_CaLm { get; set; }
        /// <summary>
        /// Statistika výkony - 3. celkova + regionalni (kombinovana) CA + RA
        /// </summary>
        public virtual bool Perf_CaRa { get; set; }
        /// <summary>
        /// Statistika výkony - 4. epiduralni anestezii CLEA
        /// </summary>
        public virtual bool Perf_Clea { get; set; }
        /// <summary>
        /// Statistika výkony - 5. hrudni epiduralni anes. TAC
        /// </summary>
        public virtual bool Perf_Tac { get; set; }
        /// <summary>
        /// Statistika výkony - 6) ve spinalni anestezii SAA
        /// </summary>
        public virtual bool Perf_Saa { get; set; }
        /// <summary>
        /// Statistika výkony - 7) cervikalni blok C2-3
        /// </summary>
        public virtual bool Perf_C23 { get; set; }
        /// <summary>
        /// Statistika výkony - 8) suprakarikularni (nadklickove) - INF
        /// </summary>
        public virtual bool Perf_Inf { get; set; }
        /// <summary>
        /// Statistika výkony - 9) aksilarni blok AXI
        /// </summary>
        public virtual bool Perf_Axi { get; set; }
        /// <summary>
        /// Statistika výkony - 10) foot blok - FOOT 
        /// </summary>
        public virtual bool Perf_Foot { get; set; }
        /// <summary>
        /// Statistika výkony - 11) analgosedace - ANALGO
        /// </summary>
        public virtual bool Perf_Analgo { get; set; }
        /// <summary>
        /// Statistika výkony - 12) isch blok - ISCH
        /// </summary>
        public virtual bool Perf_Isch { get; set; }
        /// <summary>
        /// Statistika výkony - 13) scalenicky blok - SCAL_BLOCK
        /// </summary>
        public virtual bool Perf_ScalBlock { get; set; }
        /// <summary>
        /// Statistika výkony - 14) poplit blok - POPLIT_BLOCK
        /// </summary>
        public virtual bool Perf_PoplitBlock { get; set; }
        /// <summary>
        /// Statistika výkony - 16) odeslano na ARO pacient
        /// </summary>
        public virtual bool Perf_SendToAro { get; set; }
        /// <summary>
        /// Statistika výkony - 17) JDCH (jedno dennni chirurgie)
        /// </summary>
        public virtual bool Perf_Jdch { get; set; }
        /// <summary>
        /// Statistika výkony - 18) anestezie nad 2 hodiny
        /// </summary>
        public virtual bool Perf_MoreThan2Hours { get; set; }
        /// <summary>
        /// Statistika výkony - 20) v prubehu UPS (ustavni pohotovosti)
        /// </summary>
        public virtual bool Perf_DuringUps { get; set; }
        /// <summary>
        /// Statistika výkony - 20) v prubehu UPS (ustavni pohotovosti) - nad 65 let
        /// </summary>
        public virtual bool Perf_DuringUps_Over65Years { get; set; }
        /// <summary>
        /// Statistika výkony - 21) anes dohled
        /// </summary>
        public virtual bool Perf_Control { get; set; }
        /// <summary>
        /// Statistika výkony - 22) biluminarni rourky - Cévní
        /// </summary>
        public virtual bool Perf_BilumRourky_Cevni { get; set; }
        /// <summary>
        /// Statistika výkony - 22) biluminarni rourky - HYperhydróza
        /// </summary>
        public virtual bool Perf_BilumRourky_Hyperhydroza { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice
        /// </summary>
        public virtual bool Perf_Over65Years { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice
        /// </summary>
        public virtual bool Perf_Over65Years_MoreThan2Hours { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice - regionální
        /// </summary>
        public virtual bool Perf_Over65Years_Ra { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice - kombinovaná
        /// </summary>
        public virtual bool Perf_Over65Years_Ca { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19
        /// </summary>
        public virtual bool Perf_UpTo19Years { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19 - nad 2 hodiny
        /// </summary>
        public virtual bool Perf_UpTo19Years_MoreThan2Hours { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19 - regionální
        /// </summary>
        public virtual bool Perf_UpTo19Years_Ra { get; set; }

        /// <summary>
        /// Komplikace - 1) neplanovane prijeti na aro
        /// </summary>
        public virtual bool Compl_UnplanedAro { get; set; }
        /// <summary>
        /// Komplikace - 2) poranneni pacienta behem anestezie
        /// </summary>
        public virtual bool Compl_HurtDuringA { get; set; }
        /// <summary>
        /// Komplikace - 3) obtizna OTI (intubace)
        /// </summary>
        public virtual bool Compl_Oti { get; set; }
        /// <summary>
        /// Komplikace - 4) neplanavova obtizna OTI
        /// </summary>
        public virtual bool Compl_UnplanedOti { get; set; }
        /// <summary>
        /// Komplikace - 5) neuspesna intubace
        /// </summary>
        public virtual bool Compl_FailedOti { get; set; }
        /// <summary>
        /// Komplikace - 6) selhani RA
        /// </summary>
        public virtual bool Compl_FailedRa { get; set; }
        /// <summary>
        /// Komplikace - 7) punkce dury s unikem CCF
        /// </summary>
        public virtual bool Compl_Ccf { get; set; }
        /// <summary>
        /// Komplikace - 8) mors in tabula
        /// </summary>
        public virtual bool Compl_MorsInTabula { get; set; }
        /// <summary>
        /// Komplikace - 9) selhani anes pristroje
        /// </summary>
        public virtual bool Compl_FailedMachine { get; set; }
        #endregion

        public virtual bool IsDirty { get; set; }

        public OperationRoomActionModel()
        {
        }

        public OperationRoomActionModel(bool isNew)
        {
            _isNew = isNew;
            if (isNew)
            {
                IsDirty = true;
                IssueDate = DateTime.Now.Date;
            }
        }
            
        protected void OnBirthdayChanged()
        {
            CalculateYearsOld();
        }

        protected void OnIssueDateChanged()
        {
            CalculateYearsOld();
        }

        public void CalculateYearsOld()
        {
            var years = IssueDate.Year - Birthday.Year;
            Perf_Over65Years = years >= 65;
            Perf_UpTo19Years = years <= 19;
        }

        public void SaveModelState()
        {
            var json = JsonConvert.SerializeObject(this);
            modelState = JsonConvert.DeserializeObject<OperationRoomActionModel>(json);
        }

        public void BeginEdit()
        {
        }

        public void EndEdit()
        {
            if (_isNew) return;

            if (IsSame(modelState, this))
            {
                IsDirty = false;
            }
            else
            {
                IsDirty = true;
            }
        }

        public void CancelEdit()
        {
        }

        private bool IsSame(OperationRoomActionModel m1, OperationRoomActionModel m2)
        {
            return
                m1.Birthday == m2.Birthday &&
                m1.Compl_Ccf == m2.Compl_Ccf &&
                m1.Compl_FailedMachine == m2.Compl_FailedMachine &&
                m1.Compl_FailedOti == m2.Compl_FailedOti &&
                m1.Compl_FailedRa == m2.Compl_FailedRa &&
                m1.Compl_HurtDuringA == m2.Compl_HurtDuringA &&
                m1.Compl_MorsInTabula == m2.Compl_MorsInTabula &&
                m1.Compl_Oti == m2.Compl_Oti &&
                m1.Compl_UnplanedAro == m2.Compl_UnplanedAro &&
                m1.Compl_UnplanedOti == m2.Compl_UnplanedOti &&
                m1.Created == m2.Created &&
                m1.Description == m2.Description &&
                m1.Id == m2.Id &&
                m1.IsDeleted == m2.IsDeleted &&
                m1.IssueDate == m2.IssueDate &&
                m1.Modified == m2.Modified &&
                m1.Perf_Analgo == m2.Perf_Analgo &&
                m1.Perf_Axi == m2.Perf_Axi &&
                m1.Perf_BilumRourky_Cevni == m2.Perf_BilumRourky_Cevni &&
                m1.Perf_BilumRourky_Hyperhydroza == m2.Perf_BilumRourky_Hyperhydroza &&
                m1.Perf_C23 == m2.Perf_C23 &&
                m1.Perf_CaLm == m2.Perf_CaLm &&
                m1.Perf_CaOti == m2.Perf_CaOti &&
                m1.Perf_CaRa == m2.Perf_CaRa &&
                m1.Perf_Clea == m2.Perf_Clea &&
                m1.Perf_Control == m2.Perf_Control &&
                m1.Perf_DuringUps == m2.Perf_DuringUps &&
                m1.Perf_DuringUps_Over65Years == m2.Perf_DuringUps_Over65Years &&
                m1.Perf_Foot == m2.Perf_Foot &&
                m1.Perf_Inf == m2.Perf_Inf &&
                m1.Perf_Isch == m2.Perf_Isch &&
                m1.Perf_Jdch == m2.Perf_Jdch &&
                m1.Perf_MoreThan2Hours == m2.Perf_MoreThan2Hours &&
                m1.Perf_Over65Years == m2.Perf_Over65Years &&
                m1.Perf_Over65Years_Ca == m2.Perf_Over65Years_Ca &&
                m1.Perf_Over65Years_MoreThan2Hours == m2.Perf_Over65Years_MoreThan2Hours &&
                m1.Perf_Over65Years_Ra == m2.Perf_Over65Years_Ra &&
                m1.Perf_PoplitBlock == m2.Perf_PoplitBlock &&
                m1.Perf_Saa == m2.Perf_Saa &&
                m1.Perf_ScalBlock == m2.Perf_ScalBlock &&
                m1.Perf_SendToAro == m2.Perf_SendToAro &&
                m1.Perf_Tac == m2.Perf_Tac &&
                m1.Perf_UpTo19Years == m2.Perf_UpTo19Years &&
                m1.Perf_UpTo19Years_MoreThan2Hours == m2.Perf_UpTo19Years_MoreThan2Hours &&
                m1.Perf_UpTo19Years_Ra == m2.Perf_UpTo19Years_Ra &&
                m1.Risks_CombA == m2.Risks_CombA &&
                m1.Risks_Over65Years == m2.Risks_Over65Years &&
                m1.Risks_RA == m2.Risks_RA &&
                m1.Risks_Risks == m2.Risks_Risks &&
                m1.Risks_Ups == m2.Risks_Ups;

        }
    }
}
