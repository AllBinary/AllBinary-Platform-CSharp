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
using AndroidHardware = org.allbinary.logic.system.hardware.android.AndroidHardware;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using OperatingSystems = org.allbinary.logic.system.os.OperatingSystems;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.hardware;

public class HardwareFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly HardwareFactory instance = new HardwareFactory();
    public static HardwareFactory getInstance()
    {
        return HardwareFactory.instance;
    }

    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private HardwareFactory()
    {
    }

    // throws Exception
    public virtual HardwareInterface getInstance(GenericOperatingSystem os)
    {
        try {
            OperatingSystems operatingSystems = OperatingSystems.getInstance();
            if (this.tsUtil.compareTo(os.getName(), operatingSystems.ANDROID) == 0) {
                return new AndroidHardware();
            } else if (this.tsUtil.compareTo(os.getName(), operatingSystems.HARMONY) == 0) {
                return new AndroidHardware();
            }
            throw new Exception("No Hardware Imp for: " + os.getName());
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put("Ignoring Exception Returning NoHardware", this, commonStrings.GET_INSTANCE, e);
            return new NoHardware();
        }
    }

}

