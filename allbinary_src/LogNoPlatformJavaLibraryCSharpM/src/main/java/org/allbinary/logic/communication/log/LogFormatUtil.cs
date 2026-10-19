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
using ExceptionUtil = org.allbinary.logic.java.exception.ExceptionUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using TimeStampUtil = org.allbinary.time.TimeStampUtil;

namespace org.allbinary.logic.communication.log;

//NoPlatform
public class LogFormatUtil
{
    private static readonly LogFormatUtil instance = new LogFormatUtil();
    public static LogFormatUtil getInstance()
    {
        return LogFormatUtil.instance;
    }

    private LogFormatUtil()
    {
    }

    public virtual string get(string className, string functionName, string specialMessage, object exception)
    {
        throw new SystemException();
    }

    public virtual string getS(string className, string functionName, string specialMessage)
    {
        throw new SystemException();
    }

    public virtual string getO(object exception)
    {
        throw new SystemException();
    }

}

