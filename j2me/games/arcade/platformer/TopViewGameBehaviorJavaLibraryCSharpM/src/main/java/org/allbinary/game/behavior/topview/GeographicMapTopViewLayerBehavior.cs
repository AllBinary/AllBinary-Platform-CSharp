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
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using BasicTopViewGeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.topview.BasicTopViewGeographicMapCellTypeFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.behavior.topview;

public class GeographicMapTopViewLayerBehavior : TopViewGameLayerBehavior
{
    public GeographicMapTopViewLayerBehavior(int maxGravityActionIndex) : base(maxGravityActionIndex)
    {
        // base(maxGravityActionIndex) is called from the constructor declaration
    }

    // throws Exception
    public virtual GeographicMapCellPosition getGeographicMapCellPositionIfNotSolidBlockOrOffMapLocation(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer, int x, int y)
    {
        return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    }

    // throws Exception
    public virtual GeographicMapCellPosition getGeographicMapCellPositionIfNotSolidBlockOrOffMap(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition, VelocityProperties velocityProperties, AllBinaryLayer layer)
    {
        return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    }

    // throws Exception
    public virtual GeographicMapCellPosition getGeographicMapCellPositionFromListIfNotSolidBlockOrOffMap(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, BasicArrayList geographicMapCellPositionList, VelocityProperties velocityProperties, AllBinaryLayer layer)
    {
        return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    }

    // throws Exception
    public virtual void gravity(VelocityProperties velocityProperties, BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition)
    {
    }

    // throws Exception
    public virtual void left(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer)
    {
    }

    // throws Exception
    public virtual bool move(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer, int x, int y)
    {
        return false;
    }

    // throws Exception
    public virtual void moveAndLand(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, GeographicMapCellPosition geographicMapCellPosition, VelocityProperties velocityProperties, AllBinaryLayer layer, int x, int y)
    {
    }

    // throws Exception
    public virtual void right(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray, VelocityProperties velocityProperties, AllBinaryLayer layer)
    {
    }

    public virtual bool hasSolidBlock(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray)
    {
        int size = geographicMapInterfaceArray.Length;
        BasicTopViewGeographicMapCellTypeFactory basicTopViewGeographicMapCellTypeFactory = null;
        for (int index = 0; index < size; index++) {
            basicTopViewGeographicMapCellTypeFactory = ((BasicTopViewGeographicMapCellTypeFactory) geographicMapInterfaceArray[index].getGeographicMapCellTypeFactory());
            if (basicTopViewGeographicMapCellTypeFactory.BLOCK_CELL_TYPE.isType(geographicMapCellTypeArray[index])) {
                return true;
            }
        }
        return false;
    }

    public virtual bool isOffMap(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray)
    {
        int size = geographicMapInterfaceArray.Length;
        BasicTopViewGeographicMapCellTypeFactory basicTopViewGeographicMapCellTypeFactory = null;
        for (int index = 0; index < size; index++) {
            basicTopViewGeographicMapCellTypeFactory = ((BasicTopViewGeographicMapCellTypeFactory) geographicMapInterfaceArray[index].getGeographicMapCellTypeFactory());
            if (basicTopViewGeographicMapCellTypeFactory.OFF_MAP_CELL_TYPE.isType(geographicMapCellTypeArray[index])) {
                return true;
            }
        }
        return false;
    }

}

