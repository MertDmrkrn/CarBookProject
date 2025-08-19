using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Results.ServiceResult
{
	public class GetServiceQueryResult
	{
		public int ServiceID { get; set; }

		public string ServiceTitle { get; set; }

		public string ServiceDescription { get; set; }

		public string ServiceIcon { get; set; }
	}
}
