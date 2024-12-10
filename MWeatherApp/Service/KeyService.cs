using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.Service
{
    public class KeyService
    {
        private const string ApiKey = "api_key";

        public async Task SaveTokenAsync(string token)
        {
            await SecureStorage.Default.SetAsync(ApiKey, token);
        }

        public async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.Default.GetAsync(ApiKey);
        }

        public void DeleteToken()
        {
            SecureStorage.Default.Remove(ApiKey);
        }

    }
}
