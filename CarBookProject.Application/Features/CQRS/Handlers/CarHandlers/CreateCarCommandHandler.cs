using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Command.CarCommands;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public CreateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCarCommand command)
		{
			await _repository.CreateAsync(new Car
			{
				BigImageUrl = command.BigImageUrl,
				Luggage = command.Luggage,
				Km = command.Km,
				Model = command.Model,
				Seat = command.Seat,
				Transmisson = command.Transmisson,
				CoverImgUrl = command.CoverImgUrl,
				BrandID = command.BrandID,
				Fuel = command.Fuel
			});
		}
	}
}
