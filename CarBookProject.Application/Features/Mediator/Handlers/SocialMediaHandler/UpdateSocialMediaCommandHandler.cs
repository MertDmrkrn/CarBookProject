using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.SocialMediaHandler
{
	public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommad>
	{
		private readonly IRepository<SocialMedia> _repository;

		public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateSocialMediaCommad request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.SocialMediaID);
			values.SocialMediaName = request.SocialMediaName;
			values.SocialMediaIcon = request.SocialMediaIcon;
			values.SocialMediaUrl = request.SocialMediaUrl;
			await _repository.UpdateAsync(values);
		}
	}
}
