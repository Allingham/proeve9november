using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PlanteShopService;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Tryk enter for at starte, intast nummer for at finde specifik");
                string answer = Console.ReadLine();
                string URL = "http://localhost:55809/PlanteInline/";

                if (!(answer.Length > 0))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string content = client.GetStringAsync(URL).Result;
                        List<Plante> liste = JsonConvert.DeserializeObject<List<Plante>>(content);

                        foreach (var plante in liste)
                        {
                            Console.WriteLine(plante);
                        }
                    }
                }
                else
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string content = client.GetStringAsync(URL + $"{answer}").Result;
                        Plante plante = JsonConvert.DeserializeObject<Plante>(content);

                        Console.WriteLine(plante);
                    }
                }
            }
        }
    }
}
