using System;

using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string[] s = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        long a = long.Parse(s[0]);
        long b = long.Parse(s[1]);
        long c = long.Parse(s[2]);

        long lonNhat = Math.Max(a, Math.Max(b, c));
        long nhoNhat = Math.Min(a, Math.Min(b, c));
        long tong = a + b + c;
        double trungBinh = tong / 3.0;

        string tb = trungBinh.ToString("F2", new CultureInfo("vi-VN"));

        Console.WriteLine($"Lớn nhất: {lonNhat}; nhỏ nhất: {nhoNhat}; tổng: {tong}; trung bình: {tb}");
    }
}