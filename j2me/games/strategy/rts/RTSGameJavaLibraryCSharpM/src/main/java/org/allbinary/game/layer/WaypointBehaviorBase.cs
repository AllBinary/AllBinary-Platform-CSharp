/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using WaypointBase = org.allbinary.game.layer.waypoint.WaypointBase;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using TickableInterface = org.allbinary.game.tick.TickableInterface;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.game.layer;

public class WaypointBehaviorBase : TickableInterface
{
    private readonly BasicArrayList ownedWaypointList;
    public bool waypointOverridesAttacking = true;
    private WaypointBase waypoint = WaypointBase.NULL_WAYPOINT_BASE;
    public WaypointBehaviorBase()
    {
        this.ownedWaypointList = new BasicArrayListS(1);
    }

    public virtual string getName()
    {
        return this.GetType().FullName;
    }

    public virtual bool isRunning()
    {
        return false;
    }

    // throws Exception
    public virtual void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
    }

    public virtual BasicArrayList getOwnedWaypointList()
    {
        return this.ownedWaypointList;
    }

    public virtual WaypointBase getWaypoint()
    {
        return this.waypoint;
    }

    public virtual void setWaypoint(WaypointBase waypoint)
    {
        this.waypoint = waypoint;
    }

    public virtual BasicArrayList getSteeringVisitorList()
    {
        return this.steeringVisitorList;
    }

    public virtual string getMovementLogicAsString()
    {
        throw new SystemException();
    }

    public virtual bool isWaypointListEmptyOrOnlyTargets()
    {
        throw new SystemException();
    }

    public virtual bool isInSensorRange(CollidableDestroyableDamageableLayer layerInterface, int targetDistance)
    {
        throw new SystemException();
    }

    public virtual CollidableDestroyableDamageableLayer getCurrentTargetLayerInterface()
    {
        throw new SystemException();
    }

    public virtual string getCurrentTargetingStateString()
    {
        throw new SystemException();
    }

    public virtual bool isTrackingWaypoint()
    {
        throw new SystemException();
    }

    public virtual GeographicMapCellPosition getCurrentPathGeographicMapCellPosition()
    {
        throw new SystemException();
    }

    public virtual GeographicMapCellHistory getCurrentGeographicMapCellHistory()
    {
        throw new SystemException();
    }

    public virtual bool isWaypointOverridesAttacking()
    {
        return this.waypointOverridesAttacking;
    }

    public virtual GeographicMapCellPosition getNextUnvisitedPathGeographicMapCellPosition()
    {
        throw new SystemException();
    }

    public virtual bool needToMove()
    {
        throw new SystemException();
    }

    public virtual void setWaypointPathsList(BasicArrayList waypointPathsList)
    {
        throw new SystemException();
    }

    public virtual BasicArrayList getWaypointPathsList()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void setTarget(PathFindingLayerInterface layerInterface)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void setTargetWithDistance(PathFindingLayerInterface layerInterface, int anotherTargetDistance)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void clearTarget()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void updatePathOnTargetMove(string reason)
    {
    }

    private readonly BasicArrayList steeringVisitorList = new BasicArrayListD();
}

