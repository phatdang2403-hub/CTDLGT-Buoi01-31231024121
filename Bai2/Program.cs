using System;
using System.Text;

class Program
{
    static string[] tok = new string[0];
    static int pos = 0;

    static long Next()
    {
        while (pos >= tok.Length)
        {
            string dong = Console.ReadLine()
                ?? throw new InvalidOperationException("Thiếu dữ liệu nhập");
            tok = dong.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            pos = 0;
        }
        return long.Parse(tok[pos++]);
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int n = (int)Next();

        long max = 0, second = 0;
        bool coMax = false, coSecond = false;

        for (int i = 0; i < n; i++)
        {
            long x = Next();

            if (!coMax)
            {
                max = x;
                coMax = true;
            }
            else if (x > max)
            {
                second = max;       
                coSecond = true;
                max = x;
            }
            else if (x < max && (!coSecond || x > second))
            {
                second = x;
                coSecond = true;
            }
        }

        if (coSecond)
            Console.WriteLine($"{max} {second}");
        else
            Console.WriteLine("NO");
    }
}