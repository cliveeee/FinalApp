using System;

namespace FinalApp
{
    public static class DateTimeFormatter
    {
        public static string FormatDate(string inputDate, TimeZoneInfo timeZone)
        {
            if (DateTime.TryParse(inputDate, out DateTime utcDateTime))
            {
                DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
                string formattedDate = localDateTime.ToString("ddd dd MMM yyyy");
                return formattedDate;
            }
            return inputDate;
        }

        public static string FormatTime(string inputTime, TimeZoneInfo timeZone)
        {
            if (TimeSpan.TryParse(inputTime, out TimeSpan timeSpan))
            {
                string formattedTime = timeSpan.ToString(@"hh\:mm");
                return formattedTime;
            }
            return inputTime;
        }
    }
}
