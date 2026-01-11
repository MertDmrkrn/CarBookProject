using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQuery
{
	public class GetCarDescriptionByCarIdQuery:IRequest<GetCarDescriptionByCarIdQueryResult>
	{
		public int Id { get; set; }

		public GetCarDescriptionByCarIdQuery(int id)
		{
			Id = id;
		}
	}
}
