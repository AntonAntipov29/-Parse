using System;
using System.Linq;

namespace Calculator_program
{
    public class UserInput
    {
        public string checkedInput;
        public string currentInput;

        public string GetUserInput(TypeOfUserInput type, bool showWarning = true)
        {
            currentInput = Console.ReadLine();
            CheckUserInputWithType(type, showWarning);

            return checkedInput;
        }

        public string GetUserInput(TypeOfUserInput firstType, TypeOfUserInput secondType, bool showWarning = true)
        {
            checkedInput = GetUserInput(firstType, false);
            bool isEmptyInput = string.IsNullOrEmpty(checkedInput);

            if (isEmptyInput)
            {
                CheckUserInputWithType(secondType);
            }

            return checkedInput;
        }

        private void CheckUserInputWithType(TypeOfUserInput type, bool showWarning = true)
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
        }

        private void TypeOfUserInputNumber(bool showWarning)
        {
            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }
            else if (showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.number);
            }
        }

        private void TypeOfUserInputMoney(bool showWarning)
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
        }

        private void TypeOfUserInputCurrency(bool showWarning)
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
                else if (showWarning)
                {
                    ShowWarning();
                    GetUserInput(TypeOfUserInput.currency);
                }
            }
        }

        private void TypeOfUserInputCommand(bool showWarning)
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

        private void ShowWarning()
        {
            Console.WriteLine("Помилка, неправильний ввiд! Спробуйте ще.");
        }
    }
}
