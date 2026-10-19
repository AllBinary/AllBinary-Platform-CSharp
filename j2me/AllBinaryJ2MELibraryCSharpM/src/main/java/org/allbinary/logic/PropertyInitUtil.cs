/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2026 AllBinary 
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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic;

public class PropertyInitUtil
{
    private static readonly PropertyInitUtil instance = new PropertyInitUtil();
    public static PropertyInitUtil getInstance(int value)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        LogUtil logUtil = LogUtil.getInstance();
        logUtil.putF(new StringMaker().append("PropertyInitUtil: ").appendint(value).ToString(), logUtil, commonStrings.CONSTRUCTOR);
        return PropertyInitUtil.instance;
    }

}

