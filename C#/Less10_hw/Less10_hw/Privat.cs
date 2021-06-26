using Less10_hw.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less10_hw
{
    class Privat
    {
        const string clientUrl = "https://api.privatbank.ua/p24api";
        List<Department> departments;
        public Privat(string url)
        {
            departments = new List<Department>();
            LoadDepartments(url);
        }
        public void GetExchangeRate(string url)
        {
            var client = new RestClient(clientUrl);
            var request = new RestRequest(url);
            var response = client.Get(request);
            var rates = JsonConvert.DeserializeObject<List<ExchangeRate>>(response.Content);
            foreach (var item in rates)
            {
                Console.WriteLine(item);
            }
        }
        public void GetCashRateOnDate(string url)
        {
            var client = new RestClient(clientUrl);
            DateTime dateTime;
            Console.WriteLine("Enter date for request (yyyy-mm-dd):");
            DateTime.TryParse(Console.ReadLine(), out dateTime);
            string fullUrl = url + dateTime.Date;
            var request = new RestRequest(fullUrl);
            var response = client.Get(request);
            JObject keyValues = JObject.Parse(response.Content);
            var rates = JsonConvert.DeserializeObject<List<ExchangeRateFull>>(keyValues["exchangeRate"].ToString());
            foreach (var item in rates)
            {
                Console.WriteLine(item);
            }
        }
        public void LoadDepartments(string url)
        {
            if (departments.Count!=0)
            {
                departments.Clear();
            }
            var client = new RestClient(clientUrl);
            var request = new RestRequest(url);
            var response = client.Get(request);
            departments = JsonConvert.DeserializeObject<List<Department>>(response.Content);
        }
        public void ShowCityList()
        {
           var cities = departments.Select(c => c.City).ToList();
           var citiesDistinct = cities.Distinct().ToList();
            citiesDistinct.Sort();
            citiesDistinct.ForEach(c => c.Trim(' '));
           foreach (var item in citiesDistinct)
            {
                Console.WriteLine(item);
            }
        }

        public void GetDepartmentsByCity()
        {
            Console.WriteLine("Enter city name:");
            string cityName = Console.ReadLine();
            var result = departments.Where(d => d.City.Contains(cityName)).ToList();
            result.ForEach(d => Console.WriteLine(d));
        }
        public void GetDepartmentsByAddress()
        {
            Console.WriteLine("Enter city name:");
            string cityName = Console.ReadLine();
            Console.WriteLine("Enter address:");
            string address = Console.ReadLine();
            var result = departments.Where(d => d.Address.Contains(address) && d.City.Contains(cityName)).ToList();
            result.ForEach(d => Console.WriteLine(d));
        }
    }
}
