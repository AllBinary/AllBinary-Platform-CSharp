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

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackGeographicMapCellTypes
{
    private static readonly RaceTrackGeographicMapCellTypes instance = new RaceTrackGeographicMapCellTypes();
    public static RaceTrackGeographicMapCellTypes getInstance()
    {
        return RaceTrackGeographicMapCellTypes.instance;
    }

    public readonly RaceTrackGeographicMapCellType BOTTOM_LEFT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType BOTTOM_RIGHT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType TOP_LEFT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType TOP_RIGHT_TURN_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType HORIZONTAL_STRAIGHT_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType VERTICAL_STRAIGHT_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType START_LINE_ROAD_CELL_TYPE;
    public readonly RaceTrackGeographicMapCellType DEFAULT_FINISH_LINE_ROAD_CELL_TYPE;
    public RaceTrackGeographicMapCellTypes()
    {
        this.BOTTOM_LEFT_TURN_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Bottom Left Turn", 1, 1, 0);
        this.BOTTOM_RIGHT_TURN_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Bottom Right Turn", 2, 1, 0);
        this.TOP_LEFT_TURN_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Top Left Turn", 3, 1, 0);
        this.TOP_RIGHT_TURN_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Top Right Turne", 4, 1, 0);
        this.HORIZONTAL_STRAIGHT_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Horizontal Straight", 5, 1, 0);
        this.VERTICAL_STRAIGHT_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Vertical Straight", 6, 1, 0);
        this.START_LINE_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Start Line", 7, 1, 0);
        this.DEFAULT_FINISH_LINE_ROAD_CELL_TYPE = new RaceTrackGeographicMapCellType("Finish Line", 8, 1, 0);
    }

}

