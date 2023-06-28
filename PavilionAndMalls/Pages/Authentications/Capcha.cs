namespace PavilionAndMalls.Pages.Authentications
{
    public class Capcha
    {
        public static string Make()
        {
            System.Random rand = new System.Random();
            string capcha;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                int r = rand.Next(1, 3);
                if (r == 1)
                    sb.Append(ArrSymbols.arr[rand.Next(0, 25)]);
                else if (r == 2)
                    sb.Append(ArrSymbols.ARR[rand.Next(0, 25)]);
                else if (r == 3)
                    sb.Append(ArrSymbols.INT[rand.Next(0, 9)]);
            }
            capcha = sb.ToString();
            return capcha;
        }
    }
}
