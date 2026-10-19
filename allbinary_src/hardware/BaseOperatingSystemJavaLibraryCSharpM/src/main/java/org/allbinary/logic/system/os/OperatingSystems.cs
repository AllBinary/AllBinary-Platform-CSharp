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

namespace org.allbinary.logic.system.os;

public class OperatingSystems
{
    private static readonly OperatingSystems instance = new OperatingSystems();
    public readonly string LINUX = "Linux";
    public readonly string WINDOWS = "Windows";
    public readonly string SOLARIS = "Solaris";
    public readonly string WINDOWS2000 = "Windows 2000";
    public readonly string WINDOWS_NT = "Windows NT";
    public readonly string WINDOWS_10 = "Windows 10";
    public readonly string WINDOWS_11 = "Windows 11";
    public readonly string WINDOWS_VISTA = "Windows Vista";
    public readonly string WINDOWS_XP = "Windows XP";
    public readonly string ANDROID;
    public readonly string HARMONY = "HarmonyOS";
    private OperatingSystems()
    {
        this.ANDROID = this.LINUX;
    }

    private bool unknownSpecificOSAllowed = true;
    public virtual bool isUnknownSpecificOSAllowed()
    {
        return this.unknownSpecificOSAllowed;
    }

    public virtual void setUnknownSpecificOSAllowed(bool aUnknownSpecificOSAllowed)
    {
        this.unknownSpecificOSAllowed = aUnknownSpecificOSAllowed;
    }

    public static OperatingSystems getInstance()
    {
        return OperatingSystems.instance;
    }

}

