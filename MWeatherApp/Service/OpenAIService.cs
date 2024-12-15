﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MWeatherApp.Service
{

    public static class OpenAIService
    {
        private static readonly IConfiguration _configuration;

        static OpenAIService()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static async Task<string> GetCityDescription(string cityName)
        {
            if (string.IsNullOrEmpty(cityName)) return null;

            using var httpClient = new HttpClient();

            var apiKey = _configuration["OpenAI:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("API key not found in configuration. Please check your secrets or environment variables.");
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);


            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
            {
            new { role = "user", content = $"Provide a brief description of the city named {cityName}." }
        },
                max_tokens = 150,
                temperature = 0.7,
            };

            var response = await httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var CityDescription = ExtractDescription(responseContent);

                return CityDescription;
            }
            else
            {

                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error fetching city description: {errorContent}");
            }
        }

        private static string ExtractDescription(string responseContent)
        {
            try
            {

                using var json = JsonDocument.Parse(responseContent);
                var root = json.RootElement;

                var choices = root.GetProperty("choices");
                if (choices.GetArrayLength() > 0)
                {
                    var content = choices[0].GetProperty("message").GetProperty("content").GetString();
                    return content?.Trim() ?? "No description available.";
                }
                else
                {
                    return "No description available.";
                }
            }
            catch (Exception ex)
            {
                // Handle parsing errors
                throw new Exception("Error parsing the API response.", ex);
            }
        }
    }

}
