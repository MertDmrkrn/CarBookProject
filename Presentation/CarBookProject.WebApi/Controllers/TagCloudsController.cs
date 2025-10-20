﻿using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBookProject.Application.Features.Mediator.Queries.TagCloudQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagCloudsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TagCloudsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> TagCloudList()
		{
			var values = await _mediator.Send(new GetTagCloudQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTagCloud(int id)
		{
			var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
		{
			await _mediator.Send(command);
			return Ok("Etiket Eklendi.");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveTagCloud(int id)
		{
			await _mediator.Send(new RemoveTagCloudCommand(id));
			return Ok("Etiket Silindi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
		{
			await _mediator.Send(command);
			return Ok("Etiket Güncellendi.");
		}
	}
}
