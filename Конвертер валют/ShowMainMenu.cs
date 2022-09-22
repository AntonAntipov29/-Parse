using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class ShowMainMenu
    {
        public void ShowMenu()
        {
            string choiseInput;
            int choiseInputInt;
            Console.WriteLine("Введiть номер калькулятора, який хочете використовувати:");
            Console.WriteLine("1. Простий калькулятор");
            Console.WriteLine("2. Калькулятор вiку");
            Console.WriteLine("3. Калькулятор податкiв");

            UserInput userInput = new UserInput();
            choiseInput = userInput.GetUserInput(TypeOfUserInput.number);
            choiseInputInt = Convert.ToInt32(choiseInput);

            if (choiseInputInt == 1)
            {
                Console.Clear();
                var simpleCalculator = new SimpleCalculator();
                simpleCalculator.LaunchSimpleCalculator();
            }
            else if (choiseInputInt == 2)
            {
                Console.Clear();
                var ageCalculator = new AgeCalculator();
                ageCalculator.LaunchAgeCalculator();
            }
            else if (choiseInputInt == 3)
            {
                Console.Clear();
                TaxCalculator taxCalculator = new TaxCalculator();
                taxCalculator.Show();
            }
            else
            {
                Console.Clear();
                ShowMenu();
            }
        }
    }
}
