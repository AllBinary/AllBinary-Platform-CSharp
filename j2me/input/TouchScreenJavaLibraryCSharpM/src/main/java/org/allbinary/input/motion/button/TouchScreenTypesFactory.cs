/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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

public class TouchScreenTypesFactory
{
    private static readonly TouchScreenTypesFactory instance = new TouchScreenTypesFactory();
    public static TouchScreenTypesFactory getInstance()
    {
        return TouchScreenTypesFactory.instance;
    }

    public readonly TouchScreenType FINGER = new TouchScreenType("Finger");
    public readonly TouchScreenType NOTOUCH = new TouchScreenType("No Touch");
    public readonly TouchScreenType STYLUS = new TouchScreenType("Stylus");
    public readonly TouchScreenType UNDEFINED = new TouchScreenType("Undefined");
}

