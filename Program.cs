﻿using System.Text;

public class Codewars
{
    static void Main(string[] args)
    {
    }
    public double MyPow(double x, int n)
    {
        long N = n;

        if (N < 0)
        {
            x = 1 / x;
            N = -N;
        }
        double result = 1.0;
        while (N > 0)
        {
            if ((N % 2) == 1)
            {
                result *= x;
            }

            x *= x;
            N /= 2;
        }
        return result;
    }
}