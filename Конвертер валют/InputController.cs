using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator_program
{
    public class InputController : ICommand
    {
        public string checkedInput;
        private string currentInput;

        public delegate void TimerIsOver();
        public event TimerIsOver Message;

        NumberFormatInfo formatDot = new NumberFormatInfo()
        {
                NumberDecimalSeparator = ".",
        };

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

        public string GetUserInput(TypeOfUserInput firstType, TypeOfUserInput secondType, bool showWarning = false)
        {           
            checkedInput = GetUserInput(firstType, false);
            bool isWrongType = string.IsNullOrEmpty(checkedInput);

            if (isWrongType)
            {
                CheckUserInputWithType(secondType, false);
                if (isWrongType)
                {
                    CheckUserInputWithType(firstType, true);
                }
            }           
            
            return checkedInput;
        }

        public void CheckUserInputWithType(TypeOfUserInput type, bool showWarning = true)
        {
            if (type == TypeOfUserInput.year)
            {
                TypeOfUserInputYear(showWarning);
            }
            else if (type == TypeOfUserInput.menuItem)
            {
                TypeOfUserInputMenuItem(showWarning);
            }
            else if (type == TypeOfUserInput.number)
            {
                TypeOfUserInputNumber(showWarning);
            }
            else if (type == TypeOfUserInput.currency)
            {
                TypeOfUserInputCurrency(showWarning);
            }
            else if (type == TypeOfUserInput.command)
            {
                TypeOfUserInputCommand(showWarning);
            }
            else if (type == TypeOfUserInput.operation)
            {
                TypeOfUserInputOperation(showWarning);
            }
            else if (type == TypeOfUserInput.date)
            {
                TypeOfUserInputDate(showWarning);
            }
        }

        private void TypeOfUserInputYear(bool showWarning = true)
        {
            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }
            else if (currentInput.Length == 0 || showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.year);
            }          
        }

        private void TypeOfUserInputMenuItem(bool showWarning = true)
        {
            if (int.TryParse(currentInput, out int number))
            {
                checkedInput = currentInput;
            }
            else if (currentInput.Length == 0 || showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.menuItem);
            }
        }

        private void TypeOfUserInputNumber(bool showWarning = true)
        {
            double number;
            bool isNumber = double.TryParse(currentInput, out number);
            bool isLetter = currentInput.Any(Char.IsLetter);

            if (isNumber)
            {
                checkedInput = currentInput;
            }
            else if (!isNumber && !isLetter && currentInput.Contains("."))
            {
                Convert.ToDouble(currentInput, formatDot);
                checkedInput = Convert.ToString(currentInput);
            }
            else if (currentInput.Length == 0 || showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.number);
            }
        }

        private void TypeOfUserInputCurrency(bool showWarning = true)
        {
            if (currentInput == TaxCalculator.hryvniaIndex || currentInput == TaxCalculator.dollarIndex || currentInput == TaxCalculator.euroIndex)
            {
                checkedInput = currentInput;
            }
            else if (int.TryParse(currentInput, out int number) && showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.currency);
            }
        }

        private void TypeOfUserInputCommand(bool showWarning = true)
        {
            if (currentInput == Commands.returnIndex || currentInput == Commands.mainMenuIndex)
            {
                OnMainMenuEntered();
            }
            else if (currentInput == Commands.exitIndex)
            {
                OnExitEntered();
            }
            else if (currentInput == Commands.calcAgainIndex)
            {
                checkedInput = currentInput;
            }
            else if (currentInput.Length == 0 || showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.command);
            }
        }

        private void TypeOfUserInputOperation(bool showWarning = true)
        {
            if (currentInput == SimpleCalculator.additionIndex || currentInput == SimpleCalculator.substractionIndex || currentInput == SimpleCalculator.multiplicationIndex || currentInput == SimpleCalculator.divisionIndex || currentInput == SimpleCalculator.interestIndex)
            {
                checkedInput = currentInput;
            }
            else if (currentInput.Length == 0 || showWarning)
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.operation);
            }          
        }

        private void TypeOfUserInputDate(bool showWarning = true)
        {
            bool isDate = DateTime.TryParse(currentInput, out DateTime result);

            if (isDate)
            {
                checkedInput = currentInput;
            }          
            else if (currentInput.Length == 0 || showWarning) 
            {
                ShowWarning();
                GetUserInput(TypeOfUserInput.date);
            }
        }

        public void ShowWarning()
        {
            Console.WriteLine("Помилка, неправильний ввiд! Спробуйте ще.");
        }

        public void OnExitEntered()
        {
            Environment.Exit(0);
        }

        public void OnMainMenuEntered()
        {
            Console.Clear();
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowMenu();
        }
    }
}
