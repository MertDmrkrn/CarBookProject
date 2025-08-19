using CarBookProject.Application.Features.Mediator.Results.SocialMediaResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.SocialMediaQuery
{
	public class GetSocialMediaQuery:IRequest<List<GetSocialMediaQueryResult>>
	{
	}
}
