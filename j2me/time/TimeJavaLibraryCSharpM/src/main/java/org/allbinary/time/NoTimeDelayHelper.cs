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

namespace org.allbinary.time;

public class NoTimeDelayHelper : TimeDelayHelper
{
    public static readonly NoTimeDelayHelper SINGLETON = new NoTimeDelayHelper();
    public NoTimeDelayHelper() : base(0)
    {
        // base(0) is called from the constructor declaration
    }

    public override bool isTimeTNT()
    {
        return true;
    }

    public override bool isTimeSinceTNT(int delay)
    {
        return true;
    }

    public override bool isTime(long currentTime)
    {
        return true;
    }

    public override bool isTimeSince(int delay, long currentTime)
    {
        return true;
    }

}

