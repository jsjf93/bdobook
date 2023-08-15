using System;

namespace BDOBook.App.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static string ToPrettyString(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString("dddd, MMMM d, yyyy h:mm tt");
        }
    }
}
