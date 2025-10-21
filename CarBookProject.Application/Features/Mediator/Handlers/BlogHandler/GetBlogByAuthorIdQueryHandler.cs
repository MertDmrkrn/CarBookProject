using CarBookProject.Application.Features.Mediator.Queries.BlogQuery;
using CarBookProject.Application.Features.Mediator.Results.BlogResult;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandler
{
	public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
	{
		private readonly IBlogRepository _blogRepository;

		public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var values = _blogRepository.GetBlogsByAuthorId(request.Id);
			return values.Select(x => new GetBlogByAuthorIdQueryResult
			{
				AuthorID = x.AuthorID,
				BlogID = x.BlogID,
				AuthorName = x.Author.AuthorName,
				AuthorDescription = x.Author.Description,
				AuthorImgUrl = x.Author.ImgURL
			}).ToList();
		}
	}
}
