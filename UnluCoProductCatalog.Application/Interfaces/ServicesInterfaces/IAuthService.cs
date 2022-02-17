using UnluCoProductCatalog.Application.ViewModels.UserViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Domain.Jwt;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IAuthService
    {
        User Register(RegisterViewModel registerViewModel);
        User Login(LoginViewModel loginViewModel);
        bool UserExists(string email);
        Token CreateToken(User user);
    }
}
