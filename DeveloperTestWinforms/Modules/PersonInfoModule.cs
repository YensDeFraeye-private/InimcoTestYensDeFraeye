using DeveloperTestAPI.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTestConsole.Modules
{
    public class PersonInfoModule
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<PersonInfoModel> GetPersonInfo(PersonModel personModel)
        {
            PersonInfoModel personInfoModel = null;
            try
            {
                string json = JsonConvert.SerializeObject(personModel);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:44318/api/Person/") })
                {
                    HttpResponseMessage responseMessage = httpClient.PostAsync("getInfo", data).Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string jsonString = responseMessage.Content.ReadAsStringAsync().Result;
                        personInfoModel = JsonConvert.DeserializeObject<PersonInfoModel>(jsonString);
                    }
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return personInfoModel;
        }
    }
}
