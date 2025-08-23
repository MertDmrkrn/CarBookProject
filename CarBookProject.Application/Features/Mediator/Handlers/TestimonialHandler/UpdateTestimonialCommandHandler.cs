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
	public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.TestimonialID);
			values.TestimonialName= request.TestimonialName;
			values.TestimonialComment= request.TestimonialComment;
			values.TestimonialTitle= request.TestimonialTitle;
			values.TestimonialImgUrl= request.TestimonialImgUrl;
			await _repository.UpdateAsync(values);

		}
	}
}
