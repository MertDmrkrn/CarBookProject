using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Command.BrandCommands
{
    public class CreateBrandCommand
    {
        public string BrandName { get; set; }
    }
}
