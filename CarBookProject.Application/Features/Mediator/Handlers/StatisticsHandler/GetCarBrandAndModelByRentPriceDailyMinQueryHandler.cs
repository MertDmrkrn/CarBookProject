using CarBookProject.Application.Features.Mediator.Queries.StatisticsQuery;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResult;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandler
{
	public class GetCarBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinQueryResult>
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public GetCarBrandAndModelByRentPriceDailyMinQueryHandler(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		public async Task<GetCarBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
		{
			var value = _statisticsRepository.GetCarBrandAndModelByRentPriceDailyMin();
			return new GetCarBrandAndModelByRentPriceDailyMinQueryResult
			{
				CarBrandAndModelByRentPriceDailyMin = value,
			};
		}
	}
}
