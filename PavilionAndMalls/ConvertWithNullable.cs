using System;

namespace PavilionAndMalls
{
    public static class ConvertWithNullable
    {
        public static int? ToInt32(string s)
        {
            if (s != "")
                return Convert.ToInt32(s);
            return null;
        }

        public static double? ToDouble(string s)
        {
            if (s != "")
                return Convert.ToDouble(s);
            return null;
        }
    }
}
