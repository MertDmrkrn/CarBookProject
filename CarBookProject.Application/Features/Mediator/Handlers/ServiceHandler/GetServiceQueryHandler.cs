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
	public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
	{
		private readonly IRepository<Service> _repository;

		public GetServiceQueryHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetServiceQueryResult
			{
				ServiceID = x.ServiceID,
				ServiceDescription = x.ServiceDescription,
				ServiceIcon = x.ServiceIcon,
				ServiceTitle = x.ServiceTitle
			}).ToList();
		}
	}
}
