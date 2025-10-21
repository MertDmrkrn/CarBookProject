using CarBookProject.Application.Features.Mediator.Results.BlogResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.BlogQuery
{
	public class GetBlogByAuthorIdQuery : IRequest<List<GetBlogByAuthorIdQueryResult>>
	{
		public int Id { get; set; }

		public GetBlogByAuthorIdQuery(int id)
		{
			Id = id;
		}
	}
}
