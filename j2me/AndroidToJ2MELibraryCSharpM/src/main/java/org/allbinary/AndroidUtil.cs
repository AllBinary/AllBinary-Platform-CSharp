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
using Activity = android.app.Activity;
using Build = android.os.Build;

namespace org.allbinary;

public class AndroidUtil
{
    public static readonly Activity NULL_ACTIVITY = new Activity();
    private static readonly int version = int.Parse(Build.VERSION.SDK);
    public static bool isMemoryRestrictive()
    {
        if (AndroidUtil.version < 30) {
            return true;
        }
        return false;
    }

    public static bool isAndroid()
    {
        return true;
    }

}

