using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AndreAirLinesAPI.Model
{
    public class Aircraft
    {
        #region Properties

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Aircraft_Name")]
        public string Aircraft_Name { get; set; }

        [JsonProperty("Capacity")]
        public int Capacity { get; set; }


        #endregion

        #region Methods
        public override string ToString()
        {
            return "\n * Id: " + Id
                + "\n * Aircraft Name: " + Aircraft_Name
                + "\n * Capacity: " + Capacity + "\n";
        }

        #endregion
    }
}
