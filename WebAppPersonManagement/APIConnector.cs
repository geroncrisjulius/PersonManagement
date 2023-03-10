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

        public async Task<Person_GetModel> GetPersonAsync(int id)
        {
            string requestURL = $"{_baseURL}/Person/{id}";
            using (HttpResponseMessage response = await _httpClient.GetAsync(requestURL))
            {
                if (!response.IsSuccessStatusCode) { return null; }
                string json = await response.Content.ReadAsStringAsync();
                var person = JsonConvert.DeserializeObject<Person_GetModel>(json);
                return person != null ? person : new Person_GetModel();
            }

        }

        public async Task<IEnumerable<Person_GetModel>> GetAllPersonsAsync()
        {
            string requestURL = $"{_baseURL}/Person";
            using (HttpResponseMessage response = await _httpClient.GetAsync(requestURL))
            {
                if (!response.IsSuccessStatusCode) { return null; }
                string json = await response.Content.ReadAsStringAsync();
                var persons = JsonConvert.DeserializeObject<IEnumerable<Person_GetModel>>(json);
                return persons != null ? persons : new List<Person_GetModel>();
            }

        }

        public async void CreatePersonAsync(Person_WriteModel person)
        {
            string requestURL = $"{_baseURL}/Person";

            using (HttpResponseMessage response = await _httpClient.PostAsync(requestURL, GenerateStringContent(person)))
            {


            }
        }

        public async void UpdatePersonAsync(int id, Person_WriteModel person)
        {

            string requestURL = $"{_baseURL}/Person/{id}";
            using (HttpResponseMessage response = await _httpClient.PutAsync(requestURL, GenerateStringContent(person)))
            {
            }
        }

        public async void DeletePersonAsync(int id)
        {

            string requestURL = $"{_baseURL}/Person/{id}";
            using (HttpResponseMessage response = await _httpClient.DeleteAsync(requestURL))
            {
            }
        }

        public async Task<IEnumerable<PersonType_GetModel>> GetAllPersonTypesAsync()
        {
            string requestURL = $"{_baseURL}/PersonType";
            using (HttpResponseMessage response = await _httpClient.GetAsync(requestURL))
            {

                if (!response.IsSuccessStatusCode) { return null; }
                string json = await response.Content.ReadAsStringAsync();
                var personType = JsonConvert.DeserializeObject<IEnumerable<PersonType_GetModel>>(json);
                return personType != null ? personType : new List<PersonType_GetModel>();
            }
        }

        public async Task<PersonType_GetModel> GetAllPersonTypesAsync(int id)
        {
            string requestURL = $"{_baseURL}/PersonType/{id}";
            using (HttpResponseMessage response = await _httpClient.GetAsync(requestURL))
            {

                if (!response.IsSuccessStatusCode) { return null; }
                string json = await response.Content.ReadAsStringAsync();
                var personType = JsonConvert.DeserializeObject<PersonType_GetModel>(json);
                return personType != null ? personType : new PersonType_GetModel();
            }
        }

    }
}