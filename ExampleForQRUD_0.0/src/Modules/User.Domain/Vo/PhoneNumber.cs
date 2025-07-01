using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Domain.Vo
{
    public class PhoneNumber
    {
        public string Value { get; private set; }

        private PhoneNumber(string phoneNumber) => Value = phoneNumber;

        public static PhoneNumber Create(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be empty.", nameof(phoneNumber));
            }

            if (phoneNumber.Length < 10 || phoneNumber.Length > 15)
            {
                throw new ArgumentException("Phone number must be between 10 and 15 characters long.", nameof(phoneNumber));
            }

            return new PhoneNumber(phoneNumber);
        }
        
    }
}