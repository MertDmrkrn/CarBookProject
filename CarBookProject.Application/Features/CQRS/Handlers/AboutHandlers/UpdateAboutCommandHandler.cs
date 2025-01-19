using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Command.AboutCommands;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var values = await _repository.GetByIdAsync(updateAboutCommand.AboutID);
            values.Description = updateAboutCommand.Description;
            values.Title = updateAboutCommand.Title;
            values.ImgUrl = updateAboutCommand.ImgUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
