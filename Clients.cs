using PhoneApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace Users.Plugin
{
    public class Clients
    {     
        public async Task<List<EmployeesDTO>> ProcessRepositoriesAsync(HttpClient client)
        {
            var json = await client.GetStringAsync("https://dummyjson.com/users");
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Root<Person>>(json);
            var result = new List<EmployeesDTO>();

            foreach (var item in model.users)
            {
                var value = new EmployeesDTO() { Name = item.lastName + " " + item.firstName + " " + item.maidenName };
                value.AddPhone(item.phone);
                result.Add(value);
            }
            return result;
        }
    }
}
