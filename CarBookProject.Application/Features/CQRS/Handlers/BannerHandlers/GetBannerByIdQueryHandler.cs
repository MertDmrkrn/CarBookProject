using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Queries.AboutQueries;
using CarBookProject.Application.Features.CQRS.Queries.BannerQueries;
using CarBookProject.Application.Features.CQRS.Results.BannerResults;
using CarBookProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                BannerDescription = values.BannerDescription,
                BannerTitle = values.BannerTitle,
                VideoUrl = values.VideoUrl,
                VideoDescription= values.VideoDescription
            };
        }
    }
}
