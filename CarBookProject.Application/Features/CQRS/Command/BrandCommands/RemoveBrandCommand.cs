using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Command.BrandCommands
{
    public class RemoveBrandCommand
    {
        public int ID { get; set; }

        public RemoveBrandCommand(int id)
        {
            ID = id;
        }
    }
}
