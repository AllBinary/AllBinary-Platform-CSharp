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
using OperatingSystemInterface = org.allbinary.logic.system.os.OperatingSystemInterface;

namespace org.allbinary.logic.system.hardware;

public class HardwareFactory
{
    private static readonly HardwareFactory instance = new HardwareFactory();
    public static HardwareFactory getInstance()
    {
        return HardwareFactory.instance;
    }

    private readonly HardwareInterface SINGLETON = NoHardware.getInstance();
    private HardwareFactory()
    {
    }

    // throws Exception
    public virtual HardwareInterface getInstance(OperatingSystemInterface os)
    {
        try {
            return this.SINGLETON;
        } catch (Exception e) {
            throw e;
        }
    }

}

