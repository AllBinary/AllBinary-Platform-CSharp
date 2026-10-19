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
using TsUtil = org.allbinary.TsUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using NoOperatingSystem = org.allbinary.logic.system.os.NoOperatingSystem;
using OperatingSystems = org.allbinary.logic.system.os.OperatingSystems;
using SystemProperties = org.allbinary.logic.system.os.SystemProperties;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.os.android;

public class AndroidOperatingSystemFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AndroidOperatingSystemFactory instance = new AndroidOperatingSystemFactory();
    public static AndroidOperatingSystemFactory getInstance()
    {
        return AndroidOperatingSystemFactory.instance;
    }

    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private AndroidOperatingSystemFactory()
    {
    }

    // throws Exception
    public virtual GenericOperatingSystem getOperatingSystemInstance()
    {
        try {
            GenericOperatingSystem GenericOperatingSystem = null;
            SystemProperties systemProperties = SystemProperties.getInstance();
            string osName = systemProperties.getName();
            if (this.tsUtil.compareTo(osName, OperatingSystems.getInstance().ANDROID) == 0) {
                GenericOperatingSystem = new AndroidOS();
            } else {
                if (OperatingSystems.getInstance().isUnknownSpecificOSAllowed()) {
                    GenericOperatingSystem = new AndroidOS();
                } else {
                    throw new Exception("Specific Android OS Not Supported: " + osName);
                }
            }
            return GenericOperatingSystem;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put("Failed to get OperatingSystem returning NoOperatingSystem", this, commonStrings.GET_INSTANCE, e);
            return NoOperatingSystem.NO_OPERATING_SYSTEM;
        }
    }

}

