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
//using JsType = jsinterop.annotations.JsType;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.logic.@string;

public class StringUtil
{
    private static readonly StringUtil instance = new StringUtil();
    public static StringUtil getInstance()
    {
        return StringUtil.instance;
    }

    public readonly string INIT_STRING = new string(("").ToCharArray());
    public readonly string NULL_STRING = "null";
    public readonly string EMPTY_STRING = "";
    public string[] ONE_EMPTY_STRING_ARRAY;
    private readonly string[] stringArray = new string[0];
    private StringUtil()
    {
        this.ONE_EMPTY_STRING_ARRAY = new string[] { this.EMPTY_STRING };
    }

    public virtual string getNonNull(string @string)
    {
        if (@string == null) {
            return this.EMPTY_STRING;
        } else {
            return @string;
        }
    }

    public virtual string[] getArrayInstance()
    {
        return this.stringArray;
    }

    public virtual int count(string @string, char aChar)
    {
        int count = 0;
        int size = @string.Length;
        for (int index = 0; index < size; index++) {
            if (@string[index] == aChar) {
                count++;
            }
        }
        return count;
    }

    public virtual string toString(object anyType)
    {
        if (anyType != null) {
            return anyType.ToString();
        } else {
            return this.NULL_STRING;
        }
    }

}

