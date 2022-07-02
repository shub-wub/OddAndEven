using Domain.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
            var setupExceptionMessage = new List<string>();

            if (httpClient == null) { setupExceptionMessage.Add($"Parameter {nameof(httpClient)} is null."); }

            if (userSetting == null || userSetting.Value == null) { setupExceptionMessage.Add($"Parameter {nameof(userSetting)} is null."); }
            else if (string.IsNullOrEmpty(userSetting.Value.Url)) { setupExceptionMessage.Add($"Parameter {nameof(userSetting)}.{nameof(userSetting.Value.Url)} is null."); }

            if (setupExceptionMessage.Count > 0) { throw new ArgumentNullException(string.Join(" ", setupExceptionMessage)); }

            _httpClient = httpClient;
            _userDataUrl = userSetting.Value.Url;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            var task = _httpClient.GetAsync(_userDataUrl).ContinueWith((taskResponse) =>
            {
                var response = taskResponse.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                users = JsonConvert.DeserializeObject<List<User>>(jsonString.Result);
            });
            task.Wait();

            return users;
        }
    }
}
