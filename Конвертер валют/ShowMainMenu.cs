using System;

namespace Calculator_program
{
    public class ShowMainMenu
    {
        public void ShowMenu()
        {
            string choiseInput;
            Console.WriteLine("Введiть номер калькулятора, який хочете використовувати:");
            Console.WriteLine("1. Простий калькулятор");
            Console.WriteLine("2. Калькулятор вiку");
            Console.WriteLine("3. Калькулятор податкiв");

            UserInput userInput = new UserInput();
            choiseInput = userInput.GetUserInput(TypeOfUserInput.number, TypeOfUserInput.command);

            if (choiseInput == "1")
            {
                Console.Clear();
                var simpleCalculator = new SimpleCalculator();
                simpleCalculator.LaunchSimpleCalculator();
            }
            else if (choiseInput == "2")
            {
                Console.Clear();
                var ageCalculator = new AgeCalculator();
                ageCalculator.LaunchAgeCalculator();
            }
            else if (choiseInput == "3")
            {
                Console.Clear();
                TaxCalculator taxCalculator = new TaxCalculator();
                taxCalculator.Show();
            }
            else if (choiseInput == "Exit")
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }
}
