using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ServiceCommand;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandler
{
	internal class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
	{
		private readonly IRepository<Service> _repository;

		public UpdateServiceCommandHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ServiceID);
			values.ServiceTitle = request.ServiceTitle;
			values.ServiceDescription = request.ServiceDescription;
			values.ServiceIcon = request.ServiceIcon;
			await _repository.UpdateAsync(values);
		}
	}
}
