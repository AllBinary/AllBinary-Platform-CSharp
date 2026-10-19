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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using RaceTrackGeographicMapInterfaceFactoryInterface = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapInterfaceFactoryInterface;
using RaceTrackRoadsGeographicMapCellHistoryFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackRoadsGeographicMapCellHistoryFactory;
using RaceTracksPathPrinter = org.allbinary.media.graphics.geography.map.racetrack.RaceTracksPathPrinter;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using PathGenerator = org.allbinary.media.graphics.geography.pathfinding.PathGenerator;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

public class DynamicRaceTracksPathPrinter : RaceTracksPathPrinter
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public virtual void printAllPaths(RaceTrackGeographicMapInterfaceFactoryInterface raceTrackGeographicMapInterfaceFactoryInterface, PathFindingInfo pathFindingInfo, int size)
    {
        try {
            for (int index = 0; index < size; index++) {
                BasicGeographicMap geographicMapInterface = raceTrackGeographicMapInterfaceFactoryInterface.getTrackInstance(SmallIntegerSingletonFactory.getInstance().getAt(index));
                BasicArrayList list = PathGenerator.getInstance().createList(geographicMapInterface, RaceTrackRoadsGeographicMapCellHistoryFactory.getInstance(), pathFindingInfo, 10);
                Console.WriteLine("Track " + index);
                this.printPaths(list);
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.PROCESS, e);
        }
    }

}

