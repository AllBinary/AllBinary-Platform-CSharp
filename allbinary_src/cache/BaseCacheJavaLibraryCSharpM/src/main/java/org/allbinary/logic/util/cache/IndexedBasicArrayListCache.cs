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
using CommonStrings = org.allbinary.@string.CommonStrings;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.logic.util.cache;

public class IndexedBasicArrayListCache : BaseBasicArrayListCache, CacheInterface
{
    // throws Exception
    public static IndexedBasicArrayListCache createCache(int size)
    {
        IndexedBasicArrayListCache indexedBasicArrayListCache = new IndexedBasicArrayListCache();
        indexedBasicArrayListCache.init(size);
        return indexedBasicArrayListCache;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private int size = 0;
    public int index = 0;
    public IndexedBasicArrayListCache()
    {
    }

    // throws Exception
    public virtual void init(int size)
    {
        if (this.size < size) {
            this.list.ensureCapacity(size);
            for (int index = size - 1; index >= this.size; index--) {
                this.addDefault();
            }
            this.size = size;
        }
    }

    public virtual object getAt(int index)
    {
        return this.list.objectArray[index];
    }

    // throws Exception
    public virtual void addDefault()
    {
    }

    // throws Exception
    public virtual void addObject(object anyType)
    {
        this.list.add(anyType);
    }

    // throws Exception
    public override void add(CacheableInterface cacheableInterface)
    {
        this.list.add(cacheableInterface);
    }

    // throws Exception
    public override void addArray(CacheableInterface[] cacheableInterfaces)
    {
        throw new Exception("No Imple");
    }

    public override void clear()
    {
        this.index = 0;
    }

}

