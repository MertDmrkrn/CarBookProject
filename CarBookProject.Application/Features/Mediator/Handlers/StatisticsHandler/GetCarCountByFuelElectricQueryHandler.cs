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
	public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public GetCarCountByFuelElectricQueryHandler(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
		{
			var value = _statisticsRepository.GetCarCountByFuelElectric();
			return new GetCarCountByFuelElectricQueryResult
			{
				CarCountByFuelElectric = value,
			};
		}
	}
}
