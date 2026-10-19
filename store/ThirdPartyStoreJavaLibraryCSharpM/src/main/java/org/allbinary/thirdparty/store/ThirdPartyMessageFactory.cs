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

namespace org.allbinary.thirdparty.store;

public class ThirdPartyMessageFactory
{
    private static readonly ThirdPartyMessageFactory instance = new ThirdPartyMessageFactory();
    public readonly string AUTHORIZED = "Authorized";
    public readonly string NOT_AUTHORIZED = "Not Authorized";
    public readonly string LINKAGE_ERROR = "Linkage Error";
    public static ThirdPartyMessageFactory getInstance()
    {
        return ThirdPartyMessageFactory.instance;
    }

}

