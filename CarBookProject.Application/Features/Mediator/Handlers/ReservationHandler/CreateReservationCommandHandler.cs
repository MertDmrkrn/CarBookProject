using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReservationHandler
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
	{
		private readonly IRepository<Reservation> _repository;

		public CreateReservationCommandHandler(IRepository<Reservation> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Reservation
			{
				Name = request.Name,
				Surname = request.Surname,
				Age = request.Age,
				Description = request.Description,
				CarID = request.CarID,
				DriverLicenseYear = request.DriverLicenseYear,
				DropOffLocationID = request.DropOffLocationID,
				PickUpLocationID = request.PickUpLocationID,
				Mail = request.Mail,
				Phone = request.Phone,
				Status = "Rezervasyon Alındı."
			});
		}
	}
}
