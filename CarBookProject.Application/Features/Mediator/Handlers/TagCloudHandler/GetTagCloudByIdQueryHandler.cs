﻿using CarBook.Domain.Entities;
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
	public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
	{
		private readonly IRepository<TagCloud> _repository;

		public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
		{
			_repository = repository;
		}

		public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
		{
			var values=await _repository.GetByIdAsync(request.Id);
			return new GetTagCloudByIdQueryResult
			{
				BlogID = values.BlogID,
				TagCloudID = values.TagCloudID,
				Title = values.Title
			};
		}
	}
}
