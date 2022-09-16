using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class UserInput
    {
            string returnInput;
            string currentInput;

       //For future
       /*    public string GetUserInput(TypeOfUserInput firstType,TypeOfUserInput secondType)
       // {
       } */

        public string GetUserInput(TypeOfUserInput type)
        {
           
            currentInput = Console.ReadLine();

            if (type == TypeOfUserInput.year)
            {
                if (int.TryParse(currentInput, out int number))
                {
                    returnInput = currentInput;
                }
                else
                {
                    Console.Clear();
                Console.WriteLine("Ввiд неправильний! Будь ласка введiть рiк числом!");
                
                GetUserInput(TypeOfUserInput.year);

                }
            }
            else if (type == TypeOfUserInput.number)
            {
               
                if (int.TryParse(currentInput, out int number))
                {
                    returnInput = currentInput;
                }
                else
                {
                    Console.Clear();
                }
            }
            else if (type == TypeOfUserInput.money)
            {

                double number;
                
                bool isLetter = currentInput.All(Char.IsLetter);
                if (double.TryParse(currentInput, out number))
                {
                    returnInput = currentInput;
                }
                else if (isLetter == false && currentInput.Contains("."))
                {
                    returnInput = currentInput;
                }
                else
                {
                    Console.WriteLine("Помилка! Будь ласка вводьте числами!");
                    Console.ReadKey();
                    GetUserInput(TypeOfUserInput.money);
                }
            }
            else if (type == TypeOfUserInput.currency)
            {
                if (int.TryParse(currentInput, out int number))
                {
                    Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR. Натиснiть будь-яку кнопку, щоб продовжити.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
                    GetUserInput(TypeOfUserInput.currency);
                }
                else
                {
                    if (currentInput == TaxCalculator.hryvniaIndex)
                    {
                        returnInput = currentInput;
                    }
                    else if (currentInput == TaxCalculator.dollarIndex)
                    {
                        returnInput = currentInput;
                    }
                    else if (currentInput == TaxCalculator.euroIndex)
                    {
                        returnInput = currentInput;
                    }
                    else
                    {
                        Console.WriteLine("Неправильний ввiд! Використовуйте UAH, USD або EUR. Натиснiть будь-яку кнопку, щоб продовжити.");                       
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
                        GetUserInput(TypeOfUserInput.currency);
                        
                    }

                }

            }
            else if (type == TypeOfUserInput.command)
            {
              

                if (currentInput == TaxCalculator.CalcAgainIndex)
                {

                    returnInput = currentInput;
                }
                else if (currentInput == TaxCalculator.ExitIndex)
                {
                    returnInput = currentInput;
                }
                else if (currentInput == TaxCalculator.ReturnIndex)
                {
                    returnInput = currentInput;
                }
                else
                {
                    Console.WriteLine("Помилка! Будь ласка вводьте команду!");
                    GetUserInput(TypeOfUserInput.command);
                }

            }
            return returnInput;
        }
    }
}
