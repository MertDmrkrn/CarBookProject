using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			//Select Top(1) BlogID, Count(*) as 'En İyi Blog' from Comments Group By BlogID Order By 'En İyi Blog' Desc 
			var values = _carBookContext.Comments.GroupBy(x => x.BlogID).
				Select(y => new
				{
					BlogID = y.Key,
					Count = y.Count()
				}).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
			string blogName = _carBookContext.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefault();
			return blogName;
		}

		public string GetBrandNameByMaxCar()
		{
			var values = _carBookContext.Cars.GroupBy(x => x.BrandID).
			Select(y => new
			{
				BrandId = y.Key,
				Count = y.Count()
			}).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();

			string brandName = _carBookContext.Brands.Where(x => x.BrandID == values.BrandId).Select(y => y.BrandName).FirstOrDefault();

			return brandName;
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
			int pricingId = _carBookContext.Pricings.Where(x => x.PricingName == "Günlük").Select(y => y.PricingID).FirstOrDefault();
			decimal amount = _carBookContext.CarPricings.Where(x => x.PricingID == pricingId).Max(y => y.Amount);
			int carID = _carBookContext.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
			string brandModel = _carBookContext.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.BrandName + " " + z.Model).FirstOrDefault();
			return brandModel;
		}

		public string GetCarBrandAndModelByRentPriceDailyMin()
		{
			int pricingId = _carBookContext.Pricings.Where(x => x.PricingName == "Günlük").Select(y => y.PricingID).FirstOrDefault();
			decimal amount = _carBookContext.CarPricings.Where(x => x.PricingID == pricingId).Min(y => y.Amount);
			int carID = _carBookContext.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
			string brandModel = _carBookContext.Cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.BrandName + " " + z.Model).FirstOrDefault();
			return brandModel;
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
