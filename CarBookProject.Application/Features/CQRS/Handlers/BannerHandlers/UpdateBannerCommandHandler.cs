using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Command.BannerCommands;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BannerID);
            values.BannerTitle = command.BannerTitle;
            values.BannerDescription = command.BannerDescription;
            values.VideoUrl = command.VideoUrl;
            values.VideoDescription = command.VideoDescription;
            await _repository.UpdateAsync(values);
        }
    }
}
