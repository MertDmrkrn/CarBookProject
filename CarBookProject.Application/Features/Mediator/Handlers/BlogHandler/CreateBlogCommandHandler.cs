using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.BlogCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandler
{
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public CreateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Blog
			{
				Title = request.Title,
				CoverImgURL = request.CoverImgURL,
				CreatedDate = request.CreatedDate,
				CategoryID = request.CategoryID,
				AuthorID = request.AuthorID,
			});
		}
	}
}
