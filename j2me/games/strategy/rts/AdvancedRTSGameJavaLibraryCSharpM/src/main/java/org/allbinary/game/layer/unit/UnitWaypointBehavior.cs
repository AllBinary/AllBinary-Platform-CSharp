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
using PrimaryWaypointHelper = org.allbinary.game.input.form.PrimaryWaypointHelper;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using SensorAction = org.allbinary.game.layer.SensorAction;
using SensorActionFactory = org.allbinary.game.layer.SensorActionFactory;
using WaypointBehaviorBase = org.allbinary.game.layer.WaypointBehaviorBase;
using BuildingLayer = org.allbinary.game.layer.building.BuildingLayer;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using WaypointEventListenerInterface = org.allbinary.game.layer.waypoint.@event.WaypointEventListenerInterface;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using CommonSeps = org.allbinary.@string.CommonSeps;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.layer.unit;

public class UnitWaypointBehavior : WaypointBehaviorBase, WaypointEventListenerInterface
{
    private static readonly string PATHING = "Pathing";
    public CommonSeps commonSeps = CommonSeps.getInstance();
    private int longWeaponRange = 0;
    private SensorAction sensorAction = SensorActionFactory.getInstance().ATTACK;
    private readonly TimeDelayHelper completeTimeDelayHelper;
    public readonly GeographicMapCellHistory currentGeographicMapCellHistoryP;
    private GeographicMapCellPosition lastPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition currentPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private readonly CollidableDestroyableDamageableLayer FAKE_WAYPOINT_LAYER;
    public readonly BasicArrayList targetList;
    private readonly BasicArrayList possibleTargetList;
    public readonly UnitLayer associatedAdvancedRTSGameLayer;
    private bool moving = false;
    private bool movingFromStopped = false;
    public BasicArrayList waypointPathsListP = BasicArrayListUtil.getInstance().getImmutableInstance();
    private int currentTargetDistance = Integer.MAX_VALUE;
    public CollidableDestroyableDamageableLayer currentTargetLayerInterfaceP = CollidableDestroyableDamageableLayer.getNullInstance();
    private bool trackingWaypoint = false;
    protected UnitWaypointBehavior(UnitLayer associatedAdvancedRTSGameLayer, CollidableDestroyableDamageableLayer fakeWaypoint)
    {
        this.associatedAdvancedRTSGameLayer = associatedAdvancedRTSGameLayer;
        this.completeTimeDelayHelper = new TimeDelayHelper(30000);
        this.targetList = new BasicArrayListD();
        this.possibleTargetList = new BasicArrayListD();
        this.setWaypointPathsList(BasicArrayListUtil.getInstance().getImmutableInstance());
        this.currentGeographicMapCellHistoryP = new GeographicMapCellHistory();
        this.FAKE_WAYPOINT_LAYER = fakeWaypoint;
    }

