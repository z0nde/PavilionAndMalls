namespace PavilionAndMalls
{
    public class StringChecking
    {
        public static bool Contains(string str1, string str2)
        {
            foreach (char c in str2)
            {
                if (str1.Contains(c))
                    return true;
            }
            return false;
        }
    }
}