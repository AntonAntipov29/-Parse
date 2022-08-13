using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертер_валют
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float userInput;
            string currency;
            float profit;
            float singleTaxRate = 0.05f;
            float socialContRate = 0.22f;
            float minSalary = 6500;
            float singleTax;
            float socialCont;

            //ask for gain values from user, and take it from console

            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд (UAH, USD чи EUR)");

            currency = (Console.ReadLine());

            Console.WriteLine("Введена валюта - " + currency + ". Введiть сумму");

            userInput = float.Parse(Console.ReadLine());

            Console.WriteLine("Ви ввели " + userInput + " " + currency + ". Для розрахунку податкiв нажмiть ENTER");

            Console.ReadKey();

            //maths operations with taxes 

            singleTax = userInput * singleTaxRate;
            socialCont = minSalary * socialContRate;
            profit = userInput - singleTax - socialCont;
           

            //output results in console

            Console.WriteLine("Дохiд до вирахування податкiв - " + userInput + " " + currency);
            Console.WriteLine("Всього єдиного податку (5%) - " + singleTax + " " + currency);
            Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " " + currency);
            Console.WriteLine("Прибуток пiсля вирахування податкiв - " + profit + " " + currency);

            Console.ReadKey();


        }
    }
}
