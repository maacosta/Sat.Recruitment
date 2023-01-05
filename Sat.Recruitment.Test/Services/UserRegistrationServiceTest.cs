using Microsoft.OpenApi.Any;
using Moq;
using Sat.Recruitment.Api.FunctionalExceptions;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test.Services
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserRegistrationServiceTest
    {
        [Fact]
        public void Create_Ok()
        {
            User userA = new User
            {
                Name = "A",
            };
            User userB = new User
            {
                Name = "B",
            };
            User userTarget = new User
            {
                Name = "C",
            };

            var emailNormalizerMock = new Mock<IEmailNormalizer>();
            var userDuplicationValidatorMock = new Mock<IUserDuplicationValidator>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var welcomeUserGiftServiceMock = new Mock<IWelcomeUserGiftService>();

            userDuplicationValidatorMock
                .Setup(s => s.AreDuplicated(It.IsAny<User>(), It.IsAny<User>()))
                .Returns(false);

            IAsyncEnumerable<User> users = this.GetUsersAsync(new User[] { userA, userB });
            userRepositoryMock
                .Setup(s => s.getAllUsersAsync())
                .Returns(users);

            IUserRegistrationService target = new UserRegistrationService(
                emailNormalizerMock.Object,
                userDuplicationValidatorMock.Object,
                userRepositoryMock.Object,
                welcomeUserGiftServiceMock.Object
                );

            var res = target.CreateAsync(userTarget).Result;

            Assert.True(res);
        }

        [Fact]
        public void Create_FunctionalExceptionForDuplication()
        {
            User userA = new User
            {
                Name = "A",
            };
            User userB = new User
            {
                Name = "B",
            };
            User userTarget = new User
            {
                Name = "A",
            };

            var emailNormalizerMock = new Mock<IEmailNormalizer>();
            var userDuplicationValidatorMock = new Mock<IUserDuplicationValidator>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var welcomeUserGiftServiceMock = new Mock<IWelcomeUserGiftService>();

            userDuplicationValidatorMock
                .Setup(s => s.AreDuplicated(It.IsAny<User>(), It.IsAny<User>()))
                .Returns(true);

            IAsyncEnumerable<User> users = this.GetUsersAsync(new User[] { userA, userB });
            userRepositoryMock
                .Setup(s => s.getAllUsersAsync())
                .Returns(users);

            IUserRegistrationService target = new UserRegistrationService(
                emailNormalizerMock.Object,
                userDuplicationValidatorMock.Object,
                userRepositoryMock.Object,
                welcomeUserGiftServiceMock.Object
                );

            Assert.ThrowsAsync<FunctionalException>(() => target.CreateAsync(userTarget));
        }

        async IAsyncEnumerable<User> GetUsersAsync(User[] users)
        {
            foreach (var user in users)
            {
                yield return user;
            }
        }
    }
}
