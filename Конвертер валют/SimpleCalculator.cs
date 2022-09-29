using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator_program
{ 
    public class SimpleCalculator
    {
        string firstNumber;
        double firstNumberDouble;
        string secondNumber;    
        double secondNumberDouble;
        string operation;
        double result;
        public const string additionIndex = "+";
        public const string substractionIndex = "-";
        public const string multiplicationIndex = "*";
        public const string divisionIndex = "/"; 
        public const string interestIndex = "%";
        private const double fullPercentage = 100;
        private const string formatMoney = "{0:N}";
        private string finalAnswer;

        UserInput userInput = new UserInput();

        public void Show()
        {
            GettingInput();
            Calculation();
            ShowResult();
        }

        private void GettingInput()
        {
            NumberFormatInfo formatComa = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ",",
            };
            NumberFormatInfo formatDot = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            Console.WriteLine("Ви обрали простий калькулятор.");
            Console.WriteLine("Введiть перше число");
            firstNumber = userInput.GetUserInput(TypeOfUserInput.number);

            if (firstNumber.Contains(","))
            {
                firstNumberDouble = Double.Parse(firstNumber, formatComa);              
            }
            else if (firstNumber.Contains("."))
            {
                firstNumberDouble = Double.Parse(firstNumber, formatDot);
            }
            else
            {
                firstNumberDouble = Double.Parse(firstNumber);
            }

            Console.Clear();
            Console.WriteLine($"Ведiть потрiбну операцiю: |{additionIndex}| - додавання, |{substractionIndex}| - вiднiмання, |{multiplicationIndex}| - множення, |{divisionIndex}| -  дiлення,");
            Console.WriteLine($"|{interestIndex}| - вiдсоткове спiввiдношення першого числа до другого ");
            operation = userInput.GetUserInput(TypeOfUserInput.operation);
            Console.Clear();
            Console.WriteLine("Введiть друге число");
            secondNumber = userInput.GetUserInput(TypeOfUserInput.number);

            if (secondNumber.Contains(","))
            {
                secondNumberDouble = Double.Parse(secondNumber, formatComa);
            }
            else if (secondNumber.Contains("."))
            {
                secondNumberDouble = Double.Parse(secondNumber, formatDot);
            }
            else
            {             
                secondNumberDouble = Double.Parse(secondNumber);
            } 

            Console.Clear();
            Console.WriteLine($"Ви ввели вираз: {firstNumber} {operation} {secondNumber}");
            Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
            Console.ReadKey();
            Console.Clear();
        }

        private void Calculation()
        {
            if (operation == additionIndex)
	        {
                result = firstNumberDouble + secondNumberDouble;
	        }
            else if (operation == substractionIndex)
            {
                result = firstNumberDouble - secondNumberDouble;
            }
            else if (operation == multiplicationIndex)
            {
                result = firstNumberDouble * secondNumberDouble;
            }
            else if (operation == divisionIndex)
            {
                result = firstNumberDouble / secondNumberDouble;
            }
            else if (operation == interestIndex)
            {
                result = (firstNumberDouble * fullPercentage) / secondNumberDouble;
            }           
        }       
        
        private void ShowResult()
        {
            if (operation == interestIndex)
	        {
                Console.Write("Вiдсоткове спiввiдношення " + firstNumberDouble + " до " + secondNumberDouble + " складає " + formatMoney, result);
                Console.WriteLine(" %");           
	        }         
            else 
            {
                Console.Write("Результат вашого виразу: " + firstNumberDouble + " " + operation + " " + secondNumberDouble + " = " + formatMoney, result);     
            }    
                      
            Console.WriteLine(" ");
            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб повернутись в головне меню напишiть Return.");
            Console.WriteLine("Щоб рахувати знову напишiть Calculate again.");
            finalAnswer = userInput.GetUserInput(TypeOfUserInput.command);

            if (finalAnswer == TaxCalculator.exitIndex)
            {
                Environment.Exit(0);
            }
            else if (finalAnswer == TaxCalculator.calcAgainIndex)
            {
                Console.Clear();
                Show();
            }
            else if (finalAnswer == TaxCalculator.returnIndex)
            {
                Console.Clear();
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте Exit, Return або Calculate again.");
                ShowResult();
                userInput.GetUserInput(TypeOfUserInput.command);
            }
        }   
    }
}

