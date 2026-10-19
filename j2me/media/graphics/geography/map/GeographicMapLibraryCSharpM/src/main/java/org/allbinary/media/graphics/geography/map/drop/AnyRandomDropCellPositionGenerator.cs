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
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using NullUtil = org.allbinary.logic.NullUtil;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;

namespace org.allbinary.media.graphics.geography.map.drop;

public class AnyRandomDropCellPositionGenerator : BaseDropCellPositionGenerator
{
    public readonly BasicArrayList list = new BasicArrayListD();
    public object geographicMapInterface = NullUtil.getInstance().NULL_OBJECT;
    // throws Exception
    public override void update(AllBinaryGameLayerManager allBinaryGameLayerManager, BasicGeographicMap geographicMapInterface)
    {
        this.geographicMapInterface = geographicMapInterface;
        BasicGeographicMapCellPositionFactory basicGeographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        MyRandomFactory randomFactory = MyRandomFactory.getInstance();
        AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        int total = tiledLayer.getColumns() * tiledLayer.getRows();
        int randomColumn = 0;
        int randomRow = 0;
        GeographicMapCellPosition geographicMapCellPosition = null;
        for (int index = total; --index >= 0; ) {
            randomColumn = randomFactory.getAbsoluteNextInt(tiledLayer.getColumns());
            randomRow = randomFactory.getAbsoluteNextInt(tiledLayer.getRows());
            geographicMapCellPosition = basicGeographicMapCellPositionFactory.getAt(randomColumn, randomRow);
            if (this.isDropAllowedAt(geographicMapCellPosition)) {
                this.list.add(geographicMapCellPosition);
            }
        }
    }

    // throws Exception
    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
    }

}

