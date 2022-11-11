using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_program
{
    internal class TaxCalculatorView : BaseCalculatorView
    {
        public void AskFirstInput()
        {
            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
        }      

        public void AskSecondInput(string[] months, int count)
        {
            Console.WriteLine("Введiть дохiд за " + months[count]);
        }

        public void CheckFirstInput(string currency)
        {
            Console.WriteLine($"Введена валюта - {currency}.");
        }

        public void CheckSecondInput(string currency, string formatMoney, double result)
        {
            Console.Write("Ви ввели " + formatMoney, result);
            Console.Write(" " + currency + ". ");
        }

        public void ShowResult(double yearProfit, double singleTax, double socialCont, double profit, string formatMoney)
        {
            Console.Write("Дохiд до вирахування податкiв - " + formatMoney, yearProfit);
            Console.WriteLine(" гривень");
            Console.Write("Всього єдиного податку (5%) - " + formatMoney, singleTax);
            Console.WriteLine(" гривень");
            Console.Write("Всього єдиного соцiального внеску (22%) - " + formatMoney, socialCont);
            Console.WriteLine(" гривень");
            Console.Write("Прибуток пiсля вирахування податкiв - " + formatMoney, profit);
            Console.WriteLine(" гривень");
        }    
    }
}
