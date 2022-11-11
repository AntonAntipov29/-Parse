using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class MainMenu
    {
        public void ShowMenu()
        {
            string choiseInput;
            Console.WriteLine("Введiть номер калькулятора, який хочете використовувати:");
            Console.WriteLine("1. Простий калькулятор");
            Console.WriteLine("2. Калькулятор вiку");
            Console.WriteLine("3. Калькулятор податкiв");

            InputController userInput = new InputController();
            choiseInput = userInput.GetUserInput(TypeOfUserInput.menuItem, TypeOfUserInput.command);

            if (choiseInput == "1")
            {
                Console.Clear();
                SimpleCalculator simpleCalculator = new SimpleCalculator("Простий калькулятор", 1);
                simpleCalculator.Start();
            }
            else if (choiseInput == "2")
            {
                Console.Clear();
                AgeCalculator ageCalculator = new AgeCalculator("Калькулятор вiку", 2);
                ageCalculator.Start();
            }
            else if (choiseInput == "3")
            {
                Console.Clear();
                TaxCalculator taxCalculator = new TaxCalculator("Калькулятор податкiв", 3);
                taxCalculator.Start();
            }
            else if (choiseInput == Commands.exitIndex)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                userInput.ShowWarning();
                ShowMenu();
            }
        }
    }
}
