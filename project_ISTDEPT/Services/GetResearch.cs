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
    public class GetResearch : IGetResearch
    {
        public async Task<List<Research>> Research()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/research/byInterestArea", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Research>>>(data);
                    List<Research> researchList = new List<Research>();
                    Research research = new Research();

                    foreach (KeyValuePair<string, List<Research>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            researchList.Add(item);
                        }
                    }

                    return researchList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Research> researchList = new List<Research>();
                    return researchList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Research> researchList = new List<Research>();
                    return researchList;
                }
            }
        }

        Task<List<Research>> IGetResearch.Research()
        {
            throw new NotImplementedException();
        }
    }
}
