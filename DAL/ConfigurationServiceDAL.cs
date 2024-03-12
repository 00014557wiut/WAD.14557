using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.CW1._14557.AppData;

namespace WAD.CW1._14557.DAL
{
    public static class ConfigurationServiceDAL
    {
		public static IServiceCollection ConfigurationDAL(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
		
    }
}
