using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.Data.NewDataForDisplay.ListsNewData;
using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Pages.ManagerC.Malls.Interface.FramesAddUpdateMonitoring.FramesDisplay
{
    public class QueryMonitoring
    {
        public static List<NewMalls> FoundMallsName(string mallName)
        { 
            return ListNewMalls.NewMalls
                .Where(s => s.MallName == mallName || s.MallName!.Contains(mallName))
                .Select(s => s).ToList(); ;
        }

        public static List<NewMalls> FoundMallsStatus(string mallStatus)
        {
            return ListNewMalls.NewMalls
                .Where(s => s.MallStatus == mallStatus || s.MallStatus!.Contains(mallStatus))
                .Select(s => s).ToList();
        }

        public static List<NewMalls> FoundPavilionsCount(int? pavilionsCount)
        {
            return ListNewMalls.NewMalls
                .Where(s => s.PavilionsCount == pavilionsCount || s.PavilionsCount.ToString()!.Contains(pavilionsCount.ToString()))
                .Select(s => s).ToList();
        }

        public static List<NewMalls> FoundCity(string city)
        {
            return ListNewMalls.NewMalls
                .Where(s => s.City == city || s.City!.Contains(city))
                .Select(s => s).ToList();
        }

        public static List<NewMalls> FoundBuildingCost(double? buildingCost)
        {
            return ListNewMalls.NewMalls
                .Where(s => s.BuildingCost == buildingCost)
                .Select(s => s).ToList();
        }

        public static List<NewMalls> FoundValueAddedFactor(double? vaf)
        {
            return ListNewMalls.NewMalls
                .Where(s => s.ValueAddedFactor == vaf)
                .Select(s => s).ToList();
        }

        public static List<NewMalls> FoundLevelsCount(int? levelsCount)
        {
            return ListNewMalls.NewMalls
                .Where(s => s.LevelsCount == levelsCount)
                .Select(s => s).ToList();
        }
    }
}