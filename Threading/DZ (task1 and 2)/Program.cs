using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DZ__task1_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            //ParameterizedThreadStart paramThread = new ParameterizedThreadStart(outCollection);
            //Thread thread = new Thread(paramThread);
            //thread.Start(list);

            Bank bank = new Bank();
            bank.name = "Privat24";
            bank.percent = 10;
            bank.money = 43000;
        }

        private static void outCollection(object obj)
        {
            List<int> list = obj as List<int>;
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
