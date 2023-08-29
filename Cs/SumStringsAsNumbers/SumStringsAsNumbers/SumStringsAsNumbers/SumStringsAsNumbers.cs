using System.Numerics;

public static class SumStringsAsNumbers
{
    public static string sumStrings(string a, string b) => (BigInteger.Parse("0" + a) + BigInteger.Parse("0" + b)).ToString();
}
