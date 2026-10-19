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
    private OperatingSystemFactory()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual GenericOperatingSystem getOperatingSystemInstance()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            string osString = new StringMaker().append("OperatingSystem Info: ").append(this.genericOperatingSystem.ToString()).ToString();
            Console.WriteLine(osString);
            this.logUtil.putF(osString, this, commonStrings.GET_INSTANCE);
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
        }
        return this.genericOperatingSystem;
    }

}

