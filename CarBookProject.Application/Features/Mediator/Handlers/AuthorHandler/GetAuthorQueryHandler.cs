using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.AuthorQuery;
using CarBookProject.Application.Features.Mediator.Results.AuthorResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.AuthorHandler
{
	public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
	{
		private readonly IRepository<Author> _repository;

		public GetAuthorQueryHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAuthorQueryResult
			{
				AuthorID = x.AuthorID,
				AuthorName = x.AuthorName,
				Description = x.Description,
				ImgURL = x.ImgURL
			}).ToList();
		}
	}
}
