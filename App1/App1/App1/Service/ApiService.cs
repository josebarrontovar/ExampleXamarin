using App1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Service
{
   public  class ApiService
    {

        List<ApiModel> ServiceData;
        public async Task<List<ApiModel>> GetVirtualCard(int Id)
        {
            try
            {
                var apiService = $"posts?userId={Id}";
                var URL = new Uri(AppSettings.Url_Path+apiService);
                HttpClient myClient = new HttpClient();

                var response = await myClient.GetAsync(URL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ServiceData = JsonConvert.DeserializeObject<List<ApiModel>>(content);
                 
                   
                }

            }
            catch(Exception e)
            {

            }
            return ServiceData;
        }
        
    }
}
