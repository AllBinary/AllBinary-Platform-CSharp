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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using MachineAccessControlAddressInterface = org.allbinary.logic.system.hardware.components.interfaces.MachineAccessControlAddressInterface;

namespace org.allbinary.logic.system.hardware.components.linux;

public class MachineAccessControlAddress : HardwareComponentInterface, MachineAccessControlAddressInterface
{
    public MachineAccessControlAddress()
    {
    }

    public virtual bool compareTo(HardwareComponentInterface componentInterface)
    {
        return true;
    }

    public override string ToString()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

}

