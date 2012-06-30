using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParallelLibrary101
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInput = int.Parse(Console.ReadLine());
            int secondInput = int.Parse(Console.ReadLine());
            //int third = int.Parse(Console.ReadLine());
            //int fourth = int.Parse(Console.ReadLine());
            
            //Task task1 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("***************First task in succession*********************");
            //    for (int i = 1; i < firstInput; i++)
            //    {
            //        Console.WriteLine("Printing Table for " + i);
            //        for (int k = 1; k <= 10; k++)
            //            Console.WriteLine(String.Format(" Task 1 : {0} X {1} = {2}", i, k, i * k));
            //    }
            //});
            //Task task2 = Task.Factory.StartNew(antecedent =>
            //    {
            //        Console.WriteLine("--------------------Second task in succession----------------------");
            //        for (int i = 1; i < secondInput; i++)
            //        {
            //            Console.WriteLine("Printing Table for " + i);
            //            for (int k = 1; k <= 10; k++)
            //                Console.WriteLine(String.Format(" Task 2 : {0} X {1} = {2}", i, k, i * k));
            //        }
            //    }
            //);
            
            Console.ReadLine();
        }
    }
}
