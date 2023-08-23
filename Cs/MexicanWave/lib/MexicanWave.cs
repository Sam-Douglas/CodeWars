public static class MexicanWave
{
    public static List<string> Wave(string str)
    {
        return Enumerable.Range(0, str.Length)
            .Where(i => !char.IsWhiteSpace(str[i]))
            .Select(i => str.Substring(0, i) + char.ToUpper(str[i]) + str.Substring(i + 1))
            .ToList();
    }
}