using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.ReviewCommands
{
	public class CreateReviewCommands:IRequest
	{

		public string CustomerName { get; set; }

		public string CustomerImg { get; set; }

		public string Comment { get; set; }

		public int RatingValue { get; set; }

		public DateTime ReviewDate { get; set; }

		public int CarID { get; set; }
	}
}
