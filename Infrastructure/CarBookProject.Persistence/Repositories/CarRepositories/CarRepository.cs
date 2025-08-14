using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CarRepositories
{
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _carBookContext;

		public CarRepository(CarBookContext carBookContext)
		{
			_carBookContext = carBookContext;
		}

		public List<Car> GetCarsListWithBrand()
		{
			var values = _carBookContext.Cars.Include(x => x.Brand).ToList();
			return values;
		}
	}
}
