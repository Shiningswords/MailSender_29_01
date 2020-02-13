using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTests.Start();
            ThreadPoolTests.Start();
            Console.WriteLine("Приложение должно быть закрыто");
        }
    }
}
