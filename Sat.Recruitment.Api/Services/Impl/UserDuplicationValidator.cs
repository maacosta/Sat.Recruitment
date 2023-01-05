using Sat.Recruitment.Api.Models;
using System;

namespace Sat.Recruitment.Api.Services.Impl
{
    public class UserDuplicationValidator : IUserDuplicationValidator
    {
        public bool AreDuplicated(User user1, User user2)
        {
            return user1.Email.Equals(user2.Email, StringComparison.CurrentCultureIgnoreCase)
                || user1.Phone.Equals(user2.Phone)
                || (user1.Name.Equals(user2.Name, StringComparison.CurrentCultureIgnoreCase)
                    && user1.Address.Equals(user2.Address, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
