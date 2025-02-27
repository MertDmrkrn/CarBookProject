﻿using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Command.AboutCommands;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAboutCommand removeAboutCommand)
        {
            var value = await _repository.GetByIdAsync(removeAboutCommand.ID);
            await _repository.RemoveAsync(value);
        }
    }
}
