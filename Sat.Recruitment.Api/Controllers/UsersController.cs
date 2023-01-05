using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Dtos;
using Sat.Recruitment.Api.FunctionalExceptions;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRegistrationService _userRegistrationService;
        
        public UsersController(
            IMapper mapper,
            IUserRegistrationService userRegistrationService)
        {
            _mapper = mapper;
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                return await _userRegistrationService.CreateAsync(user);
            }
            catch (FunctionalException funEx)
            {
                return BadRequest(funEx.Message);
            }
            catch (Exception ex)
            {
                // logging error
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
