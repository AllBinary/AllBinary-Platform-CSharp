/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.licensing;

public class ClientInformationFactory
{
    public virtual ClientInformation getInstance()
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        logUtil.putF(commonStrings.NOT_IMPLEMENTED, this, commonStrings.GET_INSTANCE);
        StringUtil stringUtil = StringUtil.getInstance();
        return new ClientInformation(stringUtil.NULL_STRING, stringUtil.NULL_STRING, stringUtil.NULL_STRING, stringUtil.NULL_STRING);
    }

}

