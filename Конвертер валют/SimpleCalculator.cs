using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертер_валют
{
    public class SimpleCalculator
    {
        public void SimpleCalculatorBody()
        {
            Console.WriteLine("Данна функцiя буде додана згодом, очiкуйте на оновлення.");
            Console.WriteLine("Щоб повернутись в попередньє меню введiть Return.");
            Console.WriteLine("Щоб закрити додаток введiть Exit.");
            string answer = Console.ReadLine();
            if (answer == TaxCalculator.ExitIndex)
            {
                Environment.Exit(0);
            }
            else if (answer == TaxCalculator.ReturnIndex)
            {
                Console.Clear();
                MainMenu.Main();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте Exit або Calculate again.");
                SimpleCalculatorBody();
            }

        }
    }
}
