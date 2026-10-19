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
using System.Runtime.CompilerServices;
using Log = org.allbinary.logic.communication.log.Log;
using LogFactory = org.allbinary.logic.communication.log.LogFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LinuxOperatingSystemFactory = org.allbinary.logic.system.os.linux.LinuxOperatingSystemFactory;
using SolarisOperatingSystemFactory = org.allbinary.logic.system.os.solaris.SolarisOperatingSystemFactory;
using WindowsOperatingSystemFactory = org.allbinary.logic.system.os.windows.WindowsOperatingSystemFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.os;

public class OperatingSystemFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly OperatingSystemFactory instance = new OperatingSystemFactory();
    public static OperatingSystemFactory getInstance()
    {
        return OperatingSystemFactory.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private GenericOperatingSystem genericOperatingSystem = NoOperatingSystem.NO_OPERATING_SYSTEM;
    private bool hasDetected = false;
    private OperatingSystemFactory()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual GenericOperatingSystem getOperatingSystemInstance()
    {
        try {
            OperatingSystems operatingSystems = OperatingSystems.getInstance();
            SystemProperties systemProperties = SystemProperties.getInstance();
            string osName = systemProperties.getName();
            string osArch = systemProperties.getArch();
            string osVersion = systemProperties.getVersion();
            if (!this.hasDetected) {
                this.logUtil.putF("osName: " + osName, this, this.commonStrings.GET_INSTANCE);
                this.hasDetected = true;
                if (osName.IndexOf(operatingSystems.LINUX) >= 0) {
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                        this.logUtil.putF("Found a Linux OS", this, this.commonStrings.GET_INSTANCE);
                    }
                    this.genericOperatingSystem = LinuxOperatingSystemFactory.getInstance().getOperatingSystemInstance();
                } else if (osName.IndexOf(operatingSystems.WINDOWS) >= 0) {
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                        this.logUtil.putF("Found a Windows OS", this, this.commonStrings.GET_INSTANCE);
                    }
                    this.genericOperatingSystem = WindowsOperatingSystemFactory.getInstance().getOperatingSystemInstance();
                } else if (osName.IndexOf(operatingSystems.SOLARIS) >= 0) {
                    if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                        this.logUtil.putF("Found a Solaris OS", this, this.commonStrings.GET_INSTANCE);
                    }
                    this.genericOperatingSystem = SolarisOperatingSystemFactory.getInstance().getOperatingSystemInstance();
                } else {
                    throw new Exception(new StringMaker().append("OS Not Supported: ").append(osName).ToString());
                }
                Log log = LogFactory.getInstanceF(new StringMaker().append("OperatingSystem Info: ").append(StringUtil.getInstance().toString(this.genericOperatingSystem)).ToString(), this, this.commonStrings.GET_INSTANCE);
                Console.WriteLine(log.ToString());
                this.logUtil.putL(log);
            }
            return this.genericOperatingSystem;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.GET_INSTANCE, e);
            }
            return NoOperatingSystem.NO_OPERATING_SYSTEM;
        }
    }

}

