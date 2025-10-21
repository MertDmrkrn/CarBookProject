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
	public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _blogRepository;

		public GetAllBlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = _blogRepository.GetAllBlogsWithAuthors();
			return values.Select(x => new GetAllBlogsWithAuthorQueryResult
			{
				AuthorID = x.AuthorID,
				AuthorName = x.Author.AuthorName,
				BlogID = x.BlogID,
				CategoryID = x.CategoryID,
				CoverImgURL = x.CoverImgURL,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				Description = x.Description,
				AuthorDescription = x.Author.Description,
				AuthorImgUrl = x.Author.ImgURL
			}).ToList();
		}
	}
}
