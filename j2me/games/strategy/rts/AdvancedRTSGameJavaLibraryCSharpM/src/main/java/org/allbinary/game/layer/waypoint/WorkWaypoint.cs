/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using GeologicalGeographicMapCellPosition = org.allbinary.game.layer.geological.resources.GeologicalGeographicMapCellPosition;
using GeologicalResource = org.allbinary.game.layer.geological.resources.GeologicalResource;
using UnitLayer = org.allbinary.game.layer.unit.UnitLayer;
using UnitWaypointBehavior = org.allbinary.game.layer.unit.UnitWaypointBehavior;
using WorkSound = org.allbinary.media.audio.WorkSound;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;

namespace org.allbinary.game.layer.waypoint;

public class WorkWaypoint : Waypoint
{
    public static readonly int? ID = SmallIntegerSingletonFactory.getInstance().getAt(25);
    public WorkWaypoint(PathFindingLayerInterface ownerLayer) : base(ownerLayer, WorkSound.getInstance())
    {
        // base(ownerLayer, WorkSound.getInstance()) is called from the constructor declaration
    }

    // throws Exception
    public virtual void visit(UnitLayer unitLayer)
    {
        if (unitLayer.getGroupInterface()[0] != this.ownerLayer.getGroupInterface()[0]) {
            return;
        }
        int size = this.getConnectedWaypointList().size();
        if (size > 0) {
            BasicArrayList occupyList = this.ownerLayer.getGeographicMapCellPositionArea().getOccupyingGeographicMapCellPositionList();
            bool outOfResources = true;
            GeologicalGeographicMapCellPosition geologicalGeographicMapCellPosition = null;
            GeologicalResource geologicalResource = null;
            for (int index = occupyList.size(); --index >= 0; ) {
                geologicalGeographicMapCellPosition = ((GeologicalGeographicMapCellPosition) occupyList.get(index));
                geologicalResource = geologicalGeographicMapCellPosition.getGeologicalResource();
                if (geologicalResource.getTotal() >= 1) {
                    outOfResources = false;
                    int maxResourceLoad = ((int) unitLayer.getMaxResourceLoad());
                    geologicalResource.remove(maxResourceLoad);
                    unitLayer.setLoad(maxResourceLoad);
                }
            }
            WaypointInfoHudPaintable waypointInfoHudPaintable = ((WaypointInfoHudPaintable) this.ownerLayer.getHudPaintable());
            if (this.ownerLayer == waypointInfoHudPaintable.getRtsLayer()) {
                waypointInfoHudPaintable.updateSelectionInfo();
            }
            if (!outOfResources) {
                UnitWaypointBehavior unitWaypointBehavior = ((UnitWaypointBehavior) unitLayer.getWaypointBehavior());
                RTSLayer rtsLayer = null;
                while (this.getConnectedWaypointList().size() > 0) {
                    rtsLayer = ((RTSLayer) this.getConnectedWaypointList().get(0));
                    if (rtsLayer.isDestroyed()) {
                        this.getConnectedWaypointList().remove(rtsLayer);
                    } else {
                        unitWaypointBehavior.insertWaypoint(0, rtsLayer);
                        break;
                    }
                }
            }
        }
    }

    public override int getType()
    {
        return 2;
    }

}

