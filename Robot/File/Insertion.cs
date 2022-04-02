using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Insertion
    {

         static readonly HttpClient client = new HttpClient();

        public async Task InsertJsonBD()
        {
            client.BaseAddress = new System.Uri("https://localhost:44348/");

            string pathFile = @"C:\Users\Vinícius Yashuda\Documents\generated.json";

            var list = ReadFile.GetData(pathFile);

            foreach(var flight in list)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Flights", flight);
            }

        }

    }
}
