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
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using WaypointBehaviorBase = org.allbinary.game.layer.WaypointBehaviorBase;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.waypoint;

public class Waypoint2LogHelper
{
    private static readonly Waypoint2LogHelper instance = new Waypoint2LogHelper();
    public static Waypoint2LogHelper getInstance()
    {
        return Waypoint2LogHelper.instance;
    }

    public virtual void initRange(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int closeRange, int sensorRange)
    {
    }

    public virtual void processPossibleTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, PathFindingLayerInterface layerInterface, int anotherTargetDistance, bool isShorterThanCurrentTargetDistance, bool isCurrentTargetDestroyed)
    {
    }

    public virtual void processSetTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, PathFindingLayerInterface layerInterface, int anotherTargetDistance)
    {
    }

    public virtual void processPossibleTargetCloser(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, PathFindingLayerInterface layerInterface, int anotherTargetDistance)
    {
    }

    public virtual void setTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, PathFindingLayerInterface layerInterface, int anotherTargetDistance)
    {
    }

    public virtual void setTargetPath(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void setTargetPathIgnoreNewPath(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2)
    {
    }

    public virtual void processWaypoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, PathFindingLayerInterface targetLayer, int size)
    {
    }

    public virtual void processWaypointTracked(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2)
    {
    }

    public virtual void processWaypointTrackedVisit(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition geographicMapCellPosition)
    {
    }

    public virtual void processWaypointTrackedWithoutProgress(PathFindingLayerInterface associatedAdvancedRTSGameLayer, string reason)
    {
    }

    public virtual void wander(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void targetDestroyed(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void processTargeting(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int dx, int dy)
    {
    }

    public virtual void processTargetingNonWayPoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int dx, int dy)
    {
    }

    public virtual void removeWaypoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, PathFindingLayerInterface waypointLayer, string reason)
    {
    }

    public virtual void removeWaypointList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, BasicArrayList list)
    {
    }

    public virtual void removeWaypointClear(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void clearTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void addWaypointFromUser(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer)
    {
    }

    public virtual void targetMovedSoRetarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

}

