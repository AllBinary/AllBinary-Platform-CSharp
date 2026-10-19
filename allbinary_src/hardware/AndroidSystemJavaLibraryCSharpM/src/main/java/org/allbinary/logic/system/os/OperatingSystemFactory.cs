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
using AndroidOperatingSystemFactory = org.allbinary.logic.system.os.android.AndroidOperatingSystemFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
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

    private GenericOperatingSystem genericOperatingSystem = NoOperatingSystem.NO_OPERATING_SYSTEM;
    private bool hasDetected = false;
    private OperatingSystemFactory()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual GenericOperatingSystem getOperatingSystemInstance()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            SystemProperties systemProperties = SystemProperties.getInstance();
            string osName = systemProperties.getName();
            if (!this.hasDetected) {
                this.hasDetected = true;
                if (osName.IndexOf(OperatingSystems.getInstance().ANDROID) >= 0) {
                    this.logUtil.putF("Found a Android OS", this, commonStrings.GET_INSTANCE);
                    this.genericOperatingSystem = AndroidOperatingSystemFactory.getInstance().getOperatingSystemInstance();
                    this.logUtil.putF(new StringMaker().append("Operating System Info: ").append(this.genericOperatingSystem.ToString()).ToString(), this, commonStrings.GET_INSTANCE);
                } else if (osName.IndexOf(OperatingSystems.getInstance().HARMONY) >= 0) {
                    this.logUtil.putF("Found a Harmony OS", this, commonStrings.GET_INSTANCE);
                    this.genericOperatingSystem = AndroidOperatingSystemFactory.getInstance().getOperatingSystemInstance();
                    this.logUtil.putF(new StringMaker().append("Operating System Info: ").append(this.genericOperatingSystem.ToString()).ToString(), this, commonStrings.GET_INSTANCE);
                } else {
                    throw new Exception(new StringMaker().append("OS Not Supported: ").append(osName).ToString());
                }
            }
        } catch (Exception e) {
            this.genericOperatingSystem = NoOperatingSystem.NO_OPERATING_SYSTEM;
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
        }
        return this.genericOperatingSystem;
    }

}

