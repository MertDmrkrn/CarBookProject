using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.TestimonialHandler
{
	public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Testimonial
			{
				TestimonialComment = request.TestimonialComment,
				TestimonialImgUrl = request.TestimonialImgUrl,
				TestimonialName = request.TestimonialName,
				TestimonialTitle = request.TestimonialTitle
			});
		}
	}
}
