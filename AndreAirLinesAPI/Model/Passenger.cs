    using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AndreAirLinesAPI.Model
{
    namespace Model
    {
        public class Passenger
        {

            #region Properties


            [JsonProperty("Cpf")]
            [Key]
            public string Cpf { get; set; }

            [JsonProperty("Passenger_Name")]
            public string Passenger_Name { get; set; }

            [JsonProperty("Phone")]
            public string Phone { get; set; }

            [JsonProperty("BirthDate")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime BirthDate { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Address")]
            //[ForeignKey("AddressId")]
            //public int AddressId { get; set; }
            public virtual Address Address { get; set; }



            #endregion

        }
    }

}
