using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Data.Entitites.ARO
{
    [Table("ARO_OperationRoom_Actions")]
    public class OperationRoomAction : EntityBase
    {
        public string Description { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Rizika - Rizika
        /// </summary>
        public int Risks_Risks { get; set; }
        /// <summary>
        /// Rizika - RA
        /// </summary>
        public int Risks_RA { get; set; }
        /// <summary>
        /// Rizika - pohotovost
        /// </summary>
        public int Risks_Ups { get; set; }
        /// <summary>
        /// Rizika - kombinovaná anestezie
        /// </summary>
        public int Risks_CombA { get; set; }
        /// <summary>
        /// Rizika - nad 65 let
        /// </summary>
        public int Risks_Over65Years { get; set; }


        /// <summary>
        /// Statistika výkony - 1. celková anestezie z GA + OTI (intubace)
        /// </summary>
        public bool Perf_CaOti { get; set; }
        /// <summary>
        /// Statistika výkony - 2. celková anestezie CA + LM
        /// </summary>
        public bool Perf_CaLm { get; set; }
        /// <summary>
        /// Statistika výkony - 3. celkova + regionalni (kombinovana) CA + RA
        /// </summary>
        public bool Perf_CaRa { get; set; }
        /// <summary>
        /// Statistika výkony - 4. epiduralni anestezii CLEA
        /// </summary>
        public bool Perf_Clea { get; set; }
        /// <summary>
        /// Statistika výkony - 5. hrudni epiduralni anes. TAC
        /// </summary>
        public bool Perf_Tac { get; set; }
        /// <summary>
        /// Statistika výkony - 6) ve spinalni anestezii SAA
        /// </summary>
        public bool Perf_Saa { get; set; }
        /// <summary>
        /// Statistika výkony - 7) cervikalni blok C2-3
        /// </summary>
        public bool Perf_C23 { get; set; }
        /// <summary>
        /// Statistika výkony - 8) suprakarikularni (nadklickove) - INF
        /// </summary>
        public bool Perf_Inf { get; set; }
        /// <summary>
        /// Statistika výkony - 9) aksilarni blok AXI
        /// </summary>
        public bool Perf_Axi { get; set; }
        /// <summary>
        /// Statistika výkony - 10) foot blok - FOOT 
        /// </summary>
        public bool Perf_Foot { get; set; }
        /// <summary>
        /// Statistika výkony - 11) analgosedace - ANALGO
        /// </summary>
        public bool Perf_Analgo { get; set; }
        /// <summary>
        /// Statistika výkony - 12) isch blok - ISCH
        /// </summary>
        public bool Perf_Isch { get; set; }
        /// <summary>
        /// Statistika výkony - 13) scalenicky blok - SCAL_BLOCK
        /// </summary>
        public bool Perf_ScalBlock { get; set; }
        /// <summary>
        /// Statistika výkony - 14) poplit blok - POPLIT_BLOCK
        /// </summary>
        public bool Perf_PoplitBlock { get; set; }
        /// <summary>
        /// Statistika výkony - 16) odeslano na ARO pacient
        /// </summary>
        public bool Perf_SendToAro { get; set; }
        /// <summary>
        /// Statistika výkony - 17) JDCH (jedno dennni chirurgie)
        /// </summary>
        public bool Perf_Jdch { get; set; }
        /// <summary>
        /// Statistika výkony - 18) anestezie nad 2 hodiny
        /// </summary>
        public bool Perf_MoreThan2Hours { get; set; }
        /// <summary>
        /// Statistika výkony - 20) v prubehu UPS (ustavni pohotovosti)
        /// </summary>
        public bool Perf_DuringUps { get; set; }
        /// <summary>
        /// Statistika výkony - 20) v prubehu UPS (ustavni pohotovosti) - nad 65 let
        /// </summary>
        public bool Perf_DuringUps_Over65Years { get; set; }
        /// <summary>
        /// Statistika výkony - 21) anes dohled
        /// </summary>
        public bool Perf_Control { get; set; }
        /// <summary>
        /// Statistika výkony - 22) biluminarni rourky - Cévní
        /// </summary>
        public bool Perf_BilumRourky_Cevni { get; set; }
        /// <summary>
        /// Statistika výkony - 22) biluminarni rourky - HYperhydróza
        /// </summary>
        public bool Perf_BilumRourky_Hyperhydroza { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice
        /// </summary>
        public bool Perf_Over65Years { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice
        /// </summary>
        public bool Perf_Over65Years_MoreThan2Hours { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice - regionální
        /// </summary>
        public bool Perf_Over65Years_Ra { get; set; }
        /// <summary>
        /// Statistika výkony - 23) nad 65 a vice - kombinovaná
        /// </summary>
        public bool Perf_Over65Years_Ca { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19
        /// </summary>
        public bool Perf_UpTo19Years { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19 - nad 2 hodiny
        /// </summary>
        public bool Perf_UpTo19Years_MoreThan2Hours { get; set; }
        /// <summary>
        /// Statistika výkony - 24) děti 0 - 19 - regionální
        /// </summary>
        public bool Perf_UpTo19Years_Ra { get; set; }

        /// <summary>
        /// Komplikace - 1) neplanovane prijeti na aro
        /// </summary>
        public bool Compl_UnplanedAro { get; set; }
        /// <summary>
        /// Komplikace - 2) poranneni pacienta behem anestezie
        /// </summary>
        public bool Compl_HurtDuringA { get; set; }
        /// <summary>
        /// Komplikace - 3) obtizna OTI (intubace)
        /// </summary>
        public bool Compl_Oti { get; set; }
        /// <summary>
        /// Komplikace - 4) neplanavova obtizna OTI
        /// </summary>
        public bool Compl_UnplanedOti { get; set; }
        /// <summary>
        /// Komplikace - 5) neuspesna intubace
        /// </summary>
        public bool Compl_FailedOti { get; set; }
        /// <summary>
        /// Komplikace - 6) selhani RA
        /// </summary>
        public bool Compl_FailedRa { get; set; }
        /// <summary>
        /// Komplikace - 7) punkce dury s unikem CCF
        /// </summary>
        public bool Compl_Ccf { get; set; }
        /// <summary>
        /// Komplikace - 8) mors in tabula
        /// </summary>
        public bool Compl_MorsInTabula { get; set; }
        /// <summary>
        /// Komplikace - 9) selhani anes pristroje
        /// </summary>
        public bool Compl_FailedMachine { get; set; }

    }
}
