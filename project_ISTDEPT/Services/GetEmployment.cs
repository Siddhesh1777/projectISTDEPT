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
    public class GetEmployment : IGetEmployment
    {
        public async Task<List<Employment>> Getemployment()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/employment/employmentTable/professionalEmploymentInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Employment>>>(data);
                    List<Employment> EmploymentList = new List<Employment>();
                    Employment Employment = new Employment();
                    foreach (KeyValuePair<string, List<Employment>> kvp in rtnResults)
                    {



                        foreach (var item in kvp.Value)
                        {

                            EmploymentList.Add(item);


                        }

                    }

                    return EmploymentList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Employment> employmentList = new List<Employment>();
                    return employmentList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Employment> employmentList = new List<Employment>();
                    return employmentList;
                }
            }
        }
    }
}
