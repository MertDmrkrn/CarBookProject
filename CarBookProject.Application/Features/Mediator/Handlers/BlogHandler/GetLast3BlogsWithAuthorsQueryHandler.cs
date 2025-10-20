using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.BlogQuery;
using CarBookProject.Application.Features.Mediator.Results.BlogResult;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandler
{
	public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogWithAuthorsQueryResult>>
	{
		private readonly IBlogRepository _blogRepository;

		public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<List<GetLast3BlogWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
		{
			var values = _blogRepository.GetLast3BlogsWithAuthors();
			return values.Select(x => new GetLast3BlogWithAuthorsQueryResult
			{
				AuthorID = x.AuthorID,
				BlogID = x.BlogID,
				CategoryID = x.CategoryID,
				CoverImgURL = x.CoverImgURL,
				CreatedDate = x.CreatedDate,
				Description = x.Description,
				Title = x.Title,
				AuthorName = x.Author.AuthorName

			}).ToList();
		}
	}
}
