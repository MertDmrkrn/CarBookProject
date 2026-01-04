using CarBookProject.Application.Features.Mediator.Results.CarFeatureResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.CarFeatureQuery
{
	public class GetCarFeatureByCarIdQuery : IRequest<List<GetCarFeatureByCarIdQueryResult>>
	{
		public int Id { get; set; }

		public GetCarFeatureByCarIdQuery(int id)
		{
			Id = id;
		}
	}
}
