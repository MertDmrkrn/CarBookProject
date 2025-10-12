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
	public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
	{
		private readonly IRepository<Blog> _repository;

		public GetBlogQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBlogQueryResult
			{
				AuthorID = x.AuthorID,
				BlogID = x.BlogID,
				CategoryID = x.CategoryID,
				CoverImgURL = x.CoverImgURL,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
			}).ToList();
		}
	}
}
