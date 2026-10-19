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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.system.hardware.components.interfaces;

public class NoHardwareComponent : HardwareComponentInterface
{
    private static readonly NoHardwareComponent instance = new NoHardwareComponent();
    public static NoHardwareComponent getInstance()
    {
        return NoHardwareComponent.instance;
    }

    public virtual bool compareTo(HardwareComponentInterface componentInterface)
    {
        if (this == componentInterface) {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return StringUtil.getInstance().NULL_STRING;
    }

}

