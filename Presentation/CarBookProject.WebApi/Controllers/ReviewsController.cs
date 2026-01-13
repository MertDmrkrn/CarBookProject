using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Features.Mediator.Queries.ReviewQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ReviewList(int id)
		{
			var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommands commands)
		{
			await _mediator.Send(commands);
			return Ok("Yorum Eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommands commands)
		{
			await _mediator.Send(commands);
			return Ok("Yorum Güncellendi.");
		}
	}
}
