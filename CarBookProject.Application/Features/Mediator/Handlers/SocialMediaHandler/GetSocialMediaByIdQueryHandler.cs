using CarBook.Domain.Entities;
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
	public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
	{
		private readonly IRepository<SocialMedia> _repository;

		public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
		{

			var values = await _repository.GetByIdAsync(request.Id);
			return new GetSocialMediaByIdQueryResult
			{
				SocialMediaID = values.SocialMediaID,
				SocialMediaName = values.SocialMediaName,
				SocialMediaIcon = values.SocialMediaIcon,
				SocialMediaUrl = values.SocialMediaUrl,
			};
		}
	}
}
