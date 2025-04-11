using SalesWebMvc.Models;
using SalesWebMvc.Data;
using SalesWebMvc.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class AuthService : IAuthService
    {
        private readonly SalesWebMvcContext _context; //verificar importacao

        public AuthService(SalesWebMvcContext context) //construtor
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            return _context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
