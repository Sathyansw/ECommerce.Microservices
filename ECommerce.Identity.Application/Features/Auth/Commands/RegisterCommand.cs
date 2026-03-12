using ECommerce.Identity.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Application.Features.Auth.Commands
{
    public record RegisterCommand(
    string Email,
    string Password,
    string FullName
) : IRequest<AuthResponseDto>;
}
