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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.layer;

public class BasicLayerProcessor
{
    public static readonly BasicLayerProcessor NULL_LAYER_PROCESSOR = new BasicLayerProcessor();
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly BasicArrayList list = new BasicArrayListD();
    public BasicLayerProcessor()
    {
    }

    public virtual void add(AllBinaryLayer layerInterface)
    {
        if (!this.list.contains(layerInterface)) {
            this.list.add(layerInterface);
        }
    }

    // throws Exception
    public virtual void process(AllBinaryLayerManager allBinaryLayerManager)
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

