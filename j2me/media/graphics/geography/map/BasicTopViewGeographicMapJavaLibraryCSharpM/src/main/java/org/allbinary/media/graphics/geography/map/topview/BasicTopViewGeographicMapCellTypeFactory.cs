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
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using RaceTrackGeographicMapCellType = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellType;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using HashtableUtil = org.allbinary.util.HashtableUtil;

namespace org.allbinary.media.graphics.geography.map.topview;

public class BasicTopViewGeographicMapCellTypeFactory : GeographicMapCellTypeFactory
{
    public readonly BasicTopViewGeographicMapCellType BLOCK_CELL_TYPE;
    public readonly BasicTopViewGeographicMapCellType OFF_MAP_CELL_TYPE;
    public readonly BasicTopViewGeographicMapCellType FLOOR_CELL_TYPE;
    public readonly BasicTopViewGeographicMapCellType DOOR_CELL_TYPE;
    public readonly BasicTopViewGeographicMapCellType STAIRS_UP_CELL_TYPE;
    public readonly BasicTopViewGeographicMapCellType STAIRS_DOWN_CELL_TYPE;
    public readonly BasicTopViewGeographicMapCellType OTHER_CELL_TYPE;
    private readonly int maxTileId;
    public BasicTopViewGeographicMapCellTypeFactory(ABHashtable<object, object> tileTypeToTileIdsMap, int maxTileId)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(commonStrings.START, this, commonStrings.CONSTRUCTOR);
        this.maxTileId = maxTileId;
        BasicTopViewGeographicMapStrings basicTopViewGeographicMapStrings = BasicTopViewGeographicMapStrings.getInstance();
        GeographicMapCellTypeFactory geographicMapCellTypeFactory = GeographicMapCellTypeFactory.getInstance();
        GeographicMapCellType[] geographicMapCellTypeArray = geographicMapCellTypeFactory.getGeographicMapCellTypeArray();
        int type = 0;
        if (geographicMapCellTypeArray[type] == null) {
            new RaceTrackGeographicMapCellType(CommonStrings.getInstance().UNKNOWN, type, 999, 0);
        } else {
        }
        BasicTopViewGeographicMapCellType BLOCK_CELL_TYPE = BasicTopViewGeographicMapCellType.createType(basicTopViewGeographicMapStrings.DEFAULT, 1, 1);
        BasicTopViewGeographicMapCellType OFF_MAP_CELL_TYPE = BLOCK_CELL_TYPE;
        BasicTopViewGeographicMapCellType FLOOR_CELL_TYPE = BLOCK_CELL_TYPE;
        BasicTopViewGeographicMapCellType DOOR_CELL_TYPE = BLOCK_CELL_TYPE;
        BasicTopViewGeographicMapCellType STAIRS_UP_CELL_TYPE = BLOCK_CELL_TYPE;
        BasicTopViewGeographicMapCellType STAIRS_DOWN_CELL_TYPE = BLOCK_CELL_TYPE;
        BasicTopViewGeographicMapCellType OTHER_CELL_TYPE = BLOCK_CELL_TYPE;
        object[] keyArray = HashtableUtil.getInstance().getKeysAsArray(tileTypeToTileIdsMap);
        int size = keyArray.Length;
        BasicArrayList idsWithTypeList = null;
        string key = null;
        BasicTopViewGeographicMapCellType basicPlatormGeographicMapCellType = null;
        for (int index = 0; index < size; index++) {
            key = ((string) keyArray[index]);
            idsWithTypeList = ((BasicArrayList) tileTypeToTileIdsMap.get(key));
            if (key.Equals(basicTopViewGeographicMapStrings.WALL)) {
                basicPlatormGeographicMapCellType = new BasicTopViewGeographicMapCellType(basicTopViewGeographicMapStrings.WALL, idsWithTypeList, 1000);
                BLOCK_CELL_TYPE = basicPlatormGeographicMapCellType;
            } else if (key.Equals(basicTopViewGeographicMapStrings.OFF_MAP)) {
                basicPlatormGeographicMapCellType = new BasicTopViewGeographicMapCellType(basicTopViewGeographicMapStrings.OFF_MAP, idsWithTypeList, 1001);
                OFF_MAP_CELL_TYPE = basicPlatormGeographicMapCellType;
            } else if (key.Equals(basicTopViewGeographicMapStrings.FLOOR)) {
                basicPlatormGeographicMapCellType = new BasicTopViewGeographicMapCellType(basicTopViewGeographicMapStrings.FLOOR, idsWithTypeList, 1);
                FLOOR_CELL_TYPE = basicPlatormGeographicMapCellType;
            } else if (key.Equals(basicTopViewGeographicMapStrings.DOOR)) {
                basicPlatormGeographicMapCellType = new BasicTopViewGeographicMapCellType(basicTopViewGeographicMapStrings.DOOR, idsWithTypeList, 1);
                DOOR_CELL_TYPE = basicPlatormGeographicMapCellType;
            } else if (key.Equals(basicTopViewGeographicMapStrings.STAIRS_UP)) {
                basicPlatormGeographicMapCellType = new BasicTopViewGeographicMapCellType(basicTopViewGeographicMapStrings.STAIRS_UP, idsWithTypeList, 1);
                STAIRS_UP_CELL_TYPE = basicPlatormGeographicMapCellType;
            } else if (key.Equals(basicTopViewGeographicMapStrings.STAIRS_DOWN)) {
                basicPlatormGeographicMapCellType = new BasicTopViewGeographicMapCellType(basicTopViewGeographicMapStrings.STAIRS_DOWN, idsWithTypeList, 1);
                STAIRS_DOWN_CELL_TYPE = basicPlatormGeographicMapCellType;
            } else if (key.Equals(basicTopViewGeographicMapStrings.OTHER)) {
                basicPlatormGeographicMapCellType = new BasicTopViewGeographicMapCellType(basicTopViewGeographicMapStrings.OTHER, idsWithTypeList, 1);
                OTHER_CELL_TYPE = basicPlatormGeographicMapCellType;
            }
        }
        this.BLOCK_CELL_TYPE = BLOCK_CELL_TYPE;
        this.OFF_MAP_CELL_TYPE = OFF_MAP_CELL_TYPE;
        this.FLOOR_CELL_TYPE = FLOOR_CELL_TYPE;
        this.DOOR_CELL_TYPE = DOOR_CELL_TYPE;
        this.STAIRS_UP_CELL_TYPE = STAIRS_UP_CELL_TYPE;
        this.STAIRS_DOWN_CELL_TYPE = STAIRS_DOWN_CELL_TYPE;
        this.OTHER_CELL_TYPE = OTHER_CELL_TYPE;
        type = this.maxTileId - 1;
        if (geographicMapCellTypeArray[type] == null) {
            new RaceTrackGeographicMapCellType(commonStrings.START, type, 1, 0);
        } else {
        }
        type = this.maxTileId - 2;
        if (geographicMapCellTypeArray[type] == null) {
            new RaceTrackGeographicMapCellType(commonStrings.START, type, 1, 0);
        } else {
        }
    }

    public override int getStartType()
    {
        return this.maxTileId - 1;
    }

    public override int getEndType()
    {
        return this.maxTileId - 2;
    }

    public override int getEmptyType()
    {
        return this.FLOOR_CELL_TYPE.getTypes()[0];
    }

    public override bool isPath(GeographicMapCellType cellType)
    {
        if (this.FLOOR_CELL_TYPE.isType(cellType)) {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return new StringMaker().append("key: WALL/BLOCK_CELL_TYPE: ").append(this.BLOCK_CELL_TYPE.ToString()).append("key: FLOOR_CELL_TYPE: ").append(this.FLOOR_CELL_TYPE.ToString()).append("key: OTHER_CELL_TYPE: ").append(this.OTHER_CELL_TYPE.ToString()).append("key: OFF_MAP_CELL_TYPE: ").append(this.OFF_MAP_CELL_TYPE.ToString()).append("key: DOOR_CELL_TYPE: ").append(this.DOOR_CELL_TYPE.ToString()).append("key: STAIRS_DOWN_CELL_TYPE: ").append(this.STAIRS_DOWN_CELL_TYPE.ToString()).append("key: STAIRS_UP_CELL_TYPE: ").append(this.STAIRS_UP_CELL_TYPE.ToString()).ToString();
    }

}

