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
using CommonStrings = org.allbinary.@string.CommonStrings;
using PathFindingNodeCostInfoData = org.allbinary.media.graphics.geography.pathfinding.PathFindingNodeCostInfoData;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class EmptyRaceRaceTrackGeographicMapCellTypeFactory : RaceTrackGeographicMapCellTypeFactory
{
    private static readonly EmptyRaceRaceTrackGeographicMapCellTypeFactory instanceC = new EmptyRaceRaceTrackGeographicMapCellTypeFactory();
    public static EmptyRaceRaceTrackGeographicMapCellTypeFactory getInstance()
    {
        return EmptyRaceRaceTrackGeographicMapCellTypeFactory.instanceC;
    }

    private EmptyRaceRaceTrackGeographicMapCellTypeFactory()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.EMPTY_CELL_TYPE = new RaceTrackGeographicMapCellType(commonStrings.EMPTY, 0, PathFindingNodeCostInfoData.getInstance().MAX_NODE_COST, 1);
        this.EASY_CELL_TYPE = new RaceTrackGeographicMapCellType("Easy", 19, 1, 0);
        this.FINISH_LINE_ROAD_CELL_TYPE = this.DEFAULT_FINISH_LINE_ROAD_CELL_TYPE;
    }

}

