using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Features.Mediator.Queries.CarFeatureQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarFeaturesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarFeaturesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCarFeatureListByCarID(int id)
		{
			var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
			return Ok(values);
		}

		[HttpGet("CarFeatureChaneAvailableToFalse")]
		public async Task<IActionResult> CarFeatureChaneAvailableToFalse(int id)
		{
			_mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
			return Ok("Güncelleme Yapıldı.");
		}

		[HttpGet("CarFeatureChaneAvailableToTrue")]
		public async Task<IActionResult> CarFeatureChaneAvailableToTrue(int id)
		{
			_mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
			return Ok("Güncelleme Yapıldı.");
		}
	}
}
