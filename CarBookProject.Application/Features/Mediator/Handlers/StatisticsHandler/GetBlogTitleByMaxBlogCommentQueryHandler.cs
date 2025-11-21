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
	public class GetBlogTitleByMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResult>
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public GetBlogTitleByMaxBlogCommentQueryHandler(IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		public async Task<GetBlogTitleByMaxBlogCommentQueryResult> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
		{
			var value = _statisticsRepository.GetBlogTitleByMaxBlogComment();
			return new GetBlogTitleByMaxBlogCommentQueryResult
			{
				BlogTitleByMaxBlogComment = value,
			};
		}
	}
}
