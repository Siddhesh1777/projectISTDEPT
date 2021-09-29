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
    public class GetMinors : IGetMinors
    {
        public async Task<List<Minors>> Getminors()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/minors/UgMinors", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Minors>>>(data);
                    List<Minors> minorsList = new List<Minors>();
                    Minors minors = new Minors();

                    foreach (KeyValuePair<string, List<Minors>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            minorsList.Add(item);
                        }
                    }

                    return minorsList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Minors> minorsList = new List<Minors>();
                    return minorsList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Minors> minorsList = new List<Minors>();
                    return minorsList;
                }
            }
        }

        Task<List<Minors>> IGetMinors.GetMinors()
        {
            throw new NotImplementedException();
        }
    }
}
