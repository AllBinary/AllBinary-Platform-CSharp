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
//using TiledLayer = javax.microedition.lcdui.game.TiledLayer;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class TiledLayerFactory
{
    public virtual TiledLayer getInstance(RaceTrackData raceTrackData)
    {
        int[][] mapArray = raceTrackData.getMapArray();
        return new TiledLayer(mapArray[0].Length, mapArray.Length, raceTrackData.getTileSetImage(), raceTrackData.getCellWidth(), raceTrackData.getCellHeight());
    }

    public virtual TiledLayer getMiniInstance(RaceTrackData raceTrackData)
    {
        int[][] mapArray = raceTrackData.getMapArray();
        return new TiledLayer(mapArray[0].Length, mapArray.Length, raceTrackData.getMiniTileSetImage(), raceTrackData.getMiniCellWidth(), raceTrackData.getMiniCellHeight());
    }

}

