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
    public class GetAbout : IGetAbout
    {
        public async Task<List<About>> Getabout()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/about", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<About>(data);
                    List<About> aboutList = new List<About>();
                    About about = new About();

                    // foreach (KeyValuePair<string, List<UnderGradMajors>> kvp in rtnResults)
                    // {
                    //foreach (var item in rtnResults)
                    //{
                    aboutList.Add(rtnResults);
                    // }
                    // }

                    return aboutList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<About> aboutList = new List<About>();
                    return aboutList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<About> aboutList = new List<About>();
                    return aboutList;
                }
            }
        }
    }
}
