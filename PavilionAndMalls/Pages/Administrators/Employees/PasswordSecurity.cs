using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionAndMalls.Pages.Administrators.Employees
{
    public class PasswordSecurity
    {
        public int CheckPassword(string PassWord)
        {
            int quality = 0;
            if (PassWord.Length == 8)
                quality += 1;
            if (PassWord.Contains(ArrSymbols.ARR))
                quality += 1;
            if (PassWord.Contains(ArrSymbols.INT))
                quality += 1;
            if (PassWord.Contains(ArrSymbols.ServiceSymbols))
                quality += 1;
            if (PassWord.Length <= 20)
                quality += 1;
            return quality;

        }
    }
}
