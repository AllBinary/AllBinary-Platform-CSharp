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
//using JsType = jsinterop.annotations.JsType;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using PlayN = playn.core.PlayN;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class PreLogUtil
{
    public PreLogUtil()
    {
    }

    public static void put(string specialMessage, object anyType, string functionName)
    {
        string className = PreLogUtil.getClassName(anyType);
        if (className == null) {
            className = CommonStrings.getInstance().EMPTY;
        }
        className = new StringMaker().append(className).append(CommonSeps.getInstance().FORWARD_SLASH).append(StringUtil.getInstance().toString(anyType)).ToString();
        string message = LogFormatUtil.getInstance().getS(className, functionName, specialMessage);
        PlayN.getInstance().log().debug(PreLogUtil.LOG_SUCCESS + message);
    }

    private static readonly string LOG_SUCCESS = "org.allbinary: ";
    public static void putOE(string specialMessage, object anyType, string functionName, object exception)
    {
        string className = PreLogUtil.getClassName(anyType);
        if (className == null) {
            className = CommonStrings.getInstance().EMPTY;
        }
        className = new StringMaker().append(className).append(CommonSeps.getInstance().FORWARD_SLASH).append(StringUtil.getInstance().toString(anyType)).ToString();
        string message = LogFormatUtil.getInstance().get(className, functionName, specialMessage, exception);
        PlayN.getInstance().log().error(PreLogUtil.LOG_SUCCESS + message, ((Exception) exception));
    }

    public static void putS(string specialMessage, string className, string functionName)
    {
        string message = LogFormatUtil.getInstance().getS(className, functionName, specialMessage);
        PlayN.getInstance().log().debug(PreLogUtil.LOG_SUCCESS + message);
    }

    public static void putSE(string specialMessage, string className, string functionName, object exception)
    {
        string message = LogFormatUtil.getInstance().get(className, functionName, specialMessage, exception);
        PlayN.getInstance().log().error(PreLogUtil.LOG_SUCCESS + message, ((Exception) exception));
    }

    public static string getClassName(object anyType);

}

