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
            decimal euroPerDollar = 0.97M;


            Console.WriteLine("Введите сумму в долларах");


           
            Console.WriteLine("Сумма в гривне = " + inputInDollar * uahPerDollar);
            Console.WriteLine("Сумма в евро = " + inputInDollar * euroPerDollar);
            Console.ReadKey();


        }
    }
}
