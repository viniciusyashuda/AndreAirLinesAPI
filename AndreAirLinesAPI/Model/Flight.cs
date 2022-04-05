using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AndreAirLinesAPI.Model.Model;
using Newtonsoft.Json;

namespace AndreAirLinesAPI.Model
{
    public class Flight
    {
        #region Properties

        [JsonProperty("Id")]
        public int Id { get; set; }


        [JsonProperty("Origin")]
        public virtual Airport Origin { get; set; }


        [JsonProperty("Destination")]
        public virtual Airport Destination { get; set; }


        [JsonProperty("Aircraft")]
        public virtual Aircraft Aircraft { get; set; }


        [JsonProperty("DepartureTime")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }


        [JsonProperty("ArrivalTime")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }



        #endregion

        #region Methods

        public override string ToString()
        {
            return "\n\n\nId: " + Id
                + "\nOrigin: " + Origin
                + "\nDestination: " + Destination
                + "\nAircraft: " + Aircraft
                + "\nDeparture Time: " + DepartureTime
                + "\nArrival Time: " + ArrivalTime + "\n";
        }

        #endregion
    }
}
