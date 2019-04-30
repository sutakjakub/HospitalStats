using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.Messages
{
    public class DeleteOrMessage
    {
        public int Id { get; set; }

        public DeleteOrMessage(int id)
        {
            Id = id;
        }
    }
}
