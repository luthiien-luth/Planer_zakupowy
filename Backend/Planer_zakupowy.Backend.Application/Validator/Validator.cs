﻿using Planer_zakupowy.Backend.Application.Exceptions;
using Planer_zakupowy.Backend.Application.Interfaces;
using System.Net.Mail;

namespace Planer_zakupowy.Backend.Application.Validator
{
    public class Validator : IValidator
    {
        public void ValidateRegistrationData(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidDataProvidedException("You need to provide email.");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidDataProvidedException("You need to provide password.");
            }
            if (!ValidateMailValue(email))
            {
                throw new InvalidDataProvidedException($"Email {email} has invalid foramt.");
            }
        }

        private static bool ValidateMailValue(string email)
        {
            try
            {
                var emailValue = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}