using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    public static class IncomeParser
    {
        /// <summary>
        /// Парсит строку в объект Income
        /// </summary>
        public static Income Parse(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentException("Строка не может быть пустой");
            }

            string[] parts = inputString.Split(' ');
            var income = new Income();

            income.Date = ParseDate(parts[0]);
            income.Source = ParseSource(parts);
            income.Amount = ParseAmount(parts);

            return income;
        }

        /// <summary>
        /// Парсит дату из строки
        /// </summary>
        private static DateTime ParseDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "yyyy.MM.dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Парсит источник дохода (поддерживает строки в кавычках)
        /// </summary>
        private static string ParseSource(string[] parts)
        {
            int currentIndex = 1;
            string source = string.Empty;

            if (parts[currentIndex].StartsWith("\""))
            {
                source += parts[currentIndex];
                currentIndex++;

                while (currentIndex < parts.Length && !parts[currentIndex].EndsWith("\""))
                {
                    source += " " + parts[currentIndex];
                    currentIndex++;
                }

                if (currentIndex < parts.Length && parts[currentIndex].EndsWith("\""))
                {
                    source += " " + parts[currentIndex];
                    currentIndex++;
                }
            }

            return source.Trim('"');
        }

        /// <summary>
        /// Парсит сумму дохода
        /// </summary>
        private static int ParseAmount(string[] parts)
        {
            return int.Parse(parts[parts.Length - 1]);
        }
    }
}
