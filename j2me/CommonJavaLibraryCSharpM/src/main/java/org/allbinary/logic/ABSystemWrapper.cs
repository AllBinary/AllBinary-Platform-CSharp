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
//using JsType = jsinterop.annotations.JsType;

namespace org.allbinary.logic;

public class ABSystemWrapper
{
    private static readonly ABSystemWrapper instance = new ABSystemWrapper();
    public static ABSystemWrapper getInstance()
    {
        return ABSystemWrapper.instance;
    }

    public virtual void arraycopy(object src, int srcPos, object dest, int destPos, int length)
    {
        Array.Copy((Array) src, srcPos, (Array) dest, destPos, length);
    }

    public virtual long currentTimeMillis()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }

}

