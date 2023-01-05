using Sat.Recruitment.Api.FunctionalExceptions;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services.Impl
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IEmailNormalizer _emailNormalizer;
        private readonly IUserDuplicationValidator _userDuplicationValidator;
        private readonly IUserRepository _userRepository;
        private readonly IWelcomeUserGiftService _welcomeUserGiftService;

        public UserRegistrationService(
            IEmailNormalizer emailNormalizer,
            IUserDuplicationValidator userDuplicationValidator,
            IUserRepository userRepository,
            IWelcomeUserGiftService welcomeUserGiftService)
        {
            _emailNormalizer = emailNormalizer;
            _userDuplicationValidator = userDuplicationValidator;
            _userRepository = userRepository;
            _welcomeUserGiftService = welcomeUserGiftService;
        }

        public async Task<bool> CreateAsync(User user)
        {
            _welcomeUserGiftService.Calculate(ref user);

            user.Email = _emailNormalizer.Normalize(user.Email);

            var users = _userRepository.getAllUsersAsync();

            await foreach(var u in users)
            {
                if(_userDuplicationValidator.AreDuplicated(u, user))
                {
                    Debug.WriteLine("The user is duplicated");
                    throw new FunctionalException("User is duplicated");
                }
            }

            Debug.WriteLine("User Created");

            return true;
        }
    }
}
