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
	public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
	{
		private readonly IRepository<FooterAddress> _repository;

		public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetFooterAddressByIdQueryResult
			{
				FooterAddressID = values.FooterAddressID,
				Address = values.Address,
				Description = values.Description,
				Mail = values.Mail,
				Phone = values.Phone
			};
		}
	}
}
