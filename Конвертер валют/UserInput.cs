using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class UserInput
    {
           public string checkedInput;
           private string currentInput;

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
                    checkedInput = currentInput;
                }
                else
                {
                    ShowWarning();
                    GetUserInput(TypeOfUserInput.year);

                }
            }
            else if (type == TypeOfUserInput.number)
            {
               
                if (int.TryParse(currentInput, out int number))
                {
                    checkedInput = currentInput;
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
                    checkedInput = currentInput;
                }
                else if (isLetter == false && currentInput.Contains("."))
                {
                    checkedInput = currentInput;
                }
                else
                {
                    ShowWarning();
                    GetUserInput(TypeOfUserInput.money);
                }
            }
            else if (type == TypeOfUserInput.currency)
            {
                if (int.TryParse(currentInput, out int number))
                {
                    ShowWarning();
                    GetUserInput(TypeOfUserInput.currency);
                }
                else
                {
                    if (currentInput == TaxCalculator.hryvniaIndex || currentInput == TaxCalculator.dollarIndex || currentInput == TaxCalculator.euroIndex)
                    {
                        checkedInput = currentInput;
                    }
                    else
                    {
                        ShowWarning();
                        GetUserInput(TypeOfUserInput.currency);
                        
                    }

                }

            }
            else if (type == TypeOfUserInput.command)
            {
              

                if (currentInput == TaxCalculator.calcAgainIndex || currentInput == TaxCalculator.exitIndex || currentInput == TaxCalculator.returnIndex)
                {

                    checkedInput = currentInput;
                }
                else
                {
                    ShowWarning();
                    GetUserInput(TypeOfUserInput.command);
                }

            }
            return checkedInput;
        }

        private void ShowWarning()
        {
            Console.WriteLine("Помилка, неправильний ввiд! Спробуйте ще.");
        }
    }
}
