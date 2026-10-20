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
using GameInputMotionInfo = org.allbinary.android.input.motion.GameInputMotionInfo;

namespace org.allbinary.android.input.motion.api5;

public class GameInputMotionInfoAPI5 : GameInputMotionInfo
{
    private static readonly GameInputMotionInfoAPI5 instance = new GameInputMotionInfoAPI5();
    public static GameInputMotionInfoAPI5 getInstance()
    {
        return GameInputMotionInfoAPI5.instance;
    }

    private GameInputMotionInfoAPI5() : base(int.MaxValue, 10)
    {
        // base(int.MaxValue, 10) is called from the constructor declaration
    }

}