    protected virtual void initRange(int weaponRange)
    {
        this.longWeaponRange = weaponRange / 2;
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    public override void onWaypointEvent(RTSLayerEvent @event)
    {
        AdvancedRTSGameLayer advancedRTSGameLayer = ((AdvancedRTSGameLayer) @event.getRtsLayer());
        this.associatedAdvancedRTSGameLayer.waypointLogHelperP.onWaypointEvent(this.associatedAdvancedRTSGameLayer, advancedRTSGameLayer);
        if (this.associatedAdvancedRTSGameLayer.isSelected()) {
            this.addWaypointFromUser(advancedRTSGameLayer);
        } else if (advancedRTSGameLayer.shouldAddWaypointFromBuilding()) {
            this.addWaypointFromBuilding(advancedRTSGameLayer);
        }
    }

    // throws Exception
    protected virtual void addWaypointFromUser(AdvancedRTSGameLayer advancedRTSGameLayer)
    {
    }

    // throws Exception
    private void addWaypointFromBuilding(AdvancedRTSGameLayer advancedRTSGameLayer)
    {
        if (advancedRTSGameLayer == PrimaryWaypointHelper.getInstance().getWaypointLayer() || advancedRTSGameLayer.getParentLayer() == this.associatedAdvancedRTSGameLayer.getParentLayer()) {
            if (!this.targetList.contains(advancedRTSGameLayer)) {
                this.associatedAdvancedRTSGameLayer.waypointLogHelperP.addWaypointFromBuilding(this.associatedAdvancedRTSGameLayer, advancedRTSGameLayer);
                if (advancedRTSGameLayer.isDestroyed()) {
                    throw new Exception("Trying to add a dead: " + advancedRTSGameLayer);
                }
                this.targetList.add(advancedRTSGameLayer);
                this.associatedAdvancedRTSGameLayer.waypointLogHelperP.addWaypointFromBuildingList(this.associatedAdvancedRTSGameLayer, advancedRTSGameLayer, this.targetList);
            }
        }
    }

    public override bool isWaypointListEmptyOrOnlyTargets()
    {
        return false;
    }

    // throws Exception
    public virtual bool insertWaypoint(int index, CollidableDestroyableDamageableLayer rtsLayer)
    {
        if (this.canInsertWaypoint(index, rtsLayer)) {
            this.associatedAdvancedRTSGameLayer.waypointLogHelperP.insertWaypoint(this.associatedAdvancedRTSGameLayer, index, rtsLayer, this.getName());
            if (rtsLayer.isDestroyed()) {
                throw new Exception("Trying to add a dead: " + rtsLayer);
            }
            this.targetList.addAt(index, rtsLayer);
            this.associatedAdvancedRTSGameLayer.waypointLogHelperP.insertWaypointList(this.associatedAdvancedRTSGameLayer, index, rtsLayer, this.getName(), this.targetList);
            return true;
        }
        return false;
    }

    protected virtual void move()
    {
        if (this.isMoving()) {
            this.setMovingFromStopped(false);
        } else {
            this.setMovingFromStopped(true);
        }
        this.setMoving(false);
    }

    // throws Exception
    protected virtual void setRandomGeographicMapCellHistory(BasicArrayList pathsList)
    {
        int size = pathsList.size();
        this.associatedAdvancedRTSGameLayer.waypointLogHelperP.setRandomGeographicMapCellHistoryList(this.associatedAdvancedRTSGameLayer, pathsList);
        if (size > 0) {
            BasicArrayList geographicMapCellPositionBasicArrayList = ((BasicArrayList) BasicArrayListUtil.getInstance().getRandom(pathsList));
            this.setGeographicMapCellHistoryPath(geographicMapCellPositionBasicArrayList);
        }
    }

    // throws Exception
    protected virtual void setGeographicMapCellHistoryPath(BasicArrayList geographicMapCellPositionBasicArrayList)
    {
        this.lastPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        if (this.associatedAdvancedRTSGameLayer.showMoreCaptionStates) {
            this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(UnitWaypointBehavior.PATHING, BasicColorFactory.getInstance().GREEN);
        }
        this.currentGeographicMapCellHistoryP.init();
        this.associatedAdvancedRTSGameLayer.init(this.currentGeographicMapCellHistoryP, geographicMapCellPositionBasicArrayList);
        this.setTrackingWaypoint(true);
        this.getCompleteTimeDelayHelper().setStartTimeTNT();
    }

    protected virtual bool canInsertWaypoint(int index, CollidableDestroyableDamageableLayer rtsLayer)
    {
        if (this.targetList.size() > 4) {
        } else if (this.targetList.contains(rtsLayer)) {
        } else {
            return true;
        }
        return false;
    }

    // throws Exception
    public virtual void addBuildingChase(AllBinaryLayer allbinaryLayer, GeographicMapCellPosition cellPosition)
    {
    }

    // throws Exception
    protected virtual void moveAwayFromBuilding(BuildingLayer buildingLayer)
    {
        GeographicMapCellPosition geographicMapCellPosition = this.associatedAdvancedRTSGameLayer.getCurrentGeographicMapCellPosition();
        BasicArrayList list = buildingLayer.geographicMapCellPositionAreaBase.getOccupyingGeographicMapCellPositionList();
        if (list.contains(geographicMapCellPosition)) {
            if (this.insertWaypoint(0, this.FAKE_WAYPOINT_LAYER)) {
                this.associatedAdvancedRTSGameLayer.waypointLogHelperP.moveAwayFromBuilding(this.associatedAdvancedRTSGameLayer);
                this.setCurrentTargetLayerInterface(((CollidableDestroyableDamageableLayer) this.FAKE_WAYPOINT_LAYER));
                BasicArrayList pathsList = buildingLayer.getMoveOutOfBuildAreaPath(geographicMapCellPosition);
                this.associatedAdvancedRTSGameLayer.setClosestGeographicMapCellHistory(pathsList);
            }
        }
    }

    private readonly TimeDelayHelper repeatedToLong = new TimeDelayHelper(22000);
    public override bool needToMove()
    {
        this.associatedAdvancedRTSGameLayer.waypointLogHelperP.needToMove(this.associatedAdvancedRTSGameLayer, this);
        if (this.isTrackingWaypoint() || this.sensorAction == SensorActionFactory.getInstance().EVADE || (this.currentTargetLayerInterfaceP != CollidableDestroyableDamageableLayer.getNullInstance() && this.getCurrentTargetDistance() >= this.longWeaponRange + this.currentTargetLayerInterfaceP.getHalfHeight())) {
            this.repeatedToLong.setStartTimeTNT();
            return true;
        }
        if (this.repeatedToLong.isTimeTNT()) {
            string message = "Repeating too long: " + this.getMovementLogicAsString();
            ForcedLogUtil.log(message, this.associatedAdvancedRTSGameLayer);
        }
        return false;
    }

    public override string getMovementLogicAsString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("isTrackingWaypoint: ");
        stringBuffer.appendboolean(this.isTrackingWaypoint());
        stringBuffer.append(" sensorAction: ");
        stringBuffer.append(this.sensorAction.name);
        stringBuffer.append(" getCurrentTargetLayerInterface: ");
        stringBuffer.append(StringUtil.getInstance().toString(this.currentTargetLayerInterfaceP));
        if (this.currentTargetLayerInterfaceP != CollidableDestroyableDamageableLayer.getNullInstance()) {
            stringBuffer.append(" Target Range: ");
            stringBuffer.appendint(this.getCurrentTargetDistance());
            stringBuffer.append(" >= ");
            stringBuffer.appendint(((int) (this.longWeaponRange + this.currentTargetLayerInterfaceP.getHalfHeight())));
        }
        return stringBuffer.ToString();
    }

