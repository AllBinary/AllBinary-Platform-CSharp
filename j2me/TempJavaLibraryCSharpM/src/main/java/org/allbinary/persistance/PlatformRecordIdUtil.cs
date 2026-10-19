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
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.persistance;

public class PlatformRecordIdUtil
{
    private static readonly PlatformRecordIdUtil instance = new PlatformRecordIdUtil();
    public static PlatformRecordIdUtil getInstance()
    {
        return PlatformRecordIdUtil.instance;
    }

    private readonly string PLATFORM_SHORT_NAME = "AVN";
    public virtual string getRecordId(AbeClientInformationInterface abeClientInformation, string baseRecordId)
    {
        return new StringMaker().append(abeClientInformation.toShortString()).append(CommonSeps.getInstance().UNDERSCORE).append(this.PLATFORM_SHORT_NAME).append(baseRecordId).ToString();
    }

}

