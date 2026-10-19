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
using BaseCircularPool = org.allbinary.logic.util.cache.BaseCircularPool;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.logic.util.@event;

public class AllBinaryEventCircularPool : BaseCircularPool
{
    public AllBinaryEventCircularPool(int max)
    {
        this.OBJECT_ARRAY = new object[max];
        this.circularIndexUtil = CircularIndexUtil.createInstance(max);
    }

    public virtual void initAllBinaryEventCircularPool(AllBinaryEventObjectFactoryInterface allBinaryEventObjectFactoryInterface)
    {
        this.circularIndexUtil.setIndex(0);
        int size = this.circularIndexUtil.getSize();
        for (int index = 0; index < size; index++) {
            this.OBJECT_ARRAY[index] = allBinaryEventObjectFactoryInterface.getInstance();
        }
    }

}

