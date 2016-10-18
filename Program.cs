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

            //MyAPIGet(cons).Wait();
            GetApiCallAsync(cons).Wait();

        }


        // static async Task MyAPIGet(HttpClient cons)
        // {
        //     using (cons)
        //     {
        //         HttpResponseMessage res = await cons.GetAsync("api/Kraken/GetById/22a877aa-c291-4ba8-88be-634bd181bb94");
        //         res.EnsureSuccessStatusCode();
        //         if (res.IsSuccessStatusCode)
        //         {
        //             try
        //             {
        //                 Item item = await res.Content.ReadAsAsync<Item>();
        //                 Console.WriteLine("\n");
        //                 Console.WriteLine("---------------------Calling Get Operation------------------------");
        //                 Console.WriteLine("\n");
        //                 Console.WriteLine("ItemId    Name          ReservedBy");
        //                 Console.WriteLine("-----------------------------------------------------------");
        //                 Console.WriteLine("{0}\t{1}\t\t{2}", item.ItemId, item.Name, item.ReservedBy);
        //                 Console.ReadLine();
        //             }
        //             catch (Exception ex)
        //             {

        //             }
        //         }
        //     }
        // }

        public static async Task GetApiCallAsync(HttpClient cons)
        {
            using (cons)
            {
                var response = await cons.GetStringAsync("api/Kraken/GetById/22a877aa-c291-4ba8-88be-634bd181bb94");

                if (response != null)
                {
                    try
                    {
                        var item = JsonConvert.DeserializeObject<Item>(response);
                        Console.WriteLine("\n");
                        Console.WriteLine("---------------------Calling Get Operation------------------------");
                        Console.WriteLine("\n");
                        Console.WriteLine("ItemId    Name          ReservedBy");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("{0}\t{1}\t\t{2}", item.ItemId, item.Name, item.ReservedBy);
                        
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}
