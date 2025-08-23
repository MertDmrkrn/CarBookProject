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
	public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetTestimonialByIdQueryResult
			{
				TestimonialID = values.TestimonialID,
				TestimonialComment = values.TestimonialComment,
				TestimonialImgUrl = values.TestimonialImgUrl,
				TestimonialName = values.TestimonialName,
				TestimonialTitle = values.TestimonialTitle
			};
		}
	}
}
