using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AndreAirLinesAPI.Data;
using AndreAirLinesAPI.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Robot.RobotService
{
    public class Queries
    {

        public static async Task TicketReport(int month)
        {
            using var client = new HttpClient();


            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44348/api/Tickets");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();


                var tickets = JsonConvert.DeserializeObject<List<Ticket>>(responseBody);

                var ticketsQuery =
                    (from ticket in tickets
                     where ticket.RegistrationDate.Month == month
                     select ticket);

                foreach (var ticket in ticketsQuery)
                {
                    Console.WriteLine(ticket.ToString());
                }


                string fileName = "tickets_report.json";
                string jsonString = JsonSerializer.Serialize(ticketsQuery);
                File.WriteAllText(fileName, jsonString);

            }
            catch (Exception exception)
            {
                throw new Exception("Exception: " + exception.Message);
            }
        }


        public static async Task BasePriceReport()
        {
            using var client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44348/api/BasePrices");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();


                var base_prices = JsonConvert.DeserializeObject<List<BasePrice>>(responseBody);

                var baseprice_Query =
                    (from base_price in base_prices
                     select base_price).Take(1);

                foreach (var base_price in baseprice_Query)
                {

                    Console.WriteLine(base_price);
                                        
                }


                string fileName = "baseprice_report.json";
                string jsonString = JsonSerializer.Serialize(baseprice_Query);
                File.WriteAllText(fileName, jsonString);

            }
            catch (Exception exception)
            {
                throw new Exception("Exception: " + exception.Message);
            }
        }


    }
}
