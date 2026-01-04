using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Interfaces.CarFeatureInterfaces
{
	public interface ICarFeatureRepository
	{
		List<CarFeature> GetCarFeaturesByCarID(int carID);

		void ChangCarFeatureAvailableToFalse(int id);

		void ChangCarFeatureAvailableToTrue(int id);
	}
}
