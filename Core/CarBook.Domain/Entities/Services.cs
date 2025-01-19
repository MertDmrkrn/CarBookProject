using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Services
    {
        public int ServicesID { get; set; }

        public string ServicesTitle { get; set; }
        
        public string ServicesDescription { get; set; }

        public string ServicesIcon { get; set; }
    }
}
