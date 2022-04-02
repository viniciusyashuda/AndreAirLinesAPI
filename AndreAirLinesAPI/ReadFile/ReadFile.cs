using System.Collections.Generic;
using System.IO;
using AndreAirLinesAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AndreAirLinesAPI.ReadFile
{
    public class ReadFile
    {
        public static List<Flight> GetData(string filePath)
        {

            StreamReader streamReader = new StreamReader(filePath);
            string jsonString = streamReader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<Flight>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }) as List<Flight>;

            if (list != null)
                return list;
            else
                return null;

        }

    }
}
