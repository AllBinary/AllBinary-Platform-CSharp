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
using MultiGeographicMapBehavior = org.allbinary.media.graphics.geography.map.MultiGeographicMapBehavior;
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using BasicTerrainInfo = org.allbinary.game.terrain.BasicTerrainInfo;
using TerrainEvent = org.allbinary.game.terrain.TerrainEvent;
using TerrainEventCircularStaticPool = org.allbinary.game.terrain.TerrainEventCircularStaticPool;
using TerrainEventHandler = org.allbinary.game.terrain.TerrainEventHandler;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AngleFactory = org.allbinary.math.AngleFactory;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;

namespace org.allbinary.game.behavior.topview;

public class NonPlayerTopViewCharacterBehavior : TopViewCharacterBehavior
{
    private readonly MultiGeographicMapBehavior geographicMapBehavior = new MultiGeographicMapBehavior();
    private readonly BasicTerrainInfo CLIFF = new BasicTerrainInfo(AngleFactory.getInstance().DOWN);
    // throws Exception
    public virtual void terrainEvent(AllBinaryLayer layer, Direction direction, int x, int y, BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition)
    {
        int maxColumns = geographicMapInterfaceArray[0].getAllBinaryTiledLayer().getColumns();
        if (geographicMapCellPosition.getColumn() > 0 && geographicMapCellPosition.getColumn() < maxColumns) {
            GeographicMapCellPosition nextTerrainGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
            BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = geographicMapInterfaceArray[0].getGeographicMapCellPositionFactory();
            if (direction == DirectionFactory.getInstance().LEFT) {
                nextTerrainGeographicMapCellPosition = geographicMapCellPositionFactory.getAt(geographicMapCellPosition.getColumn() - 1, geographicMapCellPosition.getRow());
            } else if (direction == DirectionFactory.getInstance().RIGHT) {
                nextTerrainGeographicMapCellPosition = geographicMapCellPositionFactory.getAt(geographicMapCellPosition.getColumn() + 1, geographicMapCellPosition.getRow());
            }
            this.geographicMapBehavior.getCellTypeAt(geographicMapInterfaceArray, geographicMapCellTypeArray, nextTerrainGeographicMapCellPosition);
            bool hasSolidBlock = this.hasSolidBlock(geographicMapInterfaceArray, geographicMapCellTypeArray);
            if (!hasSolidBlock) {
                TerrainEvent terrainEvent = TerrainEventCircularStaticPool.getInstance().getNext(this.CLIFF);
                TerrainEventHandler.getInstance(layer).fireEvent(terrainEvent);
            }
        }
    }

    public override void terrainMove(AllBinaryLayer layer, BasicGeographicMap[] geographicMapInterfaceArray, int x, int y)
    {
        layer.moveDXY(x, y);
    }

}

