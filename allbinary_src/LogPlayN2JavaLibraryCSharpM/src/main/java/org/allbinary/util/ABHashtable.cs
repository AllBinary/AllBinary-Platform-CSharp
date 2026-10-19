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
//using Set = java.util.Set;
//using JsType = jsinterop.annotations.JsType;

namespace org.allbinary.util;

public class ABHashtable<K, V> : Hashtable<K, V>
{
    public ABHashtable() : base()
    {
        // base() is called from the constructor declaration
    }

    public override int size()
    {
        return base.size();
    }

    public override bool isEmpty()
    {
        return base.isEmpty();
    }

    public override Enumeration<V> elements()
    {
        return base.elements();
    }

    public override bool contains(object value)
    {
        return base.contains(value);
    }

    public override bool containsValue(object value)
    {
        return base.containsValue(value);
    }

    public override bool containsKey(object key)
    {
        return base.containsKey(key);
    }

    public override V get(object key)
    {
        return base.get(key);
    }

    public override void clear()
    {
        base.clear();
    }

    public override object clone()
    {
        return base.clone();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}

