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
//using Closeable = java.io.Closeable;
//using FileReader = java.io.FileReader;
//using LineNumberReader = java.io.LineNumberReader;
using NullCloseable = org.allbinary.logic.io.NullCloseable;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using HardwareInterface = org.allbinary.logic.system.hardware.HardwareInterface;
using UnknownHardware = org.allbinary.logic.system.hardware.components.android.UnknownHardware;
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.system.hardware.android;

public class AndroidHardware : HardwareInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private BasicArrayList componentInterfaceVector = new BasicArrayListD();
    private readonly string PROC_BUS_INPUT_DIRECTORY = "/proc/bus/input/";
    private readonly string DEVICES;
    private readonly int MINHARDWARE = 3;
    public AndroidHardware()
    {
        this.DEVICES = this.PROC_BUS_INPUT_DIRECTORY + "devices/";
        this.init(this.DEVICES);
        int size = this.componentInterfaceVector.size();
        if (size < this.MINHARDWARE) {
            throw new Exception("Not Enough Data For A Valid License On Linux");
        }
    }

    // throws Exception
    private void init(string filePath)
    {
        Closeable lineNumberReader = NullCloseable.NULL_CLOSEABLE;
        try {
            lineNumberReader = this.get(filePath);
        } catch (Exception e) {
            this.logUtil.put("Hardware Data: " + this.ToString(), this, this.commonStrings.INIT, e);
            throw e;
        } finally {
            if (lineNumberReader != null) {
                lineNumberReader.close();
            }
        }
    }

    // throws Exception
    private LineNumberReader get(string filePath)
    {
        this.componentInterfaceVector = new BasicArrayListD();
        FileReader pciFile = new FileReader(filePath);
        LineNumberReader lineNumberReader = new LineNumberReader(pciFile);
        this.logUtil.putF("File Found", this, this.commonStrings.CONSTRUCTOR);
        string nextLine = lineNumberReader.readLine();
        while (nextLine != null) {
            nextLine = lineNumberReader.readLine();
            this.componentInterfaceVector.add(new UnknownHardware(nextLine));
        }
        return lineNumberReader;
    }

    public virtual HardwareComponentInterface getComponent(int index)
    {
        return ((HardwareComponentInterface) this.componentInterfaceVector.get(index));
    }

    public override string ToString()
    {
        StringMaker stringBuilder = new StringMaker();
        int size = this.componentInterfaceVector.size();
        for (int index = 0; index < size; index++) {
            HardwareComponentInterface componentInterface = ((HardwareComponentInterface) this.componentInterfaceVector.get(index));
            stringBuilder.append(componentInterface.ToString());
            stringBuilder.append(CommonSeps.getInstance().NEW_LINE);
        }
        return stringBuilder.ToString();
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

