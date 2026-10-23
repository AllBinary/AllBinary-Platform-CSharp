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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.util.queue;

public class BasicQueue
{
    public readonly BasicArrayList queueVector = new BasicArrayListD();
    public BasicQueue()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool offer(object anyType)
    {
        this.queueVector.add(anyType);
        return true;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void remove(object anyType)
    {
        this.queueVector.remove(anyType);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual object removeLast()
    {
        object anyType = this.queueVector.get(this.queueVector.size() - 1);
        this.queueVector.remove(anyType);
        return anyType;
    }

}

