using CarBookProject.Application.Features.Mediator.Queries.RentACarQuery;
using CarBookProject.Application.Features.Mediator.Results.RentACarResult;
using CarBookProject.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.RentACarHandler
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{
		private readonly IRentACarRepository _repository;

		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
			var resutls = values.Select(x => new GetRentACarQueryResult
			{
				CarID = x.CarID

			}).ToList();
			return resutls;
		}
	}
}
