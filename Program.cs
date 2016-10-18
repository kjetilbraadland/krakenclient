using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri("http://localhost:7967/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            MyAPIGet(cons).Wait();

        }


        static async Task MyAPIGet(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/tblTags/2");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    MyTag tag = await res.Content.ReadAsAsync<MyTag>();
                    Console.WriteLine("\n");
                    Console.WriteLine("---------------------Calling Get Operation------------------------");
                    Console.WriteLine("\n");
                    Console.WriteLine("tagId    tagName          tagDescription");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("{0}\t{1}\t\t{2}", tag.tagId, tag.tagName, tag.tagDescription);
                    Console.ReadLine();
                }
            }
        }
    }
}
