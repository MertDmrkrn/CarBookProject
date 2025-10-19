﻿using CarBookProject.Application.Features.Mediator.Results.CarPricingResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Queries.CarPricingQuery
{
	public class GetCarPricingWithCarsQuery : IRequest<List<GetCarPricingWithCarsQueryResult>>
	{

	}
}
