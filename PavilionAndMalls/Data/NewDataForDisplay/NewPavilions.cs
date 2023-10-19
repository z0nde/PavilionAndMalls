using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    public class NewPavilions
    {
        public int NumberPavilion { get; set; }
        public int? IdPavilion { get; set; }
        public string? MallStatuses { get; set; }
        public string? MallName { get; set; }
        public int? NumberFloor { get; set; }
        public string? PavilionCode { get; set; }
        public double? Area { get; set; }
        public string? PavilionStatuses { get; set; }
        public double? ValueAddFacktor { get; set; }
        public double? MeterSquareCost { get; set; }
        public int? IdMall { get; set; }

        public static List<NewPavilions> LoadedData()
        {
            var context = App.Context;
            int count = -1;
            List<NewPavilions> ListPavilions = new();
            foreach (var id in context.Pavilions.Select(s => s).ToList())
            {
                count++;
                var pavilion = new NewPavilions
                {
                    NumberPavilion = count,
                    IdMall = id.IdMall,
                    IdPavilion = id.IdPavilion,
                    MallStatuses = context.MallStatuses
                        .Where(s => s.IdMallStatus == context.Malls
                            .Where(s => s.IdMall == id.IdMall)
                            .Select(s => s.IdMallStatus).Distinct().FirstOrDefault())
                        .Select(s => s.MallStatus1).Distinct().FirstOrDefault(),
                    MallName = context.Malls
                        .Where(s => s.IdMall == id.IdMall)
                        .Select(s => s.MallName).Distinct().FirstOrDefault(),
                    NumberFloor = id.LevelNumber,
                    PavilionCode = id.PavilionNumber,
                    Area = id.Area,
                    PavilionStatuses = context.PavilionStatuses
                        .Where(s => s.IdPavilionStatus == id.IdPavilionStatus)
                        .Select(s => s.PavilionStatus1).Distinct().FirstOrDefault(),
                    ValueAddFacktor = id.ValueAddedFactor,
                    MeterSquareCost = id.SquareMeterCost
                };
                ListPavilions.Add(pavilion);
            }

            return ListPavilions;
        }
    }
}