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
using CaptionAnimationHelperBase = org.allbinary.animation.caption.CaptionAnimationHelperBase;
using WaypointBehaviorBase = org.allbinary.game.layer.WaypointBehaviorBase;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.waypoint;

public interface WaypointLayerInterface
{
    // throws Exception
    void init(GeographicMapCellHistory geographicMapCellHistory, BasicArrayList geographicMapCellPositionBasicArrayList);

    BasicArrayList getMoveOutOfBuildAreaPath(GeographicMapCellPosition geographicMapCellPosition);

    // throws Exception
    void setClosestGeographicMapCellHistory(BasicArrayList pathsList);

    void teleportTo(GeographicMapCellPosition geographicMapCellPosition);

    // throws Exception
    void setLoad(int resource);

    // throws Exception
    BasicArrayList getSurroundingGeographicMapCellPositionList();

    bool isSelected();

    bool shouldAddWaypointFromBuilding();

    bool isShowMoreCaptionStates();

    // throws Exception
    void trackTo(string reason);

    // throws Exception
    void trackToDXY(int dx, int dy);

    // throws Exception
    bool buildingChase(AllBinaryLayer allbinaryLayer, GeographicMapCellPosition cellPosition);

    TrackingEvent getTrackingEvent();

    void allStop();

    bool isWaypointListEmptyOrOnlyTargets();

    // throws Exception
    GeographicMapCellPosition getCurrentGeographicMapCellPosition();

    // throws Exception
    GeographicMapCellPosition getTopLeftGeographicMapCellPosition();

    CaptionAnimationHelperBase getCaptionAnimationHelper();

    WaypointBehaviorBase getWaypointBehavior();

    WaypointLogHelper getWaypointLogHelper();

    Waypoint2LogHelper getWaypoint2LogHelper();

    WaypointRunnableLogHelper getWaypointRunnableLogHelper();

}

