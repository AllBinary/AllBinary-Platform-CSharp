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
using java.util;
using CommonStrings = org.allbinary.@string.CommonStrings;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using EnumerationUtil = org.allbinary.util.EnumerationUtil;

namespace org.allbinary.media.graphics.geography.map.platform;

public class BasicPlatormGeographicMapCellTypeFactory : GeographicMapCellTypeFactory
{
    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    public readonly BasicPlatormGeographicMapCellType BLOCK_CELL_TYPE;
    public readonly BasicPlatormGeographicMapCellType JUMP_THRU_CELL_TYPE;
    public readonly BasicPlatormGeographicMapCellType LADDER_CELL_TYPE;
    private readonly int maxTileId;
    public BasicPlatormGeographicMapCellTypeFactory(ABHashtable<object, object> tileTypeToTileIdsMap, int maxTileId)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(commonStrings.START, this, commonStrings.INIT);
        this.maxTileId = maxTileId;
        new GeographicMapCellType(0, 0);
        BasicPlatormGeographicMapCellType BLOCK_CELL_TYPE = BasicPlatormGeographicMapCellType.createType(1);
        BasicPlatormGeographicMapCellType JUMP_THRU_CELL_TYPE = BLOCK_CELL_TYPE;
        BasicPlatormGeographicMapCellType LADDER_CELL_TYPE = BLOCK_CELL_TYPE;
        string PLATFORM = "Platform";
        string JUMP_TRHU = "JumpThru";
        string LADDER = "Ladder";
        Enumeration enumeration = tileTypeToTileIdsMap.keys();
        BasicArrayList idsWithTypeList = null;
        string key = null;
        BasicPlatormGeographicMapCellType basicPlatormGeographicMapCellType = null;
        while (this.enumerationUtil.hasMoreElements(enumeration)) {
            key = ((string) this.enumerationUtil.nextElement(enumeration));
            this.logUtil.putF(key, this, commonStrings.INIT);
            idsWithTypeList = ((BasicArrayList) tileTypeToTileIdsMap.get(key));
            basicPlatormGeographicMapCellType = new BasicPlatormGeographicMapCellType(idsWithTypeList);
            if (key.Equals(PLATFORM)) {
                BLOCK_CELL_TYPE = basicPlatormGeographicMapCellType;
            }
            if (key.Equals(JUMP_TRHU)) {
                JUMP_THRU_CELL_TYPE = basicPlatormGeographicMapCellType;
            }
            if (key.Equals(LADDER)) {
                LADDER_CELL_TYPE = basicPlatormGeographicMapCellType;
            }
        }
        this.BLOCK_CELL_TYPE = BLOCK_CELL_TYPE;
        this.JUMP_THRU_CELL_TYPE = JUMP_THRU_CELL_TYPE;
        this.LADDER_CELL_TYPE = LADDER_CELL_TYPE;
        new GeographicMapCellType(this.maxTileId - 1, 0);
        new GeographicMapCellType(this.maxTileId - 2, 0);
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
        return 0;
    }

    public override bool isPath(GeographicMapCellType cellType)
    {
        if (cellType.getType() == 0) {
            return true;
        }
        return false;
    }

}

