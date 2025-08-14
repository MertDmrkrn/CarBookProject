using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public List<GetCarWithBrandQueryResult> Handle()
		{
			var values = _repository.GetCarsListWithBrand();
			return values.Select(x => new GetCarWithBrandQueryResult
			{
				BrandName = x.Brand.BrandName,
				BrandID = x.BrandID,
				BigImageUrl = x.BigImageUrl,
				CarID = x.CarID,
				CoverImgUrl = x.CoverImgUrl,
				Fuel = x.Fuel,
				Km = x.Km,
				Luggage = x.Luggage,
				Model = x.Model,
				Seat = x.Seat,
				Transmisson = x.Transmisson

			}).ToList();
		}
	}
}
