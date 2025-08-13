using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarByIdQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarByIdQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var values= await _repository.GetByIdAsync(query.Id);
			return new GetCarByIdQueryResult
			{
				BrandID = values.BrandID,
				BigImageUrl = values.BigImageUrl,
				CarID = values.CarID,
				CoverImgUrl = values.CoverImgUrl,
				Fuel = values.Fuel,
				Km = values.Km,
				Luggage = values.Luggage,
				Model = values.Model,
				Seat = values.Seat,
				Transmisson = values.Transmisson
			};
		}
	}
}
