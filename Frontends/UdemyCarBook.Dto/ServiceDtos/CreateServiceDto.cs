using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.ServiceDtos
{
	public class CreateServiceDto
	{
		public string ServiceTitle { get; set; }

		public string ServiceDescription { get; set; }

		public string ServiceIcon { get; set; }
	}
}
