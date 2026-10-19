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
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using AllBinaryTiledLayerFactoryInterface = org.allbinary.media.graphics.geography.map.racetrack.AllBinaryTiledLayerFactoryInterface;
using RaceTrackData = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackData;
using RaceTrackInfo = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackInfo;
using TiledLayerFactory = org.allbinary.media.graphics.geography.map.racetrack.TiledLayerFactory;

namespace org.allbinary.game.layer;

public class AllBinaryTiledLayerFactory : AllBinaryTiledLayerFactoryInterface
{
    // throws Exception
    public virtual AllBinaryTiledLayer getInstance(RaceTrackInfo raceTrackInfo, RaceTrackData raceTrackData)
    {
        AllBinaryTiledLayer allbinaryTiledLayer = null;
        TiledLayer tiledLayer = new TiledLayerFactory().getInstance(raceTrackData);
        allbinaryTiledLayer = new AllBinaryJ2METiledLayer(raceTrackData.getId(), tiledLayer, raceTrackData.getMapArray(), ((int) BasicColorFactory.getInstance().RED));
        allbinaryTiledLayer.setCells(raceTrackData.getMapArray());
        return allbinaryTiledLayer;
    }

    // throws Exception
    public virtual AllBinaryTiledLayer getMiniInstance(RaceTrackData raceTrackData)
    {
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        TiledLayer tiledLayer = new TiledLayerFactory().getMiniInstance(raceTrackData);
        AllBinaryTiledLayer allbinaryTiledLayer = new AllBinaryJ2METiledLayer(smallIntegerSingletonFactory.getAt(((int) raceTrackData.getId()) + 100 + 1), tiledLayer, raceTrackData.getMapArray(), ((int) BasicColorFactory.getInstance().RED));
        allbinaryTiledLayer.setCells(raceTrackData.getMapArray());
        return allbinaryTiledLayer;
    }

}

