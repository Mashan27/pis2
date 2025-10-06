using praktika2pis;
using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Главный класс программы
/// Отвечает только за координацию работы других классов
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    static void Main(string[] args)
    {
        try
        {
            RunDemo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }

        WaitForExit();
    }

    /// <summary>
    /// Запускает демонстрацию всех функций
    /// </summary>
    private static void RunDemo()
    {
        DemonstrateBasicParsing();
        DemonstrateNewIncomeTypes();
        DemonstrateFileOperations();
        DemonstrateBusinessAnalysis();
    }

    /// <summary>
    /// Демонстрирует базовый парсинг строк
    /// </summary>
    private static void DemonstrateBasicParsing()
    {
        Console.WriteLine("=== БАЗОВЫЙ ПАРСИНГ ===");

        string incomeString = "2025.06.12 \"Министерство Образования\" 2000";
        Income income = IncomeParser.Parse(incomeString);
        Console.WriteLine($"1. Обычный доход: {income}");

        string businessString = "\"Министерство Образования\" 150";
        Buisness business = BusinessParser.Parse(businessString);
        Console.WriteLine($"2. Бизнес: {business}");
    }

    /// <summary>
    /// Демонстрирует новые типы доходов
    /// </summary>
    private static void DemonstrateNewIncomeTypes()
    {
        Console.WriteLine("\n=== НОВЫЕ ТИПЫ ДОХОДОВ ===");

        OrganizationIncome orgIncome = CreateOrganizationIncome();
        Console.WriteLine($"3. Доход организации: {orgIncome}");

        TypedIncome typedIncome = CreateTypedIncome();
        Console.WriteLine($"4. Типизированный доход: {typedIncome}");
    }

    /// <summary>
    /// Демонстрирует работу с файлами
    /// </summary>
    private static void DemonstrateFileOperations()
    {
        Console.WriteLine("\n=== РАБОТА С ФАЙЛАМИ ===");

        string testFile = "test_incomes.txt";
        CreateTestFile(testFile);

        Console.WriteLine("5. Чтение из файла:");
        List<Income> incomesFromFile = FileProcessor.ReadIncomesFromFile(testFile);
        DisplayIncomes(incomesFromFile);

        string outputFile = "output_incomes.txt";
        FileProcessor.WriteIncomesToFile(incomesFromFile, outputFile);

        Console.WriteLine("6. Обработка набора строк:");
        ProcessIncomeStrings();
    }

    /// <summary>
    /// Демонстрирует анализ бизнесов
    /// </summary>
    private static void DemonstrateBusinessAnalysis()
    {
        Console.WriteLine("\n=== АНАЛИЗ БИЗНЕСОВ ===");

        Buisness[] businesses = CreateTestBusinesses();
        DisplayBusinessAnalysis(businesses);
    }

    /// <summary>
    /// Создает тестовый доход организации
    /// </summary>
    private static OrganizationIncome CreateOrganizationIncome()
    {
        return new OrganizationIncome
        {
            Date = new DateTime(2025, 6, 15),
            Source = "Продажа продукции",
            Amount = 500000,
            OrganizationName = "ООО 'Ромашка'",
            TaxId = "7734567890",
            BankAccount = "40702810500000012345"
        };
    }

    /// <summary>
    /// Создает тестовый типизированный доход
    /// </summary>
    private static TypedIncome CreateTypedIncome()
    {
        return new TypedIncome
        {
            Date = new DateTime(2025, 6, 20),
            Source = "Консультационные услуги",
            Amount = 75000,
            OperationType = "Услуги",
            Category = "Консалтинг",
            IsCompleted = true
        };
    }

    /// <summary>
    /// Обрабатывает массив строк с доходами
    /// </summary>
    private static void ProcessIncomeStrings()
    {
        string[] incomeStrings = {
            "2025.03.01 \"Аванс\" 30000",
            "2025.03.15 \"Зарплата\" 40000",
            "2025.03.20 \"Подработка\" 15000"
        };

        foreach (string incomeStr in incomeStrings)
        {
            Income income = IncomeParser.Parse(incomeStr);
            Console.WriteLine($"   - {income}");
        }
    }

    /// <summary>
    /// Отображает список доходов
    /// </summary>
    private static void DisplayIncomes(List<Income> incomes)
    {
        foreach (var income in incomes)
        {
            Console.WriteLine($"   - {income}");
        }
    }

    /// <summary>
    /// Создает тестовые бизнесы для демонстрации
    /// </summary>
    private static Buisness[] CreateTestBusinesses()
    {
        return new Buisness[]
        {
            BusinessParser.Parse("\"IT Компания\" 50"),
            BusinessParser.Parse("\"Торговая сеть\" 200"),
            BusinessParser.Parse("\"Производство\" 75")
        };
    }

    /// <summary>
    /// Отображает анализ бизнесов
    /// </summary>
    private static void DisplayBusinessAnalysis(Buisness[] businesses)
    {
        Buisness maxBusiness = BusinessAnalyzer.FindWithMaxEmployees(businesses);
        Buisness minBusiness = BusinessAnalyzer.FindWithMinEmployees(businesses);
        double averageEmployees = BusinessAnalyzer.CalculateAverageEmployees(businesses);

        Console.WriteLine($"7. Бизнес с макс. сотрудниками: {maxBusiness}");
        Console.WriteLine($"8. Бизнес с мин. сотрудниками: {minBusiness}");
        Console.WriteLine($"9. Среднее кол-во сотрудников: {averageEmployees:F2}");
    }

    /// <summary>
    /// Создает тестовый файл с доходами
    /// </summary>
    private static void CreateTestFile(string filePath)
    {
        string[] testData = {
            "2025.01.15 \"Зарплата\" 50000",
            "2025.01.20 \"Фриланс\" 25000",
            "2025.02.01 \"Инвестиции\" 15000",
            "2025.02.15 \"Премия\" 20000"
        };

        File.WriteAllLines(filePath, testData);
        Console.WriteLine($"Создан тестовый файл: {filePath}");
    }

    /// <summary>
    /// Ожидает нажатия клавиши для выхода
    /// </summary>
    private static void WaitForExit()
    {
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}