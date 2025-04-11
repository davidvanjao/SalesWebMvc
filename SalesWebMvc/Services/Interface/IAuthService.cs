using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Interface
{
    public interface IAuthService
    {
        User Authenticate(string email, string password);
    }
}
