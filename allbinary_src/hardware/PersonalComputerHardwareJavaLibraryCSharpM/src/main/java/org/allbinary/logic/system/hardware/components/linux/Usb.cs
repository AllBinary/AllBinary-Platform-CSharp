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
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using UsbInterface = org.allbinary.logic.system.hardware.components.interfaces.UsbInterface;

namespace org.allbinary.logic.system.hardware.components.linux;

public class Usb : HardwareComponentInterface, UsbInterface
{
    private string data;
    public Usb(string data)
    {
        this.data = data;
    }

    public virtual bool compareTo(HardwareComponentInterface componentInterface)
    {
        return true;
    }

    public override string ToString()
    {
        return this.data;
    }

}

