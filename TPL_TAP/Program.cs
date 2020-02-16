using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TPL_TAP
{
    class Program
    {
        static void Main(string[] args)
        {
            //TPLTests.Start();
            //TasksTest.Start();
            TasksTest.StartAsync();

            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();
            Console.WriteLine("Приложение должно быть закрыто");
            Console.ReadKey();
        }

    }
}
