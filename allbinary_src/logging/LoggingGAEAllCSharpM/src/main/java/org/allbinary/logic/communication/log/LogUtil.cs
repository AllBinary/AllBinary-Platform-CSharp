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
//using Level = java.util.logging.Level;
//using Logger = java.util.logging.Logger;
using NullUtil = org.allbinary.logic.NullUtil;
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

    private readonly Logger logger = Logger.getLogger(typeof(LogUtil).getName());
    private readonly LogFormatUtil logFormatUtil = LogFormatUtil.getInstance();
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
        this.put(specialMessage, anyType, functionName, NullUtil.getInstance().NULL_OBJECT);
    }

    public virtual void putFS(string specialMessage, string className, string functionName)
    {
        this.putS(specialMessage, className, functionName, NullUtil.getInstance().NULL_OBJECT);
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        try {
            string className = CommonStrings.getInstance().EMPTY;
            Type clazz = anyType.GetType();
            if (clazz.getName() != null) {
                className = clazz.getName();
            }
            string message = this.logFormatUtil.getS(className, functionName, specialMessage);
            if (exception != null) {
                this.logger.log(Level.SEVERE, message, exception);
            } else {
                this.logger.log(Level.INFO, message);
            }
        } catch (Exception e) {
        }
    }

    public virtual void putS(string specialMessage, string className, string functionName, object exception)
    {
        try {
            string message = this.logFormatUtil.getS(className, functionName, specialMessage);
            if (exception != null) {
                this.logger.log(Level.SEVERE, message, exception);
            } else {
                this.logger.log(Level.INFO, message);
            }
        } catch (Exception e) {
        }
    }

}

