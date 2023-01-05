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
    public class UserDuplicationValidatorTest
    {
        [Fact]
        public void AreDuplicated_FalseWithEverythingDistinct()
        {
            User userA = new User
            {
                Name = "A",
                Email = "a@a.com",
                Phone = "123",
                Address = "aa",
                UserType = "bb",
                Money = 10,
            };
            User userB = new User
            {
                Name = "B",
                Email = "b@b.com",
                Phone = "456",
                Address = "bb",
                UserType = "cc",
                Money = 11,
            };

            IUserDuplicationValidator target = new UserDuplicationValidator();

            var res = target.AreDuplicated(userA, userB);

            Assert.False(res);
        }

        [Fact]
        public void AreDuplicated_FalseWithSameNameDistinctAdress()
        {
            User userA = new User
            {
                Name = "A",
                Email = "a@a.com",
                Phone = "123",
                Address = "aa",
                UserType = "bb",
                Money = 10,
            };
            User userB = new User
            {
                Name = "A",
                Email = "b@b.com",
                Phone = "456",
                Address = "bb",
                UserType = "cc",
                Money = 11,
            };

            IUserDuplicationValidator target = new UserDuplicationValidator();

            var res = target.AreDuplicated(userA, userB);

            Assert.False(res);
        }

        [Fact]
        public void AreDuplicated_TrueWithSameNameAndAdress()
        {
            User userA = new User
            {
                Name = "A",
                Email = "a@a.com",
                Phone = "123",
                Address = "aa",
                UserType = "bb",
                Money = 10,
            };
            User userB = new User
            {
                Name = "A",
                Email = "b@b.com",
                Phone = "456",
                Address = "aa",
                UserType = "bb",
                Money = 10,
            };

            IUserDuplicationValidator target = new UserDuplicationValidator();

            var res = target.AreDuplicated(userA, userB);

            Assert.True(res);
        }

        [Fact]
        public void AreDuplicated_TrueWithSamePhone()
        {
            User userA = new User
            {
                Name = "A",
                Email = "a@a.com",
                Phone = "123",
                Address = "aa",
                UserType = "bb",
                Money = 10,
            };
            User userB = new User
            {
                Name = "B",
                Email = "b@b.com",
                Phone = "123",
                Address = "bb",
                UserType = "cc",
                Money = 11,
            };

            IUserDuplicationValidator target = new UserDuplicationValidator();

            var res = target.AreDuplicated(userA, userB);

            Assert.True(res);
        }

        [Fact]
        public void AreDuplicated_TrueWithSameEmail()
        {
            User userA = new User
            {
                Name = "A",
                Email = "a@a.com",
                Phone = "123",
                Address = "aa",
                UserType = "bb",
                Money = 10,
            };
            User userB = new User
            {
                Name = "B",
                Email = "a@a.com",
                Phone = "456",
                Address = "bb",
                UserType = "cc",
                Money = 11,
            };

            IUserDuplicationValidator target = new UserDuplicationValidator();

            var res = target.AreDuplicated(userA, userB);

            Assert.True(res);
        }
    }
}
