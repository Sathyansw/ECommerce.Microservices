using ECommerce.Identity.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Application.Features.Auth.Commands
{
    public record LoginCommand(
     string Email,
     string Password
 ) : IRequest<AuthResponseDto>;
}
