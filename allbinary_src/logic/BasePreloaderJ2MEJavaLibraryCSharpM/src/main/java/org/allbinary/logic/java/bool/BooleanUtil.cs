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
using TsUtil = org.allbinary.TsUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.logic.java.@bool;

public class BooleanUtil
{
    private static readonly BooleanUtil instance = new BooleanUtil();
    public static BooleanUtil getInstance()
    {
        return BooleanUtil.instance;
    }

    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private BooleanUtil()
    {
    }

    // throws Exception
    public virtual bool getFromString(string booleanString)
    {
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        BooleanFactory booleanFactory = BooleanFactory.getInstance();
        if (stringValidationUtil.isEmpty(booleanString)) {
            return false;
        }
        string booleanStringLowerCase = booleanString.ToLower();
        if (this.tsUtil.compareTo(booleanStringLowerCase, booleanFactory.TRUE_STRING) == 0) {
            return true;
        } else if (this.tsUtil.compareTo(booleanStringLowerCase, booleanFactory.FALSE_STRING) == 0) {
            return false;
        } else {
            throw new Exception("Invalid booleanString - Must be true or false");
        }
    }

    // throws Exception
    public virtual bool isStringBoolean(string booleanString)
    {
        BooleanFactory booleanFactory = BooleanFactory.getInstance();
        string booleanStringLowerCase = booleanString.ToLower();
        if (string.CompareOrdinal(booleanStringLowerCase, booleanFactory.TRUE_STRING) == 0 || string.CompareOrdinal(booleanStringLowerCase, booleanFactory.FALSE_STRING) == 0) {
            return true;
        }
        return false;
    }

    public virtual string toStringFromBooleanArray(bool[] booleanArray)
    {
        StringMaker stringMaker = new StringMaker();
        int size = booleanArray.Length;
        for (int index = 0; index < size; index++) {
            stringMaker.appendboolean(booleanArray[index]);
        }
        return stringMaker.ToString();
    }

}

