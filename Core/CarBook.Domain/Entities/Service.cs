﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }

        public string ServiceTitle { get; set; }
        
        public string ServiceDescription { get; set; }

        public string ServiceIcon { get; set; }
    }
}
