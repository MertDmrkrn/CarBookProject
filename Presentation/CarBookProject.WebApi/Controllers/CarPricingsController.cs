﻿using CarBookProject.Application.Features.Mediator.Queries.CarPricingQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPricingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarPricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCarPricingWithCarsList()
		{
			var values = await _mediator.Send(new GetCarPricingWithCarsQuery());
			return Ok(values);
		}
	}
}
