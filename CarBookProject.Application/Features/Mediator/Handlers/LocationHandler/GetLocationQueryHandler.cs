using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.LocationQuery;
using CarBookProject.Application.Features.Mediator.Results.LocationResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.LocationHandler
{
	public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
	{
		private readonly IRepository<Location> _repository;

		public GetLocationQueryHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetLocationQueryResult
			{
				LocationID = x.LocationID,
				LocationName = x.LocationName
			}).ToList();

		}
	}
}
