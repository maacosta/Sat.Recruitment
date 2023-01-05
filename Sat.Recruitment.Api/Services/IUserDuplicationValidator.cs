using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Services
{
    public interface IUserDuplicationValidator
    {
        bool AreDuplicated(User user1, User user2);
    }
}
