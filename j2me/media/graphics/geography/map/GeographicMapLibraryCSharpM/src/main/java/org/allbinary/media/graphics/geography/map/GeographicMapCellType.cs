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
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellType
{
    public static readonly GeographicMapCellType[] NULL_GEOGRAPHIC_MAP_CELL_TYPE_ARRAY = new GeographicMapCellType[0];
    public static readonly GeographicMapCellType NULL_GEOGRAPHIC_MAP_CELL_TYPE = new GeographicMapCellType(Integer.MIN_VALUE, 0);
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly int type;
    public GeographicMapCellType(int type, int reset)
    {
        this.type = type;
        if (type != Integer.MIN_VALUE) {
            GeographicMapCellTypeFactory geographicMapCellTypeFactory = GeographicMapCellTypeFactory.getInstance();
            GeographicMapCellType[] geographicMapCellTypeArray = geographicMapCellTypeFactory.getGeographicMapCellTypeArray();
            if (geographicMapCellTypeArray[type] == null || reset == 1) {
                geographicMapCellTypeArray[type] = this;
            } else {
                if (reset != -1) {
                    throw new SystemException();
                }
            }
        }
    }

    public virtual int getType()
    {
        return this.type;
    }

    public override string ToString()
    {
        return SmallIntegerSingletonFactory.getInstance().getAt(this.type).ToString();
    }

}

