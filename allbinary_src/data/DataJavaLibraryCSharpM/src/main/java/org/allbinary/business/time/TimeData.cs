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

namespace org.allbinary.business.time;

public class TimeData
{
    private static readonly TimeData instance = new TimeData();
    public static TimeData getInstance()
    {
        return TimeData.instance;
    }

    private TimeData()
    {
    }

    public readonly string NAME = "TIME_NAME";
    public readonly string START = "TIME_START";
    public readonly string END = "TIME_END";
}

