using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace PavilionAndMalls.Pages
{
    public class NewMalls
    {
        public int IdMall { get; set; }
        public string? MallName { get; set; }
        public int? IdMallStatus { get; set; }
        public int? PavilionsCount { get; set; }
        public string? City { get; set; }
        public double? BuildingCost { get; set; }
        public double? ValueAddedFactor { get; set; }
        public int? LevelsCount { get; set; }
        public BitmapImage? MallPhoto { get; set; }

        public static List<NewMalls> LoadedData()
        {
            List<NewMalls> ListMalls = new List<NewMalls>();
            var ids = PavilionsContext.GetContext().Malls.Select(s => s).ToList();
            foreach (var id in ids)
            {
                NewMalls mall = new NewMalls();
                mall.IdMall = id.IdMall;
                mall.MallName = id.MallName;
                mall.IdMallStatus = id.IdMallStatus;
                mall.PavilionsCount = id.PavilionsCount;
                mall.City = PavilionsContext.GetContext().Cities.Where(s => s.IdCity == id.IdCity).Select(s => s.CityName).FirstOrDefault();
                mall.BuildingCost = id.BuildingCost;
                mall.ValueAddedFactor = id.ValueAddedFactor;
                mall.LevelsCount = id.LevelsCount;
                mall.MallPhoto = PhotoConverter.ToImage(id.MallPicture);
                ListMalls.Add(mall);
            }

            return ListMalls;
        }
    }
}
