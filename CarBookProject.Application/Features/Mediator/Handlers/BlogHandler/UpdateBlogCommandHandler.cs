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
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public UpdateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.BlogID);
			values.CoverImgURL = request.CoverImgURL;
			values.Title = request.Title;
			values.CreatedDate = request.CreatedDate;
			values.CategoryID = request.CategoryID;
			values.AuthorID = request.AuthorID;
			await _repository.UpdateAsync(values);
		}
	}
}
