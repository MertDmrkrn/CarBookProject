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
	public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
	{
		private readonly IStatisticsRepository _statisticRepository;

		public GetAvgRentPriceForMonthlyQueryHandler(IStatisticsRepository statisticRepository)
		{
			_statisticRepository = statisticRepository;
		}

		public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
		{
			var value = _statisticRepository.GetAvgRentPriceForMonthly();
			return new GetAvgRentPriceForMonthlyQueryResult
			{
				AvgRentPriceForMonthly = value,
			};
		}
	}
}
