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

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellTypeFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly GeographicMapCellTypeFactory instance = new GeographicMapCellTypeFactory();
    public static GeographicMapCellTypeFactory getInstance()
    {
        return GeographicMapCellTypeFactory.instance;
    }

    private readonly GeographicMapCellType[] geographicMapCellTypeArray = new GeographicMapCellType[512];
    public virtual GeographicMapCellType get(int type)
    {
        return this.geographicMapCellTypeArray[type];
    }

    public virtual GeographicMapCellType[] getGeographicMapCellTypeArray()
    {
        return this.geographicMapCellTypeArray;
    }

    public virtual int getStartType()
    {
        throw new SystemException();
    }

    public virtual int getEndType()
    {
        throw new SystemException();
    }

    public virtual int getEmptyType()
    {
        throw new SystemException();
    }

    public virtual bool isPath(GeographicMapCellType cellType)
    {
        throw new SystemException();
    }

}

