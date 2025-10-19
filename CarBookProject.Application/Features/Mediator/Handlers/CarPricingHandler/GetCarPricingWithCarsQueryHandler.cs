using CarBookProject.Application.Features.Mediator.Queries.CarPricingQuery;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResult;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandler
{
	public class GetCarPricingWithCarsQueryHandler : IRequestHandler<GetCarPricingWithCarsQuery, List<GetCarPricingWithCarsQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithCarsQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
		{
			var values = _carPricingRepository.GetCarPricingWithCars();
			return values.Select(x => new GetCarPricingWithCarsQueryResult
			{
				Amount = x.Amount,
				CarPricingID = x.CarPricingID,
				Brand = x.Car.Brand.BrandName,
				CoverImgUrl = x.Car.CoverImgUrl,
				Model = x.Car.Model
			}).ToList();
		}
	}
}
