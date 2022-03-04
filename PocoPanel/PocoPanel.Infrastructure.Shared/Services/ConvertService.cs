using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocoPanel.Application.Interfaces;
using System.Globalization;

namespace PocoPanel.Infrastructure.Shared.Services
{
    public class ConvertService : IConvert
    {
        public decimal RoundNumber(decimal? number)
        {
            if (number.HasValue)
                return Math.Round(number.Value, MidpointRounding.AwayFromZero);
            else
                return 0;
        }

        public string PersionDateTime(DateTime dateTime)
        {
            var ps = new PersianCalendar();
            return $"{ps.GetYear(dateTime)}/{ps.GetMonth(dateTime)}/{ps.GetDayOfMonth(dateTime)} - {ps.GetHour(dateTime)}:{ps.GetMinute(dateTime)}";
        }

        public string GetSocialUserName(string userName)
        {
            string result = userName;

            if (userName.StartsWith("@"))
                result = userName.Remove(0, 1);

            return result;
        }
    }
}