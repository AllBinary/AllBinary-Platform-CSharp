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
using java.util;
using StdUtil = org.allbinary.logic.StdUtil;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using MathData = org.allbinary.logic.math.MathData;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.@string;

public class SpecialCharacterUtil
{
    public static HashMap<object, object> getHashMap()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
        StringUtil stringUtil = StringUtil.getInstance();
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put("!", stringUtil.EMPTY_STRING);
        hashMap.put("@", stringUtil.EMPTY_STRING);
        hashMap.put(commonPhoneStrings.POUND, stringUtil.EMPTY_STRING);
        hashMap.put("$", stringUtil.EMPTY_STRING);
        hashMap.put("%", stringUtil.EMPTY_STRING);
        hashMap.put("^", stringUtil.EMPTY_STRING);
        hashMap.put(commonSeps.AMPERSAND, stringUtil.EMPTY_STRING);
        hashMap.put(commonPhoneStrings.STAR, stringUtil.EMPTY_STRING);
        hashMap.put(commonSeps.PARENTHESIS_OPEN, stringUtil.EMPTY_STRING);
        hashMap.put(commonSeps.PARENTHESIS_CLOSE, stringUtil.EMPTY_STRING);
        hashMap.put(commonSeps.DASH, stringUtil.EMPTY_STRING);
        hashMap.put(commonSeps.UNDERSCORE, stringUtil.EMPTY_STRING);
        hashMap.put(MathData.getInstance().PLUS, stringUtil.EMPTY_STRING);
        hashMap.put(commonSeps.EQUALS, stringUtil.EMPTY_STRING);
        hashMap.put("\\", stringUtil.EMPTY_STRING);
        hashMap.put("|", stringUtil.EMPTY_STRING);
        hashMap.put(AbPathData.getInstance().EXTENSION_SEP, stringUtil.EMPTY_STRING);
        hashMap.put(",", stringUtil.EMPTY_STRING);
        hashMap.put("<", stringUtil.EMPTY_STRING);
        hashMap.put(">", stringUtil.EMPTY_STRING);
        hashMap.put("?", stringUtil.EMPTY_STRING);
        hashMap.put(AbPathData.getInstance().SEPARATOR, stringUtil.EMPTY_STRING);
        hashMap.put("~", stringUtil.EMPTY_STRING);
        hashMap.put("`", stringUtil.EMPTY_STRING);
        return hashMap;
    }

}

