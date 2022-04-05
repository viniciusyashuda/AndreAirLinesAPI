using System;
using System.Linq;
using AndreAirLinesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Robot.RobotService;

namespace Robot
{
    public class Program
    {

        static void Main(string[] args)
        {

            string option;
            bool flag = true;


            do
            {


                Console.WriteLine("******** Robot Menu ********\n");
                Console.WriteLine("Choose an option: \n");
                Console.WriteLine("|1| Insert data");
                Console.WriteLine("|2| Generate a report on tickets purchased in a specific month");
                Console.WriteLine("|3| Generate a report on most recent base prices");
                Console.WriteLine("|4| Leave\n");
                Console.Write("Option: ");
                option = Console.ReadLine();


                switch (option)
                {

                    case "1":

                        Console.Clear();

                        Insertion.InsertJsonBD().Wait();

                        Console.WriteLine("Press |SPACE| to continue");
                        Console.ReadKey();

                        Console.Clear();

                        break;

                    case "2":

                        Console.Clear();

                        Console.WriteLine("Enter the number of the month in which you want to search: ");
                        int month = int.Parse(Console.ReadLine());

                        Queries.TicketReport(month).Wait();

                        Console.WriteLine("Press |SPACE| to continue");
                        Console.ReadKey();

                        Console.Clear();

                        break;
                    case "3":

                        Console.Clear();

                        Queries.BasePriceReport().Wait();

                        Console.WriteLine("Press |SPACE| to continue");
                        Console.ReadKey();

                        Console.Clear();

                        break;

                    case "4":
                        flag = false;
                        break;

                    default:

                        Console.Clear();

                        Console.WriteLine("Please, enter a valid option!");

                        Console.WriteLine("Press |SPACE| to continue");
                        Console.ReadKey();

                        Console.Clear();

                        break;
    
                }

            }
            while (flag == true);











        }
    }
}
