using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Domain.Vo
{
    public class Email
    {
        public string Value { get; private set; }

        private Email(string email) => Value = email;

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("Email must be a valid email address.", nameof(email));
            }

            return new Email(email);
        }

    }
}