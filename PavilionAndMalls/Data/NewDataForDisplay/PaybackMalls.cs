using System;
using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class PaybackMalls
    {
        public string MallName { get; set; }
        public string City { get; set; }
        public int Payback { get; set; }

        public static List<PaybackMalls> LoadedData()
        {
            var data = new List<PaybackMalls>();
            foreach (var id in NewPavilions.LoadedData())
            {
                PaybackMalls payback = new()
                {

                };
                data.Add(payback);
            }
            return data;
        }
    }
}