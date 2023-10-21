using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class RentPavilion
    {
        public int IdMall { get; set; }
        public double? CostRentingPavilion { get; set; }
        public double? CostArea { get; set; }

        public RentPavilion(int id, double? costRentingPavilion, double? costArea) => 
            (IdMall, CostRentingPavilion, CostArea) = (id, costRentingPavilion, costArea);

        public static List<RentPavilion> LoadedDataPavilions()
        {
            var context = App.Context;
            var data = new List<RentPavilion>();
            foreach (var id in context.Pavilions.Select(s => s).ToList())
            {
                DateTime? start = context.PavilionsTenants
                    .Where(s => s.IdPavilion == id.IdPavilion)
                    .Select(s => s.RentStart).FirstOrDefault();
                DateTime? end = context.PavilionsTenants
                    .Where(s => s.IdPavilion == id.IdPavilion)
                    .Select(s => s.RentEnd).FirstOrDefault();
                if (start != null)
                {
                    if (end == null)
                        end = DateTime.Now;
                    int months = MyDate.DifferenceInMonths((DateTime)end!, (DateTime)start!);

                    double? costArea = id.Area * id.SquareMeterCost * id.ValueAddedFactor;

                    data.Add(new RentPavilion((int)id.IdMall!, costArea * months, costArea));
                }
            }
            return data;
        }
    }
}