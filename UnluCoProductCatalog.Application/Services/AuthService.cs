using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Domain.Jwt;

namespace UnluCoProductCatalog.Application.Services
{
    public class AuthService :IAuthService
    {





        public User Register(RegisterViewModel registerViewModel)
        {
            throw new NotImplementedException();
        }

        public User Login(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string email)
        {
            throw new NotImplementedException();
        }

        public Token CreateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
