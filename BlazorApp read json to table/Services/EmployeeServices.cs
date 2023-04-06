using System.Text.Json;

namespace BlazorApp_read_json_to_table.Services
{
    public class EmployeeServices
    {
        private readonly HttpClient httpClient;

        public EmployeeServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Dictionary<string,object>>> GetEmployees()
        {
            var response = await httpClient.GetAsync("https://localhost:44359/api/employees");
            var json = await response.Content.ReadAsStringAsync();
            var jsonDocumnet = JsonDocument.Parse(json);

            var Employees = new List<Dictionary<string,object>>();

            foreach(var jsonElement in jsonDocumnet.RootElement.EnumerateArray()) {
                var Employe = new Dictionary<string,object>();

                foreach(var property in jsonElement.EnumerateObject())
                {
                    Employe.Add(property.Name, property.Value);
                }

                Employees.Add(Employe);

            }
            return Employees;
        }
    }
}
