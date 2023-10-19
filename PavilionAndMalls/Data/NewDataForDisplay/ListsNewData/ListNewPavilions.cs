using System.Collections.Generic;

namespace PavilionAndMalls.Data.NewDataForDisplay.ListsNewData
{
    public class ListNewPavilions
    {
        public static List<NewPavilions> NewPavilions { get; set; } = NewDataForDisplay.NewPavilions.LoadedData();

        public static void ReNumber()
        {
            int cout = -1;
            foreach (var o in NewPavilions)
            {
                o.NumberPavilion = cout++;         
            }
        }

        public static List<NewPavilions> ReNumber(List<NewPavilions> newPavilions)
        {
            int cout = -1;
            foreach (var o in newPavilions)
            {
                o.NumberPavilion = cout++;
            }
            return newPavilions;
        }
    }
}