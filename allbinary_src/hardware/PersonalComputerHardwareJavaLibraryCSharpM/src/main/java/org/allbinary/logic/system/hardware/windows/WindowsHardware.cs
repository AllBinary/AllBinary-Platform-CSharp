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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using HardwareInterface = org.allbinary.logic.system.hardware.HardwareInterface;
using ComponentFactory = org.allbinary.logic.system.hardware.components.ComponentFactory;
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
using CommonSeps = org.allbinary.@string.CommonSeps;
using org.allbinary.util;

namespace org.allbinary.logic.system.hardware.windows;

public class WindowsHardware : HardwareInterface
{
    private BasicArrayList componentInterfaceVector = null;
    private BasicArrayList videoInterfaceVector = null;
    private BasicArrayList hardDriveControllerInterfaceVector = null;
    private BasicArrayList cpuInterfaceVector = null;
    private BasicArrayList usbInterfaceVector = null;
    private BasicArrayList ethernetInterfaceVector = null;
    private BasicArrayList multimediaInterfaceVector = null;
    private BasicArrayList fireWireInterfaceVector = null;
    private BasicArrayList bridgeInterfaceVector = null;
    private BasicArrayList hardDriveInterfaceVector = null;
    private BasicArrayList macInterfaceVector = null;
    private BasicArrayList monitorInterfaceVector = null;
    private readonly string NAME = "Windows Hardware Profile";
    private readonly int MINHARDWARE = 0;
    private readonly ComponentFactory componentFactory = ComponentFactory.getInstance();
    public WindowsHardware()
    {
        try {
            this.componentInterfaceVector = new BasicArrayListD();
            this.videoInterfaceVector = new BasicArrayListD();
            this.hardDriveControllerInterfaceVector = new BasicArrayListD();
            this.cpuInterfaceVector = new BasicArrayListD();
            this.usbInterfaceVector = new BasicArrayListD();
            this.ethernetInterfaceVector = new BasicArrayListD();
            this.multimediaInterfaceVector = new BasicArrayListD();
            this.fireWireInterfaceVector = new BasicArrayListD();
            this.bridgeInterfaceVector = new BasicArrayListD();
            this.hardDriveInterfaceVector = new BasicArrayListD();
            this.macInterfaceVector = new BasicArrayListD();
            this.monitorInterfaceVector = new BasicArrayListD();
            if (this.componentInterfaceVector.size() < this.MINHARDWARE) {
                throw new Exception("Not Enough Data For A Valid License On Windows");
            }
        } catch (Exception e) {
            throw e;
        }
    }

    private string getComponentType(string component)
    {
        if (component.IndexOf(this.componentFactory.ETHERNET.ToString()) >= 0) {
            return this.componentFactory.ETHERNET.ToString();
        } else if (component.IndexOf(this.componentFactory.BRIDGE.ToString()) >= 0) {
            return this.componentFactory.BRIDGE.ToString();
        } else if (component.IndexOf(this.componentFactory.IDE.ToString()) >= 0) {
            return this.componentFactory.IDE.ToString();
        } else if (component.IndexOf(this.componentFactory.MULTIMEDIA.ToString()) >= 0) {
            return this.componentFactory.MULTIMEDIA.ToString();
        } else if (component.IndexOf(this.componentFactory.SCSI.ToString()) >= 0) {
            return this.componentFactory.SCSI.ToString();
        } else if (component.IndexOf(this.componentFactory.USB.ToString()) >= 0) {
            return this.componentFactory.USB.ToString();
        } else if (component.IndexOf(this.componentFactory.VGA.ToString()) >= 0) {
            return this.componentFactory.VGA.ToString();
        } else {
            return null;
        }
    }

    public virtual MediaInterface getMultimedia(int index)
    {
        return ((MediaInterface) this.multimediaInterfaceVector.get(index));
    }

    public virtual BridgeInterface getBridge(int index)
    {
        return ((BridgeInterface) this.bridgeInterfaceVector.get(index));
    }

    public virtual CpuInterface getCpu(int index)
    {
        return ((CpuInterface) this.cpuInterfaceVector.get(index));
    }

    public virtual EthernetInterface getEthernet(int index)
    {
        return ((EthernetInterface) this.ethernetInterfaceVector.get(index));
    }

    public virtual FireWireInterface getFireWire(int index)
    {
        return ((FireWireInterface) this.fireWireInterfaceVector.get(index));
    }

    public virtual HardDriveControllerInterface getHardDriveController(int index)
    {
        return ((HardDriveControllerInterface) this.hardDriveControllerInterfaceVector.get(index));
    }

    public virtual HardDriveInterface getHardDrive(int index)
    {
        return ((HardDriveInterface) this.hardDriveInterfaceVector.get(index));
    }

    public virtual MachineAccessControlAddressInterface getMachineAccessControlAddress(int index)
    {
        return ((MachineAccessControlAddressInterface) this.macInterfaceVector.get(index));
    }

    public virtual MonitorInterface getMonitor(int index)
    {
        return ((MonitorInterface) this.monitorInterfaceVector.get(index));
    }

    public virtual UsbInterface getUsb(int index)
    {
        return ((UsbInterface) this.usbInterfaceVector.get(index));
    }

    public virtual VideoInterface getVideo(int index)
    {
        return ((VideoInterface) this.videoInterfaceVector.get(index));
    }

    public virtual HardwareComponentInterface getComponent(int index)
    {
        return ((HardwareComponentInterface) this.componentInterfaceVector.get(index));
    }

    public override string ToString()
    {
        StringMaker hardwareBuffer = new StringMaker();
        int size = this.componentInterfaceVector.size();
        for (int index = 0; index < size; index++) {
            HardwareComponentInterface componentInterface = ((HardwareComponentInterface) this.componentInterfaceVector.get(index));
            hardwareBuffer.append(componentInterface.ToString());
            hardwareBuffer.append(CommonSeps.getInstance().NEW_LINE);
        }
        return hardwareBuffer.ToString();
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

