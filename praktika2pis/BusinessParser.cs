using praktika2pis;
using System;

/// <summary>
/// Парсер для строк с информацией о бизнесе
/// </summary>
public static class BusinessParser
{
    /// <summary>
    /// Парсит строку в объект Buisness
    /// </summary>
    public static Buisness Parse(string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString))
        {
            throw new ArgumentException("Строка не может быть пустой");
        }

        string[] parts = inputString.Split(' ');
        var buisness = new Buisness();

        buisness.Name = ParseBusinessName(parts);
        buisness.CountEmployees = ParseEmployeeCount(parts);

        return buisness;
    }

    /// <summary>
    /// Парсит название бизнеса
    /// </summary>
    private static string ParseBusinessName(string[] parts)
    {
        int currentIndex = 0;
        string name = string.Empty;

        while (currentIndex < parts.Length && !parts[currentIndex].EndsWith("\""))
        {
            name += parts[currentIndex] + " ";
            currentIndex++;
        }

        if (currentIndex < parts.Length)
        {
            name += parts[currentIndex];
        }

        return name.Trim().Trim('"');
    }

    /// <summary>
    /// Парсит количество сотрудников
    /// </summary>
    private static int ParseEmployeeCount(string[] parts)
    {
        return int.Parse(parts[parts.Length - 1]);
    }
}