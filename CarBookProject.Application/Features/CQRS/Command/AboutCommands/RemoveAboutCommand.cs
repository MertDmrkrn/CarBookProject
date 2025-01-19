using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Command.AboutCommands
{
    public class RemoveAboutCommand
    {
        public int ID { get; set; }

        public RemoveAboutCommand(int id)
        {
            ID = id;
        }
    }
}
