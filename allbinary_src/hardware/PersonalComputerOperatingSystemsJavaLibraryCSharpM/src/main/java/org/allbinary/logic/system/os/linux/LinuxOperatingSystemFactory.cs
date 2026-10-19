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
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using NoOperatingSystem = org.allbinary.logic.system.os.NoOperatingSystem;
using OperatingSystems = org.allbinary.logic.system.os.OperatingSystems;
using SystemProperties = org.allbinary.logic.system.os.SystemProperties;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.os.linux;

public class LinuxOperatingSystemFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly LinuxOperatingSystemFactory instance = new LinuxOperatingSystemFactory();
    public static LinuxOperatingSystemFactory getInstance()
    {
        return LinuxOperatingSystemFactory.instance;
    }

    private LinuxOperatingSystemFactory()
    {
    }

    public virtual GenericOperatingSystem getOperatingSystemInstance()
    {
        try {
            OperatingSystems operatingSystems = OperatingSystems.getInstance();
            string osName = SystemProperties.getInstance().getName();
            GenericOperatingSystem operatingSystemInterface = null;
            if (string.CompareOrdinal(osName, operatingSystems.LINUX) == 0) {
                operatingSystemInterface = new LinuxOS();
            } else {
                if (operatingSystems.isUnknownSpecificOSAllowed()) {
                    operatingSystemInterface = new LinuxOS();
                } else {
                    throw new Exception("Specific Linux OS Not Supported: " + osName);
                }
            }
            return operatingSystemInterface;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            return NoOperatingSystem.NO_OPERATING_SYSTEM;
        }
    }

}

