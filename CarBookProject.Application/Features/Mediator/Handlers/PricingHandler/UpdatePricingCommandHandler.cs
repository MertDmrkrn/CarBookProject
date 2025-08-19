using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.PricingCommand;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.PricingHandler
{
	public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
	{
		private readonly IRepository<Pricing> _repository;

		public UpdatePricingCommandHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.PricingID);
			values.PricingName = request.PricingName;
			await _repository.UpdateAsync(values);
		}
	}
}
