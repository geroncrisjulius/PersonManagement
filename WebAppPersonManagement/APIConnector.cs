using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebAppPersonManagement
{

    public class APIConnector
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        private string _baseURL;

        public APIConnector(string baseURL)
        {
            _baseURL = baseURL;
        }

        private StringContent GenerateStringContent(object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            string requestURL = $"{_baseURL}Person";
            using (HttpResponseMessage response = await _httpClient.GetAsync(requestURL))
            {
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
                return persons != null ? persons : new List<Person>();
            }

        }

        public async void CreatePerson(Person person)
        {
            string requestURL = $"{_baseURL}Person";

            using (HttpResponseMessage response = await _httpClient.PostAsync(requestURL, GenerateStringContent(person)))
            {
                response.EnsureSuccessStatusCode();

            }
        }

        public async void UpdatePerson(int id, Person person)
        {

            string requestURL = $"{_baseURL}Person/{id}";
            using (HttpResponseMessage response = await _httpClient.PutAsync(requestURL, GenerateStringContent(person)))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public async void DeletePerson(int id)
        {

            string requestURL = $"{_baseURL}Person/{id}";
            using (HttpResponseMessage response = await _httpClient.DeleteAsync(requestURL))
            {
                response.EnsureSuccessStatusCode();
            }
        }


    }
}