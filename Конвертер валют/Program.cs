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
            decimal USD;
            decimal dollar = 37.5M;
            decimal dollarValue = 36.92M;
            decimal euroPerDollar = 0.97M;


            Console.WriteLine("Введите сумму в долларах");
            USD = decimal.Parse(Console.ReadLine());


            Console.WriteLine("Сумма в гривне = " + USD * dollar);
            Console.ReadKey();


        }
    }
}
