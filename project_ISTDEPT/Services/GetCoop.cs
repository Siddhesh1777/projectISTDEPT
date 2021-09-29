using Newtonsoft.Json;
using Project3_FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Project3_FinalExam.Services
{
    public class GetCoop : IGetCoop
    {
        public async Task<List<Coop>> Getcoop()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/employment/coopTable/coopInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Coop>>>(data);
                    List<Coop> CoopList = new List<Coop>();
                    Coop Coop = new Coop();
                    foreach (KeyValuePair<string, List<Coop>> kvp in rtnResults)
                    {



                        foreach (var item in kvp.Value)
                        {

                            CoopList.Add(item);


                        }

                    }

                    return CoopList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Coop> CoopList = new List<Coop>();
                    return CoopList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Coop> CoopList = new List<Coop>();
                    return CoopList;
                }
            }
        }
    }
}
