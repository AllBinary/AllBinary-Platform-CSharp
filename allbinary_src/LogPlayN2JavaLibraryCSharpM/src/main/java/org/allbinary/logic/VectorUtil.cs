/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2026 AllBinary 
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
//using JsType = jsinterop.annotations.JsType;

namespace org.allbinary.logic;

public class VectorUtil
{
    private static readonly VectorUtil instance = new VectorUtil();
    public static VectorUtil getInstance()
    {
        return VectorUtil.instance;
    }

    public virtual int getSize(object anyType)
    {
        Vector<object> vector = ((Vector<object>) anyType);
        return vector.size();
    }

    public virtual object elementAt(object anyType, int index)
    {
        Vector<object> vector = ((Vector<object>) anyType);
        return vector.elementAt(index);
    }

}

