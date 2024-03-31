﻿//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 


using System;

namespace Foram.Api.Models.Foundations.Guests
{
	public class Guest
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

        public string LastName { get; set; }

		public DateTimeOffset DateOfBirth { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string Adress { get; set; }

		public GenderType Gender { get; set; }

    }
}
