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
	public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
	{
		private readonly IRepository<Pricing> _repository;

		public CreatePricingCommandHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Pricing
			{
				PricingName = request.PricingName
			});
		}
	}
}
