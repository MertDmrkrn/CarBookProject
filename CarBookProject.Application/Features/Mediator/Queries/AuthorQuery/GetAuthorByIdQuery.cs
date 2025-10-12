using CarBookProject.Application.Features.Mediator.Results.AuthorResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.AuthorQuery
{
	public class GetAuthorByIdQuery : IRequest<GetAuthorByIdQueryResult>
	{
		public int Id { get; set; }

		public GetAuthorByIdQuery(int id)
		{
			Id = id;
		}
	}
}
