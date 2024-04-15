//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free To Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System.Threading.Tasks;
using Foram.Api.Models.Foundations.Guests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Foram.Api.Brokers.Strorages
{
    public partial class StorageBroker 
	{
		public DbSet<Guest> Guests{ get; set;}

		public async ValueTask<Guest> InsertGuestAsync(Guest guest)
		{
			 using var broker = new StorageBroker(this.configuration);


			EntityEntry<Guest> guestEntityEntry =
				await broker.Guests.AddAsync(guest);

			await broker.SaveChangesAsync();

			return guestEntityEntry.Entity;


		}

        
    }
}

