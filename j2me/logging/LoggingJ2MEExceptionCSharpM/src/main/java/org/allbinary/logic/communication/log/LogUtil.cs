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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class LogUtil
{
    private static readonly LogUtil instance = new LogUtil();
    public static LogUtil getInstance()
    {
        return LogUtil.instance;
    }

    private readonly LogFormatUtil logFormatUtil = LogFormatUtil.getInstance();
    private readonly string LOG_SUCCESS = "org.allbinary: ";
    private LogUtil()
    {
    }

    public virtual void putL(Log log)
    {
        if (log == LogFactory.LOG) {
            return;
        }
        object exception = log.getThrowable();
        if (exception == null) {
            return;
        }
        string specialMessage = log.getSpecialMessage();
        object anyType = log.getObject();
        string functionName = log.getFunctionName();
        this.put(specialMessage, anyType, functionName, exception);
    }

    public virtual void putF(string specialMessage, object anyType, string functionName)
    {
    }

    public virtual void putFS(string specialMessage, string className, string functionName)
    {
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        string className = CommonStrings.getInstance().EMPTY;
        if (anyType.GetType().FullName != null) {
            className = new string((anyType.GetType().FullName).ToCharArray());
        }
        string message = this.logFormatUtil.get(className, functionName, specialMessage, exception);
        Console.Write(this.LOG_SUCCESS);
        Console.WriteLine(message);
    }

}

