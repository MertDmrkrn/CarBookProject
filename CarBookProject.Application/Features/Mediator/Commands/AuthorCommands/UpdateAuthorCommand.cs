using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.AuthorCommands
{
	public class UpdateAuthorCommand:IRequest
	{
		public int AuthorID { get; set; }

		public string AuthorName { get; set; }

		public string ImgURL { get; set; }

		public string Description { get; set; }
	}
}
