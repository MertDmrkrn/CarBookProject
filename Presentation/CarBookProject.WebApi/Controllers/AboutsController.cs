using CarBookProject.Application.Features.CQRS.Command.AboutCommands;
using CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBookProject.Application.Features.CQRS.Queries.AboutQueries;
using CarBookProject.Application.Features.CQRS.Results.AboutResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutCommand createAboutCommand)
        {
            await _createAboutCommandHandler.Handle(createAboutCommand);
            return Ok("Hakkımda Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
        {
            await _updateAboutCommandHandler.Handle(updateAboutCommand);
            return Ok("Hakkımda Bilgisi Güncellendi");
        }
    }
}
