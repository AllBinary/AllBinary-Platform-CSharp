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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.waypoint;

public class WaypointSelectedLogHelper : WaypointLogHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly WaypointSelectedLogHelper instanceC = new WaypointSelectedLogHelper();
    public static WaypointSelectedLogHelper getInstance()
    {
        return WaypointSelectedLogHelper.instanceC;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly StringUtil stringUtil = StringUtil.getInstance();
    public override void onWaypointEvent(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" onWaypointEvent: ");
        stringBuffer.append(advancedRTSGameLayer.getName());
        if (advancedRTSGameLayer.getParentLayer() != null) {
            stringBuffer.append(" With Parent: ");
            stringBuffer.append(advancedRTSGameLayer.getParentLayer().getName());
        }
        this.logUtil.putF(stringBuffer.ToString(), this, "onWaypointEvent");
    }

    public override void addWaypointFromBuilding(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" Adding Waypoint: ");
        stringBuffer.append(advancedRTSGameLayer.getName());
        if (advancedRTSGameLayer.getParentLayer() != null) {
            stringBuffer.append(" With Parent: ");
            stringBuffer.append(advancedRTSGameLayer.getParentLayer().getName());
        }
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: onWaypointEvent");
    }

    public override void addWaypointFromBuildingList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer, BasicArrayList list)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" Waypoints: ");
        stringBuffer.append(this.stringUtil.toString(list));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: onWaypointEvent");
    }

    public override void insertWaypoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int index, CollidableDestroyableDamageableLayer rtsLayer, string waypointName)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(waypointName);
        stringBuffer.append(" Insert: ");
        stringBuffer.append(rtsLayer.getName());
        stringBuffer.append(" for Waypoint: ");
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: insertWaypoint");
    }

    public override void insertWaypointList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int index, CollidableDestroyableDamageableLayer rtsLayer, string waypointName, BasicArrayList list)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(waypointName);
        stringBuffer.append(" Insert: ");
        stringBuffer.append(rtsLayer.getName());
        stringBuffer.append(" Waypoints: ");
        stringBuffer.append(this.stringUtil.toString(list));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: insertWaypoint");
    }

    public override void setRandomGeographicMapCellHistoryList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, BasicArrayList pathsList)
    {
        int size = pathsList.size();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(CommonLabels.getInstance().START);
        stringBuffer.appendint(size);
        stringBuffer.append(" -> ");
        stringBuffer.append(this.stringUtil.toString(pathsList));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: setRandomGeographicMapCellHistory");
    }

    public override void moveAwayFromBuilding(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" Trying to move away from building").ToString(), this, "selected: moveAwayFromBuilding");
    }

    public override void needToMove(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(unitWaypointBehavior.getMovementLogicAsString()).ToString(), this, "needToMove");
    }

    public override void setRandomGeographicMapCellHistory(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" pathsList is null").ToString(), this, "setRandomGeographicMapCellHistory");
    }

    public override void setCurrentPathGeographicMapCellPosition(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition existingCurrentPathGeographicMapCellPosition, GeographicMapCellPosition currentPathGeographicMapCellPosition)
    {
        if (existingCurrentPathGeographicMapCellPosition == null) {
            this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" currentPathGeographicMapCellPosition: ").append(this.stringUtil.toString(currentPathGeographicMapCellPosition)).ToString(), this, "setCurrentPathGeographicMapCellPosition");
        }
    }

    public override void setNextUnvisitedPathGeographicMapCellPosition(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition existingNextUnvisitedPathGeographicMapCellPosition, GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition)
    {
        if (existingNextUnvisitedPathGeographicMapCellPosition != nextUnvisitedPathGeographicMapCellPosition) {
            this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" nextUnvisitedPathGeographicMapCellPosition: ").append(this.stringUtil.toString(nextUnvisitedPathGeographicMapCellPosition)).ToString(), this, "setNextUnvisitedPathGeographicMapCellPosition");
        }
    }

}

