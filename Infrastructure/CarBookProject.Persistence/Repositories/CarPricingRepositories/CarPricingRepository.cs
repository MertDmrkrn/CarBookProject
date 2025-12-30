using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Application.ViewModels;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 3).ToList();
			return values;
		}

		public List<CarPricing> GetCarPricingWithTimePeriod()
		{
			throw new NotImplementedException();
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select Model,CoverImgUrl, PricingID, Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarID Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel viewModel = new CarPricingViewModel()
						{
							Model = reader["Model"].ToString(),
							CoverImgUrl = reader["CoverImgUrl"].ToString(),
							//Amounts = new List<decimal>
							//{
							//	Convert.ToDecimal(reader[2]),
							//	Convert.ToDecimal(reader[3]), 
							//	Convert.ToDecimal(reader[4])
							//}

							Amounts = new List<decimal>
							{
							reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
							reader.IsDBNull(3) ? 0 : reader.GetDecimal(3), //Eğer ki veriler içerisinde null değer varsa bu yöntem kullanılır.
							reader.IsDBNull(4) ? 0 : reader.GetDecimal(4)
							}
						};
						values.Add(viewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}

//var values = from x in _context.CarPricings
//			 group x by x.PricingID into g
//			 select new
//			 {
//				 Model = g.Key,
//				 DailyPrice = g.Where(y => y.CarPricingID == 2).Sum(z => z.Amount),
//				 WeeklyPrice = g.Where(y => y.CarPricingID == 3).Sum(z => z.Amount),
//				 MonthlyPrice = g.Where(y => y.CarPricingID == 4).Sum(z => z.Amount)
//			 };
//return values.ToList();
//return null;