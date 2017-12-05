using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using BioHR.Model.Dictionary;

namespace BioHR.Controller.Function
{
    public class DateTimeReferences
    {
        static DateTime _baseDate = DateTime.Today;

        public static DateTime GetTodayDate()
        {
            return (_baseDate);
        }

        public static DateTime GetMaxDate()
        {
            return (DateTime.MaxValue);
        }

        public static String GetDay(string date)
        {
            return (Convert.ToDateTime(date).Day.ToString());
        }

        public static String GetMonth(string date)
        {
            return (Convert.ToDateTime(date).Month.ToString());
        }

        public static String GetYear(string date)
        {
            return (Convert.ToDateTime(date).Year.ToString());
        }

        #region :: GET CUSTOM DATE FORMAT DISPLAY ::

        public static String GetShortDateFormat(string date)
        {
            return Convert.ToDateTime(date).ToString("d");
        }

        public static String GetMonthRomawiFormat(string date)
        {
            return NumToEnum<BulanRomawi>(Convert.ToInt16(GetMonth(date))).ToString();
        }

        public static String GetMonthFromEnum(string month)
        {
            switch (month.ToLower())
            {
                case "januari":
                    {
                        return "01";
                    }
                case "februari":
                    {
                        return "02";
                    }
                case "maret":
                    {
                        return "03";
                    }
                case "april":
                    {
                        return "04";
                    }
                case "mei":
                    {
                        return "05";
                    }
                case "juni":
                    {
                        return "06";
                    }
                case "juli":
                    {
                        return "07";
                    }
                case "agustus":
                    {
                        return "08";
                    }
                case "september":
                    {
                        return "09";
                    }
                case "oktober":
                    {
                        return "10";
                    }
                case "november":
                    {
                        return "11";
                    }
                case "desember":
                    {
                        return "12";
                    }
                default: { return "01"; }
            }
        }

        public static T1 NumToEnum<T1>(int number)
        {
            return (T1)Enum.ToObject(typeof(T1), number);
        }

        public static String GetDateFormatToNumber(string date)
        {
            return GetMonthFromEnum(date.Split(' ')[1].ToLower()) + "/" + date.Split(' ')[0] + "/" + date.Split(' ')[2];
        }

        public static String GetDateFormat(string date)
        {
            return GetDay(date) + " " + NumToEnum<Bulan>(Convert.ToInt16(GetMonth(date))) + " " + GetYear(date);
        }

        public static String GetDateFormatMonth(string date)
        {
            return NumToEnum<Bulan>(Convert.ToInt16(GetMonth(date))).ToString();
        }


        //Date Format : DDMMYYYY
        public static string GetIndonesianDateFormat(string date)
        {
            return GetDayFromIndonesianDateFormat(date) + "/" + GetMonthFromIndonesianDateFormat(date) + "/" + GetYearFromIndonesianDateFormat(date);
        }

        public static String GetDayFromIndonesianDateFormat(string date)
        {
            return date.Substring(0, 2);
        }

        public static String GetMonthFromIndonesianDateFormat(string date)
        {
            return date.Substring(3, 2);
        }

        public static String GetYearFromIndonesianDateFormat(string date)
        {
            return date.Substring(6, 4);
        }

        //Date Format : MMDDYYYY
        public static string GetEnglishDateFormat(string date)
        {
            return GetMonthFromEnglishDateFormat(date) + "/" + GetDayFromEnglishDateFormat(date) + "/" + GetYearFromEnglishDateFormat(date);
        }

        public static String GetDayFromEnglishDateFormat(string date)
        {
            return date.Substring(3, 2);
        }

        public static String GetMonthFromEnglishDateFormat(string date)
        {
            return date.Substring(0, 2);
        }

        public static String GetYearFromEnglishDateFormat(string date)
        {
            return date.Substring(6, 4);
        }

        #endregion

        #region :: GET DAY START & END ::

        public static DateTime GetYesterday()
        {
            return (_baseDate.AddDays(-1));
        }
        public static DateTime GetThisWeekStart()
        {
            return (_baseDate.AddDays(-(int)_baseDate.DayOfWeek));
        }
        public static DateTime GetThisWeekEnd()
        {
            return (GetThisWeekStart().AddDays(7).AddSeconds(-1));
        }
        public static DateTime GetLastWeekStart()
        {
            return (GetThisWeekStart().AddDays(-7));
        }
        public static DateTime GetLastWeekEnd()
        {
            return (GetThisWeekStart().AddSeconds(-1));
        }

        public static DateTime GetThisMonthStart()
        {
            return (_baseDate.AddDays(1 - _baseDate.Day));
        }
        public static DateTime GetThisMonthEnd()
        {
            return (GetThisMonthStart().AddMonths(1).AddSeconds(-1));
        }
        public static DateTime GetLastMonthStart()
        {
            return (GetThisMonthStart().AddMonths(-1));
        }
        public static DateTime GetLastMonthEnd()
        {
            return (GetThisMonthStart().AddSeconds(-1));
        }

        #endregion

    }

    public class TimeReferences
    {
        public static string GetTimeDifference(string t1, string t2)
        {
            DateTime time1 = Convert.ToDateTime(t1);
            DateTime time2 = Convert.ToDateTime(t2);

            TimeSpan timeSpan = time1.Subtract(time2);

            return timeSpan.ToString();
        }

        public static double GetTimeDifferenceTotalHours(string t1, string t2)
        {
            DateTime time1 = Convert.ToDateTime(t1);
            DateTime time2 = Convert.ToDateTime(t2);

            return time1.Subtract(time2).TotalHours;
        }

        public static double GetTimeDifferenceTotalMinutes(string t1, string t2)
        {
            DateTime time1 = Convert.ToDateTime(t1);
            DateTime time2 = Convert.ToDateTime(t2);

            return time1.Subtract(time2).TotalMinutes;
        }

        public static double GetTimeDifferenceTotalSeconds(string t1, string t2)
        {
            DateTime time1 = Convert.ToDateTime(t1);
            DateTime time2 = Convert.ToDateTime(t2);

            return time1.Subtract(time2).TotalSeconds;
        }

    }

}