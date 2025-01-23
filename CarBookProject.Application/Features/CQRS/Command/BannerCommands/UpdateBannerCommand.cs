﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Command.BannerCommands
{
    public class UpdateBannerCommand
    {
        public int BannerID { get; set; }

        public string BannerTitle { get; set; }

        public string BannerDescription { get; set; }

        public string VideoDescription { get; set; }

        public string VideoUrl { get; set; }
    }
}
