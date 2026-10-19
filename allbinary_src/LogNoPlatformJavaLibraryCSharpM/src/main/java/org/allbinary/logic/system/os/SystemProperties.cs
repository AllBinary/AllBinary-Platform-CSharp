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

//NoPlatform
public class SystemProperties
{
    private static readonly SystemProperties instance = new SystemProperties();
    public static SystemProperties getInstance()
    {
        return SystemProperties.instance;
    }

    private SystemProperties()
    {
    }

    public virtual string getName()
    {
        throw new SystemException();
    }

    public virtual string getArch()
    {
        throw new SystemException();
    }

    public virtual string getVersion()
    {
        throw new SystemException();
    }

    public virtual string getUserHomePath()
    {
        throw new SystemException();
    }

}

