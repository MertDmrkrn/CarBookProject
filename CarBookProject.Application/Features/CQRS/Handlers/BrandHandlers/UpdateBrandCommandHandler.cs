using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Command.BrandCommands;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var values=await _repository.GetByIdAsync(command.BrandID);
            values.BrandName = command.BrandName;
            await _repository.UpdateAsync(values);
        }
    }
}
