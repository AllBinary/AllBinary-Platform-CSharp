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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;

namespace org.allbinary.logic.communication.log;

public class ForcedLogUtil
{
    public static void log(string message, object anyType)
    {
        try {
            throw new Exception(message);
        } catch (Exception e) {
            PreLogUtil.putOE(CommonStrings.getInstance().EXCEPTION, anyType, "log", e);
        }
    }

}

