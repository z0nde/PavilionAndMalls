using System;
using System.Collections.Generic;
using System.Linq;
using PavilionAndMalls.EF_Core;

namespace PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesDisplay
{
    public class QueryAddUpdate
    {
        public string? MallName { get; set; }
        public string? ValueAddedFactor { get; set; }
        public string? Status { get; set; }
        public string? BuildingCost { get; set; }
        public string? City { get; set; }
        public string? PathImage { get; set; }
        public string? LevelCount { get; set; }
        public string? CountPavilions { get; set; }

        public QueryAddUpdate(string? mallName, string? vaf, string? status, string? buildingCost, string? city, string? pathImage, string? levelCount, string? countPavilions)
        {
            MallName = mallName;
            ValueAddedFactor = vaf;
            Status = status;
            BuildingCost = buildingCost;
            City = city;
            PathImage = pathImage;
            LevelCount = levelCount;
            CountPavilions = countPavilions;
        }

        private int IdCity()
        {
            int IdCity = App.Context.Cities
                .Where(s => s.CityName == City)
                .Select(s => s.IdCity).FirstOrDefault();
            return IdCity;
        }

        private int IdStatus()
        {
            int IdStatus = App.Context.MallStatuses
                .Where(s => s.MallStatus1 == Status)
                .Select(s => s.IdMallStatus).FirstOrDefault();
            return IdStatus;
        }

        private int SearchMallCity()
        {

            int idMall = App.Context.Malls
                .Where(s => s.MallName == MallName && s.IdCity == IdCity())
                .Select(s => s.IdMall).FirstOrDefault();
            return idMall;
        }

        public int AddCity()
        {
            var context = App.Context;
            City cityName = new()
            {
                CityName = City
            };
            context.Update(cityName);
            context.SaveChanges();

            return context.Cities.Count() + 1;
        }

        public int FoundSuchCity()
        {
            var cities = App.Context.Cities
                .Where(s => s.CityName == City)
                .Select(s => s.IdCity).FirstOrDefault();

            if (cities == 0)
                return AddCity();
            else 
                return cities;
        }

        public Mall FoundIdMalls(int idMall, PavilionsContext context)
        {
            return context.Malls
                .Where(s => s.IdMall == idMall)
                .Select(s => s).Distinct().FirstOrDefault()!;
        }

        /*public static List<string?> ListCity()
        {
            List<string?> CityList = PavilionsContext.GetContext().Cities.Select(s => s.CityName).ToList();
            return CityList;
        }

        public static List<string?> ListMalls()
        {
            List<string?> MallList = PavilionsContext.GetContext().Malls.Select(s => s.MallName).ToList();
            return MallList;
        }*/


        public void AddMall()
        {
            var context = App.Context;

            Mall Mall = new()
            {
                MallName = MallName,
                IdMallStatus = IdStatus(),
                PavilionsCount = Convert.ToInt32(CountPavilions),
                IdCity = FoundSuchCity(),
                BuildingCost = Convert.ToDouble(BuildingCost),
                ValueAddedFactor = Convert.ToDouble(ValueAddedFactor),
                LevelsCount = Convert.ToInt32(LevelCount),
                MallPicture = PhotoConverter.ToByteArrWithPath(PathImage!)
            };

            context.Malls.Add(Mall);
            context.SaveChanges();
        }

        public void UpdateMall()
        {
            PavilionsContext context = App.Context;
            int IdMall = SearchMallCity();
            Mall upMall = FoundIdMalls(IdMall, context);

            upMall!.MallName = MallName;
            upMall.ValueAddedFactor = Convert.ToDouble(ValueAddedFactor);
            upMall.IdMallStatus = IdStatus();
            upMall.BuildingCost = Convert.ToDouble(BuildingCost);
            upMall.IdCity = FoundSuchCity();
            upMall.MallPicture = PhotoConverter.ToByteArrWithPath(PathImage!);
            upMall.LevelsCount = Convert.ToInt32(LevelCount);
            upMall.PavilionsCount = Convert.ToInt32(CountPavilions);

            context.SaveChanges();
        }
    }
}
