using praktika2pis;
using System;
using System.Linq;

/// <summary>
/// Анализатор бизнесов
/// </summary>
public static class BusinessAnalyzer
{
    /// <summary>
    /// Находит бизнес с максимальным количеством сотрудников
    /// </summary>
    public static Buisness FindWithMaxEmployees(Buisness[] buisnesses)
    {
        if (buisnesses == null || buisnesses.Length == 0)
        {
            throw new ArgumentException("Массив бизнесов не может быть пустым");
        }

        Buisness buisnessMax = buisnesses[0];

        foreach (var buisness in buisnesses)
        {
            if (buisness.CountEmployees > buisnessMax.CountEmployees)
            {
                buisnessMax = buisness;
            }
        }

        return buisnessMax;
    }

    /// <summary>
    /// Находит бизнес с минимальным количеством сотрудников
    /// </summary>
    public static Buisness FindWithMinEmployees(Buisness[] buisnesses)
    {
        if (buisnesses == null || buisnesses.Length == 0)
        {
            throw new ArgumentException("Массив бизнесов не может быть пустым");
        }

        Buisness buisnessMin = buisnesses[0];

        foreach (var buisness in buisnesses)
        {
            if (buisness.CountEmployees < buisnessMin.CountEmployees)
            {
                buisnessMin = buisness;
            }
        }

        return buisnessMin;
    }

    /// <summary>
    /// Вычисляет среднее количество сотрудников
    /// </summary>
    public static double CalculateAverageEmployees(Buisness[] buisnesses)
    {
        if (buisnesses == null || buisnesses.Length == 0)
        {
            return 0;
        }

        return buisnesses.Average(b => b.CountEmployees);
    }
}
