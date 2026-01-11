using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQuery;
using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResult;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandler
{
	public class GetCarDescriptionByCarIdHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;

		public GetCarDescriptionByCarIdHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarDescription(request.Id);
			return new GetCarDescriptionByCarIdQueryResult
			{
				CarDescriptionDetails = values.CarDescriptionDetails,
				CarID = values.CarID,
				CarDescriptionID = values.CarDescriptionID
			};
		}
	}
}
