using PavilionAndMalls.Data.NewDataForDisplay;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdateMonitoring.FramesDisplay
{
    public class QueryMonitoring
    {
        public static List<NewMalls> FoundMallsName(string mallName)
        {
            var ids = new List<NewMalls>();
            ids = NewMalls.LoadedData()
                .Where(s => s.MallName == mallName || s.MallName.Contains(mallName))
                .Select(s => s).ToList();
            return ids;
        }

        public static List<NewMalls> FoundMallsStatus(string mallStatus)
        {
            var ids = new List<NewMalls>();
            ids = NewMalls.LoadedData()
                .Where(s => s.MallStatus == mallStatus || s.MallStatus.Contains(mallStatus))
                .Select(s => s).ToList();
            return ids;
        }

        public static List<NewMalls> FoundPavilionsCount(int? pavilionsCount)
        {
            var ids = new List<NewMalls>();
            ids = NewMalls.LoadedData()
                .Where(s => s.PavilionsCount == pavilionsCount || s.PavilionsCount.ToString().Contains(pavilionsCount.ToString()))
                .Select(s => s).ToList();
            return ids;
        }

        public static List<NewMalls> FoundCity(string city)
        {
            var ids = new List<NewMalls>();
            ids = NewMalls.LoadedData()
                .Where(s => s.City == city || s.City.Contains(city))
                .Select(s => s).ToList();
            return ids;
        }

        public static List<NewMalls> FoundBuildingCost(double? buildingCost)
        {
            var ids = new List<NewMalls>();
            ids = NewMalls.LoadedData()
                .Where(s => s.BuildingCost == buildingCost)
                .Select(s => s).ToList();
            return ids;
        }

        public static List<NewMalls> FoundValueAddedFactor(double? vaf)
        {
            List<NewMalls> ids = new();
            ids = NewMalls.LoadedData()
                .Where(s => s.ValueAddedFactor == vaf)
                .Select(s => s).ToList();
            return ids;
        }

        public static List<NewMalls> FoundLevelsCount(int? levelsCount)
        {
            List<NewMalls> ids = new();
            ids = NewMalls.LoadedData()
                .Where(s => s.LevelsCount == levelsCount)
                .Select(s => s).ToList();
            return ids;
        }
    }
}