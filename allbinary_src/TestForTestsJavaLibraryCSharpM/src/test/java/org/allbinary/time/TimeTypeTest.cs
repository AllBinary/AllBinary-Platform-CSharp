// Generated Code Do Not Modify

using System;
using System.Linq;
//using Calendar = java.util.Calendar;
using Assertions = org.junit.jupiter.api.Assertions;
using DisplayName = org.junit.jupiter.api.DisplayName;
using Test = org.junit.jupiter.api.Test;

namespace org.allbinary.time;

public class TimeTypeTest
{
    private static long millisForHourLocal(int hour)
    {
        Calendar cal = Calendar.getInstance();
        cal.set(Calendar.HOUR_OF_DAY, hour);
        cal.set(Calendar.MINUTE, 0);
        cal.set(Calendar.SECOND, 0);
        cal.set(Calendar.MILLISECOND, 0);
        return cal.getTimeInMillis();
    }

    private class TestableTimeTypeUtil : TimeTypeUtil
    {
        private readonly int hour;
        public TestableTimeTypeUtil(int hour)
        {
            this.hour = hour;
        }

        public override int getHourOfDay()
        {
            return this.hour;
        }

    }
    public virtual void isNight_returnsTrue_for_hours_less_than_6()
    {
        /* Otherwise - statement - ForEachStmt */
    }

    public virtual void isNight_returnsTrue_for_hours_greater_than_18()
    {
        /* Otherwise - statement - ForEachStmt */
    }

    public virtual void isNight_returnsFalse_for_boundary_hours_6_and_18()
    {
        /* Otherwise - statement - ForEachStmt */
    }

    public virtual void getNightOrDay_returns_expected_label()
    {
        TimeTypeUtil nightUtil = new TestableTimeTypeUtil(0);
        Assertions.assertEquals(nightUtil.NIGHT, nightUtil.getNightOrDay());
        TimeTypeUtil dayUtil = new TestableTimeTypeUtil(12);
        Assertions.assertEquals(dayUtil.DAY, dayUtil.getNightOrDay());
    }

    public virtual void getHourOfDay_long_converts_epoch_to_local_hour()
    {
        TimeTypeUtil util = new TimeTypeUtil();
        /* Otherwise - statement - ForEachStmt */
    }

    public virtual void isNight_long_expected_ranges()
    {
        TimeTypeUtil util = new TimeTypeUtil();
        /* Otherwise - statement - ForEachStmt */
        /* Otherwise - statement - ForEachStmt */
    }

    public virtual void getNightOrDay_long_consistency()
    {
        TimeTypeUtil util = new TimeTypeUtil();
        long nightMillis = TimeTypeTest.millisForHourLocal(0);
        long dayMillis = TimeTypeTest.millisForHourLocal(12);
        Assertions.assertEquals(util.NIGHT, util.getNightOrDay(nightMillis));
        Assertions.assertEquals(util.DAY, util.getNightOrDay(dayMillis));
    }

    public virtual void boundaries_day_for_long_based_api()
    {
        TimeTypeUtil util = new TimeTypeUtil();
        /* Otherwise - statement - ForEachStmt */
    }

    public virtual void constants_accessible_and_stable()
    {
        TimeTypeUtil util = new TimeTypeUtil();
        Assertions.assertEquals("Night", util.NIGHT);
        Assertions.assertEquals("Day", util.DAY);
    }

    public virtual void getInstance_returns_same_singleton()
    {
        TimeTypeUtil a = TimeTypeUtil.getInstance();
        TimeTypeUtil b = TimeTypeUtil.getInstance();
        Assertions.assertSame(a, b);
    }

}

