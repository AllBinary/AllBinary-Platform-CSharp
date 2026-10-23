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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.http;

public class AcceptableResponse
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public AcceptableResponse(string candidate, string tagName, int index)
    {
        this.logUtil.putF(tagName, this, this.commonStrings.CONSTRUCTOR);
        AcceptableResponseUtil acceptableResponseUtil = AcceptableResponseUtil.getInstance();
        acceptableResponseUtil.candidateVector.addAt(index, candidate);
        acceptableResponseUtil.tagNameVector.addAt(index, tagName);
    }

}

