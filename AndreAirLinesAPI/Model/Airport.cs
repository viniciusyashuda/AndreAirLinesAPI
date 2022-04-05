using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AndreAirLinesAPI.Model
{
    public class Airport
    {
        #region Properties

        [JsonProperty("Acronym")]
        [Key]
        public string IATA_Code { get; set; }

        [JsonProperty("Airport_Name")]
        public string Airport_Name { get; set; }

        [JsonProperty("Address")]
        public virtual Address Address { get; set; }


        #endregion

        #region Methods
        public override string ToString()
        {
            return "\n * IATA Code: " + IATA_Code
                + "\n * Airport Name: " + Airport_Name
                + "\n * Address: " + Address + "\n";
        }

        #endregion
    }
}
