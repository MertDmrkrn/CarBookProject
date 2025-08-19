using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.PricingQuery;
using CarBookProject.Application.Features.Mediator.Results.PricingResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.PricingHandler
{
	public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
	{

		private readonly IRepository<Pricing> _repository;

		public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
		{
			var values=await _repository.GetByIdAsync(request.Id);
			return new GetPricingByIdQueryResult
			{
				PricingID = values.PricingID,
				PricingName = values.PricingName
			};
		}
	}
}
