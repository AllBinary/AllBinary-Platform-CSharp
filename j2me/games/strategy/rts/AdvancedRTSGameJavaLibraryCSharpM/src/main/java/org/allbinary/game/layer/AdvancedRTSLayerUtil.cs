/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using WorkWaypoint = org.allbinary.game.layer.waypoint.WorkWaypoint;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using BaseRaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.BaseRaceTrackGeographicMap;
using org.allbinary.util;

namespace org.allbinary.game.layer;

public class AdvancedRTSLayerUtil
{
    private static readonly AdvancedRTSLayerUtil instance = new AdvancedRTSLayerUtil();
    public static AdvancedRTSLayerUtil getInstance()
    {
        return AdvancedRTSLayerUtil.instance;
    }

    public ABHashtable<object, object> createFakeRTSLayerHashtable(BaseRaceTrackGeographicMap baseRaceTrackGeographicMap)
    {
        ABHashtable<object, object> hashtable = RTSLayerUtil.getInstance().createFakeRTSLayerHashtable(baseRaceTrackGeographicMap);
        hashtable.put(WorkWaypoint.ID, SmallIntegerSingletonFactory.getInstance().getAt(50));
        return hashtable;
    }

}

