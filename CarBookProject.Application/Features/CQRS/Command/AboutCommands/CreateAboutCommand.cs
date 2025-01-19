using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Command.AboutCommands
{
    public class CreateAboutCommand
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }
    }
}
