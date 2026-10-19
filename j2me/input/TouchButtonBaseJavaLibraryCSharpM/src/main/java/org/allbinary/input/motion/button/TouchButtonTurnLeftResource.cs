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

namespace org.allbinary.input.motion.button;

public class TouchButtonTurnLeftResource : TouchButtonResource
{
    private static readonly TouchButtonResource instance = new TouchButtonTurnLeftResource();
    public static TouchButtonResource getInstance()
    {
        return TouchButtonTurnLeftResource.instance;
    }

    private TouchButtonTurnLeftResource() : base("/touch_button_turn_left_arrow_64_by_64.png", "/touch_button_turn_left_arrow_hint_64_by_64.png")
    {
        // base("/touch_button_turn_left_arrow_64_by_64.png", "/touch_button_turn_left_arrow_hint_64_by_64.png") is called from the constructor declaration
    }

}

