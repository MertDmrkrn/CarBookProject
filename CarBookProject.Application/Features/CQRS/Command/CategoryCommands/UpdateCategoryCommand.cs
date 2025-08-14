using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Command.CategoryCommands
{
	public class UpdateCategoryCommand
	{
		public int CategoryID { get; set; }

		public string CategoryName { get; set; }
	}
}
