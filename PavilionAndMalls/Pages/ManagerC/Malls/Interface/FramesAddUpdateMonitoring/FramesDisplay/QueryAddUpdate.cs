using System;
using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesDisplay
{
    public class QueryAddUpdate
    {
        private int IdCity(string City)
        {
            int IdCity = App.Context.Cities
                .Where(s => s.CityName == City)
                .Select(s => s.IdCity).FirstOrDefault();
            return IdCity;
        }

        private int IdStatus(string Status)
        {
            int IdStatus = App.Context.MallStatuses
                .Where(s => s.MallStatus1 == Status)
                .Select(s => s.IdMallStatus).FirstOrDefault();
            return IdStatus;
        }

        private int SearchMallCity(string Mall, string City)
        {
            int idMall = App.Context.Malls
                .Where(s => s.MallName == Mall && s.IdCity == IdCity(City))
                .Select(s => s.IdMall).FirstOrDefault();
            return idMall;
        }

        public int AddCity(string city)
        {
            var context = App.Context;
            City cityName = new()
            {
                CityName = city
            };
            context.Update(cityName);
            context.SaveChanges();

            return context.Cities.Count() + 1;
        }

        public int FoundSuchCity(string city)
        {
            var cities = App.Context.Cities
                .Where(s => s.CityName == city)
                .Select(s => s.IdCity).FirstOrDefault();

            if (cities == 0)
                return AddCity(city);
            else 
                return cities;
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


        public void AddMall(string MallName, string ValueAddedFactor, string Status, string BuildingCost, string City, string PathImage, string LevelCount, string CountPavilions)
        {
            var context = App.Context;

            double ValueAdd = Convert.ToDouble(ValueAddedFactor);
            double Cost = Convert.ToDouble(BuildingCost);
            int Floors = Convert.ToInt32(LevelCount);
            int Count = Convert.ToInt32(CountPavilions);
            int idStatus = IdStatus(Status);
            //int idCity = IdCity(City);
            int idCity = FoundSuchCity(City);
            byte[] Photo = PhotoConverter.ToByteArrWithPath(PathImage);

            Mall Mall = new()
            {
                MallName = MallName,
                IdMallStatus = idStatus,
                PavilionsCount = Count,
                IdCity = idCity,
                BuildingCost = Cost,
                ValueAddedFactor = ValueAdd,
                LevelsCount = Floors,
                MallPicture = Photo
            };

            context.Malls.Add(Mall);
            context.SaveChanges();
        }

        public void UpdateMall(string MallName, string ValueAddedFactor, string Status, string BuildingCost, string City, string PathImage, string LevelCount, string CountPavilions, string SearchMall, string SearchCity)
        {
            var context = App.Context;

            double ValueAdd = Convert.ToDouble(ValueAddedFactor);
            double Cost = Convert.ToDouble(BuildingCost);
            int Floors = Convert.ToInt32(LevelCount);
            int Count = Convert.ToInt32(CountPavilions);
            int idStatus = IdStatus(Status);
            //int idCity = IdCity(City);
            int idCity = FoundSuchCity(City);
            byte[] Photo = PhotoConverter.ToByteArrWithPath(PathImage);
            int IdMall = SearchMallCity(SearchMall, SearchCity);

            var upMall = context.Malls
                .Where(s => s.IdMall == IdMall)
                .Select(s => s).Distinct().FirstOrDefault();
            upMall!.MallName = MallName;
            upMall.ValueAddedFactor = ValueAdd;
            upMall.IdMallStatus = idStatus;
            upMall.BuildingCost = Cost;
            upMall.IdCity = idCity;
            upMall.MallPicture = Photo;
            upMall.LevelsCount = Floors;
            upMall.PavilionsCount = Count;

            context.SaveChanges();
        }
    }
}
