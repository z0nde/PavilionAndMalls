using System.Collections.Generic;

namespace PavilionAndMalls.Data.NewDataForDisplay.ListsNewData
{
    public class ListNewEmployee
    {
        public List<NewEmployee> Employees { get; set; } = NewEmployee.LoadedData();
    }
}