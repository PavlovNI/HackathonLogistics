using System;
using System.Collections.Generic;

namespace Hackathon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Обработка тренеровочных данных.
            List<Data> inputs = Data.Load("train.csv");
            inputs = Data.Balancing(inputs);
            Data.Save(inputs, $"train2.csv");

            //...
            //Тренировка модели с помощью ML.NET Model Builder 
            //...

            // Загрузка тренировочного набора данных.
            List<Input> dataTests = Input.Load("test.csv");

            Console.WriteLine("Загружены данные для тестирования.");

            //Прогнозирование для тестовых данных.
            List<Output> outputs = new List<Output>();

            for (int i = 0; i < dataTests.Count; i++)
            {
                outputs.Add(MLModel1.Predict(dataTests[i]));

                if (i == 1000000) { Console.WriteLine("25%"); }
                if (i == 2000000) { Console.WriteLine("50%"); }
                if (i == 3000000) { Console.WriteLine("75%"); }
                if (i == 3999999) { Console.WriteLine("100%"); }
            }

            //Сохранение прогнозов.
            Output.Save(outputs, "result.csv");

            Console.WriteLine("Проверка завершина.");
            Console.ReadKey();
        }
    }
}
