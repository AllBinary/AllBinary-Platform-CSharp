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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class PreLogUtil
{
    public PreLogUtil()
    {
    }

    public static void put(string specialMessage, object anyType, string functionName)
    {
        PreLogUtil.putOE(specialMessage, anyType, functionName, NullUtil.getInstance().NULL_OBJECT);
    }

    private static readonly string LOG_SUCCESS = "org.allbinary: ";
    public static void putOE(string specialMessage, object anyType, string functionName, object exception)
    {
        string className = CommonStrings.getInstance().EMPTY;
        if (anyType.GetType().FullName != null) {
            className = new string((anyType.GetType().FullName).ToCharArray());
        }
        string message = LogFormatUtil.getInstance().get(className, functionName, specialMessage, exception);
        Console.Write(LOG_SUCCESS);
        Console.WriteLine(message);
    }

    public static void putSE(string specialMessage, string className, string functionName, object exception)
    {
        string message = LogFormatUtil.getInstance().get(className, functionName, specialMessage, exception);
        Console.Write(LOG_SUCCESS);
        Console.WriteLine(message);
    }

}

