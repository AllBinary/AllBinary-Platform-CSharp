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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using RaceTrackData = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackData;
using RaceTrackInfo = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackInfo;

namespace org.allbinary.media.graphics.geography.map.racetrack.threed;

public class AllBinaryThreedTiledLayerFactory
{
    private static readonly AllBinaryThreedTiledLayerFactory instance = new AllBinaryThreedTiledLayerFactory();
    public static AllBinaryThreedTiledLayerFactory getInstance()
    {
        return AllBinaryThreedTiledLayerFactory.instance;
    }

    // throws Exception
    public virtual AllBinaryTiledLayer getInstance(RaceTrackInfo raceTrackInfo, RaceTrackData raceTrackData)
    {
        throw new Exception("No Threed");
    }

}

