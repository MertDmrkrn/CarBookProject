using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandler
{
	public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
	{
		private readonly IRepository<Comment> _repository;

		public CreateCommentCommandHandler(IRepository<Comment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Comment
			{
				Description = request.Description,
				Name = request.Name,
				CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
				BlogID = request.BlogID,
				Email = request.Email
			});
		}
	}
}
