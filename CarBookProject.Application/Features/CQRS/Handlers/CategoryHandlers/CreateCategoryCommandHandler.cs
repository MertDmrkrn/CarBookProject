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
	public class CreateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public CreateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCategoryCommand command)
		{
			await _repository.CreateAsync(new Category
			{
				CategoryName = command.CategoryName
			});
		}

	}
}
