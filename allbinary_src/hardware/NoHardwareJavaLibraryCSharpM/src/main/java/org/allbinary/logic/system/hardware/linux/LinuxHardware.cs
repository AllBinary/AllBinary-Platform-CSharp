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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using HardwareInterface = org.allbinary.logic.system.hardware.HardwareInterface;
using BridgeInterface = org.allbinary.logic.system.hardware.components.interfaces.BridgeInterface;
using CpuInterface = org.allbinary.logic.system.hardware.components.interfaces.CpuInterface;
using EthernetInterface = org.allbinary.logic.system.hardware.components.interfaces.EthernetInterface;
using FireWireInterface = org.allbinary.logic.system.hardware.components.interfaces.FireWireInterface;
using HardDriveControllerInterface = org.allbinary.logic.system.hardware.components.interfaces.HardDriveControllerInterface;
using HardDriveInterface = org.allbinary.logic.system.hardware.components.interfaces.HardDriveInterface;
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using MachineAccessControlAddressInterface = org.allbinary.logic.system.hardware.components.interfaces.MachineAccessControlAddressInterface;
using MediaInterface = org.allbinary.logic.system.hardware.components.interfaces.MediaInterface;
using MonitorInterface = org.allbinary.logic.system.hardware.components.interfaces.MonitorInterface;
using UsbInterface = org.allbinary.logic.system.hardware.components.interfaces.UsbInterface;
using VideoInterface = org.allbinary.logic.system.hardware.components.interfaces.VideoInterface;
using org.allbinary.util;

namespace org.allbinary.logic.system.hardware.linux;

public class LinuxHardware : HardwareInterface
{
    public LinuxHardware()
    {
    }

    public virtual MediaInterface getMultimedia(int index)
    {
        throw new SystemException();
    }

    public virtual BridgeInterface getBridge(int index)
    {
        throw new SystemException();
    }

    public virtual CpuInterface getCpu(int index)
    {
        throw new SystemException();
    }

    public virtual EthernetInterface getEthernet(int index)
    {
        throw new SystemException();
    }

    public virtual FireWireInterface getFireWire(int index)
    {
        throw new SystemException();
    }

    public virtual HardDriveControllerInterface getHardDriveController(int index)
    {
        throw new SystemException();
    }

    public virtual HardDriveInterface getHardDrive(int index)
    {
        throw new SystemException();
    }

    public virtual MachineAccessControlAddressInterface getMachineAccessControlAddress(int index)
    {
        throw new SystemException();
    }

    public virtual MonitorInterface getMonitor(int index)
    {
        throw new SystemException();
    }

    public virtual UsbInterface getUsb(int index)
    {
        throw new SystemException();
    }

    public virtual VideoInterface getVideo(int index)
    {
        throw new SystemException();
    }

    public virtual HardwareComponentInterface getComponent(int index)
    {
        throw new SystemException();
    }

    public override string ToString()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual bool compareTo(HardwareInterface hardwareInterface)
    {
        return true;
    }

    public virtual ABHashtable<object, object> difference(HardwareInterface hardwareInterface)
    {
        return StdUtil.getInstance().NULL_TABLE;
    }

    public virtual bool isNextHardware(string nextLine)
    {
        return false;
    }

}

