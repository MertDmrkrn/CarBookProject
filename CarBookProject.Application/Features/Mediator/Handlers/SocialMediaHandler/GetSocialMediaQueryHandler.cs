using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.ServiceQuery;
using CarBookProject.Application.Features.Mediator.Queries.SocialMediaQuery;
using CarBookProject.Application.Features.Mediator.Results.SocialMediaResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.SocialMediaHandler
{
	public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
	{
		private readonly IRepository<SocialMedia> _repository;

		public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetSocialMediaQueryResult
			{
				SocialMediaID = x.SocialMediaID,
				SocialMediaName = x.SocialMediaName,
				SocialMediaIcon = x.SocialMediaIcon,
				SocialMediaUrl = x.SocialMediaUrl
			}).ToList();
		}
	}
}
