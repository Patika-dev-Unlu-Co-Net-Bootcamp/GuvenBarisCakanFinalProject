﻿using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Jwt;
using UnluCoProductCatalog.Application.RabbitMQ;
using UnluCoProductCatalog.Application.Services.Mail;
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
        private readonly IPusblisherService _pusblisherService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, TokenGenarator tokenGenarator, IPusblisherService pusblisherService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenarator = tokenGenarator;
            _pusblisherService = pusblisherService;
        }

        public async Task<bool> Register(RegisterViewModel registerUserModel)
        {
            var validator = new RegisterViewModelValidator();

            await validator.ValidateAsync(registerUserModel);

            var user = new User
            {
                UserName = registerUserModel.UserName,
                Email = registerUserModel.Email,
            };

            var emailCheckUser = await _userManager.FindByEmailAsync(registerUserModel.Email);

            if (emailCheckUser is null) throw new InvalidOperationException("Email already exists");

            var result = await _userManager.CreateAsync(user, registerUserModel.Password);

            Console.WriteLine(result.Errors);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                await _signInManager.SignInAsync(user, false);
                return true;
            }
            throw new InvalidOperationException("User registration is not successful");

        }

        public async Task<Token> Login(LoginViewModel loginUserModel)
        {
            var validator = new LoginViewModelValidator();

            await validator.ValidateAsync(loginUserModel);

            var userFind = await _userManager.FindByEmailAsync(loginUserModel.Email);

            if (userFind is null)
                throw new InvalidOperationException("Email is not correct");

            var result = await _userManager.CheckPasswordAsync(userFind, loginUserModel.Password);

            if (!result)
            {
                await AccessRightControl(userFind);
                throw new InvalidOperationException("Password is not correct");
            }
            
            var userRoles = await _userManager.GetRolesAsync(userFind);
            return _tokenGenarator.CreateToken(userFind, userRoles);
        }

        private async Task AccessRightControl(User userFind)
        {
            userFind.AccessFailedCount += 1;
            await _userManager.UpdateAsync(userFind);
            if (userFind.AccessFailedCount == 3)
            {
                userFind.LockoutEnabled = true;
                await _userManager.UpdateAsync(userFind);

                var email = new Email
                {
                    To = userFind.Email,
                    Subject = "Account Blocked",
                    Body = "Your account has been blocked for logging in 3 times wrong in a row."
                };
                _pusblisherService.Publish(email,"blocked");

                throw new InvalidOperationException("User blocked");
            }
        }
    }
}
