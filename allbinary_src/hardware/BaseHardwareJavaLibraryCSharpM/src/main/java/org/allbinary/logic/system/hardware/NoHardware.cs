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
using StdUtil = org.allbinary.logic.StdUtil;
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using NoHardwareComponent = org.allbinary.logic.system.hardware.components.interfaces.NoHardwareComponent;
using org.allbinary.util;

namespace org.allbinary.logic.system.hardware;

public class NoHardware : HardwareInterface
{
    private static readonly HardwareInterface instance = new NoHardware();
    public static HardwareInterface getInstance()
    {
        return NoHardware.instance;
    }

    public virtual HardwareComponentInterface getComponent(int index)
    {
        return NoHardwareComponent.getInstance();
    }

    public override string ToString()
    {
        return "No Hardware";
    }

    public virtual bool compareTo(HardwareInterface hardwareInterface)
    {
        return true;
    }

    public virtual ABHashtable<object, object> difference(HardwareInterface hardwareInterface)
    {
        return StdUtil.getInstance().NULL_TABLE;
    }

}

