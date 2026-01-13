using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Validator.ReviewValidatiors
{
	public class CreateReviewValidatior : AbstractValidator<CreateReviewCommands>
	{
		public CreateReviewValidatior()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz!");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız!");
			RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz!");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz!");
			RuleFor(x => x.Comment).MinimumLength(30).WithMessage("Lütfen en az 30 karakter girişi yapınız!");
			RuleFor(x => x.Comment).MaximumLength(300).WithMessage("Lütfen en fazla 300 karakter girişi yapınız!");

		}
	}
}
