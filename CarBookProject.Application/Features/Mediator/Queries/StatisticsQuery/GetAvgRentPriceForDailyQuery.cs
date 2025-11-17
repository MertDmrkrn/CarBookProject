using CarBookProject.Application.Features.Mediator.Results.StatisticsResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.StatisticsQuery
{
	public class GetAvgRentPriceForDailyQuery : IRequest<GetAvgRentPriceForDailyQueryResult>
	{
	}
}
