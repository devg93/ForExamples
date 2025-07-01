using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Domain.Vo
{
    public class Name
    {
        public string FirstName { get; private set; }
   

        private Name(string firstName)
        {
            FirstName = firstName;
        }

        public static Name Create(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be empty.", nameof(firstName));
            }

            

            return new Name(firstName);
        }
    }
}