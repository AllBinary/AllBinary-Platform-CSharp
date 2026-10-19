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
using TimeStampUtil = org.allbinary.time.TimeStampUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ExceptionUtil = org.allbinary.logic.java.exception.ExceptionUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class LogFormatUtil
{
    private static readonly LogFormatUtil instance = new LogFormatUtil();
    public static LogFormatUtil getInstance()
    {
        return LogFormatUtil.instance;
    }

    private readonly TimeStampUtil timeStampUtil = TimeStampUtil.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly string LOG_ERROR = "\nLog-Error: ";
    private readonly string EMPTY = "Empty";
    private readonly string STACK_TRACE = "\nStack Trace: ";
    private readonly string TIME = "Time: ";
    private readonly string CLASS_NAME;
    private readonly string FUNCTION_CALL = CommonLabels.getInstance().COLON_SEP;
    private readonly string SPECIAL_MESSAGE = "> ";
    private LogFormatUtil()
    {
        this.CLASS_NAME = this.commonSeps.SPACE;
    }

    public virtual string get(string className, string functionName, string specialMessage, object exception)
    {
        StringMaker stringBuffer = this.getF(className, functionName);
        stringBuffer.append(this.getO(exception));
        stringBuffer.append(this.SPECIAL_MESSAGE);
        stringBuffer.append(specialMessage);
        stringBuffer.append(this.commonSeps.NEW_LINE);
        return stringBuffer.ToString();
    }

    public virtual string getS(string className, string functionName, string specialMessage)
    {
        StringMaker stringBuffer = this.getF(className, functionName);
        stringBuffer.append(this.SPECIAL_MESSAGE);
        stringBuffer.append(specialMessage);
        stringBuffer.append(this.commonSeps.NEW_LINE);
        return stringBuffer.ToString();
    }

    private StringMaker getF(string className, string functionName)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.TIME);
        stringBuffer.append(this.timeStampUtil.getAsString());
        stringBuffer.append(this.CLASS_NAME);
        stringBuffer.append(className);
        stringBuffer.append(this.FUNCTION_CALL);
        stringBuffer.append(functionName);
        return stringBuffer;
    }

    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly ExceptionUtil exceptionUtil = ExceptionUtil.getInstance();
    private readonly NullUtil nullUtil = NullUtil.getInstance();
    public virtual string getO(object exception)
    {
        if (exception != this.nullUtil.NULL_OBJECT) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.LOG_ERROR);
            string exceptionAsString = exception.ToString();
            if (exceptionAsString != null) {
                stringBuffer.append(exceptionAsString);
            } else {
                stringBuffer.append(this.EMPTY);
            }
            stringBuffer.append(this.STACK_TRACE);
            if (exception != this.nullUtil.NULL_OBJECT) {
                stringBuffer.append(this.exceptionUtil.getStackTrace(((Exception) exception)));
            } else {
                stringBuffer.append(this.stringUtil.NULL_STRING);
            }
            return stringBuffer.ToString();
        } else {
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

}

