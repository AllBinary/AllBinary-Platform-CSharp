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
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackGeographicMapCellTypeFactory : GeographicMapCellTypeFactory
{
    private static readonly RaceTrackGeographicMapCellTypeFactory instanceC = new RaceTrackGeographicMapCellTypeFactory();
    public static RaceTrackGeographicMapCellTypeFactory getInstance()
    {
        return RaceTrackGeographicMapCellTypeFactory.instanceC;
    }

    public GeographicMapCellType EMPTY_CELL_TYPE = new GeographicMapCellType(0, -1);
    public GeographicMapCellType EASY_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType BOTTOM_LEFT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType BOTTOM_RIGHT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType TOP_LEFT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType TOP_RIGHT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType HORIZONTAL_STRAIGHT_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType VERTICAL_STRAIGHT_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType START_LINE_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType DEFAULT_FINISH_LINE_ROAD_CELL_TYPE;
    public GeographicMapCellType FINISH_LINE_ROAD_CELL_TYPE = GeographicMapCellType.NULL_GEOGRAPHIC_MAP_CELL_TYPE;
    public RaceTrackGeographicMapCellTypeFactory()
    {
        this.EASY_CELL_TYPE = this.EMPTY_CELL_TYPE;
        RaceTrackGeographicMapCellTypes raceTrackGeographicMapCellTypes = RaceTrackGeographicMapCellTypes.getInstance();
        this.BOTTOM_LEFT_TURN_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.BOTTOM_LEFT_TURN_ROAD_CELL_TYPE;
        this.BOTTOM_RIGHT_TURN_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.BOTTOM_RIGHT_TURN_ROAD_CELL_TYPE;
        this.TOP_LEFT_TURN_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.TOP_LEFT_TURN_ROAD_CELL_TYPE;
        this.TOP_RIGHT_TURN_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.TOP_RIGHT_TURN_ROAD_CELL_TYPE;
        this.HORIZONTAL_STRAIGHT_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.HORIZONTAL_STRAIGHT_ROAD_CELL_TYPE;
        this.VERTICAL_STRAIGHT_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.VERTICAL_STRAIGHT_ROAD_CELL_TYPE;
        this.START_LINE_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.START_LINE_ROAD_CELL_TYPE;
        this.DEFAULT_FINISH_LINE_ROAD_CELL_TYPE = raceTrackGeographicMapCellTypes.DEFAULT_FINISH_LINE_ROAD_CELL_TYPE;
    }

    public override int getStartType()
    {
        return this.START_LINE_ROAD_CELL_TYPE.getType();
    }

    public override int getEndType()
    {
        return this.FINISH_LINE_ROAD_CELL_TYPE.getType();
    }

    public override int getEmptyType()
    {
        return this.EMPTY_CELL_TYPE.getType();
    }

    public override bool isPath(GeographicMapCellType cellType)
    {
        if (cellType != this.EMPTY_CELL_TYPE && cellType != this.EASY_CELL_TYPE) {
            return true;
        }
        return false;
    }

}

