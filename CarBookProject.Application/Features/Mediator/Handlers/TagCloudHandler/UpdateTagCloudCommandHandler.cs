using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandler
{
	public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
	{
		private readonly IRepository<TagCloud> _repository;

		public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.TagCloudID);
			values.TagCloudID = request.TagCloudID;
			values.Title = request.Title;
			values.BlogID = request.BlogID;
			await _repository.UpdateAsync(values);
		}
	}
}
