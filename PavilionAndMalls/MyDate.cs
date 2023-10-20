using System;

namespace PavilionAndMalls
{
    public static class MyDate
    {
        /// <summary>
        /// Возвращает разницу между датами в месяцах.
        /// </summary>
        /// <param name="end">Первая рассматриваемая дата.</param>
        /// <param name="start">Вторая рассматриваемая дата.</param>
        /// <returns>Число полных месяцев между указанными датами.</returns>
        public static int DifferenceInMonths(DateTime end, DateTime start)
        {
            DateTime previous, next;
            if (end > start)
            {
                previous = start;
                next = end;
            }
            else
            {
                previous = end;
                next = start;
            }

            return
                (next.Year - previous.Year) * 12
              + next.Month - previous.Month
              + (previous.Day <= next.Day ? 0 : -1);
        }
    }
}