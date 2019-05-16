using System;

namespace Lacky
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int c = 0;

            int d = 0;
            int e = 0;
            int f = 0;

            int result = 0;

            for (int l1 = 0; l1 < 10; l1++)
            {
                a = l1;
                for (int l2 = 0; l2 < 10; l2++)
                {
                    b = l2;
                    for (int l3 = 0; l3 < 10; l3++)
                    {
                        c = l3;
                        for (int l4 = 0; l4 < 10; l4++)
                        {
                            d = l4;
                            for (int l5 = 0; l5 < 10; l5++)
                            {
                                e = l5;
                                for (int l6 = 0; l6 < 10; l6++)
                                {
                                    f = l6;

                                    if ((a + b + c) == (d + e + f)) result++;
                                }
                            }
                        }
                    }
                }
            }


            Console.WriteLine("Hello World! --- " + result);
        }
    }
}
