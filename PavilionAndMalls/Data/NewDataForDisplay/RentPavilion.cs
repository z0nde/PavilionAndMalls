using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class RentPavilion
    {
        public double? CostRentingPavilion { get; set; }
        public double? CostArea { get; set; }

        public RentPavilion(double? costRentingPavilion, double? costArea)
        {
            CostRentingPavilion = costRentingPavilion;
            CostArea = costArea;
        }

        /// <summary>
        /// Возвращает разницу между датами в месяцах.
        /// </summary>
        /// <param name="end">Первая рассматриваемая дата.</param>
        /// <param name="start">Вторая рассматриваемая дата.</param>
        /// <returns>Число полных месяцев между указанными датами.</returns>
        public static int DifferenceInMonths(DateTime end, DateTime start)
        {
            DateTime previous, next;
            if (end > start)
            {
                previous = start;
                next = end;
            }
            else
            {
                previous = end;
                next = start;
            }

            return
                (next.Year - previous.Year) * 12
              + next.Month - previous.Month
              + (previous.Day <= next.Day ? 0 : -1);
        }

        public static List<RentPavilion> LoadedDataPavilions()
        {
            var context = App.Context;
            var data = new List<RentPavilion>();
            foreach (var id in App.Context.Pavilions.Select(s => s).ToList())
            {
                DateTime? start = context.PavilionsTenants
                    .Where(s => s.IdPavilion == id.IdPavilion)
                    .Select(s => s.RentStart).FirstOrDefault();
                DateTime? end = context.PavilionsTenants
                    .Where(s => s.IdPavilion == id.IdPavilion)
                    .Select(s => s.RentEnd).FirstOrDefault();
                int months = DifferenceInMonths((DateTime)end!, (DateTime)start!);
                double? costArea = id.Area * id.SquareMeterCost +
                        id.Area * id.SquareMeterCost * id.ValueAddedFactor;

                RentPavilion rent = new(costArea * months, costArea);
                data.Add(rent);
            }
            return data;
        }
    }
}