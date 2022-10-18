using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator_program
{ 
    public class SimpleCalculator : BaseCalculator
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

        public SimpleCalculator(string name, int id) : base(name, id)
        {
            base.name = name;
            base.id = id;   
        }

        public string nameOfCalculator
        {
            set { name = value; }
        }

        public new void Show()
        {
            GettingInput();
            Calculation();
            AskFinalAnswer();
        }

        public override void GettingInput()
        {
            NumberFormatInfo formatComa = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ",",
            };
            NumberFormatInfo formatDot = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            Console.WriteLine($"Ви обрали {name}.");
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

        public override void Calculation()
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
        }       
    }
}

