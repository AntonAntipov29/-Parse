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

        //public void GetUserInput(bool showWarning = true)
        //{
 
        //} 

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
        private void ShowWarning()
        {
            Console.WriteLine("Помилка, неправильний ввiд! Спробуйте ще.");
        }
        private void TypeOfUserInputYear()
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
        private void TypeOfUserInputNumber()
        {
            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }
            else
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.number);
            }
        }
        private void TypeOfUserInputMoney()
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
        private void TypeOfUserInputCurrency()
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
        private void TypeOfUserInputCommand()
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
    }
}
