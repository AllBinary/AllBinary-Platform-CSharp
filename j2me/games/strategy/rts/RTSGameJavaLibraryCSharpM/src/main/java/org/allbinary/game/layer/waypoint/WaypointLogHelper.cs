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
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.waypoint;

public class WaypointLogHelper
{
    private static readonly WaypointLogHelper instance = new WaypointLogHelper();
    public static WaypointLogHelper getInstance()
    {
        return WaypointLogHelper.instance;
    }

    public virtual void onWaypointEvent(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer)
    {
    }

    public virtual void addWaypointFromBuilding(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer)
    {
    }

    public virtual void addWaypointFromBuildingList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer, BasicArrayList list)
    {
    }

    public virtual void insertWaypoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int index, CollidableDestroyableDamageableLayer rtsLayer, string waypointName)
    {
    }

    public virtual void insertWaypointList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int index, CollidableDestroyableDamageableLayer rtsLayer, string waypointName, BasicArrayList list)
    {
    }

    public virtual void setRandomGeographicMapCellHistoryList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, BasicArrayList pathsList)
    {
    }

    public virtual void moveAwayFromBuilding(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void needToMove(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior)
    {
    }

    public virtual void setRandomGeographicMapCellHistory(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void setCurrentPathGeographicMapCellPosition(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition existingCurrentPathGeographicMapCellPosition, GeographicMapCellPosition currentPathGeographicMapCellPosition)
    {
    }

    public virtual void setNextUnvisitedPathGeographicMapCellPosition(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition existingNextUnvisitedPathGeographicMapCellPosition, GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition)
    {
    }

}

