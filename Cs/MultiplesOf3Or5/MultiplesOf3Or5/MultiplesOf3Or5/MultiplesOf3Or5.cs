public static class MultiplesOf3Or5
{
    public static int SumOfMultiples(int testLimit, params int[] multiplesOf)
    {
        int sum = 0;
        for (int i = 1; i < testLimit; i++)
        {
            if (IsMultipleOfAny(i, multiplesOf))
            {
                sum += i;
            }
        }
        return sum;
    }

    private static bool IsMultipleOfAny(int number, int[] multiples)
    {
        foreach (var multiple in multiples)
        {
            if (number % multiple == 0)
            {
                return true;  // Found a multiple, no need to continue checking
            }
        }
        return false;
    }
}
