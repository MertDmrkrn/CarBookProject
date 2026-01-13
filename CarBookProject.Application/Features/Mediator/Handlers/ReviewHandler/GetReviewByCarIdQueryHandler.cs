using CarBookProject.Application.Features.Mediator.Queries.ReviewQuery;
using CarBookProject.Application.Features.Mediator.Results.ReviewResult;
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandler
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _reviewRepository.GetReviewsByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIdQueryResult
			{
				CarID = x.CarID,
				Comment = x.Comment,
				CustomerImg = x.CustomerImg,
				CustomerName = x.CustomerName,
				RatingValue = x.RatingValue,
				ReviewDate = x.ReviewDate,
				ReviewID = x.ReviewID
			}).ToList();
		}
	}
}
