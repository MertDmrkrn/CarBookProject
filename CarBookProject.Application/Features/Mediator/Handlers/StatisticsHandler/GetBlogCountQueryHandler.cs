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
	public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
	{

		private readonly IStatisticsRepository _statisticsRepository;

		public GetBlogCountQueryHandler(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
		{
			var value = _statisticsRepository.GetBlogCount();
			return new GetBlogCountQueryResult
			{
				BlogCount = value,
			};
		}
	}
}
