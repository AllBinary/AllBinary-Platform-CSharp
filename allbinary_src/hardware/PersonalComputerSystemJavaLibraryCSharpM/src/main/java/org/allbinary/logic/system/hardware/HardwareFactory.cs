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
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using OperatingSystems = org.allbinary.logic.system.os.OperatingSystems;
using LinuxHardware = org.allbinary.logic.system.hardware.linux.LinuxHardware;
using WindowsHardware = org.allbinary.logic.system.hardware.windows.WindowsHardware;

namespace org.allbinary.logic.system.hardware;

public class HardwareFactory
{
    private static readonly HardwareFactory instance = new HardwareFactory();
    public static HardwareFactory getInstance()
    {
        return HardwareFactory.instance;
    }

    private HardwareFactory()
    {
    }

    // throws Exception
    public static HardwareInterface getInstance(GenericOperatingSystem os)
    {
        try {
            OperatingSystems operatingSystems = OperatingSystems.getInstance();
            if (os.getName().compareTo(operatingSystems.LINUX) == 0) {
                return ((HardwareInterface) new LinuxHardware());
            } else if (os.getName().indexOf(operatingSystems.WINDOWS) >= 0) {
                return ((HardwareInterface) new WindowsHardware());
            }
            throw new Exception("No Hardware Imp for: " + os.getName());
        } catch (Exception e) {
            throw e;
        }
    }

}

