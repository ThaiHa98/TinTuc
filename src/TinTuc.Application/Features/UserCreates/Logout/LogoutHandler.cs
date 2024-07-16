﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Application.Helper;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Application.Features.UserCreates.Logout
{
    public class LogoutHandler : IRequestHandler<LogoutRequest, string>
    {
        private readonly IRepositoryInterface<User> _repositoryInterface;
        private readonly Token _token;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogoutHandler(IRepositoryInterface<User> repositoryInterface, Token token, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryInterface = repositoryInterface;
            _token = token;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<string> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Lấy token từ cookies
                var context = _httpContextAccessor.HttpContext;
                if (!context.Request.Cookies.TryGetValue("authenticationToken", out var token))
                {
                    throw new Exception("Token not found in cookies");
                }

                // Xác thực token
                if (!_token.ValidateToken(token))
                {
                    throw new Exception("Invalid token");
                }

                // Lấy thông tin người dùng từ token
                var principal = _token.GetPrincipalFromToken(token);
                var tokenUserId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value);

                if (tokenUserId != request.Id)
                {
                    throw new Exception("Token does not match the user Id");
                }

                // Xóa cookie authenticationToken
                context.Response.Cookies.Delete("authenticationToken");

                return Task.FromResult("Logout successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while logging out", ex);
            }
        }
    }
}