using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Persistence
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Member","true"),
            new Claim("Edit Member","true"),
            new Claim("Delete Member","true"),
            new Claim("Create Employee","true"),
            new Claim("Edit Employee","true"),
            new Claim("Role","Librarian"),
            new Claim("Role","Admin")
        };
    }
}