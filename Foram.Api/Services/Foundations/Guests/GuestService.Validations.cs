﻿//= = = = = = = = = = = = = = = = = = = = = = = = = = 
//Copyright (c) Coalition of Good-Hearted Engiineers
//Free to Use To Find Comfort and Peace
//= = = = = = = = = = = = = = = = = = = = = = = = = = 

using System;
using Foram.Api.Models.Foundations.Guests;
using Foram.Api.Models.Foundations.Guests.Exceptions;

namespace Foram.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestOnAdd(Guest guest)
        {
            ValidateGuestNotNull(guest);

            Validate(
                (Rule: IsInvalid(guest.Id), Parameter: nameof(Guest.Id)),
                (Rule: IsInvalid(guest.FirstName), Parameter: nameof(Guest.FirstName)),
                (Rule: IsInvalid(guest.LastName), Parameter: nameof(Guest.LastName)),
                (Rule: IsInvalid(guest.DateOfBirth), Parameter: nameof(Guest.DateOfBirth)),
                (Rule: IsInvalid(guest.Email), Parameter: nameof(Guest.Email)),
                (Rule: IsInvalid(guest.Address), Parameter: nameof(Guest.Address)),
                (Rule: IsInvalid(guest.Gender), Parameter: nameof(Guest.Gender)));
        }
        private void ValidateGuestNotNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id id required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };


        private static dynamic IsInvalid(DateTimeOffset data) => new
        {
            Condition = data == default,
            Message = "Data is required"
        };

        private static dynamic IsInvalid(GenderType gender) => new
        {
            Condition = Enum.IsDefined(typeof(GenderType), gender) is false,
            Message = "Value is invalid"

        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var InvalidGuestException = new InvalidGuestException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    InvalidGuestException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            InvalidGuestException.ThrowIfContainsErrors();
        }

    }
}
