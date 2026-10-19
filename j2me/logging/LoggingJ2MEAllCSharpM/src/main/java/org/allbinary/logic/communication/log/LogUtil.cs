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
using TsUtil = org.allbinary.TsUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
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
        string className = CommonStrings.getInstance().EMPTY;
        if (anyType.GetType().FullName != null) {
            className = new string((new StringMaker().append(anyType.GetType().FullName).append(CommonSeps.getInstance().COLON).append(Convert.ToString(TsUtil.getInstance().hashCode(anyType), 16)).ToString()).ToCharArray());
        }
        string message = this.logFormatUtil.getS(className, functionName, specialMessage);
        Console.Write(this.LOG_SUCCESS);
        Console.WriteLine(message);
    }

    public virtual void putFS(string specialMessage, string className, string functionName)
    {
        string message = this.logFormatUtil.getS(className, functionName, specialMessage);
        Console.Write(this.LOG_SUCCESS);
        Console.WriteLine(message);
    }

    private readonly string LOG_SUCCESS = "org.allbinary: ";
    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        string className = CommonStrings.getInstance().EMPTY;
        if (anyType.GetType().FullName != null) {
            int hashCodeValue = TsUtil.getInstance().hashCode(anyType);
            string hexString = Convert.ToString(hashCodeValue, 16);
            className = new string((new StringMaker().append(anyType.GetType().FullName).append(CommonSeps.getInstance().COLON).append(hexString).ToString()).ToCharArray());
        }
        string message = this.logFormatUtil.get(className, functionName, specialMessage, exception);
        Console.Write(this.LOG_SUCCESS);
        Console.WriteLine(message);
    }

}

