using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetCarQueryResult
			{
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
