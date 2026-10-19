/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2007 AllBinary 
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
using TouchButtonBlankResource = org.allbinary.input.motion.button.TouchButtonBlankResource;
using TouchButtonResource = org.allbinary.input.motion.button.TouchButtonResource;

namespace org.allbinary.game.input.resource;

public class TouchButtonDowngradeResource : TouchButtonResource
{
    private static readonly TouchButtonResource instance = new TouchButtonDowngradeResource();
    public static TouchButtonResource getInstance()
    {
        return TouchButtonDowngradeResource.instance;
    }

    private TouchButtonDowngradeResource() : base("/touch_button_downgrade_64_by_64.png", "/touch_button_downgrade_hint_64_by_64.png")
    {
        // base("/touch_button_downgrade_64_by_64.png", "/touch_button_downgrade_hint_64_by_64.png") is called from the constructor declaration
    }

}

