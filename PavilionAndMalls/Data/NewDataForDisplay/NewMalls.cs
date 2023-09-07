using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace PavilionAndMalls.Data.NewDataForDisplay
{
    /// <summary>
    /// Класс 
    /// </summary>
    public class NewMalls
    {
        public int IdMall { get; set; }
        public string? MallName { get; set; }
        public string? MallStatus { get; set; }
        public int? PavilionsCount { get; set; }
        public string? City { get; set; }
        public double? BuildingCost { get; set; }
        public double? ValueAddedFactor { get; set; }
        public int? LevelsCount { get; set; }
        public BitmapImage MallPhoto { get; set; }

        public int IdMallStatus { get; set; }

        public static List<NewMalls> LoadedData()
        {
            var ListMalls = new List<NewMalls>();
            var context = App.context;
            foreach (Mall id in context.Malls
                .Where(s => s.IdMallStatus != 4)
                .Select(s => s)
                .ToList())
            {
                NewMalls mall = new()
                {
                    IdMall = id.IdMall,
                    MallName = id.MallName,
                    IdMallStatus = (int)id.IdMallStatus!,
                    MallStatus = context.MallStatuses
                        .Where(s => s.IdMallStatus == id.IdMallStatus)
                        .Select(s => s.MallStatus1)
                        .FirstOrDefault(),
                    PavilionsCount = id.PavilionsCount,
                    City = context.Cities
                        .Where(s => s.IdCity == id.IdCity)
                        .Select(s => s.CityName)
                        .FirstOrDefault(),
                    BuildingCost = id.BuildingCost,
                    ValueAddedFactor = id.ValueAddedFactor,
                    LevelsCount = id.LevelsCount,
                    MallPhoto = PhotoConverter.ToImage(id.MallPicture)
                };
                ListMalls.Add(mall);
            }
            return ListMalls;
        }
    }
}