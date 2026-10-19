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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;

namespace org.allbinary.logic.java.number;

public class LongUtil
{
    private LongUtil()
    {
    }

    public static string fillIn(string end)
    {
        StringMaker frameStringBuffer = new StringMaker();
        if (frameStringBuffer.length() < LongData.MAX_LONG_LENGTH) {
            CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
            int size = LongData.MAX_LONG_LENGTH - frameStringBuffer.length();
            for (int index = 0; index < size; index++) {
                frameStringBuffer.append(commonPhoneStrings.ZERO);
            }
        }
        frameStringBuffer.append(end);
        return frameStringBuffer.ToString();
    }

}

