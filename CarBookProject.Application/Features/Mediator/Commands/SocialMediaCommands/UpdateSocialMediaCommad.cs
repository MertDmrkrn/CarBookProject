using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Commands.SocialMediaCommands
{
	public class UpdateSocialMediaCommad : IRequest
	{
		public int SocialMediaID { get; set; }

		public string SocialMediaName { get; set; }

		public string SocialMediaUrl { get; set; }

		public string SocialMediaIcon { get; set; }
	}
}
