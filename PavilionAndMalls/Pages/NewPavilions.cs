using PavilionAndMalls.Pages.Manager_C;
using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Pages
{
    public class NewPavilions
    {
        public string? MallStatuses { get; set; }
        public string? MallName { get; set; }
        public int? NumberFloor { get; set; }
        public string? PavilionCode { get; set; }
        public double? Area { get; set; }
        public string? PavilionStatuses { get; set; }
        public double? ValueAddFacktor { get; set; }
        public double? MeterSquareCost { get; set; }

        public static List<NewPavilions> LoadedData()
        {
            List<NewPavilions> ListPavilions = new List<NewPavilions>();
            var ids = PavilionsContext.GetContext().Pavilions
                .Where(s => s.IdMall == ManagerCData.IdMalls)
                .Select(s => s).ToList();
            foreach (var id in ids)
            { 
                var pavilion = new NewPavilions();
                pavilion.MallStatuses = PavilionsContext.GetContext().MallStatuses
                    .Where(s => s.IdMallStatus == (PavilionsContext.GetContext().Malls
                        .Where(s => s.IdMall == id.IdMall)
                        .Select(s => s.IdMallStatus).Distinct().FirstOrDefault()))
                    .Select(s => s.MallStatus1).Distinct().FirstOrDefault();
                pavilion.MallName = PavilionsContext.GetContext().Malls
                    .Where(s => s.IdMall == id.IdMall)
                    .Select(s => s.MallName).Distinct().FirstOrDefault();
                pavilion.NumberFloor = id.LevelNumber;
                pavilion.PavilionCode = id.PavilionNumber;
                pavilion.Area = id.Area;
                pavilion.PavilionStatuses = PavilionsContext.GetContext().PavilionStatuses
                    .Where(s => s.IdPavilionStatus == id.IdPavilionStatus)
                    .Select(s => s.PavilionStatus1).Distinct().FirstOrDefault();
                pavilion.ValueAddFacktor = id.ValueAddedFactor;
                pavilion.MeterSquareCost = id.SquareMeterCost;
                ListPavilions.Add(pavilion);
            }

            return ListPavilions;
        }
    }
}