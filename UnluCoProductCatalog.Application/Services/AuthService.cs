using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Validations;
using UnluCoProductCatalog.Application.Validations.AuthValidation;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Domain.Jwt;

namespace UnluCoProductCatalog.Application.Services
{
    public class AuthService :IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenGenarator _tokenGenarator;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, TokenGenarator tokenGenarator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenarator = tokenGenarator;
        }

        public async Task<bool> Register(RegisterViewModel registerUserModel)
        {

            var validator = new RegisterViewModelValidator();

            await validator.ValidateAsync(registerUserModel);

            var user = new User
            {
                FirstName = registerUserModel.FirstName,
                LastName = registerUserModel.LastName,
                Email = registerUserModel.Email,
            };

            var emailCheckUser = await _userManager.FindByEmailAsync(registerUserModel.Email);

            if (emailCheckUser is not null) throw new InvalidOperationException("Email already exists");

            var result = await _userManager.CreateAsync(user, registerUserModel.Password);

            if (!result.Succeeded) return false;
            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, false);
            return true;
        }

        public async Task<Token> Login(LoginViewModel loginUserModel)
        {
            var validator = new LoginViewModelValidator();

            await validator.ValidateAsync(loginUserModel);

            if (loginUserModel.Email is null || loginUserModel.Password is null)
            {
                throw new InvalidOperationException("Email or Password can not be null");
            }

            var userFind = await _userManager.FindByEmailAsync(loginUserModel.Email);
            if (userFind is null) throw new InvalidOperationException("User email is not correct");

            var result = await _userManager.CheckPasswordAsync(userFind, loginUserModel.Password);

            if (!result)
                throw new InvalidOperationException("Password is not correct");

            var userRoles = await _userManager.GetRolesAsync(userFind);
            return _tokenGenarator.CreateToken(userFind, userRoles);

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
