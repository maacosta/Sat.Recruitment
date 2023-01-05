using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Services
{
    public interface IEmailNormalizer
    {
        string Normalize(string email);
    }
}
