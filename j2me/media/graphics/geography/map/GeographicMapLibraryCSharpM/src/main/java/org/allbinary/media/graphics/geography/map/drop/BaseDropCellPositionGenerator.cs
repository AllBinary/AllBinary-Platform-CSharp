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
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;

namespace org.allbinary.media.graphics.geography.map.drop;

public class BaseDropCellPositionGenerator : DropCellPositionGeneratorInterface
{
    public virtual string getName()
    {
        return this.GetType().FullName;
    }

    // throws Exception
    public virtual void update(AllBinaryGameLayerManager allBinaryGameLayerManager, BasicGeographicMap geographicMapInterface)
    {
    }

    // throws Exception
    public virtual bool isDropAllowedAt(GeographicMapCellPosition geographicMapCellPosition)
    {
        return true;
    }

    // throws Exception
    public virtual void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
    }

}

