using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Queries.AboutQueries;
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
	public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
	{
		private readonly IRepository<Author> _repository;

		public GetAuthorByIdQueryHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
		{
			var values=await _repository.GetByIdAsync(request.Id);
			return new GetAuthorByIdQueryResult
			{
				AuthorID = values.AuthorID,
				AuthorName = values.AuthorName,
				Description = values.Description,
				ImgURL = values.ImgURL
			};
		}
	}
}
