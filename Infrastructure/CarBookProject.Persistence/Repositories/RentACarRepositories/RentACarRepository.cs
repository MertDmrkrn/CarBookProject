using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.RentACarInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.RentACarRepositories
{
	public class RentACarRepository : IRentACarRepository
	{
		private readonly CarBookContext _carBookContext;

		public RentACarRepository(CarBookContext carBookContext)
		{
			_carBookContext = carBookContext;
		}

		public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
		{
			var values = await _carBookContext.RentACars.Where(filter).ToListAsync();
			return values;
		}
	}
}
