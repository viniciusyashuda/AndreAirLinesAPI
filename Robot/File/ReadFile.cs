using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreAirLinesAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Robot
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
