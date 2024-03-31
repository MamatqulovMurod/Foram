//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System;
using Foram.Api.Models.Foundations.Guests;
using Microsoft.EntityFrameworkCore;

namespace Foram.Api.Brokers.Strorages
{
	public partial class StorageBroker
	{
		public DbSet<Guest> Guests{ get; set;}
	}
}

