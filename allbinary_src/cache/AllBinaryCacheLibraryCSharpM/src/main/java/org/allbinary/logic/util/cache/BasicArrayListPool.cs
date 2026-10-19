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
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.util.cache;

public class BasicArrayListPool : AbstractArrayListPool
{
    public BasicArrayListPool(CacheableInterfaceFactoryInterface cacheableInterfaceFactoryInterface) : base(cacheableInterfaceFactoryInterface)
    {
        // base(cacheableInterfaceFactoryInterface) is called from the constructor declaration
    }

    public override void clear()
    {
        this.buffers.clear();
    }

    // throws Exception
    public override CacheableInterface remove(object key)
    {
        int size = this.buffers.size();
        if (size > 0) {
            return ((CacheableInterface) this.buffers.removeAt(size - 1));
        } else {
            return this.cacheableInterfaceFactoryInterface.getInstance(key);
        }
    }

    // throws Exception
    public virtual void addAll(BasicArrayList usedList)
    {
        for (int index = usedList.size(); --index >= 0; ) {
            CacheableInterface anyType = ((CacheableInterface) usedList.objectArray[index]);
            this.add(anyType);
        }
        usedList.clear();
    }

    // throws Exception
    public virtual void releaseUsedBackToPool(BasicArrayList usedList)
    {
        for (int index = usedList.size(); --index >= 0; ) {
            BasicArrayListCacheable list = ((BasicArrayListCacheable) usedList.objectArray[index]);
            if (list.size() == 0) {
                usedList.removeAt(index);
                this.add(list);
            }
        }
    }

}

