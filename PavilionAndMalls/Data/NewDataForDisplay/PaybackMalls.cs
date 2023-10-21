using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class PaybackMalls
    {
        public string MallName { get; set; }
        public string City { get; set; }
        public double Payback { get; set; }

        public PaybackMalls(string mallName, string city, double payback) =>
            (MallName, City, Payback) = (mallName, city, payback);

        public static List<PaybackMalls> LoadedData()
        {
            var context = App.Context;
            var data = new List<PaybackMalls>();
            foreach (var id in context.Malls.Select(s => s).ToList())
            {
                string mallName = id.MallName!;
                string city = context.Cities
                    .Where(s => s.IdCity == id.IdCity)
                    .Select(s => s.CityName).FirstOrDefault()!;

                List<RentPavilion> PavilionsInNMall = RentPavilion.LoadedDataPavilions()
                    .Where(s => s.IdMall == id.IdMall)
                    .Select(s => s).ToList();
                double payback = 0.0;
                foreach (var i in PavilionsInNMall)
                {
                    payback += (double)i.CostRentingPavilion!;
                }
                payback = 100 - (((double)id.BuildingCost! - payback) / (double)id.BuildingCost * 100);

                data.Add(new PaybackMalls(mallName, city, payback));
            }
            return data;
        }
    }
}