using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Command.CategoryCommands;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class RemoveCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public RemoveCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveCategoryCommand command)
		{
			var values = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(values);
		}
	}
}
