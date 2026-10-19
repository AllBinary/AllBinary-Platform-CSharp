/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using WaypointLayer = org.allbinary.game.layer.waypoint.WaypointLayer;
using CellPosition = org.allbinary.graphics.CellPosition;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class CustomMapGenerator : CustomMapGeneratorBase
{
    private readonly int[][] customMapArray;
    private readonly RaceTrackGeographicMap raceTrackGeographicMap;
    private readonly GeographicMapCellTypeFactory geographicMapCellTypeFactory;
    public CustomMapGenerator(RaceTrackGeographicMap raceTrackGeographicMap)
    {
        this.raceTrackGeographicMap = raceTrackGeographicMap;
        this.geographicMapCellTypeFactory = this.raceTrackGeographicMap.getGeographicMapCellTypeFactory();
        int[][] mapArray = raceTrackGeographicMap.getRaceTrackData().getMapArray();
        int size2 = mapArray[0].Length;
        this.customMapArray = System.Linq.Enumerable.Range(0, mapArray.Length).Select(_ => new int[size2]).ToArray();
        if (mapArray.Length != this.customMapArray.Length || mapArray[0].Length != this.customMapArray[0].Length) {
            throw new Exception("Array Incorrect");
        }
    }

    // throws Exception
    public override void copyMapIntoCustomMap()
    {
        int[][] mapArray = this.raceTrackGeographicMap.getRaceTrackData().getMapArray();
        int startIndex2 = mapArray[0].Length - 1;
        for (int index = mapArray.Length - 1; index >= 0; index--) {
            for (int index2 = startIndex2; index2 >= 0; index2--) {
                this.customMapArray[index][index2] = this.getCustomType(index2, index, mapArray[index][index2]);
            }
        }
    }

    private readonly DropCellPositionHistory dropCellPositionHistory = DropCellPositionHistory.getInstance();
    // throws Exception
    public override int getCustomType(int column, int row, int currentType)
    {
        int emptyType = this.geographicMapCellTypeFactory.getEmptyType();
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = this.raceTrackGeographicMap.getGeographicMapCellPositionFactory();
        CellPosition cellPosition = geographicMapCellPositionFactory.getAt(column, row);
        if (this.dropCellPositionHistory.isCellPositionWithDrop(cellPosition)) {
            AllBinaryLayer layer = this.dropCellPositionHistory.getLayerInterface(cellPosition);
            if (layer == AllBinaryLayer.NULL_ALLBINARY_LAYER) {
                return emptyType;
            }
            AdvancedRTSGameLayer rtsLayer = ((AdvancedRTSGameLayer) layer);
            if (!(rtsLayer.getType() == WaypointLayer.getStaticType())) {
                return emptyType;
            }
        }
        return currentType;
    }

    public override int[][] getCustomMapArray()
    {
        return this.customMapArray;
    }

}

