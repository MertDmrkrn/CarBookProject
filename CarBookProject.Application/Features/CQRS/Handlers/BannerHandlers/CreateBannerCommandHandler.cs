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
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner
            {
                BannerTitle = command.BannerTitle,
                BannerDescription = command.BannerDescription,
                VideoUrl = command.VideoUrl,
                VideoDescription = command.VideoDescription
            });            
        }
    }
}
