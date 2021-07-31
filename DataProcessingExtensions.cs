using CommonMark;
using System;
using System.Web;

namespace MessengerComparison
{
    public static class DataProcessingExtensions
    {
        public static string ToHtml(this string s)
        {
            var result = CommonMarkConverter.Convert(s);

            if (result.StartsWith("<p>"))
            {
                result = result.Remove(0, 3);
                result = result.Remove(result.LastIndexOf("</p>"), 4);
            }

            return result;
        }

        public static (string, string) GetScoreValue(this string s)
        {
            var array = s.Split('|');

            if (array.Length == 2)
            {
                return (array[0], array[1].ToHtml());
            }
            else if (array.Length == 1)
            {
                return (string.Empty, array[0].ToHtml());
            }
            else
            {
                return (array[0], s.Remove(0, array[0].Length + 1).ToHtml());
            }
        }

        public static bool AreTelegramFeaturesPresent(this Aspect aspect)
        {
            foreach (var feature in aspect.Features)
                if (!string.IsNullOrEmpty(feature.Telegram))
                    return true;
            return false;
        }

        public static bool AreViberFeaturesPresent(this Aspect aspect)
        {
            foreach (var feature in aspect.Features)
                if (!string.IsNullOrEmpty(feature.Viber))
                    return true;
            return false;
        }

        public static bool AreWhatsAppFeaturesPresent(this Aspect aspect)
        {
            foreach (var feature in aspect.Features)
                if (!string.IsNullOrEmpty(feature.WhatsApp))
                    return true;
            return false;
        }

        public static DateTime ToDateTime(this string unixTimeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0,
                                       System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(Convert.ToDouble(unixTimeStamp));
            
            return dateTime;
        }

        public static string ToUrlString(this string inputString)
        {
            return HttpUtility.UrlEncode(inputString.Replace(' ', '-'));
        }
    }
}