using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AndreAirLinesAPI.Model
{
    public class Address
    {
        #region Properties  

        public int Id { get; set; }

        [JsonProperty("cep")]
        public string PostalCode { get; set; }

        [JsonProperty("logradouro")]
        public string Street { get; set; }

        public int Number { get; set; }

        [JsonProperty("bairro")]
        public string District { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }

        public string Country { get; set; }

        [JsonProperty("uf")]
        public string Federative_Unit { get; set; }

        [JsonProperty("complemento")]
        public string Complement { get; set; }

        public Address(string postalCode, string street, int number, string district, string city,string country, string federative_Unit, string complement)
        {
            PostalCode = postalCode;
            Street = street;
            Number = number;
            District = district;
            City = city;
            Country = country;
            Federative_Unit = federative_Unit;
            Complement = complement;
        }

        #endregion


    }
}
