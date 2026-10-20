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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.time;

public class TimeDelayHelper
{
    private long startTime = ((long) (-1));
    private long elapsedTimeAtPause = long.MinValue;
    public int delay;
    public TimeDelayHelper(int delay)
    {
        this.delay = delay;
        this.setStartTimeTNT();
    }

    public virtual bool isTimeTNT()
    {
        long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (currentTime - this.startTime > ((long) this.delay)) {
            this.startTime = currentTime;
            return true;
        }
        return false;
    }

    public virtual bool isTimeSinceTNT(int delay)
    {
        long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (currentTime - this.startTime > ((long) delay)) {
            this.startTime = currentTime;
            return true;
        }
        return false;
    }

    public virtual bool isTime(long currentTime)
    {
        if (currentTime - this.startTime > ((long) this.delay)) {
            this.startTime = currentTime;
            return true;
        }
        return false;
    }

    public virtual bool isTimeWithoutReset(long currentTime)
    {
        if (currentTime - this.startTime > ((long) this.delay)) {
            return true;
        }
        return false;
    }

    public virtual bool isTimeSince(int delay, long currentTime)
    {
        if (currentTime - this.startTime > ((long) this.delay)) {
            this.startTime = currentTime;
            return true;
        }
        return false;
    }

    public virtual long getElapsedTNT()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.startTime;
    }

    public virtual long getElapsed(long currentTime)
    {
        return currentTime - this.startTime;
    }

    public virtual bool isElapsed(long currentTime, long time)
    {
        if (this.getElapsed(currentTime) > time) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool isElapsedTNT(long time)
    {
        if (this.getElapsedTNT() > time) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void setStartTime(long startTime)
    {
        this.startTime = startTime;
    }

    public virtual long getStartTime()
    {
        return this.startTime;
    }

    public virtual void setStartTimeTNT()
    {
        this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }

    public virtual void pause()
    {
        this.elapsedTimeAtPause = this.getElapsedTNT();
        this.startTime = long.MaxValue;
    }

    public virtual bool resume()
    {
        if (this.elapsedTimeAtPause != long.MinValue) {
            this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + this.elapsedTimeAtPause;
            this.elapsedTimeAtPause = long.MinValue;
            this.setStartTimeTNT();
            return true;
        }
        return false;
    }

    public virtual string toStringAt(long currentTime)
    {
        long elapsed = this.getElapsed(currentTime);
        if (elapsed > 0L) {
            CommonLabels commonLabels = CommonLabels.getInstance();
            string elapsedAsString = (elapsed).ToString();
            return new StringMaker().append(commonLabels.START).appendlong(this.startTime).append(commonLabels.CURRENT).appendlong(currentTime).append(commonLabels.ELAPSED).append(elapsedAsString).ToString();
        } else {
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

    public override string ToString()
    {
        long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        long elapsed = this.getElapsed(currentTime);
        if (elapsed > 0L) {
            CommonLabels commonLabels = CommonLabels.getInstance();
            string elapsedAsString = (elapsed).ToString();
            return new StringMaker().append(commonLabels.START).appendlong(this.startTime).append(commonLabels.CURRENT).appendlong(currentTime).append(commonLabels.ELAPSED).append(elapsedAsString).ToString();
        } else {
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

}

