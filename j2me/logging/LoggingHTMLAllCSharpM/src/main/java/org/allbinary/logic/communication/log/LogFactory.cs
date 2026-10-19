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

namespace org.allbinary.logic.communication.log;

public class LogFactory
{
    public static Log getInstance(string specialMessage, object anyType, string functionName, object exception)
    {
        return new Log(specialMessage, anyType, functionName, exception);
    }

    public static Log getInstanceF(string specialMessage, object anyType, string functionName)
    {
        return new Log(specialMessage, anyType, functionName, NullUtil.getInstance().NULL_OBJECT);
    }

}

