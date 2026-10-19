/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
//using JsConstructor = jsinterop.annotations.JsConstructor;

namespace org.allbinary.util;

public class BasicArrayListS : BasicArrayList
{
    public BasicArrayListS(int size) : base(NullUtil.getInstance().NULL_OBJECT_ARRAY)
    {
        // base(NullUtil.getInstance().NULL_OBJECT_ARRAY) is called from the constructor declaration
        if (size < 0) {
            throw new ArgumentException(new StringMaker().append("Init Size Exception: ").appendint(size).ToString());
        }
        this.objectArray = new object[size];
    }

}

