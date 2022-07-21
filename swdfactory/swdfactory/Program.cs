using System;

namespace swdfactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK: Fibonacci");
            Fibonacci fibo = new Fibonacci(10);
            //Returned method as array
            fibo.Task();
            for (int i = 0; i < fibo.Task().Length; i++)
            {
                Console.Write($" {fibo.Task()[i]}");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TASK: FIND PATH");



            /////////////////////TASK 2: FIND PATH///////////////////////
            int Y = 3;
            int X = 4;
            int startY = 3;
            int startX = 1;
            int finishY = 1;
            int finishX = 4;

            FindPath findpath = new FindPath(Y, X, startY, startX, finishY, finishX);
            findpath.Task();

            Console.ReadLine();
        }
    }
}
