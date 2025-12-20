using CarBookProject.Application.Features.Mediator.Results.RentACarResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.RentACarQuery
{
	public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
	{
		public int LocationID { get; set; }
		
		public bool Available { get; set; }
	}
}
