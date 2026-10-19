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
using PickedUpLayerInterfaceFactoryInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterfaceFactoryInterface;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using DropLayerFactory = org.allbinary.game.layer.drop.DropLayerFactory;
using PickupLayerCircularStaticPool = org.allbinary.game.layer.pickup.PickupLayerCircularStaticPool;
using RaceTrackPickupLayer = org.allbinary.game.layer.pickup.RaceTrackPickupLayer;
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using GPoint = org.allbinary.graphics.GPoint;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;

namespace org.allbinary.media.graphics.geography.map.racetrack.drop;

public class RaceTrackRandomDropCellPositionGenerator : RaceTrackDropCellPositionGenerator
{
    private static RaceTrackRandomDropCellPositionGenerator SINGLETON = new RaceTrackRandomDropCellPositionGenerator();
    public static RaceTrackRandomDropCellPositionGenerator getInstance()
    {
        return RaceTrackRandomDropCellPositionGenerator.SINGLETON;
    }

    private readonly MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
    private readonly int cellsPerRowOrColumn = 3;
    private readonly int totalCells;
    private readonly int[] rowArray = new int[] { 0, 1, 2, 0, 1, 2, 0, 1, 2 };
    private readonly int[] columnArray = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
    private int cellWidth = 0;
    private int cellHeight = 0;
    private RaceTrackRandomDropCellPositionGenerator()
    {
        this.totalCells = this.cellsPerRowOrColumn * this.cellsPerRowOrColumn;
    }

    // throws Exception
    public override void update(AllBinaryGameLayerManager allBinaryGameLayerManager, BasicGeographicMap geographicMapInterface)
    {
        base.update(allBinaryGameLayerManager, geographicMapInterface);
        AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        this.cellWidth = tiledLayer.getCellWidth() / this.cellsPerRowOrColumn;
        this.cellHeight = tiledLayer.getCellHeight() / this.cellsPerRowOrColumn;
    }

    // throws Exception
    protected override void drop(AllBinaryLayerManager allBinaryLayerManager, int index)
    {
        GeographicMapCellPosition geographicMapCellPosition = ((GeographicMapCellPosition) this.list.get(index));
        GPoint point = geographicMapCellPosition.getPoint();
        int randomCell = this.myRandomFactory.getAbsoluteNextInt(this.totalCells);
        int row = this.rowArray[randomCell];
        int column = this.columnArray[randomCell];
        int x = point.getX() + (row * this.cellWidth);
        int y = point.getY() + (column * this.cellHeight);
        PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactory = DropLayerFactory.getInstance().getRandomInstance();
        AllBinaryTiledLayer tiledLayer = this.raceTrackGeographicMap.getAllBinaryTiledLayer();
        RaceTrackPickupLayer pickupLayer = ((RaceTrackPickupLayer) PickupLayerCircularStaticPool.getInstance().getInstanceXYZ(pickedUpLayerInterfaceFactory, x, y, tiledLayer.getZP() + 3));
        pickupLayer.setTiledLayer(tiledLayer);
        allBinaryLayerManager.append(pickupLayer);
    }

}

