//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engineers
//Free to Use Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 


using System;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Foram.Api.Brokers.Strorages
{
	public partial class StorageBrokers : EFxceptionsContext
	{
		private readonly IConfiguration configuration;

		public StorageBrokers(IConfiguration configuration)
		{
			this.configuration = configuration;
			this.Database.Migrate();
		}	

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString =
				this.configuration.GetConnectionString(name: "DefaultConnection");

			optionsBuilder.UseSqlServer(connectionString);
		}

        public override void Dispose() { }
        
        

    }
}

