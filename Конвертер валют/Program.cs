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

            //ask for gain value from user, and take it from console

            Console.WriteLine("Введiть суму доходу за мiсяць в гривнi.");
            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд (UAH, USD чи EUR)");

            gain = float.Parse(Console.ReadLine());

            //maths operations with taxes 

            singleTax = gain * singleTaxRate;
            socialCont = gain * socialContRate;
            gain -= singleTax;
            gain -= socialCont;

            //output results in console

            Console.WriteLine("Дохiд до вирахування податкiв - " + (gain + singleTax + socialCont) + " UAH");
            Console.WriteLine("Всього єдиного податку (5%) - " + singleTax + " UAH");
            Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " UAH");
            Console.WriteLine("Прибуток пiсля вирахування податкiв - " + gain + " UAH");

            Console.ReadKey();


        }
    }
}
