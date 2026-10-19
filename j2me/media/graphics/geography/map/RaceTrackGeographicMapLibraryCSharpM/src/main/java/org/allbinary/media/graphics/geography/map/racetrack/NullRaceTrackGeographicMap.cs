/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using Layer = org.allbinary.layer.Layer;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellPositionFactoryInterface = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionFactoryInterface;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class NullRaceTrackGeographicMap : RaceTrackGeographicMapInterface
{
    public static readonly NullRaceTrackGeographicMap NULL_RACE_TRACK_GEOGRAPHIC_MAP = new NullRaceTrackGeographicMap();
    public virtual int? getId()
    {
        throw new SystemException();
    }

    public virtual string getName()
    {
        throw new SystemException();
    }

    public virtual void reset()
    {
        throw new SystemException();
    }

    public virtual AllBinaryTiledLayer getAllBinaryTiledLayer()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual bool getCellPositionsAt(Layer layer, GeographicMapCellPosition[][] currentCellPositionArray, GeographicMapCellPosition[][] cellPositionArray)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual GeographicMapCellPosition getCellPositionAtXY(int x, int y)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual GeographicMapCellPosition getCellPositionAtXYNoThrow(int x, int y)
    {
        throw new SystemException();
    }

    public virtual int getCellTypeFromMapCellTypeInt(int cellTypeId)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual GeographicMapCellType getCellTypeAtXY(int x, int y)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual GeographicMapCellType getCellTypeAt(GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

    public virtual BasicGeographicMapCellPositionFactory getGeographicMapCellPositionFactory()
    {
        throw new SystemException();
    }

    public virtual GeographicMapCellPositionFactoryInterface getGeographicMapCellPositionFactoryInterface()
    {
        throw new SystemException();
    }

    public virtual BasicColor getForegroundBasicColor()
    {
        throw new SystemException();
    }

    public virtual BasicColor getBackgroundBasicColor()
    {
        throw new SystemException();
    }

    public virtual RaceTrackInfo getRaceTrackInfo()
    {
        throw new SystemException();
    }

    public virtual void setRaceTrackInfo(RaceTrackInfo aRaceTrackInfo)
    {
        throw new SystemException();
    }

    public virtual RaceTrackData getRaceTrackData()
    {
        throw new SystemException();
    }

    public virtual void setRaceTrackData(RaceTrackData raceTrackData)
    {
        throw new SystemException();
    }

}

