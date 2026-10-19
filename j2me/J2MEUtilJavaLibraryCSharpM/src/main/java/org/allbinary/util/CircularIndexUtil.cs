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
using CommonLabels = org.allbinary.@string.CommonLabels;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.util;

public class CircularIndexUtil
{
    public static readonly CircularIndexUtil NULL_CIRCULAR_INDEX_UTIL = new CircularIndexUtil(0, 0);
    private int index = 0;
    private int lastIndex = 0;
    private int size = 0;
    private CircularIndexUtil(int index, int size)
    {
        this.setSize(size);
        this.setIndex(index);
    }

    public virtual int next()
    {
        if (this.index >= this.lastIndex) {
            this.index = 0;
        } else {
            this.index++;
        }
        return this.index;
    }

    public virtual int previous()
    {
        if (this.index < 1) {
            this.index = this.lastIndex;
        } else {
            this.index--;
        }
        return this.index;
    }

    public virtual void setIndex(int index)
    {
        if (index > this.lastIndex) {
            return;
        }
        this.index = index;
    }

    public virtual int getIndex()
    {
        return this.index;
    }

    public static CircularIndexUtil createInstance(int max)
    {
        return new CircularIndexUtil(0, max);
    }

    public static CircularIndexUtil createInstanceAt(int index, int max)
    {
        return new CircularIndexUtil(index, max);
    }

    public virtual void setSize(int size)
    {
        this.size = size;
        this.lastIndex = size - 1;
        this.index = 0;
    }

    public virtual int getSize()
    {
        return this.size;
    }

    public override string ToString()
    {
        return new StringMaker().append(CommonLabels.getInstance().INDEX_LABEL).appendint(this.index).append("lastIndex: ").appendint(this.lastIndex).append("size: ").appendint(this.size).ToString();
    }

}

