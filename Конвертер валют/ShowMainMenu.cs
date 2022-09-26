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
            Console.WriteLine("Щоб вийти введiть Exit");

            UserInput userInput = new UserInput();
            choiseInput = userInput.GetUserInput(TypeOfUserInput.number, TypeOfUserInput.command, showWarning:true);

            if (choiseInput == TaxCalculator.firstItem)
            {
                Console.Clear();
                SimpleCalculator simpleCalculator = new SimpleCalculator();
                simpleCalculator.LaunchSimpleCalculator();
            }
            else if (choiseInput == TaxCalculator.secondItem)
            {
                Console.Clear();
                AgeCalculator ageCalculator = new AgeCalculator();
                ageCalculator.LaunchAgeCalculator();
            }
            else if (choiseInput == TaxCalculator.thirdItem)
            {
                Console.Clear();
                TaxCalculator taxCalculator = new TaxCalculator();
                taxCalculator.Show();
            }
            else if (choiseInput == TaxCalculator.exitIndex)
            {
                Environment.Exit(0);
            } 
        }
    }
}
