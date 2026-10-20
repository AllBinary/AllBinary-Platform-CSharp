/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using Calendar = java.util.Calendar;

namespace org.allbinary.time;

public class TimeUtil
{
    private static readonly TimeUtil instance = new TimeUtil();
    public static TimeUtil getInstance()
    {
        return TimeUtil.instance;
    }

    public virtual void setCalendar(Calendar calendar, string yearString, string monthString, string dayString, string hourString)
    {
        int year = ((int) yearString);
        int month = ((int) monthString);
        int day = ((int) dayString);
        int hour = ((int) hourString);
        calendar.set(year, month, day, hour, 0);
    }

    public virtual void setCalendar(Calendar calendar, string yearString, string monthString, string dayString, string hourString, string minuteString, string secondString)
    {
        int year = ((int) yearString);
        int month = ((int) monthString);
        int day = ((int) dayString);
        int hour = ((int) hourString);
        int minute = ((int) minuteString);
        int second = ((int) secondString);
        calendar.set(year, month, day, hour, minute, second);
    }

    public virtual void setExpirationCalendar(Calendar calendar, string yearsString, string monthsString, string daysString, string hoursString, string minutesString, string secondsString)
    {
        int year = calendar.get(Calendar.YEAR) + ((int) yearsString);
        int month = calendar.get(Calendar.MONTH) + ((int) monthsString);
        int day = calendar.get(Calendar.DAY_OF_MONTH) + ((int) daysString);
        int hour = calendar.get(Calendar.HOUR) + ((int) hoursString);
        int minute = calendar.get(Calendar.MINUTE) + ((int) minutesString);
        int second = calendar.get(Calendar.SECOND) + ((int) secondsString);
        calendar.set(year, month, day, hour, minute, second);
    }

    private static readonly Calendar calendar = Calendar.getInstance();
    public virtual long getTotalTime(string yearString, string monthString, string dayString, string hourString, string minuteString, string secondString)
    {
        long time = TimeUtil.calendar.getTimeInMillis();
        this.setExpirationCalendar(TimeUtil.calendar, yearString, monthString, dayString, hourString, minuteString, secondString);
        long timeDelta = TimeUtil.calendar.getTimeInMillis();
        return timeDelta - time;
    }

}

