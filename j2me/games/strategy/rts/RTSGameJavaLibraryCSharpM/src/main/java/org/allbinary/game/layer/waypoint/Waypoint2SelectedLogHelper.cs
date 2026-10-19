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
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using PositionStrings = org.allbinary.math.PositionStrings;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.waypoint;

public class Waypoint2SelectedLogHelper : Waypoint2LogHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly Waypoint2SelectedLogHelper instanceC = new Waypoint2SelectedLogHelper();
    public static Waypoint2LogHelper getInstance()
    {
        return Waypoint2SelectedLogHelper.instanceC;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly PositionStrings positionStrings = PositionStrings.getInstance();
    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly string ENEMY_POSSIBLE_TARGET = " Enemy Possible Target: ";
    private readonly string CLOSE_RANGE = "closeRange: ";
    private readonly string SENSOR_RANGE = " sensorRange: ";
    private readonly string ONLY_TARGETS = " Only Targets: ";
    private readonly string SHORTER_THAN_CURRENT_TARGET_DISTANCE = " isShorterThanCurrentTargetDistance: ";
    private readonly string CURRENT_TARGET_DESTROYED = " isCurrentTargetDestroyed: ";
    private readonly string CURRENT_TARGET_NOT_AVAILABLE = " isCurrentTargetNotAvailable: ";
    private readonly string PROCESS_POSSIBLE_TARGET = "selected: processPossibleTarget1";
    public override void initRange(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int closeRange, int sensorRange)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.CLOSE_RANGE);
        stringBuffer.appendint(closeRange);
        stringBuffer.append(this.SENSOR_RANGE);
        stringBuffer.appendint(sensorRange);
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: initRange");
    }

    public override void processPossibleTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase waypointBehaviorBase, PathFindingLayerInterface layerInterface, int anotherTargetDistance, bool isShorterThanCurrentTargetDistance, bool isCurrentTargetDestroyed)
    {
        if (waypointBehaviorBase.isWaypointListEmptyOrOnlyTargets() && waypointBehaviorBase.isInSensorRange(((CollidableDestroyableDamageableLayer) layerInterface), anotherTargetDistance)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
            stringBuffer.append(this.ONLY_TARGETS);
            stringBuffer.appendboolean(waypointBehaviorBase.isWaypointListEmptyOrOnlyTargets());
            stringBuffer.append(this.SHORTER_THAN_CURRENT_TARGET_DISTANCE);
            stringBuffer.appendboolean(isShorterThanCurrentTargetDistance);
            stringBuffer.append(this.CURRENT_TARGET_DESTROYED);
            stringBuffer.appendboolean(isCurrentTargetDestroyed);
            stringBuffer.append(this.CURRENT_TARGET_NOT_AVAILABLE);
            stringBuffer.appendboolean((waypointBehaviorBase.getCurrentTargetLayerInterface() == null));
            this.logUtil.putF(stringBuffer.ToString(), this, this.PROCESS_POSSIBLE_TARGET);
        }
    }

    public override void processSetTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase waypointBehaviorBase, PathFindingLayerInterface layerInterface, int anotherTargetDistance)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(waypointBehaviorBase.getCurrentTargetingStateString());
        stringBuffer.append(this.ENEMY_POSSIBLE_TARGET);
        stringBuffer.append(layerInterface.getName());
        stringBuffer.append(" anotherTargetDistance: ");
        stringBuffer.appendint(anotherTargetDistance);
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: processPossibleTarget2");
    }

    public override void processPossibleTargetCloser(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase waypointBehaviorBase, PathFindingLayerInterface layerInterface, int anotherTargetDistance)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(waypointBehaviorBase.getCurrentTargetingStateString());
        stringBuffer.append(this.ENEMY_POSSIBLE_TARGET);
        stringBuffer.append(layerInterface.getName());
        stringBuffer.append(" anotherTargetDistance: ");
        stringBuffer.appendint(anotherTargetDistance);
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: processPossibleTarget3");
    }

    public override void setTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase waypointBehaviorBase, PathFindingLayerInterface layerInterface, int anotherTargetDistance)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(waypointBehaviorBase.getName());
        stringBuffer.append(" targeting: ");
        stringBuffer.append(layerInterface.getName());
        stringBuffer.append(" at: ");
        stringBuffer.appendint(anotherTargetDistance);
        stringBuffer.append(" instead of: ");
        stringBuffer.append(waypointBehaviorBase.getCurrentTargetingStateString());
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: setTarget");
    }

    public override void setTargetPath(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF("Target Destroyed", this, "selected: setTargetPath");
    }

    public override void setTargetPathIgnoreNewPath(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase waypointBehaviorBase)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" Set Path To Target: ");
        stringBuffer.append(waypointBehaviorBase.getCurrentTargetLayerInterface().getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.stringUtil.toString(waypointBehaviorBase.getCurrentTargetLayerInterface()));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: setTargetPath");
    }

    public override void processWaypoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase waypointBehaviorBase, PathFindingLayerInterface targetLayer, int size)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" Size: ");
        stringBuffer.appendint(size);
        stringBuffer.append(" Waypoint: ");
        stringBuffer.append(targetLayer.getName());
        stringBuffer.append(" Target: ");
        stringBuffer.append(this.stringUtil.toString(waypointBehaviorBase.getCurrentTargetLayerInterface()));
        stringBuffer.append(" isTrackingWaypoint: ");
        stringBuffer.appendboolean(waypointBehaviorBase.isTrackingWaypoint());
        stringBuffer.append(" WaypointOverridesAttacking: ");
        stringBuffer.appendboolean(waypointBehaviorBase.isWaypointOverridesAttacking());
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: processWaypoint");
    }

    public override void processWaypointTracked(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase waypointBehaviorBase)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" currentPathGeographicMapCellPosition: ");
        stringBuffer.append(this.stringUtil.toString(waypointBehaviorBase.getCurrentPathGeographicMapCellPosition()));
        stringBuffer.append(" nextUnvisitedPathGeographicMapCellPosition: ");
        stringBuffer.append(this.stringUtil.toString(waypointBehaviorBase.getNextUnvisitedPathGeographicMapCellPosition()));
        stringBuffer.append(" Tracked: ");
        stringBuffer.append(this.stringUtil.toString(waypointBehaviorBase.getCurrentGeographicMapCellHistory().getTracked()));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: processWaypoint");
    }

    public override void processWaypointTrackedVisit(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition geographicMapCellPosition)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" Visited: ");
        stringBuffer.append(this.stringUtil.toString(geographicMapCellPosition));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: processWaypoint");
    }

    public override void processWaypointTrackedWithoutProgress(PathFindingLayerInterface associatedAdvancedRTSGameLayer, string reason)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(reason).ToString(), this, "turnTo");
    }

    public override void wander(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(associatedAdvancedRTSGameLayer.getName(), this, "wander");
    }

    public override void targetDestroyed(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" Target Destroyed").ToString(), this, "selected: processTargeting");
    }

    public override void processTargeting(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int dx, int dy)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.positionStrings.DX_LABEL);
        stringBuffer.appendint(dx);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.positionStrings.DY_LABEL);
        stringBuffer.appendint(dy);
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: processTargeting");
    }

    public override void processTargetingNonWayPoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int dx, int dy)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" Targeting Non Waypoint ");
        stringBuffer.append(this.positionStrings.DX_LABEL);
        stringBuffer.appendint(dx);
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(this.positionStrings.DY_LABEL);
        stringBuffer.appendint(dy);
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: processTargeting");
    }

    public override void removeWaypoint(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, PathFindingLayerInterface waypointLayer, string reason)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(unitWaypointBehavior2.getName());
        stringBuffer.append(" remove: ");
        stringBuffer.append(waypointLayer.getName());
        stringBuffer.append(" because: ");
        stringBuffer.append(reason);
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: removeWaypoint");
    }

    public override void removeWaypointList(PathFindingLayerInterface associatedAdvancedRTSGameLayer, WaypointBehaviorBase unitWaypointBehavior2, BasicArrayList list)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(this.commonSeps.SPACE);
        stringBuffer.append(unitWaypointBehavior2.getName());
        stringBuffer.append(" Waypoints: ");
        stringBuffer.append(this.stringUtil.toString(list));
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: removeWaypoint");
    }

    public override void removeWaypointClear(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" Clearing removed waypoint").ToString(), this, "selected: removeWaypoint");
    }

    public override void clearTarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" Cleared Target").ToString(), this, "selected: clearTarget");
    }

    public override void addWaypointFromUser(PathFindingLayerInterface associatedAdvancedRTSGameLayer, PathFindingLayerInterface advancedRTSGameLayer)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(associatedAdvancedRTSGameLayer.getName());
        stringBuffer.append(" Adding Waypoint to Selected: ");
        stringBuffer.append(advancedRTSGameLayer.getName());
        if (advancedRTSGameLayer.getParentLayer() != null) {
            stringBuffer.append(" With Parent: ");
            stringBuffer.append(advancedRTSGameLayer.getParentLayer().getName());
        }
        this.logUtil.putF(stringBuffer.ToString(), this, "selected: onWaypointEvent");
    }

    public override void targetMovedSoRetarget(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
        this.logUtil.putF(new StringMaker().append(associatedAdvancedRTSGameLayer.getName()).append(" - target moved so retargeting").ToString(), this, "turnTo");
    }

}

