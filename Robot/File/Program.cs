using System;
using System.Linq;
using AndreAirLinesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Robot
{
    public class Program
    {

        static void Main(string[] args)
        {
            Insertion insertion = new Insertion();
            insertion.InsertJsonBD().Wait();
            
        }
    }
}
