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

        public bool Q1 { get; set; }
        public bool Q2 { get; set; }
        public bool Q3 { get; set; }
        public bool Q4 { get; set; }
        public bool Q5 { get; set; }
    }
}
