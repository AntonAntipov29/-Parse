using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Linq;

namespace Calculator_program
{
    public class SimpleCalculator : BaseCalculator 
    {
        public string firstNumber;
        public double firstNumberDouble;
        public string secondNumber;
        public double secondNumberDouble;
        public string operation;
        public double result;
        public const string additionIndex = "+";
        public const string substractionIndex = "-";
        public const string multiplicationIndex = "*";
        public const string divisionIndex = "/";
        public const string interestIndex = "%";
        private const double fullPercentage = 100;
        public const string formatMoney = "{0:N}";

        SimpleCalculatorView simpleCalculatorView = new SimpleCalculatorView(); 

        public SimpleCalculator(string name, int id) : base(name, id)
        {
            base.name = name;
            base.id = id;
        }

        public string nameOfCalculator { set { name = value; } }

        public new void Start()
        {
            ShowGreeting();
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

            simpleCalculatorView.AskFirstInput();
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

            simpleCalculatorView.Clear();
            simpleCalculatorView.AskActionInput(additionIndex, substractionIndex, multiplicationIndex, divisionIndex, interestIndex);
            operation = userInput.GetUserInput(TypeOfUserInput.operation);
            simpleCalculatorView.Clear();
            simpleCalculatorView.AskSecondInput();
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

            simpleCalculatorView.Clear();
            simpleCalculatorView.CheckInput(firstNumber, secondNumber, operation);
            simpleCalculatorView.AskOfContinue();
            Console.ReadKey();
            simpleCalculatorView.Clear();
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
                simpleCalculatorView.ShowResultInterest(firstNumberDouble, secondNumberDouble, result, formatMoney);
            }
            else
            {
                simpleCalculatorView.ShowResultOther(firstNumberDouble, secondNumberDouble, operation, result, formatMoney);
            }
        }
    }    
}

