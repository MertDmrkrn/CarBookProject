using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.FeatureResult
{
	public class GetFeatureQueryResult
	{
		public int FeatureID { get; set; }

		public string FeatureName { get; set; }
	}
}
