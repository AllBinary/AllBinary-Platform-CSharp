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
using StringMaker = org.allbinary.logic.@string.StringMaker;
//using Logger = java.util.logging.Logger;
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

    public virtual void init()
    {
        PreLogUtil.put("Loggin Initialized", this, "init()");
    }

    public virtual void putL(Log log)
    {
        object exception = log.getThrowable();
        try {
            if (exception != null) {
                string specialMessage = log.getSpecialMessage();
                object anyType = log.getObject();
                string functionName = log.getFunctionName();
                string className = CommonStrings.getInstance().EMPTY;
                Type clazz = anyType.GetType();
                if (clazz.FullName != null) {
                    className = clazz.FullName;
                }
                string message = this.logFormatUtil.get(className, functionName, specialMessage, exception);
                this.logger.log(Level.INFO, message);
            }
        } catch (Exception e) {
        }
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        try {
            string className = CommonStrings.getInstance().EMPTY;
            Type clazz = anyType.GetType();
            if (clazz.FullName != null) {
                className = clazz.FullName;
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

}

