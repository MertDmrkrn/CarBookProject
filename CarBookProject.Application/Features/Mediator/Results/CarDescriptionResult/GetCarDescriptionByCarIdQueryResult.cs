using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.CarDescriptionResult
{
	public class GetCarDescriptionByCarIdQueryResult
	{
		public int CarDescriptionID { get; set; }

		public int CarID { get; set; }

		public string CarDescriptionDetails { get; set; }
	}
}
