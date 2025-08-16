using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.FooterAddressQuery;
using CarBookProject.Application.Features.Mediator.Results.FooterAddressResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandler
{
	public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
	{
		private readonly IRepository<FooterAddress> _repository;

		public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetFooterAddressQueryResult
			{
				FooterAddressID = x.FooterAddressID,
				Address = x.Address,
				Description = x.Description,
				Mail = x.Mail,
				Phone = x.Phone

			}).ToList();
		}
	}
}
