using System;

namespace Common.TypeManagement
{
    public class TypeManagement
    {
        public static DateTime? TryParseDateTime(string value)
        {
            DateTime date;
            if (DateTime.TryParse(value, out date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }

        public static int? TryParseInt(string value)
        {
            int number;
            if (int.TryParse(value, out number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }
    }
}
