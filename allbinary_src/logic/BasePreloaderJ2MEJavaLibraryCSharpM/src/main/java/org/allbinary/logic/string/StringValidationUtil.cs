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

namespace org.allbinary.logic.@string;

public class StringValidationUtil
{
    private static readonly StringValidationUtil instance = new StringValidationUtil();
    public static StringValidationUtil getInstance()
    {
        return StringValidationUtil.instance;
    }

    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private StringValidationUtil()
    {
    }

    public virtual bool containsSpaces(string value)
    {
        if (value.IndexOf(' ') >= 0) {
            return true;
        }
        return false;
    }

    public virtual bool isNumber(string value)
    {
        int numberOfDecimalPoints = 0;
        for (int index = 0; index < value.Length; index++) {
            char digit = value[index];
            if (!this.isNumberFromChar(digit) && digit != '.') {
                return false;
            }
            if (digit == '.') {
                numberOfDecimalPoints++;
                if (numberOfDecimalPoints > 1) {
                    return false;
                }
            }
        }
        return true;
    }

    public virtual bool isNumberFromChar(char digit)
    {
        if (digit != '0' && digit != '1' && digit != '2' && digit != '3' && digit != '4' && digit != '5' && digit != '6' && digit != '7' && digit != '8' && digit != '9') {
            return false;
        }
        return true;
    }

    public virtual bool isValidRequired(string value, int min, int max)
    {
        if (value == null || value.Length < min || value.Length > max) {
            return false;
        }
        return true;
    }

    public virtual bool isValidRequiredNumber(string value, int min, int max)
    {
        if (this.isEmpty(value) || value.Length < min || value.Length > max) {
            return false;
        }
        if (!this.isNumber(value)) {
            return false;
        }
        return true;
    }

    public virtual bool isValidNotRequired(string value, int min, int max)
    {
        if (value != null) {
            if (value.Length < min || value.Length > max) {
                return false;
            }
        }
        return true;
    }

    public virtual bool isValidNotRequiredNumber(string value, int min, int max)
    {
        if (value != null) {
            if (this.tsUtil.compareTo(value, this.stringUtil.NULL_STRING) == 0 || value.Length < min || value.Length > max) {
                return false;
            }
            if (!this.isNumber(value)) {
                return false;
            }
        }
        return true;
    }

    public virtual bool isEmpty(string @string)
    {
        if (@string != null && this.tsUtil.compareTo(@string, this.stringUtil.NULL_STRING) != 0 && this.tsUtil.compareTo(@string, this.stringUtil.EMPTY_STRING) != 0) {
            return false;
        } else {
            return true;
        }
    }

}

