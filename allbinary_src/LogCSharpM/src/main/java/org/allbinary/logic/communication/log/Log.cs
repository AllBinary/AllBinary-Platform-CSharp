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
using LogFormatUtil = org.allbinary.logic.communication.log.LogFormatUtil;

namespace org.allbinary.logic.communication.log;

public class Log
{
    private readonly LogFormatUtil logFormatUtil = LogFormatUtil.getInstance();
    private readonly string specialMessage;
    private readonly object anyType;
    private readonly string functionName;
    private readonly object exception;
    public Log(string specialMessage, object anyType, string functionName, object exception)
    {
        this.specialMessage = specialMessage;
        this.anyType = anyType;
        this.functionName = functionName;
        this.exception = exception;
    }

    public virtual string getSpecialMessage()
    {
        return this.specialMessage;
    }

    public virtual object getObject()
    {
        return this.anyType;
    }

    public virtual string getFunctionName()
    {
        return this.functionName;
    }

    public virtual object getThrowable()
    {
        return this.exception;
    }

    public override string ToString()
    {
        string className = CommonStrings.getInstance().EMPTY;
        Type clazz = this.anyType.GetType();
        if (clazz.FullName != null) {
            className = clazz.FullName;
        }
        return this.logFormatUtil.get(className, this.functionName, this.specialMessage, this.exception);
    }

}

