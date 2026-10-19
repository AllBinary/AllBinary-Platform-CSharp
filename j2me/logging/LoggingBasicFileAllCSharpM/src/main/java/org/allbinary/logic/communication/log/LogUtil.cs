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
using FileLog = org.allbinary.log.FileLog;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
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
        string specialMessage = log.getSpecialMessage();
        object anyType = log.getObject();
        string functionName = log.getFunctionName();
        object exception = log.getThrowable();
        this.put(specialMessage, anyType, functionName, exception);
    }

    public virtual void putF(string specialMessage, object anyType, string functionName)
    {
        FileLog.put(specialMessage, anyType, functionName);
    }

    public virtual void putFS(string specialMessage, string className, string functionName)
    {
        FileLog.put(specialMessage, className, functionName);
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        FileLog.put(specialMessage, anyType, functionName, ((Exception) exception));
    }

}

