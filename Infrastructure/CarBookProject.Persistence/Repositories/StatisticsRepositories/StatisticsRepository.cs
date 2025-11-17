using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.StatisticsRepositories
{
	public class StatisticsRepository : IStatisticsRepository
	{

		private readonly CarBookContext _carBookContext;

		public StatisticsRepository(CarBookContext carBookContext)
		{
			_carBookContext = carBookContext;
		}



		public string GetBlogTitleByMaxBlogComment()
		{
			throw new NotImplementedException();
		}

		public string GetBrandNameByMaxCar()
		{
			throw new NotImplementedException();
		}

		public int GetCarCountByKmSmallerThen1000()
		{
			var value = _carBookContext.Cars.Where(x => x.Km < 1000).Count();
			return value;
		}

		public int GetAuthorCount()
		{
			var values = _carBookContext.Authors.Count();
			return values;
		}

		public decimal GetAvgRentPriceForDaily()
		{
			int id = _carBookContext.Pricings.Where(y => y.PricingName == "Günlük").Select(z => z.PricingID).FirstOrDefault();
			var values = _carBookContext.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
			return values;

		}

		public decimal GetAvgRentPriceForMonthly()
		{
			int id = _carBookContext.Pricings.Where(y => y.PricingName == "Aylık").Select(z => z.PricingID).FirstOrDefault();
			var values = _carBookContext.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
			return values;
		}

		public decimal GetAvgRentPriceForWeekly()
		{
			int id = _carBookContext.Pricings.Where(y => y.PricingName == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
			var values = _carBookContext.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
			return values;
		}

		public int GetBlogCount()
		{
			var values = _carBookContext.Blogs.Count();
			return values;
		}

		public int GetBrandCount()
		{
			var values = _carBookContext.Brands.Count();
			return values;
		}

		public string GetCarBrandAndModelByRentPriceDailyMax()
		{
			throw new NotImplementedException();
		}

		public string GetCarBrandAndModelByRentPriceDailyMin()
		{
			throw new NotImplementedException();
		}

		public int GetCarCount()
		{
			var value = _carBookContext.Cars.Count();
			return value;
		}

		public int GetCarCountByFuelElectric()
		{
			var values = _carBookContext.Cars.Where(x => x.Fuel == "Elektrik").Count();
			return values;
		}

		public int GetCarCountByFuelGasolineOrDiesel()
		{
			var values = _carBookContext.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Mazot").Count();
			return values;
		}

		public int GetCarCountByTransmissionIsAuto()
		{
			var values = _carBookContext.Cars.Where(x => x.Transmisson == "Otomatik").Count();
			return values;
		}

		public int GetLocationCount()
		{
			var values = _carBookContext.Locations.Count();
			return values;
		}
	}
}
