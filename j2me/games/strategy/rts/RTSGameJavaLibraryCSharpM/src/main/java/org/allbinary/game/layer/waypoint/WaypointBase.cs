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
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using NoSound = org.allbinary.media.audio.NoSound;
using Sound = org.allbinary.media.audio.Sound;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using MultipassState = org.allbinary.media.graphics.geography.pathfinding.MultipassState;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.layer.waypoint;

public class WaypointBase : EventListenerInterface
{
    public static WaypointBase NULL_WAYPOINT_BASE = new WaypointBase(NoSound.getInstance());
    private readonly BasicArrayList connectedWaypointList = new BasicArrayListD();
    private readonly Sound sound;
    public AllBinaryGameLayerManager allBinaryGameLayerManagerP = AllBinaryGameLayerManager.getNullInstance();
    public WaypointBase(Sound sound)
    {
        this.sound = sound;
    }

    public virtual Sound getSound()
    {
        return this.sound;
    }

    // throws Exception
    public virtual void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        this.allBinaryGameLayerManagerP = allBinaryGameLayerManager;
    }

    public virtual BasicArrayList getConnectedWaypointList()
    {
        return this.connectedWaypointList;
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    public virtual PathFindingInfo getPathFindingInfo(GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual BasicArrayList getPathsList(GeographicMapCellPosition geographicMapCellPosition, PathFindingInfo pathFindingInfo, MultipassState multipassState)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual BasicArrayList getPathsListRunnable(GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual BasicArrayList getPathsListFromCacheOnly(GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void visit(PathFindingLayerInterface unitLayer)
    {
    }

    public virtual void reset()
    {
    }

    public virtual int getType()
    {
        return 0;
    }

}

