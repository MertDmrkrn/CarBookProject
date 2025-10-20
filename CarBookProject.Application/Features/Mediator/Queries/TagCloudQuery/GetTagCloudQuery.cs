using CarBookProject.Application.Features.Mediator.Results.TagCloudResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.TagCloudQuery
{
	public class GetTagCloudQuery : IRequest<List<GetTagCloudQueryResult>>
	{
	}
}
