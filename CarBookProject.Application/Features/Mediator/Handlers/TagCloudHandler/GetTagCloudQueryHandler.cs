using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.TagCloudQuery;
using CarBookProject.Application.Features.Mediator.Results.TagCloudResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandler
{
	public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
	{
		private readonly IRepository<TagCloud> _repository;

		public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetTagCloudQueryResult
			{
				BlogID = x.BlogID,
				TagCloudID = x.TagCloudID,
				Title = x.Title
			}).ToList();
		}
	}
}
