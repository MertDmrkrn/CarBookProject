using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.BlogResult
{
	public class GetBlogByAuthorIdQueryResult
	{
		public int BlogID { get; set; }

		public string AuthorName { get; set; }

		public string AuthorDescription { get; set; }

		public string AuthorImgUrl { get; set; }

		public int AuthorID { get; set; }
	}
}
