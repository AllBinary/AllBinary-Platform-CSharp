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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class LogFactory
{
    public static readonly Log LOG = new Log(StringUtil.getInstance().EMPTY_STRING, NullUtil.getInstance().NULL_OBJECT, StringUtil.getInstance().EMPTY_STRING, NullUtil.getInstance().NULL_OBJECT);
    public static Log getInstanceD()
    {
        StringUtil stringUtil = StringUtil.getInstance();
        NullUtil nullUtil = NullUtil.getInstance();
        return new Log(stringUtil.EMPTY_STRING, nullUtil.NULL_OBJECT, stringUtil.EMPTY_STRING, nullUtil.NULL_OBJECT);
    }

    public static Log getInstance(string specialMessage, object anyType, string functionName, object exception)
    {
        return LogFactory.LOG;
    }

    public static Log getInstanceF(string specialMessage, object anyType, string functionName)
    {
        return LogFactory.LOG;
    }

}