    public virtual bool isMovingFromStopped()
    {
        return this.movingFromStopped;
    }

    protected virtual void setMovingFromStopped(bool movingFromStopped)
    {
        this.movingFromStopped = movingFromStopped;
    }

    public override void setWaypointPathsList(BasicArrayList waypointPathsList)
    {
        this.waypointPathsListP = waypointPathsList;
    }

    public override BasicArrayList getWaypointPathsList()
    {
        return this.waypointPathsListP;
    }

    protected virtual bool isMoving()
    {
        return this.moving;
    }

    protected virtual void setMoving(bool moving)
    {
        this.moving = moving;
    }

    public override bool isTrackingWaypoint()
    {
        return this.trackingWaypoint;
    }

    protected virtual BasicArrayList getPossibleTargetList()
    {
        return this.possibleTargetList;
    }

    protected virtual void setLastPathGeographicMapCellPosition(GeographicMapCellPosition lastPathGeographicMapCellPosition)
    {
        this.lastPathGeographicMapCellPosition = lastPathGeographicMapCellPosition;
    }

    protected virtual GeographicMapCellPosition getLastPathGeographicMapCellPosition()
    {
        return this.lastPathGeographicMapCellPosition;
    }

    protected virtual void setCurrentPathGeographicMapCellPosition(GeographicMapCellPosition currentPathGeographicMapCellPosition)
    {
        this.currentPathGeographicMapCellPosition = currentPathGeographicMapCellPosition;
    }

    public override GeographicMapCellPosition getCurrentPathGeographicMapCellPosition()
    {
        return this.currentPathGeographicMapCellPosition;
    }

    protected virtual void setSensorAction(SensorAction sensorAction)
    {
        this.sensorAction = sensorAction;
    }

    protected virtual SensorAction getSensorAction()
    {
        return this.sensorAction;
    }

    protected virtual void setCurrentTargetLayerInterface(CollidableDestroyableDamageableLayer currentTargetLayerInterface)
    {
        this.currentTargetLayerInterfaceP = currentTargetLayerInterface;
    }

    public override CollidableDestroyableDamageableLayer getCurrentTargetLayerInterface()
    {
        return this.currentTargetLayerInterfaceP;
    }

    protected virtual void setCurrentTargetDistance(int currentTargetDistance)
    {
        this.currentTargetDistance = currentTargetDistance;
    }

    protected virtual int getCurrentTargetDistance()
    {
        return this.currentTargetDistance;
    }

    protected virtual TimeDelayHelper getCompleteTimeDelayHelper()
    {
        return this.completeTimeDelayHelper;
    }

    public override GeographicMapCellHistory getCurrentGeographicMapCellHistory()
    {
        return this.currentGeographicMapCellHistoryP;
    }

    protected virtual void setTrackingWaypoint(bool trackingWaypoint)
    {
        this.trackingWaypoint = trackingWaypoint;
    }

}

