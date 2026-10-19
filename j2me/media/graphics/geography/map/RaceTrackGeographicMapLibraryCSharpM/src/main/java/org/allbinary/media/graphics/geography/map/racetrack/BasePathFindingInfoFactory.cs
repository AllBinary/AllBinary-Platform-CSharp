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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using PathFindingNode = org.allbinary.media.graphics.geography.pathfinding.PathFindingNode;
using GeographicMapCellPositionFactoryInitVisitorInterface = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionFactoryInitVisitorInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class BasePathFindingInfoFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    // throws Exception
    public virtual void init(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int[][] mapArray)
    {
        class RaceTrackGeographicMapCellPositionFactoryInitVisitor : GeographicMapCellPositionFactoryInitVisitorInterface
        {
            private int startLineId;
            private int finishLineId;
            public RaceTrackGeographicMapCellPositionFactoryInitVisitor()
            {
                GeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = geographicMapInterface.getGeographicMapCellTypeFactory();
                this.startLineId = raceTrackGeographicMapCellTypeFactory.getStartType();
                this.finishLineId = raceTrackGeographicMapCellTypeFactory.getEndType();
            }

            // throws Exception
            public virtual void visit(AllBinaryTiledLayer tiledLayer, GeographicMapCellPosition cellPosition)
            {
                int row = cellPosition.getRow();
                int column = cellPosition.getColumn();
                try {
                    int cellTypeId = mapArray[row][column];
                    int geographicCellType = geographicMapInterface.getCellTypeFromMapCellTypeInt(cellTypeId);
                    if (geographicCellType == this.startLineId) {
                        this.addStartPathFindingNode(pathFindingInfo, cellPosition);
                    }
                    if (geographicCellType == this.finishLineId) {
                        if (geographicCellType == this.startLineId) {
                            this.addEndPathFindingNode(pathFindingInfo, geographicMapInterface.getGeographicMapCellPositionFactoryInterface().getInstance(geographicMapInterface, cellPosition.getColumn(), cellPosition.getRow(), tiledLayer.getColumns(), tiledLayer.getRows(), tiledLayer.getCellWidth(), tiledLayer.getCellHeight()));
                        } else {
                            this.addEndPathFindingNode(pathFindingInfo, cellPosition);
                        }
                    }
                    GeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = geographicMapInterface.getGeographicMapCellTypeFactory();
                    GeographicMapCellTypeFactory geographicMapCellTypeFactory = GeographicMapCellTypeFactory.getInstance();
                    if (raceTrackGeographicMapCellTypeFactory.isPath(geographicMapCellTypeFactory.get(geographicCellType))) {
                        RaceTrackRoadsGeographicMapCellHistoryFactory.getInstance().track(cellPosition);
                    } else {
                    }
                } catch (Exception e) {
                    CommonSeps commonSeps = CommonSeps.getInstance();
                    logUtil.put(new StringMaker().append(commonSeps.BRACKET_OPEN).appendint(row).append(commonSeps.BRACKET_CLOSE).append(commonSeps.BRACKET_OPEN).appendint(column).append("] in [").appendint(mapArray.Length).append(commonSeps.BRACKET_CLOSE).append(commonSeps.BRACKET_OPEN).appendint(mapArray[0].Length).append(commonSeps.BRACKET_CLOSE).ToString(), this, "visit", e);
                    throw e;
                }
            }

        }
        geographicMapInterface.getGeographicMapCellPositionFactory().visit(new RaceTrackGeographicMapCellPositionFactoryInitVisitor());
    }

    // throws Exception
    private void addStartPathFindingNode(PathFindingInfo pathFindingInfo, GeographicMapCellPosition startGeographicMapCellPosition)
    {
        pathFindingInfo.addStartPathFindingNode(new PathFindingNode(NullUtil.getInstance().NULL_OBJECT, startGeographicMapCellPosition));
    }

    // throws Exception
    private void addEndPathFindingNode(PathFindingInfo pathFindingInfo, GeographicMapCellPosition endGeographicMapCellPosition)
    {
        pathFindingInfo.addEndPathFindingNode(new PathFindingNode(NullUtil.getInstance().NULL_OBJECT, endGeographicMapCellPosition));
    }

    // throws Exception
    public virtual PathFindingInfo getInstancePathFindingInfo(BasicGeographicMap geographicMapInterface, int[][] graphArray)
    {
        throw new SystemException();
    }

}

