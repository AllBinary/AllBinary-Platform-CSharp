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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.logic.util.cache;

public class BaseBasicArrayListCache
{
    public readonly BasicArrayList list = new BasicArrayListD();
    public virtual string log()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("S: ");
        stringBuffer.appendint(this.list.size());
        return stringBuffer.ToString();
    }

}

