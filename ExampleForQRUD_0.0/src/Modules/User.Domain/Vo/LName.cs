using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Domain.Vo
{
    public class LName
    {
        public string Value { get; private set; }
       
        private LName(string lastName) => Value = lastName;

        public static LName Create(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be empty.", nameof(lastName));
            }

            if (lastName.Length < 2 || lastName.Length > 50)
            {
                throw new ArgumentException("Last name must be between 2 and 50 characters long.", nameof(lastName));
            }

            return new LName(lastName);
        }
        
    }
}