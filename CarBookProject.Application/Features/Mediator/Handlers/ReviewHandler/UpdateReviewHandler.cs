using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandler
{
	public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommands>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommands request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ReviewID);
			values.CustomerName = request.CustomerName;
			values.ReviewDate = request.ReviewDate;
			values.CarID = request.CarID;
			values.RatingValue = request.RatingValue;
			values.CustomerName = request.CustomerName;
			await _repository.UpdateAsync(values);
		}
	}
}
