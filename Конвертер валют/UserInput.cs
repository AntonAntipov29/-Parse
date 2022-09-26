using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class UserInput
    {
        public string checkedInput;
        private string currentInput;

        public string GetUserInput(bool showWarning = true)
        {
            currentInput = Console.ReadLine();

            if (currentInput.Length == 0 || currentInput.Contains(" ") && showWarning)
	        {
                ShowWarning();  
                GetUserInput(showWarning);
	        }

            else if (currentInput.Length == 0 || currentInput.Contains(" "))
	        {
                Console.WriteLine("Ви нiчого не ввели!");
                GetUserInput(showWarning);
	        }

            else
            {
                currentInput = checkedInput;
            }
 
            return checkedInput;
        } 

        public string GetUserInput(TypeOfUserInput type)
        {
            currentInput = Console.ReadLine();

            if (type == TypeOfUserInput.year)
            {
                TypeOfUserInputYear();
            }

            else if (type == TypeOfUserInput.number)
            {
                TypeOfUserInputNumber();
            }

            else if (type == TypeOfUserInput.money)
            {
                TypeOfUserInputMoney();
            }

            else if (type == TypeOfUserInput.currency)
            {
                TypeOfUserInputCurrency();
            }

            else if (type == TypeOfUserInput.command)
            {
                TypeOfUserInputCommand();
            }

            return checkedInput;
        }

        public string GetUserInput(TypeOfUserInput firstType, TypeOfUserInput secondType, bool showWarning = true)
        {
            currentInput = Console.ReadLine();

            if (firstType == TypeOfUserInput.year && secondType == TypeOfUserInput.command && showWarning)
            {
                if (int.TryParse(currentInput, out int number))
                {
                    TypeOfUserInputYear();
                }
                if (currentInput == TaxCalculator.calcAgainIndex || currentInput == TaxCalculator.exitIndex || currentInput == TaxCalculator.returnIndex)
                {
                    TypeOfUserInputCommand();
                }
            }
            
            else if (firstType == TypeOfUserInput.number)
            {
                TypeOfUserInputNumber();
            }

            else if (firstType == TypeOfUserInput.money)
            {
                TypeOfUserInputMoney();
            }

            else if (firstType == TypeOfUserInput.currency)
            {
                TypeOfUserInputCurrency();
            }

            else if (firstType == TypeOfUserInput.command)
            {
                TypeOfUserInputCommand();
            }

            return checkedInput;
        }

        private void ShowWarning()
        {
            Console.WriteLine("Помилка, неправильний ввiд! Спробуйте ще.");
        }

        private void TypeOfUserInputYear(bool showWarning = true)
        {
            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }

            else if (showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.year);
            }

            else 
	        {
                GetUserInput(TypeOfUserInput.year);
	        }
        }

        private void TypeOfUserInputNumber(bool showWarning = true)
        {
            

            if (currentInput == TaxCalculator.firstItem || currentInput == TaxCalculator.secondItem || currentInput == TaxCalculator.thirdItem)
            {
                checkedInput = currentInput;
            }

            else if(showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.number);
            }

            else
            {
                GetUserInput(TypeOfUserInput.number);
            }
        }

        private void TypeOfUserInputMoney(bool showWarning = true)
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

            else if (showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.money);
            }

            else
            {
                GetUserInput(TypeOfUserInput.money);
            }
        }

        private void TypeOfUserInputCurrency(bool showWarning = true)
        {
            if (int.TryParse(currentInput, out int number) && showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.currency);
            }

            else if (int.TryParse(currentInput, out int secondNumber) && showWarning)
            {
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
                    GetUserInput(TypeOfUserInput.currency);
                }

            }
        }

        private void TypeOfUserInputCommand(bool showWarning = true)
        {
            if (currentInput == TaxCalculator.calcAgainIndex || currentInput == TaxCalculator.exitIndex || currentInput == TaxCalculator.returnIndex)
            {
                checkedInput = currentInput;
            }

            else if (showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.command);
            }

            else
            {
                GetUserInput(TypeOfUserInput.command);
            }
        }
    }
}
