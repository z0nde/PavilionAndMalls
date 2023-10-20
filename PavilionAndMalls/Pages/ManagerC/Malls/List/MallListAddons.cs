using System;
using System.Collections.Generic;
using System.Linq;
using PavilionAndMalls.EF_Core;

namespace PavilionAndMalls.Pages.ManagerC.Malls.List
{
    public class MallListAddons
    {
        public static List<string> GetStatusExDel()
        {
            //вернул бы одной строкой, без объявления экзмепляра списка, но мне не нравится
            //длинное подчёркивание nullable
            List<string?> list = new(PavilionsContext.GetContext().MallStatuses
                .Where(s => s.IdMallStatus != 4)
                .OrderBy(s => s.IdMallStatus)
                .Select(s => s.MallStatus1)
                .Distinct().ToList());
            return list;
        }
    }
}