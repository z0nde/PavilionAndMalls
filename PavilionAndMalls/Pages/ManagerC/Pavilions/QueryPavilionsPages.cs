using PavilionAndMalls.Data.NewDataForDisplay;
using PavilionAndMalls.EF_Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PavilionAndMalls.Pages.Manager_C.Pavilion
{
    public class QueryPavilionsPages
    {
        public static string? FoundFloor()
        {
            var floor = PavilionsContext.GetContext().Pavilions
                .Where(s => s.IdPavilion == ManagerCData.IdPavilions)
                .Select(s => s.LevelNumber).Distinct().FirstOrDefault().ToString();
            return floor;
        }

        /*public string? FoundPavilionCode()
        {
            var code = NewPavilions.LoadedData()
                .Where(s => s. == ManagerCData.IdPavilions)
                .Select(s => s.PavilionNumber).Distinct().FirstOrDefault();
            return code;
        }

        public string? FoundStatus()
        {
            string? status = PavilionsContext.GetContext().PavilionStatuses
                .Where(s => s.IdPavilionStatus == (PavilionsContext.GetContext().Pavilions
                    .Where(s => s.IdPavilion == ManagerCData.IdPavilions)
                    .Select(s => s.IdPavilionStatus).Distinct().FirstOrDefault()))
                .Select(s => s.PavilionStatus1).Distinct().FirstOrDefault();
            return status;
        }*/

        public List<string?> Statuses()
        {
            return PavilionsContext.GetContext().PavilionStatuses
                .Select(s => s.PavilionStatus1).Distinct().ToList();
        }

        public NewPavilions GetListForAddUpdate(List<NewPavilions> newPavilions, int  count)
        {
            return newPavilions
                .Where(s => s.NumberPavilion == count)
                .Select(s => s).Distinct().FirstOrDefault()!;
        }

        public int IdStatus(string status)
        {
            int idStatus = PavilionsContext.GetContext().PavilionStatuses
                .Where(s => s.PavilionStatus1 == status)
                .Select(s => s.IdPavilionStatus).Distinct().FirstOrDefault();
            return idStatus;
        }


        public void AddPavilion(string Floor, string CodePavilion, string Area, string Status, string VAF, string MQC)
        {
            int floor = Convert.ToInt32(Floor);
            double area = Convert.ToDouble(Area);
            double vaf = Convert.ToDouble(VAF);
            double mqc = Convert.ToDouble(MQC);
            int idStatus = IdStatus(Status);

            var pavilion = new EF_Core.Pavilion
            {
                LevelNumber = floor,
                IdMall = ManagerCData.IdMalls,
                PavilionNumber = CodePavilion,
                Area = area,
                IdPavilionStatus = idStatus,
                ValueAddedFactor = vaf,
                SquareMeterCost = mqc
            };
            PavilionsContext.GetContext().Pavilions.Add(pavilion);
            PavilionsContext.GetContext().SaveChanges();
        }

        public void UpdatePavilion(string Floor, string CodePavilion, string Area, string Status, string VAF, string MQC)
        {
            int floor = Convert.ToInt32(Floor);
            double area = Convert.ToDouble(Area);
            double vaf = Convert.ToDouble(VAF);
            double mqc = Convert.ToDouble(MQC);
            int idStatus = IdStatus(Status);

            var update = PavilionsContext.GetContext().Pavilions
                .Where(s => s.IdPavilion == ManagerCData.IdPavilions)
                .Select(s => s).Distinct().FirstOrDefault();
            update.LevelNumber = floor;
            update.PavilionNumber = CodePavilion;
            update.Area = area;
            update.IdPavilionStatus = idStatus;
            update.ValueAddedFactor = vaf;
            update.SquareMeterCost = mqc;
            PavilionsContext.GetContext().SaveChanges();
        }
    }
}