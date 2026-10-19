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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.thirdparty.store;

public class NoThirdPartyStore : ThirdPartyStore
{
    public NoThirdPartyStore() : base(StringUtil.getInstance().EMPTY_STRING)
    {
        // base(StringUtil.getInstance().EMPTY_STRING) is called from the constructor declaration
    }

    public override void authorize(AbeClientInformationInterface clientInformationInterface)
    {
        this.setAuthorized(true);
    }

}

