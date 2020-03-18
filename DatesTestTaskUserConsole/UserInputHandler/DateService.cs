using DatesTestTaskUserConsole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DatesTestTaskUserConsole.UserInputHandler
{
    public interface IDateService
    {
        Task InsertDates(DateTime from, DateTime to);
        Task<List<DatesRangeDTO>> GetIntersection(DateTime from, DateTime to);
    }
    public class DateService : IDateService
    {
        private readonly HttpClient _client;

        public DateService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<DatesRangeDTO>> GetIntersection(DateTime from, DateTime to)
        {
            CultureInfo provider = CultureInfo.CurrentCulture;
            var content = await _client.GetStringAsync($"Dates/GetRanges/?from={from.ToString("yyyy-MM-dd")}&to={to.ToString("yyyy-MM-dd")}");

            var ranges = JsonConvert.DeserializeObject<List<DatesRangeDTO>>(content);
            foreach(DatesRangeDTO range in ranges)
            {
                string a = range.From.ToString("yyyy-MM-dd");
                string b = range.To.ToString("yyyy-MM-dd");
                Console.WriteLine($"intersection found with dates ({a} - {b})");
            }
            return null;
        }

        public async Task InsertDates(DateTime from, DateTime to)
        {
            DatesRangeDTO period = new DatesRangeDTO(from, to);
            var json = JsonConvert.SerializeObject(period);
            var data = new StringContent(json, Encoding.UTF8, "application/json");             
            var response = await _client.PostAsync("Dates/AddRange", data);
            string result = response.StatusCode.ToString();
            Console.WriteLine("Status code shows if adding operation was successful");
            Console.WriteLine(result);
        }
    }
}
