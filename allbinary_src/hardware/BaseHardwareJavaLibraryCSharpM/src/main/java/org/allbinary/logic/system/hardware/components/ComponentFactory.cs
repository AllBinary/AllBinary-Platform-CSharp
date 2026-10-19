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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.hardware.components;

public class ComponentFactory
{
    private static readonly ComponentFactory instance = new ComponentFactory();
    public static ComponentFactory getInstance()
    {
        return ComponentFactory.instance;
    }

    public readonly Component VGA = new Component("VGA");
    public readonly Component IDE = new Component("IDE");
    public readonly Component SCSI = new Component("SCSI");
    public readonly Component BRIDGE = new Component("bridge");
    public readonly Component ETHERNET = new Component("Ethernet");
    public readonly Component USB = new Component("USB");
    public readonly Component MULTIMEDIA = new Component("Multimedia");
    public readonly Component PCI = new Component("PCI");
    public readonly Component RAID = new Component("RAID");
    public readonly Component SMBUS = new Component("SMBus");
    public readonly Component PIC = new Component("PIC");
    public readonly Component Class = new Component("Class");
    public readonly Component UNKNOWN = new Component(CommonStrings.getInstance().UNKNOWN);
}

