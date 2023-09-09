using System.Collections.Generic;

namespace PavilionAndMalls
{
    public static class Collections
    {
        public readonly static List<string> CRUD = new()
        { "Добавить", "Изменить", "Удалить" };

        public readonly static List<string> SortItemsForCombo = new()
        { "По возрастанию", "По убыванию" };
    }
}