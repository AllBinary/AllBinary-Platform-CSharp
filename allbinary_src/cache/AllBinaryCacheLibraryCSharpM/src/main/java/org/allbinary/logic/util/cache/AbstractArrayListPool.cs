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
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.util.cache;

public class AbstractArrayListPool : PoolInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public BasicArrayList buffers = new BasicArrayListD();
    public CacheableInterfaceFactoryInterface cacheableInterfaceFactoryInterface;
    public AbstractArrayListPool(CacheableInterfaceFactoryInterface cacheableInterfaceFactoryInterface)
    {
        this.cacheableInterfaceFactoryInterface = cacheableInterfaceFactoryInterface;
    }

    // throws Exception
    public virtual void clear()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual CacheableInterface remove(object key)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual void add(CacheableInterface cacheableInterface)
    {
        this.buffers.add(cacheableInterface);
    }

    // throws Exception
    public virtual void addArray(CacheableInterface[] cacheableInterfaces)
    {
        for (int index = 0; index < cacheableInterfaces.Length; index++) {
            this.buffers.add(cacheableInterfaces[index]);
        }
    }

}

