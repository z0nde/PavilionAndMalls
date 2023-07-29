using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public static class ArrSymbols
    {
        public static string arr = "abcdefghijklmnopqrstuvwxyz";
        public static string ARR = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string INT = "0123456789";
        public static string ServiceSymbols = ",.<>/?:;\\|{][}=+-_!@#$%^&*";
    }

    public class PasswordSecurity
    {
        public int CheckPassword(string PassWord)
        {
            int quality = 0;
            if (PassWord.Length >= 8 && PassWord.Length <=15)
                quality += 1;
            if (PassWord.Contains(ArrSymbols.ARR))
                quality += 1;
            if (PassWord.Contains(ArrSymbols.INT))
                quality += 1;
            if (PassWord.Contains(ArrSymbols.ServiceSymbols))
                quality += 1;
            if (PassWord.Length > 15 && PassWord.Length <= 20)
                quality += 1;
            return quality;

        }
    }
}
