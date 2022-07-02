using Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _userDataUrl;

        public Repository(HttpClient httpClient, IOptions<UserSettings> userSetting)
        {
        }

    }
}
