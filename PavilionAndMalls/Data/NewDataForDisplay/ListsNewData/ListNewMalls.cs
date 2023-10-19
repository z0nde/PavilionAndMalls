using System.Collections.Generic;

namespace PavilionAndMalls.Data.NewDataForDisplay.ListsNewData
{
    public class ListNewMalls
    {
        public static List<NewMalls> NewMalls { get; set; } = NewDataForDisplay.NewMalls.LoadedData();

        public static void ReNumber()
        {
            int cout = -1;
            foreach (var o in NewMalls)
            {
                o.NumberMall = cout++;         
            }
        }

        public static List<NewMalls> ReNumber(List<NewMalls> listMalls)
        {
            int cout = -1;
            foreach (var o in listMalls)
            {
                o.NumberMall = cout++;
            }
            return listMalls;
        }
    }
}