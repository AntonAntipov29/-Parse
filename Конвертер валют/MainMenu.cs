using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертер_валют
{

    public class MainMenu
    {
        public static void Main()
        {
            AgeControl();

            void AgeControl()
            {
                uint rightYear = 2004;
                uint tooOld = 1922;
                uint yearOfBirthInt;
                Console.WriteLine("Вiтеємо Вас в калькуляторi податкiв!");
                Console.WriteLine("Будь ласка введiть рiк вашого народження:");
                yearOfBirthInt = Convert.ToUInt32(UserInput.GetUserInput(Enum.TypeOfUserInput.year));
                if (yearOfBirthInt < rightYear && yearOfBirthInt > tooOld)
                {
                    Console.WriteLine("Повнолiття пiдтверджено. Натиснiть будь-яку кнопку, щоб продовжити.");
                }
                else
                {
                    Console.WriteLine("Повнолiття не пiдтверджено. Натиснiть будь-яку кнопку, щоб закрити калькулятор.");
                    Environment.Exit(0);
                }

                Console.ReadKey();
                Console.Clear();
                Menu();

            }
            void Menu()
            {
                int choiseInput;
                Console.WriteLine("Введiть номер калькулятора, який хочете використовувати:");
                Console.WriteLine("1. Простий калькулятор");
                Console.WriteLine("2. Калькулятор вiку");
                Console.WriteLine("3. Калькулятор податкiв");
                choiseInput = Convert.ToInt32(UserInput.GetUserInput(Enum.TypeOfUserInput.number));

                if (choiseInput == 1)
                {
                    Console.Clear();
                    var simpleCalculator = new SimpleCalculator();
                    simpleCalculator.SimpleCalculatorBody();
                }
                else if (choiseInput == 2)
                {
                    Console.Clear();
                    var ageCalculator = new AgeCalculator();
                    ageCalculator.AgeCalculatorBody();
                }
                else if (choiseInput == 3)
                {
                    Console.Clear();
                    TaxCalculator taxCalculator = new TaxCalculator();
                    taxCalculator.TaxCalculatorBody();

                }
                else
                {

                    Console.WriteLine("Введiть номер з доступних варiантiв");
                    Console.Clear();
                    Menu();
                }
            }

        }
    }
}
