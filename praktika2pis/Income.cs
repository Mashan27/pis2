using System;

/// <summary>
/// Класс для представления дохода
/// </summary>
public class Income
{
    public DateTime Date { get; set; }
    public string Source { get; set; }
    public int Amount { get; set; }

    /// <summary>
    /// Возвращает строковое представление объекта
    /// </summary>
    public override string ToString()
    {
        return $"Дата: {Date.ToShortDateString()} Источник: {Source} Сумма: {Amount}";
    }
}