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
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using NullPathFindingLayer = org.allbinary.game.layer.NullPathFindingLayer;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using UnitLayer = org.allbinary.game.layer.unit.UnitLayer;
using UnitWaypointBehavior = org.allbinary.game.layer.unit.UnitWaypointBehavior;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.input.form;

public class AssignWaypointsUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AssignWaypointsUtil instance = new AssignWaypointsUtil();
    public static AssignWaypointsUtil getInstance()
    {
        return AssignWaypointsUtil.instance;
    }

    private readonly RTSLayerEvent WAYPOINT_EVENT = new RTSLayerEvent(NullPathFindingLayer.NULL_PATH_FINDING_LAYER);
    public virtual void set(UnitLayer unitLayer, AdvancedRTSGameLayer ownerAdvancedRTSGameLayer)
    {
        try {
            BasicArrayList list = ownerAdvancedRTSGameLayer.getWaypointBehavior().getOwnedWaypointList();
            UnitWaypointBehavior unitWaypointBehavior = ((UnitWaypointBehavior) unitLayer.getWaypointBehavior());
            for (int index = list.size() - 1; index >= 0; index--) {
                RTSLayer waypointLayer = ((RTSLayer) list.get(index));
                this.WAYPOINT_EVENT.setRtsLayer(waypointLayer);
                unitWaypointBehavior.onWaypointEvent(this.WAYPOINT_EVENT);
            }
            PathFindingLayerInterface waypointLayer = PrimaryWaypointHelper.getInstance().getWaypointLayer();
            if (waypointLayer != NullPathFindingLayer.NULL_PATH_FINDING_LAYER) {
                this.WAYPOINT_EVENT.setRtsLayer(waypointLayer);
                unitWaypointBehavior.onWaypointEvent(this.WAYPOINT_EVENT);
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "set", e);
        }
    }

}

