using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.BlogQuery;
using CarBookProject.Application.Features.Mediator.Results.BlogResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandler
{
	public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
	{
		private readonly IRepository<Blog> _repository;

		public GetBlogByIdQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);

			return new GetBlogByIdQueryResult
			{
				AuthorID = values.AuthorID,
				BlogID = values.BlogID,
				CategoryID = values.CategoryID,
				CoverImgURL = values.CoverImgURL,
				CreatedDate = values.CreatedDate,
				Title = values.Title
			};
		}
	}
}
