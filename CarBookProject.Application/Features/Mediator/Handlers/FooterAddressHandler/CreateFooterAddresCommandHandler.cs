using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandler
{
	public class CreateFooterAddresCommandHandler : IRequestHandler<CreateFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public CreateFooterAddresCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new FooterAddress
			{
				Address = request.Address,
				Description = request.Description,
				Mail = request.Mail,
				Phone = request.Phone
			});
		}
	}
}
