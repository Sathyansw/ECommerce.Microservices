using ECommerce.Identity.Application.DTOs;
using ECommerce.Identity.Application.Features.Auth.Commands;
using ECommerce.Identity.Application.Interfaces;
using ECommerce.Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Application.Features.Auth.Handlers
{
    public class LoginCommandHandler
         : IRequestHandler<LoginCommand, AuthResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwt;

        public LoginCommandHandler(
            UserManager<ApplicationUser> userManager,
            IJwtTokenGenerator jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }

        public async Task<AuthResponseDto> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Check user exists
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new Exception("Invalid email or password");

            // 2️⃣ Validate password
            var isPasswordValid = await _userManager
                .CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                throw new Exception("Invalid email or password");

            // 3️⃣ Generate JWT Token
            var token = await _jwt.GenerateToken(user);

            // 4️⃣ Generate Refresh Token
            var refreshToken = _jwt.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            // 5️⃣ Return response
            return new AuthResponseDto
            {
                Email = user.Email,
                Token = token,
                RefreshToken = refreshToken
            };
        }
    }
}
