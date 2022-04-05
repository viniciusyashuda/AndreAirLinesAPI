using System;

namespace AndreAirLinesAPI.Model
{
    public class BasePrice
    {

        public int Id { get; set; }

        public Airport Origin { get; set; }

        public Airport Destination { get; set; }

        public double Value { get; set; }

        public DateTime InclusionDate { get; set; }


        public override string ToString()
        {
            return "\n Id: " + Id
                + "\n Origin: " + Origin.Airport_Name
                + "\n Destination: " + Destination.Airport_Name
                + "\n Value: " + Value
                + "\n Inclusion Date: " + InclusionDate; 
        }


    }
}
