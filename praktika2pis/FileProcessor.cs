using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    public static class FileProcessor
    {
        /// <summary>
        /// Читает доходы из файла
        /// </summary>
        public static List<Income> ReadIncomesFromFile(string filePath)
        {
            var incomes = new List<Income>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден!");
                return incomes;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine($"Найдено {lines.Length} строк в файле");

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        try
                        {
                            Income income = ParseIncomeFromString(line);
                            incomes.Add(income);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка чтения: {line}. {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка файла: {ex.Message}");
            }

            return incomes;
        }

        /// <summary>
        /// Записывает доходы в файл
        /// </summary>
        public static void WriteIncomesToFile(List<Income> incomes, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Income income in incomes)
                    {
                        string line = $"{income.Date:yyyy.MM.dd} \"{income.Source}\" {income.Amount}";
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"Записано {incomes.Count} доходов в {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи: {ex.Message}");
            }
        }

        /// <summary>
        /// Парсит строку в Income
        /// </summary>
        private static Income ParseIncomeFromString(string str)
        {
            string[] parts = str.Split();

            var info = new Income();
            info.Date = DateTime.ParseExact(parts[0], "yyyy.MM.dd", CultureInfo.InvariantCulture);

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

            info.Source = source.Trim('"');
            info.Amount = int.Parse(parts[indexNow]);

            return info;
        }
    }
}
