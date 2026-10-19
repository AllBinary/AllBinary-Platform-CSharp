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
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPositionBaseFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionBaseFactory;
using GeographicMapCellPositionFactoryInterface = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionFactoryInterface;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class BasicGeographicMapFactory
{
    // throws Exception
    public virtual BasicGeographicMap getInstance(RaceTrackInfo raceTrackInfo, RaceTrackData raceTrackData, AllBinaryTiledLayerFactoryInterface tiledLayerFactoryInterface, GeographicMapCellPositionFactoryInterface geographicMapCellPositionFactoryInterface, GeographicMapCellTypeFactory geographicMapCellTypeFactory)
    {
        return new BasicGeographicMap(SmallIntegerSingletonFactory.getInstance().getAt(((int) raceTrackInfo.getId()) + 100 + 1), raceTrackInfo.getName(), raceTrackData.getCellTypeIdToGeographicMapCellTypeArray(), tiledLayerFactoryInterface.getMiniInstance(raceTrackData), BasicColorFactory.getInstance().CLEAR_COLOR, BasicColorFactory.getInstance().CLEAR_COLOR, geographicMapCellPositionFactoryInterface, new GeographicMapCellPositionBaseFactory(), geographicMapCellTypeFactory);
    }

}

