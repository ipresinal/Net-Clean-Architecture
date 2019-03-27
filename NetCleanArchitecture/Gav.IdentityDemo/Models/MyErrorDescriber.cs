using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Gav.IdentityDemo.Models
{
    public class MyErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {

            return new IdentityError()
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "El password debe contener al menos una mayúscula"
            };

            
        }

         
    }
}
