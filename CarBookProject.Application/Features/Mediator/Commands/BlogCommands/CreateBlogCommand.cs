using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.BlogCommands
{
	public class CreateBlogCommand : IRequest
	{
		public string Title { get; set; }

		public int AuthorID { get; set; }

		public string CoverImgURL { get; set; }

		public DateTime CreatedDate { get; set; }

		public int CategoryID { get; set; }
	}
}
