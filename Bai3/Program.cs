using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static long PhienBanA(int[] a)
    {
        long best = a[0];
        for (int i = 0; i < a.Length; i++)
        {
            long tong = 0;
            for (int j = i; j < a.Length; j++)
            {
                tong += a[j];
                if (tong > best) best = tong;
            }
        }
        return best;
    }

    static long Kadane(int[] a)
    {
        long cur = a[0];
        long best = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            cur = Math.Max(a[i], cur + a[i]);
            best = Math.Max(best, cur);
        }
        return best;
    }

    static double DoThoiGian(Func<int[], long> f, int[] data, int soLan)
    {
        f(data);
        double[] t = new double[soLan];
        for (int k = 0; k < soLan; k++)
        {
            var sw = Stopwatch.StartNew();
            f(data);
            sw.Stop();
            t[k] = sw.Elapsed.TotalMilliseconds;
        }
        Array.Sort(t);
        return t[soLan / 2];
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int[][] mau =
        {
            new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 },
            new[] { -8, -3, -6, -2, -5, -4 },
            new[] { 1, 2, 3 },
        };
        foreach (int[] m in mau)
            Console.WriteLine($"[{string.Join(" ", m)}] -> A: {PhienBanA(m)}, Kadane: {Kadane(m)}");

        Console.WriteLine();
        Console.WriteLine($"{"n",8} | {"O(n^2) (ms)",14} | {"Kadane (ms)",14}");
        var rnd = new Random(12345);
        foreach (int n in new[] { 100, 1000, 10000 })
        {
            int[] data = new int[n];
            for (int i = 0; i < n; i++) data[i] = rnd.Next(-100, 101);

            double tA = DoThoiGian(PhienBanA, data, 21);
            double tB = DoThoiGian(Kadane, data, 21);

            Console.WriteLine($"{n,8} | {tA,14:F4} | {tB,14:F4}");
        }
    }
}