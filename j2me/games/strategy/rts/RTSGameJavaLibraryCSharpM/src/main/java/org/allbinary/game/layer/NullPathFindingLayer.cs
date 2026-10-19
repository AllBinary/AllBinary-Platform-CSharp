/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using Group = org.allbinary.game.identification.Group;
using Waypoint2LogHelper = org.allbinary.game.layer.waypoint.Waypoint2LogHelper;
using WaypointLogHelper = org.allbinary.game.layer.waypoint.WaypointLogHelper;
using WaypointRunnableLogHelper = org.allbinary.game.layer.waypoint.WaypointRunnableLogHelper;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public class NullPathFindingLayer : PathFindingLayerInterface
{
    public static readonly NullPathFindingLayer NULL_PATH_FINDING_LAYER = new NullPathFindingLayer();
    public virtual string getName()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual BasicArrayList getEndGeographicMapCellPositionList()
    {
        throw new SystemException();
    }

    public virtual bool shouldHandleStartSameAsEnd()
    {
        throw new SystemException();
    }

    public virtual GeographicMapCellPositionAreaBase getGeographicMapCellPositionArea()
    {
        throw new SystemException();
    }

    public virtual SelectionHudPaintable getHudPaintable()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void handleCost(PathFindingLayerInterface ownerLayer)
    {
        throw new SystemException();
    }

    public virtual PathFindingLayerInterface getParentLayer()
    {
        throw new SystemException();
    }

    public virtual RTSLayer2LogHelper getRTSLayer2LogHelper()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void setTarget(PathFindingLayerInterface targetGameLayer)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void init(GeographicMapCellHistory geographicMapCellHistory, BasicArrayList geographicMapCellPositionBasicArrayList)
    {
        throw new SystemException();
    }

    public virtual BasicArrayList getMoveOutOfBuildAreaPath(GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void setClosestGeographicMapCellHistory(BasicArrayList pathsList)
    {
        throw new SystemException();
    }

    public virtual void teleportTo(GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void setLoad(int resource)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual BasicArrayList getSurroundingGeographicMapCellPositionList()
    {
        throw new SystemException();
    }

    public virtual bool isSelected()
    {
        throw new SystemException();
    }

    public virtual bool shouldAddWaypointFromBuilding()
    {
        throw new SystemException();
    }

    public virtual bool isShowMoreCaptionStates()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void trackTo(string reason)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void trackToDXY(int dx, int dy)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual bool buildingChase(AllBinaryLayer allbinaryLayer, GeographicMapCellPosition cellPosition)
    {
        throw new SystemException();
    }

    public virtual TrackingEvent getTrackingEvent()
    {
        throw new SystemException();
    }

    public virtual void allStop()
    {
        throw new SystemException();
    }

    public virtual bool isWaypointListEmptyOrOnlyTargets()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual GeographicMapCellPosition getCurrentGeographicMapCellPosition()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual GeographicMapCellPosition getTopLeftGeographicMapCellPosition()
    {
        throw new SystemException();
    }

    public virtual CaptionAnimationHelperBase getCaptionAnimationHelper()
    {
        throw new SystemException();
    }

    public virtual WaypointBehaviorBase getWaypointBehavior()
    {
        throw new SystemException();
    }

    public virtual WaypointLogHelper getWaypointLogHelper()
    {
        throw new SystemException();
    }

    public virtual Waypoint2LogHelper getWaypoint2LogHelper()
    {
        throw new SystemException();
    }

    public virtual WaypointRunnableLogHelper getWaypointRunnableLogHelper()
    {
        throw new SystemException();
    }

    public virtual Group[] getGroupInterface()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual bool isDestroyed()
    {
        throw new SystemException();
    }

    public virtual int getSourceId()
    {
        throw new SystemException();
    }

}

