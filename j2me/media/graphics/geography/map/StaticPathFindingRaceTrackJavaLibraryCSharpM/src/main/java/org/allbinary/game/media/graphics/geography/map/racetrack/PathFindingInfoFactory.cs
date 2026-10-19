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
using CommonStrings = org.allbinary.@string.CommonStrings;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasePathFindingInfoFactory = org.allbinary.media.graphics.geography.map.racetrack.BasePathFindingInfoFactory;
using RaceTrackRoadsGeographicMapCellHistoryFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackRoadsGeographicMapCellHistoryFactory;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using PathFindingNodeCostInfoFactoryBase = org.allbinary.media.graphics.geography.pathfinding.PathFindingNodeCostInfoFactoryBase;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

public class PathFindingInfoFactory : BasePathFindingInfoFactory
{
    private static readonly PathFindingInfoFactory instance = new PathFindingInfoFactory();
    public static PathFindingInfoFactory getInstance()
    {
        return PathFindingInfoFactory.instance;
    }

    private PathFindingInfoFactory()
    {
    }

    // throws Exception
    public override PathFindingInfo getInstancePathFindingInfo(BasicGeographicMap geographicMapInterface, int[][] graphArray)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        PreLogUtil.put(commonStrings.START, this, commonStrings.GET_INSTANCE);
        PathFindingInfo pathFindingInfo = new PathFindingInfo(new PathFindingNodeCostInfoFactoryBase(), new BasicArrayListS(1), new BasicArrayListS(1));
        RaceTrackRoadsGeographicMapCellHistoryFactory.getInstance().init();
        this.init(geographicMapInterface, pathFindingInfo, graphArray);
        return pathFindingInfo;
    }

}

