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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.hardware;

public class SystemHardwareFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly SystemHardwareFactory instance = new SystemHardwareFactory();
    public static SystemHardwareFactory getInstance()
    {
        return SystemHardwareFactory.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private HardwareInterface hardwareInterface = NoHardware.getInstance();
    private SystemHardwareFactory()
    {
    }

    public virtual HardwareInterface getInstance(GenericOperatingSystem operatingSystemInterface)
    {
        try {
            if (this.hardwareInterface == NoHardware.getInstance()) {
                this.hardwareInterface = HardwareFactory.getInstance().getInstance(operatingSystemInterface);
            }
            this.logUtil.putF("Found Hardware", this, this.commonStrings.CONSTRUCTOR);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
        return this.hardwareInterface;
    }

    public static string static_toString()
    {
        SystemHardwareFactory systemHardwareFactory = SystemHardwareFactory.getInstance();
        StringMaker osBuffer = new StringMaker();
        osBuffer.append("Hardware Info: \n");
        if (systemHardwareFactory.hardwareInterface != null) {
            osBuffer.append(systemHardwareFactory.hardwareInterface.ToString());
        } else {
            osBuffer.append(StringUtil.getInstance().NULL_STRING);
        }
        return osBuffer.ToString();
    }

}

