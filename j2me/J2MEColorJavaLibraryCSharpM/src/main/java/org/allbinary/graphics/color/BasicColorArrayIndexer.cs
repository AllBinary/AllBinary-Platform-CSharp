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
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;

namespace org.allbinary.graphics.color;

public class BasicColorArrayIndexer
{
    private BasicColor[] basicColorArray;
    private CircularIndexUtil circularIndexUtil;
    public BasicColorArrayIndexer(BasicColor[] basicColorArray)
    {
        this.basicColorArray = basicColorArray;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.basicColorArray.Length);
    }

    public virtual void next()
    {
        this.circularIndexUtil.next();
    }

    public virtual BasicColor get()
    {
        return this.basicColorArray[this.circularIndexUtil.getIndex()];
    }

    public virtual BasicColor[] getBasicColorArray()
    {
        return this.basicColorArray;
    }

}

