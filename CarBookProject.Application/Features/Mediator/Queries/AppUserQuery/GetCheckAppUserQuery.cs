using CarBookProject.Application.Features.Mediator.Results.AppUserResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.GetCheckAppUserQuery
{
	public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
	{
		public string Username { get; set; }

		public string Password { get; set; }
	}
}
