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

//ActualPlatform
public class LogUtil
{
    private static readonly LogUtil instance = new LogUtil();
    public static LogUtil getInstance()
    {
        return LogUtil.instance;
    }

    private readonly LogFormatUtil logFormatUtil = LogFormatUtil.getInstance();
    private readonly string LABEL = "org.allbinary";
    private readonly string LOG_SUCCESS = "org.allbinary: ";
    private LogUtil()
    {
    }

    public virtual void putL(Log log)
    {
        string specialMessage = log.getSpecialMessage();
        object anyType = log.getObject();
        string functionName = log.getFunctionName();
        object exception = log.getThrowable();
        if (log != null) {
            this.put(specialMessage, anyType, functionName, exception);
        }
    }

    public virtual void putF(string specialMessage, object anyType, string functionName)
    {
    }

    public virtual void putFS(string specialMessage, string className, string functionName)
    {
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        string className = this.LABEL;
        className = anyType.GetType().FullName;
        string message = this.logFormatUtil.get(className, functionName, specialMessage, exception);
        android.util.Log.i(this.LABEL, this.LOG_SUCCESS + message);
    }

}

