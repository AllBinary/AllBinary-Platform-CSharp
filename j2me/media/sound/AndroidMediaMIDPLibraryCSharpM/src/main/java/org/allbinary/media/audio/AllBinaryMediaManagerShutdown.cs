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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.media.audio;

public class AllBinaryMediaManagerShutdown
{
    private static readonly AllBinaryMediaManagerShutdown instance = new AllBinaryMediaManagerShutdown();
    // throws Exception
    public static void shutdown(SoundsFactoryInterface soundsFactoryInterface)
    {
        LogUtil logUtil = LogUtil.getInstance();
        logUtil.putF("No Media Shutdown for Android Process", AllBinaryMediaManagerShutdown.instance, "shutdown");
    }

}

