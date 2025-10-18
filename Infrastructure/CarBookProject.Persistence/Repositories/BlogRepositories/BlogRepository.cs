using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Persistence.Repositories.BlogRepositories
{
	public class BlogRepository : IBlogRepository
	{
		private readonly CarBookContext _context;

		public BlogRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Blog> GetLast3BlogsWithAuthors()
		{
			var values = _context.Blogs.Include(x => x.Author).OrderByDescending(y=>y.BlogID).Take(3).ToList();
			return values;
		}
	}
}
