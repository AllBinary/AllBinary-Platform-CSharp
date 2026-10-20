// Generated Code Do Not Modify

using System;
using System.Linq;
using Calendar = java.util.Calendar;
//using TimeZone = java.util.TimeZone;

namespace org.allbinary.time;

public class TimeTypeUtil
{
    private static readonly TimeTypeUtil instance = new TimeTypeUtil();
    public static TimeTypeUtil getInstance()
    {
        return TimeTypeUtil.instance;
    }

    public readonly string NIGHT = "Night";
    public readonly string DAY = "Day";
    public virtual bool isNight()
    {
        int hoursOfDay = this.getHourOfDay();
        return hoursOfDay < 6 || hoursOfDay > 18;
    }

    public virtual int getHourOfDay()
    {
        Calendar calendar = Calendar.getInstance();
        return calendar.get(Calendar.HOUR_OF_DAY);
    }

    public virtual string getNightOrDay()
    {
        return (this.isNight() ? this.NIGHT : this.DAY);
    }

    public virtual int getHourOfDay(long timeInMillis)
    {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(timeInMillis);
        return calendar.get(Calendar.HOUR_OF_DAY);
    }

    public virtual bool isNight(long timeInMillis)
    {
        int hoursOfDay = this.getHourOfDay(timeInMillis);
        return hoursOfDay < 6 || hoursOfDay > 18;
    }

    public virtual string getNightOrDay(long timeInMillis)
    {
        return (this.isNight(timeInMillis) ? this.NIGHT : this.DAY);
    }

}

