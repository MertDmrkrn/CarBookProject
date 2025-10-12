using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Results.BlogResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.BlogQuery
{
	public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
	{
		public int Id { get; set; }

		public GetBlogByIdQuery(int id)
		{
			Id = id;
		}
	}
}
