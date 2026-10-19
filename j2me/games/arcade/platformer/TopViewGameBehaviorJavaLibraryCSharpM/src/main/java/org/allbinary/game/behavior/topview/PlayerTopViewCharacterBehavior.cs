/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using Direction = org.allbinary.direction.Direction;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using TrackingEventCircularStaticPool = org.allbinary.game.tracking.TrackingEventCircularStaticPool;
using TrackingEventHandler = org.allbinary.game.tracking.TrackingEventHandler;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapUtil = org.allbinary.media.graphics.geography.map.BasicGeographicMapUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;

namespace org.allbinary.game.behavior.topview;

public class PlayerTopViewCharacterBehavior : TopViewCharacterBehavior
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    // throws Exception
    public override void terrainEvent(AllBinaryLayer layer, Direction direction, int x, int y, BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellPosition geographicMapCellPosition)
    {
        TrackingEventHandler.getInstance().fireEvent(TrackingEventCircularStaticPool.getInstance().getNextInstance(layer));
    }

    public override void terrainMove(AllBinaryLayer layer, BasicGeographicMap[] geographicMapInterfaceArray, int x, int y)
    {
        BasicGeographicMapUtil basicGeographicMapUtil = BasicGeographicMapUtil.getInstance();
        basicGeographicMapUtil.setPosition(geographicMapInterfaceArray, x, y);
    }

    private void moveIfOnScreen(AllBinaryLayer layer, int ax, int ay)
    {
    }

    private bool isTiledLayerMoveable(AllBinaryTiledLayer terrainTiledLayer, int x, int y)
    {
        return (terrainTiledLayer.getXP() + DisplayInfoSingleton.getInstance().getLastWidth() < terrainTiledLayer.getWidth() || x < 0) && (terrainTiledLayer.getXP() > 0 || x > 0);
    }

}

