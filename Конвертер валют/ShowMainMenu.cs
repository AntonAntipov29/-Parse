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

            UserInput userInput = new UserInput();
            choiseInput = userInput.GetUserInput(TypeOfUserInput.menuItem, TypeOfUserInput.command);
            
            if (choiseInput == "1")
            {
                Console.Clear();
                SimpleCalculator simpleCalculator = new SimpleCalculator();
                simpleCalculator.Show();
            }
            else if (choiseInput == "2")
            {
                Console.Clear();
                AgeCalculator ageCalculator = new AgeCalculator();
                ageCalculator.Show();
            }
            else if (choiseInput == "3")
            {
                Console.Clear();
                TaxCalculator taxCalculator = new TaxCalculator();
                taxCalculator.Show();
            }
            else if (choiseInput == BaseCalculator.exitIndex)
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
