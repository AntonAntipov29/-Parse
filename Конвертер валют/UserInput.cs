using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертер_валют
{
    internal class UserInput
    {
        public static string GetUserInput(Enum.TypeOfUserInput type)
        {
            string returnInput = "";

            if (type == Enum.TypeOfUserInput.year)
            {
                string yearOfBirth;
                yearOfBirth = Console.ReadLine();
                if (int.TryParse(yearOfBirth, out int number))
                {
                    returnInput = yearOfBirth;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ввiд неправильний! Будь ласка введiть рiк числом!");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu.Main();

                }
            }
            else if (type == Enum.TypeOfUserInput.number)
            {
                string menuVariant;
                menuVariant = Console.ReadLine();
                if (int.TryParse(menuVariant, out int number))
                {
                    returnInput = menuVariant;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ввiд неправильний! Будь ласка введiть число!");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu.Main();

                }
            }
            else if (type == Enum.TypeOfUserInput.money)
            {

                string moneyInput;
                float number;
                moneyInput = Console.ReadLine();
                bool isLetter = moneyInput.All(Char.IsLetter);
                if (Single.TryParse(moneyInput, out number))
                {
                    returnInput = moneyInput;
                }
                else if (isLetter == false && moneyInput.Contains("."))
                {
                    returnInput = moneyInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Помилка! Будь ласка вводьте числами!");
                    Console.ReadKey();
                    var reload = new TaxCalculator();
                }
            }
            else if (type == Enum.TypeOfUserInput.currency)
            {
                string currencyInput;
                currencyInput = Console.ReadLine();
                if (int.TryParse(currencyInput, out int number))
                {
                    Console.Clear();
                    Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR. Натиснiть будь-яку кнопку, щоб продовжити.");
                    Console.Clear();
                    var reload = new TaxCalculator();
                }
                else
                {
                    if (currencyInput == TaxCalculator.hryvniaIndex)
                    {
                        returnInput = currencyInput;
                    }
                    else if (currencyInput == TaxCalculator.dollarIndex)
                    {
                        returnInput = currencyInput;
                    }
                    else if (currencyInput == TaxCalculator.euroIndex)
                    {
                        returnInput = currencyInput;
                    }
                    else
                    {
                        Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR. Натиснiть будь-яку кнопку, щоб продовжити.");
                        Console.ReadKey();
                        Console.Clear();
                        var reload = new TaxCalculator();
                    }

                }

            }
            else if (type == Enum.TypeOfUserInput.command)
            {
                string commandInput;
                commandInput = Console.ReadLine();

                if (commandInput == TaxCalculator.CalcAgainIndex)
                {

                    returnInput = commandInput;
                }
                else if (commandInput == TaxCalculator.ExitIndex)
                {
                    returnInput = commandInput;
                }
                else if (commandInput == TaxCalculator.ReturnIndex)
                {
                    returnInput = commandInput;
                }

            }
            return returnInput;
        }
    }
}
