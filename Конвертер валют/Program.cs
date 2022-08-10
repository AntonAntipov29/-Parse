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
            double USD;
            double dollar = 37.5;


            Console.WriteLine("Введите сумму в долларах");
            USD = double.Parse(Console.ReadLine());


            Console.WriteLine("Сумма в гривне = " + USD * dollar);


        }
    }
}
