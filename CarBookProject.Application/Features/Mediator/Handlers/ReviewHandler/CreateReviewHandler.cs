using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandler
{
	public class CreateReviewHandler : IRequestHandler<CreateReviewCommands>
	{
		private readonly IRepository<Review> _repository;

		public CreateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReviewCommands request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Review
			{
				CustomerImg = request.CustomerImg,
				CarID = request.CarID,
				Comment = request.Comment,
				CustomerName = request.CustomerName,
				RatingValue = request.RatingValue,
				ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
			});
				
		}
	}
}
