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
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using BuildingEventListenerInterface = org.allbinary.game.layer.building.@event.BuildingEventListenerInterface;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using UnitWaypointBehavior = org.allbinary.game.layer.unit.UnitWaypointBehavior;
using PathFindingInfoFactory = org.allbinary.game.media.graphics.geography.map.racetrack.PathFindingInfoFactory;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using Sound = org.allbinary.media.audio.Sound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using CustomMapGenerator = org.allbinary.media.graphics.geography.map.racetrack.CustomMapGenerator;
using RaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMap;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using PathGenerator = org.allbinary.media.graphics.geography.pathfinding.PathGenerator;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.layer.waypoint;

public class NoCacheWaypoint : WaypointBase, BuildingEventListenerInterface
{
    public readonly PathFindingLayerInterface ownerLayer;
    public NoCacheWaypoint(PathFindingLayerInterface ownerLayer, Sound sound) : base(sound)
    {
        // base(sound) is called from the constructor declaration
        this.ownerLayer = ownerLayer;
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
    }

    public virtual void releaseCachedPaths()
    {
    }

    // throws Exception
    public override BasicArrayList getPathsListFromCacheOnly(GeographicMapCellPosition geographicMapCellPosition)
    {
        return BasicArrayListUtil.getInstance().getImmutableInstance();
    }

    // throws Exception
    public override BasicArrayList getPathsListRunnable(GeographicMapCellPosition geographicMapCellPosition)
    {
        return this.createPaths(geographicMapCellPosition);
    }

    // throws Exception
    protected virtual GeographicMapCellPosition getEndGeographicMapCellPosition(GeographicMapCellPosition startGeographicMapCellPosition)
    {
        BasicArrayList endList = this.ownerLayer.getEndGeographicMapCellPositionList();
        GeographicMapCellPosition endGeographicMapCellPosition = ((GeographicMapCellPosition) BasicArrayListUtil.getInstance().getRandom(endList));
        if (startGeographicMapCellPosition == endGeographicMapCellPosition) {
            for (int index = endList.size() - 1; index >= 0; index--) {
                endGeographicMapCellPosition = ((GeographicMapCellPosition) endList.get(index));
                if (startGeographicMapCellPosition != endGeographicMapCellPosition) {
                    break;
                }
            }
        }
        return endGeographicMapCellPosition;
    }

    // throws Exception
    private BasicArrayList createPaths(GeographicMapCellPosition startGeographicMapCellPosition)
    {
        GeographicMapCellPosition endGeographicMapCellPosition = this.getEndGeographicMapCellPosition(startGeographicMapCellPosition);
        if (endGeographicMapCellPosition == null) {
            return BasicArrayListUtil.getInstance().getImmutableInstance();
        }
        if (startGeographicMapCellPosition == endGeographicMapCellPosition) {
            if (this.ownerLayer.shouldHandleStartSameAsEnd()) {
                return BasicArrayListUtil.getInstance().getImmutableInstance();
            } else {
                throw new Exception("Start should not be End: " + endGeographicMapCellPosition);
            }
        }
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.allBinaryGameLayerManagerP);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        RaceTrackGeographicMap raceTrackGeographicMap = ((RaceTrackGeographicMap) geographicMapInterface);
        GeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = raceTrackGeographicMap.getGeographicMapCellTypeFactory();
        CustomMapGenerator customMapGenerator = ((CustomMapGenerator) raceTrackGeographicMap.getCustomMapGenerator());
        customMapGenerator.copyMapIntoCustomMap();
        int[][] customMapArray = customMapGenerator.getCustomMapArray();
        customMapArray[startGeographicMapCellPosition.getRow()][startGeographicMapCellPosition.getColumn()] = raceTrackGeographicMapCellTypeFactory.getStartType();
        customMapArray[endGeographicMapCellPosition.getRow()][endGeographicMapCellPosition.getColumn()] = raceTrackGeographicMapCellTypeFactory.getEndType();
        PathFindingInfo pathFindingInfo = PathFindingInfoFactory.getInstance().getInstancePathFindingInfo(raceTrackGeographicMap, customMapArray);
        BasicArrayList list = PathGenerator.getInstance().getInstanceNoCache(geographicMapInterface, pathFindingInfo, 2);
        if (list.size() < 1) {
            throw new Exception("Path may have been cleared by clearing caching");
        }
        return list;
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    public override void onBuildingEvent(RTSLayerEvent @event)
    {
    }

    public override void reset()
    {
        this.getConnectedWaypointList().clear();
    }

    // throws Exception
    public override void visit(PathFindingLayerInterface unitLayer)
    {
        if (unitLayer.getGroupInterface()[0] != this.ownerLayer.getGroupInterface()[0]) {
            return;
        }
        int size = this.getConnectedWaypointList().size();
        if (size > 0) {
            UnitWaypointBehavior unitWaypointBehavior = ((UnitWaypointBehavior) unitLayer.getWaypointBehavior());
            while (this.getConnectedWaypointList().size() > 0) {
                CollidableDestroyableDamageableLayer rtsLayer = ((CollidableDestroyableDamageableLayer) this.getConnectedWaypointList().get(0));
                if (rtsLayer.isDestroyed()) {
                    this.getConnectedWaypointList().remove(rtsLayer);
                } else {
                    unitLayer.handleCost(this.ownerLayer);
                    unitWaypointBehavior.insertWaypoint(0, rtsLayer);
                    break;
                }
            }
        }
    }

}

