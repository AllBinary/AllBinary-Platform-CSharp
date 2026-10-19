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
using PointFactory = org.allbinary.graphics.PointFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.layer.relationship;

public class MiddleRelativeLayerRelationship : RelativeLayerRelationship
{
    public MiddleRelativeLayerRelationship(AllBinaryLayer layer) : base(layer, PointFactory.getInstance().createXY(layer.getHalfWidth(), layer.getHalfHeight()), BasicArrayListUtil.getInstance().getImmutableInstance())
    {
        // base(layer, PointFactory.getInstance().createXY(layer.getHalfWidth(), layer.getHalfHeight()), BasicArrayListUtil.getInstance().getImmutableInstance()) is called from the constructor declaration
    }

}

