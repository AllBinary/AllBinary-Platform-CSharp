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
using java.util;
//using JsMethod = jsinterop.annotations.JsMethod;

namespace org.allbinary.util;

//ArkTs does not have this.  So this is for the ArkTs build.
public class EnumerationUtil
{
    private static readonly EnumerationUtil instance = new EnumerationUtil();
    public static EnumerationUtil getInstance()
    {
        return EnumerationUtil.instance;
    }

    public virtual bool hasMoreElements(Enumeration<object> enumeration)
    {
        return enumeration.hasMoreElements();
    }

    public virtual object nextElement(Enumeration<object> enumeration)
    {
        return enumeration.nextElement();
    }

    public virtual object[] getAsArray(Enumeration<object> enumeration)
    {
        BasicArrayList basicArrayList = new BasicArrayListD();
        while (this.hasMoreElements(enumeration)) {
            basicArrayList.add(this.nextElement(enumeration));
        }
        return basicArrayList.toArray();
    }

}

