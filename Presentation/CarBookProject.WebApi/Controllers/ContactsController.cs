using CarBookProject.Application.Features.CQRS.Command.ContactCommands;
using CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBookProject.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly GetContactQueryHandler _getContactQueryHandler;
		private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
		private readonly CreateContactCommandHandler _createContactCommandHandler;
		private readonly RemoveContactCommandHandler _removeContactCommandHandler;
		private readonly UpdateContactCommandHandler _updateContactCommandHandler;

		public ContactsController(GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, CreateContactCommandHandler createContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
		{
			_getContactQueryHandler = getContactQueryHandler;
			_getContactByIdQueryHandler = getContactByIdQueryHandler;
			_createContactCommandHandler = createContactCommandHandler;
			_removeContactCommandHandler = removeContactCommandHandler;
			_updateContactCommandHandler = updateContactCommandHandler;
		}


		[HttpGet]
		public async Task<IActionResult> ContactList()
		{
			var values = await _getContactQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetContact(int id)
		{
			var values = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactCommand command)
		{
			await _createContactCommandHandler.Handle(command);
			return Ok("İletişim Eklendi.");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveContact(int id)
		{
			await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
			return Ok("İletişim Silindi.");
		}


		[HttpPut]
		public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
		{
			await _updateContactCommandHandler.Handle(command);
			return Ok("İletişim Güncellendi.");
		}

	}
}
