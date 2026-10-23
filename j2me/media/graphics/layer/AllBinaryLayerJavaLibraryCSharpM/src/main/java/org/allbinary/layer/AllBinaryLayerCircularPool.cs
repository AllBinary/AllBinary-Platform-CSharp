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

namespace org.allbinary.layer;

public class AllBinaryLayerCircularPool : BaseCircularPool
{
    public AllBinaryLayerCircularPool()
    {
    }

    // throws Exception
    public virtual void initAllBinaryLayerCircularPool(AllBinaryLayerFactoryInterface allbinaryLayerFactoryInterface, int total)
    {
        this.circularIndexUtil = CircularIndexUtil.createInstance(total);
        this.OBJECT_ARRAY = new AllBinaryLayer[total];
        for (int localIndex = 0; localIndex < total; localIndex++) {
            this.OBJECT_ARRAY[localIndex] = allbinaryLayerFactoryInterface.getInstance();
        }
    }

}

