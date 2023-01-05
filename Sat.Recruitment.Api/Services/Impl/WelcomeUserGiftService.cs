using Sat.Recruitment.Api.Models;
using System;

namespace Sat.Recruitment.Api.Services.Impl
{
    public class WelcomeUserGiftService : IWelcomeUserGiftService
    {
        public void Calculate(ref User user)
        {
            if (user.UserType == "Normal")
            {
                if (user.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = user.Money * percentage;
                    user.Money = user.Money + gif;
                }
                if (user.Money < 100)
                {
                    if (user.Money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = user.Money * percentage;
                        user.Money = user.Money + gif;
                    }
                }
            }
            if (user.UserType == "SuperUser")
            {
                if (user.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = user.Money * percentage;
                    user.Money = user.Money + gif;
                }
            }
            if (user.UserType == "Premium")
            {
                if (user.Money > 100)
                {
                    var gif = user.Money * 2;
                    user.Money = user.Money + gif;
                }
            }
        }
    }
}
