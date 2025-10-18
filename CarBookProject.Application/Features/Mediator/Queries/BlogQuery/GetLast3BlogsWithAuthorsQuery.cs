using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Features.Mediator.Results.BlogResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.BlogQuery
{
	public class GetLast3BlogsWithAuthorsQuery:IRequest<List<GetLast3BlogWithAuthorsQueryResult>>
	{

	}
}
