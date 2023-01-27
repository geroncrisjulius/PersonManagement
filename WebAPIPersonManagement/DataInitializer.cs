using Microsoft.EntityFrameworkCore;
using WebAPIPersonManagement.Database;

namespace WebAPIPersonManagement
{
    public class DataInitializer
    {
        private readonly PersonManagerContext _context;
        private static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("http://my-json-server.typicode.com/m4ur1c1o86/codetest/"),
        };

        public DataInitializer(PersonManagerContext context)
        {
            this._context = context;
        }

        public async void Initialize()
        {
            var persons = await GetDefaultPersonsAsync(sharedClient);
            _context.Persons.AddRange(persons);
            _context.SaveChanges();

            var personTypes = new[]
            {
                new PersonType { Type = 1, Description = "Teacher" },
                new PersonType { Type = 2, Description = "Student" }
            };

            _context.PersonTypes.AddRange(personTypes);
            _context.SaveChanges();
        }

        private static async Task<IEnumerable<Person>> GetDefaultPersonsAsync(HttpClient httpClient)
        {
            using (HttpResponseMessage response = await httpClient.GetAsync("persons"))
            {
                response.EnsureSuccessStatusCode();

                var persons = await response.Content.ReadFromJsonAsync<IEnumerable<Person>>();
                return persons != null ? persons : new List<Person>();
            }

        }
    }


}
