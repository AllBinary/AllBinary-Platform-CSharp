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

namespace org.allbinary.logic.communication.log;

//NoPlatform
public class LogUtil
{
    private static readonly LogUtil instance = new LogUtil();
    public static LogUtil getInstance()
    {
        return LogUtil.instance;
    }

    private LogUtil()
    {
    }

    public virtual void putL(Log log)
    {
        throw new SystemException();
    }

    public virtual void putF(string specialMessage, object anyType, string functionName)
    {
    }

    public virtual void putF(string specialMessage, string className, string functionName)
    {
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        throw new SystemException();
    }

}

