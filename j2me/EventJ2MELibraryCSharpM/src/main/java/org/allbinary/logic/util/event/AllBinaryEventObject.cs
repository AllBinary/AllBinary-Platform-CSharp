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
using NullUtil = org.allbinary.logic.NullUtil;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.logic.util.@event;

public class AllBinaryEventObject
{
    public static readonly AllBinaryEventObject NULL_EVENT = new AllBinaryEventObject(NullUtil.getInstance().NULL_OBJECT);
    private object source;
    public AllBinaryEventObject(object anyType)
    {
        this.source = anyType;
    }

    public virtual object getSource()
    {
        return this.source;
    }

    public virtual void setSource(object source)
    {
        this.source = source;
    }

}

