using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rapidapi
{
    class Program
    {
            static void Main(string[] args)
            {
                var result = numbersFacts();

                Console.ReadLine();
            }
            static Task numbersFacts()
            {
                WebRequest request = WebRequest.Create("https://numbersapi.p.rapidapi.com/6/21/date?fragment=true&json=true");
                request.Headers.Add("X-RapidAPI-Host", "numbersapi.p.rapidapi.com");
                request.Headers.Add("X-RapidAPI-Key", "e56a56465dmshcab6dc055b50ba0p11d6bfjsn9d8753c65d94");


                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {

                        string line = reader.ReadToEnd();

                        numbers results = JsonConvert.DeserializeObject<numbers>(line);
                        Console.WriteLine("Факты даты " + results.Text);
                        Console.WriteLine("Год " + results.year);
                        Console.WriteLine("Число " + results.number);
                        Console.WriteLine("Поиск " + results.found);
                        Console.WriteLine("Тип " + results.type);
                    }
                }
                response.Close();
                Console.WriteLine("Запрос выполнен");
                return Task.CompletedTask;  
        }
    }
}
