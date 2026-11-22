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
        
        geographicMapInterface.getGeographicMapCellPositionFactory().visit(new RaceTrackGeographicMapCellPositionFactoryInitVisitor(this, geographicMapInterface, pathFindingInfo, mapArray));
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

        class RaceTrackGeographicMapCellPositionFactoryInitVisitor : GeographicMapCellPositionFactoryInitVisitorInterface
        {
            internal int startLineId;
            internal int finishLineId;
            internal readonly BasePathFindingInfoFactory pathFindingInfoFactory;
            internal readonly BasicGeographicMap geographicMapInterface;
            internal readonly PathFindingInfo pathFindingInfo;
            internal readonly int[][] mapArray;
            public RaceTrackGeographicMapCellPositionFactoryInitVisitor(BasePathFindingInfoFactory pathFindingInfoFactory, BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int[][] mapArray)
            {
                this.pathFindingInfoFactory = pathFindingInfoFactory;
                this.geographicMapInterface = geographicMapInterface;
                this.pathFindingInfo = pathFindingInfo;
                this.mapArray = mapArray;
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
                    int cellTypeId = this.mapArray[row][column];
                    int geographicCellType = this.geographicMapInterface.getCellTypeFromMapCellTypeInt(cellTypeId);
                    if (geographicCellType == this.startLineId) {
                        this.pathFindingInfoFactory.addStartPathFindingNode(this.pathFindingInfo, cellPosition);
                    }
                    if (geographicCellType == this.finishLineId) {
                        if (geographicCellType == this.startLineId) {
                            this.pathFindingInfoFactory.addEndPathFindingNode(this.pathFindingInfo, this.geographicMapInterface.getGeographicMapCellPositionFactoryInterface().getInstance(this.geographicMapInterface, cellPosition.getColumn(), cellPosition.getRow(), tiledLayer.getColumns(), tiledLayer.getRows(), tiledLayer.getCellWidth(), tiledLayer.getCellHeight()));
                        } else {
                            this.pathFindingInfoFactory.addEndPathFindingNode(this.pathFindingInfo, cellPosition);
                        }
                    }
                    GeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = this.geographicMapInterface.getGeographicMapCellTypeFactory();
                    GeographicMapCellTypeFactory geographicMapCellTypeFactory = GeographicMapCellTypeFactory.getInstance();
                    if (raceTrackGeographicMapCellTypeFactory.isPath(geographicMapCellTypeFactory.get(geographicCellType))) {
                        RaceTrackRoadsGeographicMapCellHistoryFactory.getInstance().track(cellPosition);
                    } else {
                    }
                } catch (Exception e) {
                    CommonSeps commonSeps = CommonSeps.getInstance();
                    this.pathFindingInfoFactory.logUtil.put(new StringMaker().append(commonSeps.BRACKET_OPEN).appendint(row).append(commonSeps.BRACKET_CLOSE).append(commonSeps.BRACKET_OPEN).appendint(column).append("] in [").appendint(this.mapArray.Length).append(commonSeps.BRACKET_CLOSE).append(commonSeps.BRACKET_OPEN).appendint(this.mapArray[0].Length).append(commonSeps.BRACKET_CLOSE).ToString(), this, "visit", e);
                    throw e;
                }
            }

        }

}

