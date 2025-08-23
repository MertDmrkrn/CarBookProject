using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.TestimonialQuery;
using CarBookProject.Application.Features.Mediator.Results.TestimonialResult;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.TestimonialHandler
{
	public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetTestimonialQueryResult
			{
				TestimonialID = x.TestimonialID,
				TestimonialComment = x.TestimonialComment,
				TestimonialImgUrl = x.TestimonialImgUrl,
				TestimonialName = x.TestimonialName,
				TestimonialTitle = x.TestimonialTitle
			}).ToList();
		}
	}
}
