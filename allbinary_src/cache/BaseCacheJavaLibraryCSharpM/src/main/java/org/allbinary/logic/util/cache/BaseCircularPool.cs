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
using System.Runtime.CompilerServices;
//using JsType = jsinterop.annotations.JsType;
using NullUtil = org.allbinary.logic.NullUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.logic.util.cache;

public class BaseCircularPool
{
    public CircularIndexUtil circularIndexUtil = CircularIndexUtil.NULL_CIRCULAR_INDEX_UTIL;
    public object[] OBJECT_ARRAY = NullUtil.getInstance().NULL_OBJECT_ARRAY;
    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual object getNextInstance()
    {
        object anyType = this.OBJECT_ARRAY[this.circularIndexUtil.getIndex()];
        this.circularIndexUtil.next();
        return anyType;
    }

    public virtual void init(AllBinaryObjectFactoryInterface allBinaryObjectFactoryInterface)
    {
        this.circularIndexUtil.setIndex(0);
        int size = this.circularIndexUtil.getSize();
        for (int index = 0; index < size; index++) {
            this.OBJECT_ARRAY[index] = allBinaryObjectFactoryInterface.getInstance();
        }
    }

    // throws Exception
    public virtual object getInstance(int index)
    {
        return this.OBJECT_ARRAY[index];
    }

}

