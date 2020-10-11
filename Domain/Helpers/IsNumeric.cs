using System;
using System.Collections.Generic;
using System.Text;

public static class IsNumeric
{
    public static int IsN(string s)
    {
        return int.TryParse(s, out int n) ? n : 0;
    }

    public static long IsL(string s)
    {
        return long.TryParse(s, out long n) ? n : 0;
    }

    public static double IsD(string s)
    {
        return double.TryParse(s, out double n) ? n : 0;
    }

    public static float IsF(string s)
    {
        return float.TryParse(s, out float n) ? n : 0;
    }


}