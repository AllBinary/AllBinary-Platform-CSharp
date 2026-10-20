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
using Date = java.util.Date;

namespace org.allbinary.time;

//NoPlatform
public class TimeStampUtil
{
    private static readonly TimeStampUtil instance = new TimeStampUtil();
    public static TimeStampUtil getInstance()
    {
        return TimeStampUtil.instance;
    }

    private TimeStampUtil()
    {
    }

    public virtual string getAsString()
    {
        throw new SystemException();
    }

}

