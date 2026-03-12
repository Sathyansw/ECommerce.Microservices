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
    public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwt;

        public RegisterCommandHandler(
            UserManager<ApplicationUser> userManager,
            IJwtTokenGenerator jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }

        public async Task<AuthResponseDto> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                FullName = request.FullName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception("Registration failed");

            // 🔐 Generate JWT
            var token = _jwt.GenerateToken(user);

            // 🔄 Generate Refresh Token
            var refreshToken = _jwt.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);

            return new AuthResponseDto
            {
                Email = user.Email,
                Token = token,
                RefreshToken = refreshToken
            };
        }
    }
}
