using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        List<long> so = new List<long>();
        while (so.Count < 3)
        {
            string dong = Console.ReadLine() ?? "";
            foreach (string t in dong.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (so.Count < 3)
                    so.Add(long.Parse(t));
            }
        }
        long a = so[0], b = so[1], c = so[2];

        long lonNhat = Math.Max(a, Math.Max(b, c));
        long nhoNhat = Math.Min(a, Math.Min(b, c));
        long tong = a + b + c;
        double trungBinh = tong / 3.0;

        string tb = trungBinh.ToString("F2", new CultureInfo("vi-VN"));

        Console.WriteLine($"Lớn nhất: {lonNhat}; nhỏ nhất: {nhoNhat}; tổng: {tong}; trung bình: {tb}");
    }
}