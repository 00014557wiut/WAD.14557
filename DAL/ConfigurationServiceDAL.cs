using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.CW1._14557.AppData;
using WAD.CW1._14557.DAL.Interfaces;
using WAD.CW1._14557.DAL.Repositories;

namespace WAD.CW1._14557.DAL
{
    public static class ConfigurationServiceDAL
    {
		public static IServiceCollection ConfigurationDAL(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			services.AddScoped<ICommentRepository, CommentRepository>();
			services.AddScoped<IIssueRepository, IssueRepository>();

			services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
		
    }
}
