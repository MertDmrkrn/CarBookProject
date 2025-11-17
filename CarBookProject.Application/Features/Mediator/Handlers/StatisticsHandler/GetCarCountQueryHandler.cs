using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQuery;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResult;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandler
{
	public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
	{
		private readonly ICarRepository _carRepository;

		public GetCarCountQueryHandler(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
		{
			var values = _carRepository.GetCarCount();
			return new GetCarCountQueryResult
			{
				CarCount = values,
			};
		}
	}
}
