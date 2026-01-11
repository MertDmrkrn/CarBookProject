using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> CarDescriptionByCarIdList(int id)
		{
			var values = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			return Ok(values);
		}
	}
}
