using CsvHelper;
using CsvHelper.Configuration;
using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        public async IAsyncEnumerable<User> getAllUsersAsync()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader("Files\\Users.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                await foreach(var r in csv.GetRecordsAsync<User>())
                {
                    yield return r;
                }
            }
        }
    }
}
