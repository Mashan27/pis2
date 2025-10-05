using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    class Program
    {

        public static Income ParseString(string str)
        {
            string[] parts = str.Split();

            var info = new Income();
            info.date = DateTime.ParseExact(parts[0], "yyyy.MM.dd", CultureInfo.InvariantCulture);

            int indexNow = 1;
            string source = "";
            if (parts[indexNow].StartsWith("\""))
            {
                source += parts[indexNow];
                indexNow++;
                while (indexNow < parts.Length && !parts[indexNow].EndsWith("\""))
                {
                    source += " " + parts[indexNow];
                    indexNow++;
                }
                if (indexNow < parts.Length && parts[indexNow].EndsWith("\""))
                {
                    source += " " + parts[indexNow];
                    indexNow++;
                }
            }

            info.source = source.Trim('"');

            info.amount = int.Parse(parts[indexNow]);

            return info;
        }
        public static Buisness ParseForBuisness(string str)
        {
            var parts = str.Split();
            var info = new Buisness();
            int indexNow = 0;
            string source = "";
            while (!parts[indexNow].EndsWith("\""))
            {
                source += parts[indexNow] + " ";
                indexNow++;
            }
            source += " " + parts[indexNow];
            info.name = source.Trim('"');
            info.countEmployers = int.Parse(parts[indexNow + 1]);
            return info;
        }
        public static Buisness MaxCountEmployers(Buisness[] buisnesses)
        {
            Buisness buisnessMax = new Buisness();
            buisnessMax = buisnesses[0];
            foreach (var buisness in buisnesses)
            {
                if (buisness.countEmployers > buisnessMax.countEmployers)
                {
                    buisnessMax.countEmployers = buisness.countEmployers;
                    buisnessMax = buisness;
                }
            }
            return buisnessMax;
        }


        static void Main(string[] args)
        {
            string someString = $"2025.06.12 \"Министерство Образования\" 2000";
            Console.WriteLine(ParseString(someString));
            string buisnesString = "\"Министерство Образования\" 150";
            Console.WriteLine(ParseForBuisness(buisnesString));


            Console.ReadKey();
        }
    }
}
