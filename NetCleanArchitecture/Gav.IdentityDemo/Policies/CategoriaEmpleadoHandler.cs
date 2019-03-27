using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Gav.IdentityDemo.Policies
{
    public class CategoriaEmpleadoHandler : AuthorizationHandler<CategoriaEmpleadorequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CategoriaEmpleadorequirement requirement)
        {
            if (context.User.Claims.Any(x => x.Type == "CategoriaEmpleado2"))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
