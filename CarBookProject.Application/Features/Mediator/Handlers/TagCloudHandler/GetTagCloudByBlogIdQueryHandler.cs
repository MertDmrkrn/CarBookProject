using CarBookProject.Application.Features.Mediator.Queries.TagCloudQuery;
using CarBookProject.Application.Features.Mediator.Results.TagCloudResult;
using CarBookProject.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandler
{
	public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
	{
		private readonly ITagCloudRepository _tagCloudRepository;

		public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
		{
			_tagCloudRepository = tagCloudRepository;
		}

		public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
		{
			var values = _tagCloudRepository.GetTagCloudsByBlogId(request.Id);
			return values.Select(x => new GetTagCloudByBlogIdQueryResult
			{
				BlogID = x.BlogID,
				TagCloudID = x.TagCloudID,
				Title = x.Title
			}).ToList();
		}
	}
}
