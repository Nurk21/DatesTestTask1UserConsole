using DatesTestTaskUserConsole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var content = await _client.GetStringAsync("Dates/GetRanges/?from=2019-10-07&to=2019-10-28");

            var user = JsonConvert.DeserializeObject<List<DatesRangeDTO>>(content);
            Console.WriteLine(content);
            return null;
        }

        public async Task InsertDates(DateTime from, DateTime to)
        {
            DatesRangeDTO period = new DatesRangeDTO(from, to);
            var json = JsonConvert.SerializeObject(period);
            var data = new StringContent(json, Encoding.UTF8, "application/json");     
            
            var response = await _client.PostAsync("Dates/AddRange", data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }
}
