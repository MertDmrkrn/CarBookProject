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
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCarCommand command)
		{
			var values = await _repository.GetByIdAsync(command.CarID);
			values.Fuel = command.Fuel;
			values.Transmisson = command.Transmisson;
			values.BigImageUrl = command.BigImageUrl;
			values.CoverImgUrl = command.CoverImgUrl;
			values.Km = command.Km;
			values.Luggage = command.Luggage;
			values.Seat = command.Seat;
			values.Model = command.Model;
			values.BrandID = command.BrandID;
			await _repository.UpdateAsync(values);
		}
	}
}
