/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.data.tables.generator;

public class IdGeneratorEntityFactory
{
    private IdGeneratorEntityFactory()
    {
    }

    public static IdGeneratorEntityInterface getInstance()
    {
        try {
            return ((IdGeneratorEntityInterface) new org.allbinary.data.tables.generator.IdGeneratorEntity());
        } catch (Exception e) {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, "ServerLicenseRequestEntityFactory", commonStrings.GET_INSTANCE, e);
            return null;
        }
    }

}

