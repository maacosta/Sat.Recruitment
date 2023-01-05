using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Services
{
    public interface IWelcomeUserGiftService
    {
        void Calculate(ref User user);
    }
}
