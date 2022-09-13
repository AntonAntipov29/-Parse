using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертер_валют
{
    
    public class TaxCalculator
    {
        public const string ExitIndex = "Exit";
        public const string CalcAgainIndex = "Calculate again";
        public const string ReturnIndex = "Return";
        public const string dollarIndex = "USD";
        public const string euroIndex = "EUR";
        public const string hryvniaIndex = "UAH";

        public void TaxCalculatorBody()
        {
            double yearProfit;
            string currency;
            double profit;
            float singleTaxRate = 0.05f;
            float socialContRate = 0.22f;
            const float MIN_SALARY = 6500;
            double singleTax;
            double socialCont;
            float dollarRate = 39.77f;
            float euroRate = 39.4f;
            float hryvniaRate = 1f;
            float currencyVariant = 0;
            string formatMoney = "{0:N}";


            Console.WriteLine("Введiть валюту в якiй ви отримуєте дохiд UAH, USD або EUR");
            currency = UserInput.GetUserInput(Enum.TypeOfUserInput.currency);
            Console.WriteLine($"Введена валюта - {currency}. ");
            Console.WriteLine("Натиснiть ENTER, щоб продовжити.");
            Console.ReadKey();
            yearProfit = YearProfit();
            Console.Write("Ви ввели " + formatMoney, yearProfit);
            Console.Write(" " + currency);
            Console.WriteLine(". Для розрахунку податкiв натиснiть ENTER");
            Console.ReadKey();
            Console.Clear();

            //maths operations with taxes 
            if (currency == hryvniaIndex)
            {
                currencyVariant = hryvniaRate;
            }
            else if (currency == dollarIndex)
            {
                currencyVariant = dollarRate;
            }
            else if (currency == euroIndex)
            {
                currencyVariant = euroRate;
            }


            yearProfit = yearProfit * currencyVariant;
            singleTax = yearProfit * singleTaxRate;
            socialCont = MIN_SALARY * socialContRate;
            profit = yearProfit - singleTax - socialCont;

            //output results in console


            Console.Write("Дохiд до вирахування податкiв - " + formatMoney, yearProfit);
            Console.WriteLine(" гривень");
            Console.Write("Всього єдиного податку (5%) - " + formatMoney, singleTax);
            Console.WriteLine(" гривень");
            Console.Write("Всього єдиного соцiального внеску (22%) - " + formatMoney, socialCont);
            Console.WriteLine(" гривень");
            Console.Write("Прибуток пiсля вирахування податкiв - " + formatMoney, profit);
            Console.WriteLine(" гривень");

            FinalAnswer();
        }

        double YearProfit()
        {
            string[] months = { "Сiчень", "Лютий", "Березень", "Квiтень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
            string[] monthsProfit = new string[12];
            double[] monthsProfitDouble = new double[12];
            int count = 0;
            double result = 0;


            NumberFormatInfo formatComa = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ",",
            };
            NumberFormatInfo formatDot = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            while (count < months.Length)
            {
                Console.Clear();
                Console.WriteLine("Введiть дохiд за " + months[count]);
                monthsProfit[count] = UserInput.GetUserInput(Enum.TypeOfUserInput.money);

                if (monthsProfit[count].Contains(","))
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count], formatComa);
                }
                else if (monthsProfit[count].Contains("."))
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count], formatDot);
                }
                else
                {
                    monthsProfitDouble[count] = Double.Parse(monthsProfit[count]);
                }
                result += monthsProfitDouble[count];
                count++;
            }
            return result;
        }

        void FinalAnswer()
        {
            string finalAnswer = "";

            Console.WriteLine("Щоб закрити програму напишiть Exit, щоб рахувати знову напишiть Calculate again.");
            finalAnswer = UserInput.GetUserInput(Enum.TypeOfUserInput.command);

            if (finalAnswer == ExitIndex)
            {
                Environment.Exit(0);
            }
            else if (finalAnswer == CalcAgainIndex)
            {
                Console.Clear();
                var reload = new TaxCalculator();
                reload.TaxCalculatorBody();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неправильний ввiд! Використовуйте Exit або Calculate again.");
                FinalAnswer();
            }

            Console.ReadKey();
        }
    }
}
