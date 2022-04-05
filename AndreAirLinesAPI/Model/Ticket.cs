using System;
using AndreAirLinesAPI.Model.Model;

namespace AndreAirLinesAPI.Model
{
    public class Ticket
    {

        public int Id { get; set; }

        public Flight Flight { get; set; }

        public Passenger Passenger { get; set; }

        public Class Class { get; set; }

        public BasePrice BasePrice { get; set; }

        public double SalePercentage { get; set; }

        public double TotalValue { get; set; }

        public DateTime RegistrationDate { get; set; }


        public override string ToString()
        {
            return "\n Id: " + Id
                + "\n Flight Id: " + Flight.Id
                + "\n Passenger Cpf: " + Passenger.Cpf
                + "\n Class: " + Class.Description
                + "\n Base Price: " + BasePrice.Value
                + "\n Sale Percentage: " + SalePercentage
                + "\n Total Value: " + TotalValue
                + "\n Registration Date: " + RegistrationDate;
        }

    }
}
