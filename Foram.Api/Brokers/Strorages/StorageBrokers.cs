  //= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 


using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Foram.Api.Brokers.Strorages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;

            this.Database.Migrate();

        }

        //private async ValueTask<T> InsertAsync<T>(T @object) where T: class
        //{
        //	using var broker = new StorageBroker(this.configuration);

        //	broker.Entry<T>(@object).State = EntityState.Added;

        //	await broker.SaveChangesAsync();
        //	return @object;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        public override void Dispose() { }


    }
}

