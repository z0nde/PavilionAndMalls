namespace PavilionAndMalls.Pages.Administrators.Employees
{
    public class PasswordSecurity
    {
        public int CheckPassword(string PassWord)
        {
            int quality = 0;
            if (PassWord.Length <= 8)
                quality += 1;
            if (StringChecking.Contains(PassWord, StringSymbols.ARR))
                quality += 1;
            if (StringChecking.Contains(PassWord, StringSymbols.INT))
                quality += 1;
            if (StringChecking.Contains(PassWord, StringSymbols.ServiceSymbols))
                quality += 1;
            if (PassWord.Length >= 20)
                quality += 1;
            return quality;
        }
    }
}