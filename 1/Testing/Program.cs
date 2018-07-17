namespace Testing
{
    using System;
    using System.Linq;
    using Tests;
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите: Имя (не пустая строка)");
                    var _name = Console.ReadLine();

                    Console.WriteLine("Вес в кг (целое число, больше 0)");
                    var _weight = Console.ReadLine();

                    Console.WriteLine("Рост в см (целое число, больше 0)");
                    var _growth = Console.ReadLine();

                    Console.WriteLine("Возраст (целое число, больше 0)");
                    var _age = Console.ReadLine();

                    Console.WriteLine("Зрение (дробное число, от 0 до 1)");
                    var _eye = Console.ReadLine();

                    Console.WriteLine("Разделённый пробелами список вредных привычек и болезней (может быть пустым)");
                    var _troubles = Console.ReadLine();

                    var candidate = new Candidate(_name, _weight, _growth, _age, _eye, _troubles);

                    Diagnostic.Run(candidate);

                    var results = TestCandidate.Run(candidate).ToList();

                    if (results.Any(r => r.Value == MarkEnum.unsatisfactorily) || results.Where(r => r.Value == MarkEnum.satisfactorily).Count() >= 3)
                    {
                        Console.WriteLine($"Кандидат {candidate.name} не прошел тестирование");
                        Console.WriteLine("Проблемы:");
                        results.Where(r => r.Value != MarkEnum.good)
                            .ToList()
                            .ForEach(r => { Console.WriteLine(r.Comment); });
                    }
                    else
                    {
                        Console.WriteLine($"Кандидат {candidate.name} подходит");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Протестировать других кандидатов? (y/n)");
                if (Console.ReadLine() != "y")
                {
                    return;
                }
                Console.WriteLine();
            }
        }
    }
}