using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Results.BrandResults;
using CarBookProject.Application.Features.CQRS.Results.CategoryResults;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryQueryHandler
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCategoryByIdQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetCategoryByIdQueryResult
			{
				CategoryID = x.CategoryID,
				CategoryName = x.CategoryName
			}).ToList();
		}
	}
}
