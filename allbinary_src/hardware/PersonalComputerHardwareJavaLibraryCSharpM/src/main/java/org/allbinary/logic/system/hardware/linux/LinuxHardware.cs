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
//using FileReader = java.io.FileReader;
//using LineNumberReader = java.io.LineNumberReader;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FilePathData = org.allbinary.logic.io.file.FilePathData;
using SubDirectory = org.allbinary.logic.io.file.directory.SubDirectory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
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
using Cpu = org.allbinary.logic.system.hardware.components.linux.Cpu;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.system.hardware.linux;

public class LinuxHardware : HardwareInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
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
    private static readonly string PCIFILE = "/proc/pci";
    private readonly string NAME = "Linux Hardware Profile";
    private readonly int MINHARDWARE = 5;
    public LinuxHardware(string path)
    {
        this.init(path);
    }

    public LinuxHardware()
    {
        this.init(PCIFILE);
        if (this.componentInterfaceVector.size() < this.MINHARDWARE) {
            throw new Exception("Not Enough Data For A Valid License On Linux");
        }
        Cpu cpu = new Cpu();
        if (cpu != null) {
            this.cpuInterfaceVector.add(cpu);
            this.componentInterfaceVector.add(cpu);
        }
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().OS)) {
            this.logUtil.putF("Hardware Data: " + this.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    private void init(string filePath)
    {
        LineNumberReader lineNumberReader = null;
        try {
            this.init(lineNumberReader, filePath);
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().OS)) {
                this.logUtil.put("Hardware Data: " + this.ToString(), this, this.commonStrings.CONSTRUCTOR, e);
            }
            throw e;
        }
    }

    // throws Exception
    private void init(LineNumberReader lineNumberReader, string filePath)
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
            FileReader pciFile = new FileReader(filePath);
            lineNumberReader = new LineNumberReader(pciFile);
            if (lineNumberReader == null) {
                BasicArrayList fileVector = SubDirectory.getInstance().search(filePath, AbFile.createAbFile(FilePathData.getInstance().PATH_START));
                if (!fileVector.isEmpty()) {
                    AbFile file = ((AbFile) fileVector.get(0));
                    lineNumberReader = new LineNumberReader(new FileReader(file.getPath()));
                }
                if (lineNumberReader == null) {
                    throw new Exception("No Linux File Data");
                }
            }
            if (lineNumberReader != null) {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().OS)) {
                    this.logUtil.putF("PCI File Found", this, this.commonStrings.CONSTRUCTOR);
                }
                string nextLine = lineNumberReader.readLine();
                while (lineNumberReader != null && nextLine != null) {
                    if (this.isNextHardware(nextLine)) {
                        break;
                    }
                    nextLine = lineNumberReader.readLine();
                }
                while (this.isNextHardware(nextLine)) {
                    StringMaker componentData = new StringMaker();
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().OS)) {
                        this.logUtil.putF("Found Hardware Device: " + this.componentInterfaceVector.size(), this, this.commonStrings.CONSTRUCTOR);
                    }
                    componentData.append(nextLine);
                    componentData.append(CommonSeps.getInstance().NEW_LINE);
                    nextLine = lineNumberReader.readLine();
                    string componentType = PCComponentFactory.getInstance().getComponentType(nextLine);
                    while (lineNumberReader != null) {
                        componentData.append(nextLine);
                        componentData.append(CommonSeps.getInstance().NEW_LINE);
                        nextLine = lineNumberReader.readLine();
                        if (nextLine == null || this.isNextHardware(nextLine)) {
                            break;
                        }
                    }
                    HardwareComponentInterface componentInterface = PCComponentFactory.getInstance().getInstance(componentType, componentData.ToString());
                    if (componentInterface != null) {
                        this.componentInterfaceVector.add(componentInterface);
                    }
                }
            } else {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().OS)) {
                    this.logUtil.putF("Could not load PCI File", this, this.commonStrings.CONSTRUCTOR);
                }
            }
            lineNumberReader.close();
        } finally {
            if (lineNumberReader != null) {
                lineNumberReader.close();
            }
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
            hardwareBuffer.append("Component ");
            hardwareBuffer.appendint(index);
            hardwareBuffer.append(": \n");
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

    public virtual bool isNextHardware(string nextLine)
    {
        if (nextLine != null) {
            int index = nextLine.IndexOf("Bus");
            if (index >= 0 && index < 4) {
                return true;
            }
        }
        return false;
    }

}

