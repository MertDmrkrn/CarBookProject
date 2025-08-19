using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.ServiceQuery;
using CarBookProject.Application.Features.Mediator.Results.ServiceResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandler
{
	public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
	{
		private readonly IRepository<Service> _repository;

		public GetServiceByIdQueryHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetServiceByIdQueryResult
			{
				ServiceID = values.ServiceID,
				ServiceDescription = values.ServiceDescription,
				ServiceIcon = values.ServiceIcon,
				ServiceTitle = values.ServiceTitle
			};
		}
	}
}
