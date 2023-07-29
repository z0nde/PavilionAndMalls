using System;
using System.Text;

namespace PavilionAndMalls.Pages.Authentications
{
    public class PasswordTextChanged
    {
        public static UInt64 Click { get; set; } = 0;
        public static UInt16 CountChar { get; set; } = 0;
        private static string? Password { get; set; } = "";

        private const char UnvisibleChar = '*';

        public PasswordTextChanged(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetLastIndexString(s));
            Password = sb.ToString();
            CountChar = Convert.ToUInt16(s.Length);
        }

        private static char GetLastIndexString(string s)
        {
            int i = s.LastIndexOf(s);
            return s[i];
        }

        public string? HidingPassword()
        {
            StringBuilder hiding = new StringBuilder();
            for (int i = 0; i <= CountChar; i++)
            {
                hiding.Append(UnvisibleChar);
            }
            return hiding.ToString();
        }

        public static string? Visiblpassword()
        {
            return Password;
        }
    }
}
