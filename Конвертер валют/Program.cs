﻿using System;
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
            string finalAnswer;
            uint yearOfBirth;
            bool isEighteen;
            uint rightYear = 2004;
            uint tooOld = 1922;
            float profit;
            float profitUsd;
            float profitEur;
            float singleTaxRate = 0.05f;
            float singleTaxRate = 0.05f; 
            float socialContRate = 0.22f;
            float minSalary = 6500;
            const float MIN_SALARY = 6500;
            float singleTax;
            float socialCont;
            float dollarRate = 0.027f;
            float euroRate = 0.026f;

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
            profitUsd = userInput - singleTax - socialCont * dollarRate;
            profitEur = userInput - singleTax - socialCont * euroRate;


            //output results in console

            
            
            if(currency == "UAH") 
            {
                Console.WriteLine("Дохiд до вирахування податкiв - " + userInput + " UAH" );
                Console.WriteLine("Всього єдиного податку (5%) - " + singleTax + " UAH");
                Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " UAH");
                Console.WriteLine("Прибуток пiсля вирахування податкiв - " + profit + " UAH");
            }
            else if(currency == "USD")
            {
                Console.WriteLine("Дохiд до вирахування податкiв - " + userInput/dollarRate + " UAH");
                Console.WriteLine("Всього єдиного податку (5%) - " + singleTax/dollarRate + " UAH");
                Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " UAH");
                Console.WriteLine("Прибуток пiсля вирахування податкiв - " + profitUsd/dollarRate + " UAH");
            }
            else if (currency == "EUR")
            {
                Console.WriteLine("Дохiд до вирахування податкiв - " + userInput/euroRate + " UAH");
                Console.WriteLine("Всього єдиного податку (5%) - " + singleTax/euroRate + " UAH");
                Console.WriteLine("Всього єдиного соцiального внеску (22%) - " + socialCont + " UAH");
                Console.WriteLine("Прибуток пiсля вирахування податкiв - " + profitEur/euroRate + " UAH");
            }
            else
            {
                Console.WriteLine("Введена валюта невiрна");
            }



            Console.ReadKey();


        }
    }
}
