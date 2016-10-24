using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://localhost:5000/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            CreateAsync(cons).Wait();
            GetApiCallAsync(cons).Wait();            

        }
      

        public static async Task GetApiCallAsync(HttpClient cons)
        {
            using (cons)
            {
                try
                {
                    var response = await cons.GetStringAsync("api/Kraken/GetById/22a877aa-c291-4ba8-88be-634bd181bb94");

                    if (response != null)
                    {

                        var item = JsonConvert.DeserializeObject<Job>(response);
                        Console.WriteLine("\n");
                        Console.WriteLine("---------------------Calling Get Operation------------------------");
                        Console.WriteLine("\n");
                        Console.WriteLine("ItemId    Name          ReservedBy");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("{0}\t{1}\t\t{2}", item.JobId, item.Name, item.ReservedBy);
                    }
                }
                catch (System.Net.Http.HttpRequestException hrex)
                {
                    Console.WriteLine(hrex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

            }
        }

        public static async Task CreateAsync(HttpClient cons)
        {
            using (cons)
            {
                try
                {
                    var job = new Job() { Name = "lala" };

                    StringContent cont = new StringContent(JsonConvert.SerializeObject(job));
                    var response = await cons.PostAsync("api/Kraken/Create", cont);
                }
                catch (System.Net.Http.HttpRequestException hrex)
                {
                    Console.WriteLine(hrex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

            }
        }
    }
}
