using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.Service
{
    public class KeyService
    {

        public async Task SaveTokenAsync(string key, string token)
        {
            await SecureStorage.Default.SetAsync(key, token);
        }

        public async Task<string?> GetTokenAsync(string apiKey)
        {
            return await SecureStorage.Default.GetAsync(apiKey);
        }

        public void DeleteToken(string key)
        {
            SecureStorage.Default.Remove(key);
        }

    }
}
