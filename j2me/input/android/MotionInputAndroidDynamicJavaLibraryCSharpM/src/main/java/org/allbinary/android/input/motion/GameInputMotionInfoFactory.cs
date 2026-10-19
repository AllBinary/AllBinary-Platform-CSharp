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
using AndroidInfoFactory = org.allbinary.android.AndroidInfoFactory;
using GameInputMotionInfoAPI1 = org.allbinary.android.input.motion.api1.GameInputMotionInfoAPI1;
using GameInputMotionInfoAPI5 = org.allbinary.android.input.motion.api5.GameInputMotionInfoAPI5;

namespace org.allbinary.android.input.motion;

public class GameInputMotionInfoFactory
{
    public static GameInputMotionInfo getInstance()
    {
        int SDK_VERSION = AndroidInfoFactory.getInstance().getVersion();
        if (SDK_VERSION <= 4) {
            return GameInputMotionInfoAPI1.getInstance();
        } else {
            return GameInputMotionInfoAPI5.getInstance();
        }
    }

}

