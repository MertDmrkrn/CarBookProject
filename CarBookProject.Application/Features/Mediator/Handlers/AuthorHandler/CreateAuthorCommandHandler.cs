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
	public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
	{
		private readonly IRepository<Author> _repository;

		public CreateAuthorCommandHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Author
			{
				AuthorName = request.AuthorName,
				Description = request.Description,
				ImgURL = request.ImgURL
			});
		}
	}
}
