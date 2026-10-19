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
using GroupCommonFactory = org.allbinary.game.identification.GroupCommonFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using LayerCoveringCellPositionsUtil = org.allbinary.game.layer.geographic.map.LayerCoveringCellPositionsUtil;
using GPoint = org.allbinary.graphics.GPoint;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using StdUtil = org.allbinary.logic.StdUtil;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapDirectionUtil = org.allbinary.media.graphics.geography.map.GeographicMapDirectionUtil;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using DropCellPositionGeneratorInterface = org.allbinary.media.graphics.geography.map.drop.DropCellPositionGeneratorInterface;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;
using BaseRaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.BaseRaceTrackGeographicMap;
using RaceTrackGeographicMapCellType = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellType;
using RaceTrackGeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellTypeFactory;
using org.allbinary.util;

namespace org.allbinary.media.graphics.geography.map.racetrack.drop;

public class RaceTrackAdjacentDropCellPositionGenerator : RaceTrackDropCellPositionGenerator
{
    private static RaceTrackAdjacentDropCellPositionGenerator SINGLETON = new RaceTrackAdjacentDropCellPositionGenerator();
    public static DropCellPositionGeneratorInterface getInstance()
    {
        return RaceTrackAdjacentDropCellPositionGenerator.SINGLETON;
    }

    private readonly LayerCoveringCellPositionsUtil layerCoveringCellPositionsUtil = LayerCoveringCellPositionsUtil.getInstance();
    private readonly GroupCommonFactory groupCommonFactory = GroupCommonFactory.getInstance();
    private GeographicMapCellPosition[] surroundingCellPositions = new GeographicMapCellPosition[4];
    private RaceTrackAdjacentDropCellPositionGenerator()
    {
    }

    // throws Exception
    private GeographicMapCellPosition getFirstNonRoadAdjacentCellPosition(int column, int row)
    {
        GeographicMapCellPosition nonRoadGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = this.raceTrackGeographicMap.getGeographicMapCellPositionFactory();
        this.surroundingCellPositions[0] = geographicMapCellPositionFactory.getAt(column, row - 1);
        this.surroundingCellPositions[1] = geographicMapCellPositionFactory.getAt(column, row + 1);
        this.surroundingCellPositions[2] = geographicMapCellPositionFactory.getAt(column - 1, row);
        this.surroundingCellPositions[3] = geographicMapCellPositionFactory.getAt(column + 1, row);
        BaseRaceTrackGeographicMap baseRaceTrackGeographicMap = ((BaseRaceTrackGeographicMap) this.raceTrackGeographicMap);
        RaceTrackGeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = ((RaceTrackGeographicMapCellTypeFactory) baseRaceTrackGeographicMap.getGeographicMapCellTypeFactory());
        GeographicMapCellPosition geographicMapCellPosition = null;
        RaceTrackGeographicMapCellType raceTrackGeographicMapCellType = null;
        for (int index = this.surroundingCellPositions.Length; --index >= 0; ) {
            geographicMapCellPosition = this.surroundingCellPositions[index];
            raceTrackGeographicMapCellType = ((RaceTrackGeographicMapCellType) this.raceTrackGeographicMap.getCellTypeAt(geographicMapCellPosition));
            if (!raceTrackGeographicMapCellTypeFactory.isPath(raceTrackGeographicMapCellType)) {
                nonRoadGeographicMapCellPosition = geographicMapCellPosition;
                break;
            }
        }
        return nonRoadGeographicMapCellPosition;
    }

    private readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    // throws Exception
    public override void update(AllBinaryGameLayerManager allBinaryGameLayerManager, BasicGeographicMap geographicMapInterface)
    {
        this.hashtable.put(AllBinaryGameLayerManager.ID, allBinaryGameLayerManager);
        base.update(allBinaryGameLayerManager, geographicMapInterface);
    }

    private readonly GeographicMapDirectionUtil geographicMapDirectionUtil = GeographicMapDirectionUtil.getInstance();
    // throws Exception
    protected override void drop(AllBinaryLayerManager allBinaryLayerManager, int index)
    {
        GeographicMapCellPosition geographicMapCellPosition = ((GeographicMapCellPosition) this.list.get(index));
        GeographicMapCellPosition randomGeographicMapCellPosition = this.getFirstNonRoadAdjacentCellPosition(geographicMapCellPosition.getColumn(), geographicMapCellPosition.getRow());
        if (randomGeographicMapCellPosition == null) {
            return;
        }
        DropCellPositionHistory dropCellPositionHistory = DropCellPositionHistory.getInstance();
        if (!dropCellPositionHistory.isCellPositionWithDrop(geographicMapCellPosition)) {
            Direction direction = this.geographicMapDirectionUtil.getDirectionFromCellPositionToAdjacentCellPosition(randomGeographicMapCellPosition, geographicMapCellPosition);
            object objectCanBeNull = this.hashtable.get(this.groupCommonFactory.ID);
            if (objectCanBeNull != null) {
            } else {
                this.hashtable.put(this.groupCommonFactory.ID, BasicGroupFactory.getInstance().NONE_ARRAY);
            }
            this.hashtable.put(DirectionFactory.getInstance().NAME, direction);
            GPoint point = randomGeographicMapCellPosition.getPoint();
            int x = point.getX();
            int y = point.getY();
            int z = point.getZ();
            AllBinaryLayer layerInterface = RaceTrackAdjacentDropLayerFactory.getInstance().getRandomInstance().getNextInstance(hashtable, x, y, z);
            BaseRaceTrackGeographicMap baseRaceTrackGeographicMap = ((BaseRaceTrackGeographicMap) this.raceTrackGeographicMap);
            BasicArrayList list = this.layerCoveringCellPositionsUtil.getAll(baseRaceTrackGeographicMap, randomGeographicMapCellPosition, layerInterface, new BasicArrayListD());
            if (dropCellPositionHistory.anyCellPositionWithDrop(list)) {
                return;
            }
            GeographicMapCellType geographicMapCellType = null;
            for (int index2 = list.size(); --index2 >= 0; ) {
                geographicMapCellType = this.raceTrackGeographicMap.getCellTypeAt(((GeographicMapCellPosition) list.get(index2)));
                if (this.raceTrackGeographicMapCellTypeFactory.isPath(geographicMapCellType)) {
                    return;
                }
            }
            dropCellPositionHistory.addAll(list, layerInterface);
            allBinaryLayerManager.append(layerInterface);
        }
    }

}

