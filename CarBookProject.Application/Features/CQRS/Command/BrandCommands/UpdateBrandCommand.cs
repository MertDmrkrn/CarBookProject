using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Command.BrandCommands
{
    public class UpdateBrandCommand
    {
        public int BrandID { get; set; }

        public string BrandName { get; set; }
    }
}
