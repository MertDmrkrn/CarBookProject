using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.AuthorCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.AuthorHandler
{
	public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
	{
		private readonly IRepository<Author> _repository;

		public UpdateAuthorCommandHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.AuthorID);
			values.AuthorName = request.AuthorName;
			values.Description = request.Description;
			values.ImgURL = request.ImgURL;
			await _repository.UpdateAsync(values);
		}
	}
}
