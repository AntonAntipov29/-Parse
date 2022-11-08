using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    public class SimpleCalculatorView : BaseCalculatorView
    {
        public void AskFirstInput()
        {
            Console.WriteLine("Введiть перше число");
        }

        public void AskActionInput(string additionIndex, string substractionIndex, string multiplicationIndex, string divisionIndex, string interestIndex)
        {
            Console.WriteLine($"Ведiть потрiбну операцiю: |{additionIndex}| - додавання, |{substractionIndex}| - вiднiмання, |{multiplicationIndex}| - множення, |{divisionIndex}| -  дiлення,");
            Console.WriteLine($"|{interestIndex}| - вiдсоткове спiввiдношення першого числа до другого ");
        }

        public void AskSecondInput()
        {
            Console.WriteLine("Введiть друге число");
        }

        public void CheckInput(string firstNumber, string secondNumber, string operation)
        {
            Console.WriteLine($"Ви ввели вираз: {firstNumber} {operation} {secondNumber}");
        }

        public void ShowResultInterest(double firstNumberDouble, double secondNumberDouble, double result, string formatMoney)
        {
            Console.Write("Вiдсоткове спiввiдношення " + firstNumberDouble + " до " + secondNumberDouble + " складає " + formatMoney, result);
            Console.WriteLine(" %");
        }

        public void ShowResultOther(double firstNumberDouble, double secondNumberDouble, string operation, double result, string formatMoney)
        {
            Console.WriteLine("Результат вашого виразу: " + firstNumberDouble + " " + operation + " " + secondNumberDouble + " = " + formatMoney, result);
        }
    }
}
