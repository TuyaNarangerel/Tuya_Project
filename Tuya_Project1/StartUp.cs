using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tuya_Project1.Data;

namespace Tuya_Project1
{
	public class StartUp
	{
		public IConfiguration Configuration { get; }

		public StartUp(IConfiguration configuration)
		{  
			Configuration = configuration; 
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
		}

	}
}
