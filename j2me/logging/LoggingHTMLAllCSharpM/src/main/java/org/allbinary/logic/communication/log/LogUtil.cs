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
using PlayN = playn.core.PlayN;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class LogUtil
{
    private static readonly LogUtil instance = new LogUtil();
    public static LogUtil getInstance()
    {
        return LogUtil.instance;
    }

    private readonly string LOG_SUCCESS = "org.allbinary: ";
    private LogUtil()
    {
    }

    private readonly LogFormatUtil logFormatUtil = LogFormatUtil.getInstance();
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
        string className = PreLogUtil.getClassName(anyType);
        if (className == null) {
            className = CommonStrings.getInstance().EMPTY;
        }
        string message = this.logFormatUtil.getS(className, functionName, specialMessage);
        PlayN.log().debug(this.LOG_SUCCESS + message);
    }

    public virtual void putFS(string specialMessage, string className, string functionName)
    {
        string message = this.logFormatUtil.getS(className, functionName, specialMessage);
        PlayN.log().debug(this.LOG_SUCCESS + message);
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        string className = PreLogUtil.getClassName(anyType);
        if (className == null) {
            className = CommonStrings.getInstance().EMPTY;
        }
        string message = this.logFormatUtil.get(className, functionName, specialMessage, exception);
        if (exception != null) {
            PlayN.log().error(this.LOG_SUCCESS + message, ((Exception) exception));
        } else {
            PlayN.log().debug(this.LOG_SUCCESS + message);
        }
    }

}

