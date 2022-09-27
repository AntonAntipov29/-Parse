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

        public string GetUserInput(TypeOfUserInput type, bool showWarning = true)
        {
            currentInput = Console.ReadLine();
            CheckUserInputWithType(type, showWarning);

            return checkedInput;
        }

        public string GetUserInput(TypeOfUserInput firstType, TypeOfUserInput secondType, bool showWarning = true)
        {
            
            checkedInput = GetUserInput(firstType, false);
            bool isWrongType = string.IsNullOrEmpty(checkedInput);

            if (isWrongType)
            {
                CheckUserInputWithType(secondType, false);
            }           
            
            return checkedInput;
        }

        public void CheckUserInputWithType(TypeOfUserInput type, bool showWarning = true)
        {
            if (type == TypeOfUserInput.year)
            {
                TypeOfUserInputYear(showWarning);
            }
            else if (type == TypeOfUserInput.number)
            {
                TypeOfUserInputNumber(showWarning);
            }
            else if (type == TypeOfUserInput.money)
            {
                TypeOfUserInputMoney(showWarning);
            }
            else if (type == TypeOfUserInput.currency)
            {
                TypeOfUserInputCurrency(showWarning);
            }
            else if (type == TypeOfUserInput.command)
            {
                TypeOfUserInputCommand(showWarning);
            }
        }

        private void TypeOfUserInputYear(bool showWarning)
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
            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }
            else if(showWarning)
            {
                ShowWarning();
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
            else if (int.TryParse(currentInput, out int secondNumber) && !showWarning)
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
                    ShowWarning();
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
        }
        
        public void ShowWarning()
        {
            Console.WriteLine("Помилка, неправильний ввiд! Спробуйте ще.");
        }
    }
}
