﻿using Sat.Recruitment.Api.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public interface IUserRegistrationService
    {
        Task<bool> CreateAsync(User user);
    }
}
