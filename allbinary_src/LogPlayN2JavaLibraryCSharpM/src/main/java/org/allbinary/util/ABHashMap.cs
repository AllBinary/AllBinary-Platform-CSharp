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
//using java.util;
//using JsType = jsinterop.annotations.JsType;

namespace org.allbinary.util;

public class ABHashMap<K, V> : HashMap<K, V>
{
    public override int size()
    {
        return base.size();
    }

    public override bool isEmpty()
    {
        return base.isEmpty();
    }

    public override V get(object key)
    {
        return base.get(key);
    }

    public override bool containsKey(object key)
    {
        return base.containsKey(key);
    }

    public override V put(K key, V value)
    {
        return base.put(key, value);
    }

    public override void putAll(Map<object, object> map)
    {
        base.putAll(map);
    }

    public override V remove(object key)
    {
        return base.remove(key);
    }

    public override void clear()
    {
        base.clear();
    }

    public override bool containsValue(object value)
    {
        return base.containsValue(value);
    }

    public override Set<K> keySet()
    {
        return base.keySet();
    }

    public override Set<Map.Entry<K, V>> entrySet()
    {
        return base.entrySet();
    }

    public override V getOrDefault(object key, V defaultValue)
    {
        return base.getOrDefault(key, defaultValue);
    }

    public override V putIfAbsent(K key, V value)
    {
        return base.putIfAbsent(key, value);
    }

    public override object clone()
    {
        return base.clone();
    }

}

