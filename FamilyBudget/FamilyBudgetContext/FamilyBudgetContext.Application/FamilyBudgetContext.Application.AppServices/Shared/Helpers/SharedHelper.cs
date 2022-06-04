using System;

namespace FamilyBudgetContext.Application.AppServices.Shared.Helpers;

public static class SharedHelper
{
    public static DateTime UnixTimeStampToDateTime(this long unixTimeStamp)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToUniversalTime();
        return dateTime;
    }
    
    public static long DateTimeToUnixTimeStamp(this DateTime dateTime)
    {
        return ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds();
    }
}