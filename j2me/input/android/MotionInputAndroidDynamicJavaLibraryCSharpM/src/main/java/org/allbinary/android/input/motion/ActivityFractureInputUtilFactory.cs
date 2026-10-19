/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2009 AllBinary
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
using ActivityFractureUtil = org.allbinary.android.ActivityFractureUtil;
using AndroidInfoFactory = org.allbinary.android.AndroidInfoFactory;
using ActivityFractureUtilAPI1 = org.allbinary.android.api1.ActivityFractureUtilAPI1;
using ActivityFractureUtilAPI16 = org.allbinary.android.api16.ActivityFractureUtilAPI16;
using ActivityFractureUtilAPI19 = org.allbinary.android.api19.ActivityFractureUtilAPI19;
using ActivityFractureUtilAPI5 = org.allbinary.android.api5.ActivityFractureUtilAPI5;

namespace org.allbinary.android.input.motion;

public class ActivityFractureInputUtilFactory
{
    public static ActivityFractureUtil getInstance()
    {
        int SDK_VERSION = AndroidInfoFactory.getInstance().getVersion();
        if (SDK_VERSION <= 4) {
            return ActivityFractureUtilAPI1.getInstance();
        } else if (SDK_VERSION <= 15) {
            return ActivityFractureUtilAPI5.getInstance();
        } else if (SDK_VERSION <= 16) {
            return ActivityFractureUtilAPI16.getInstance();
        } else {
            return ActivityFractureUtilAPI19.getInstance();
        }
    }

}

