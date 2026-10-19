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
using NullUtil = org.allbinary.logic.NullUtil;
using TsUtil = org.allbinary.TsUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class LogUtil
{
    private static readonly LogUtil instance = new LogUtil();
    public static LogUtil getInstance()
    {
        return LogUtil.instance;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly LogFormatUtil logFormatUtil = LogFormatUtil.getInstance();
    private readonly string LABEL = "org.allbinary";
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

    public virtual void putFS(string specialMessage, string @string, string functionName)
    {
        this.putS(specialMessage, @string, functionName, NullUtil.getInstance().NULL_OBJECT);
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        string className = this.LABEL;
        className = new string((new StringMaker().append(anyType.GetType().FullName).append(this.commonSeps.COLON).append(Convert.ToString(TsUtil.getInstance().hashCode(anyType), 16)).ToString()).ToCharArray());
        string message = this.logFormatUtil.get(className, functionName, specialMessage, exception);
        android.util.Log.i(this.LABEL, message);
    }

    public virtual void putS(string specialMessage, string @string, string functionName, object exception)
    {
        string className = this.LABEL;
        className = new string((new StringMaker().append(@string).append(this.commonSeps.COLON).append(Convert.ToString(TsUtil.getInstance().hashCode(@string), 16)).ToString()).ToCharArray());
        string message = this.logFormatUtil.get(className, functionName, specialMessage, exception);
        android.util.Log.i(this.LABEL, message);
    }

}

