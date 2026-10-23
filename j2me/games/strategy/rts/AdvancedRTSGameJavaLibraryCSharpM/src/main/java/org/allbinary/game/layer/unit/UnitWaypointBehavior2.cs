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
using J2MEUtil = org.allbinary.J2MEUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using SteeringVisitor = org.allbinary.game.layer.SteeringVisitor;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using MultipassWaypointPathRunnable = org.allbinary.game.layer.MultipassWaypointPathRunnable;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using WaypointPathRunnable = org.allbinary.game.layer.WaypointPathRunnable;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using WaypointPathRunnableBase = org.allbinary.game.layer.WaypointPathRunnableBase;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using WaypointBase = org.allbinary.game.layer.waypoint.WaypointBase;
using TrackingEventHandler = org.allbinary.game.tracking.TrackingEventHandler;
using GPoint = org.allbinary.graphics.GPoint;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using NullUtil = org.allbinary.logic.NullUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using LayerDistanceUtil = org.allbinary.math.LayerDistanceUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using PathFindingThreadPool = org.allbinary.thread.PathFindingThreadPool;
using ThreadPool = org.allbinary.thread.ThreadPool;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.game.layer.unit;

public class UnitWaypointBehavior2 : UnitWaypointBehavior
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly UnitWaypointStrings unitWaypointStrings = UnitWaypointStrings.getInstance();
    private readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    private readonly LayerDistanceUtil layerDistanceUtil = LayerDistanceUtil.getInstance();
    private readonly ThreadPool pathFindingThreadPool = PathFindingThreadPool.getInstance();
    private readonly TimeDelayHelper progressTimeDelayHelper;
    private readonly BasicArrayList wanderPathsList;
    private readonly WaypointPathRunnableBase waypointPathRunnable;
    private int sensorRange = 0;
    private int closeRange = 0;
    private GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition afterNextUnvisitedPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private bool waitingOnTargetPath = false;
    private bool waitingOnWaypointPath = false;
    private CollidableDestroyableDamageableLayer targetWithoutCachedPathLayerInterface = CollidableDestroyableDamageableLayer.getNullInstance();
    public UnitWaypointBehavior2(UnitLayer ownerAdvancedRTSGameLayer, AdvancedRTSGameLayer fakeWaypoint) : base(ownerAdvancedRTSGameLayer, fakeWaypoint)
    {
        // base(ownerAdvancedRTSGameLayer, fakeWaypoint) is called from the constructor declaration
        this.progressTimeDelayHelper = new TimeDelayHelper(5000);
        this.wanderPathsList = new BasicArrayListD();
        Features features = Features.getInstance();
        this.waypointPathRunnable = (J2MEUtil.isHTML() ? new MultipassWaypointPathRunnable() : new WaypointPathRunnable());
    }

    public override void initRange(int weaponRange)
    {
        base.initRange(weaponRange);
        this.closeRange = weaponRange;
        this.sensorRange = weaponRange * 4;
        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.initRange(this.associatedAdvancedRTSGameLayer, this.closeRange, this.sensorRange);
    }

    public override GeographicMapCellPosition getNextUnvisitedPathGeographicMapCellPosition()
    {
        return this.nextUnvisitedPathGeographicMapCellPosition;
    }

    public override bool isRunning()
    {
        if (this.waypointPathRunnable.isRunning()) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.waypointPathRunnable.isRunning()) {
            if (this.waypointPathsListP != UnitWaypointBehavior2.runningWaypointPathList) {
                this.waypointPathRunnable.setRunning(false);
                if (this.waitingOnTargetPath) {
                    this.setTargetPath();
                } else if (this.waitingOnWaypointPath) {
                    this.setWaypointPath(((AdvancedRTSGameLayer) this.waypointPathRunnable.getTargetLayer()));
                } else {
                    throw new Exception("Should not happen");
                }
            } else {
                return;
            }
        }
        this.processTargetList();
        if (!this.waypointPathRunnable.isRunning()) {
            this.processWaypoint();
        } else {
            return;
        }
        if (!this.waypointPathRunnable.isRunning()) {
            this.processTargeting();
        } else {
            return;
        }
        if (!this.waypointPathRunnable.isRunning()) {
            this.teleportIfNoProgress();
        } else {
            return;
        }
    }

    // throws Exception
    private void onEnemyMovement(AdvancedRTSGameLayer layerInterface)
    {
        int anotherTargetDistance = this.layerDistanceUtil.getDistance(this.associatedAdvancedRTSGameLayer, layerInterface);
        if (layerInterface == this.currentTargetLayerInterfaceP) {
            this.setCurrentTargetDistance(anotherTargetDistance);
        } else {
            this.processPossibleTarget(layerInterface, anotherTargetDistance);
        }
    }

    // throws Exception
    private void processPossibleTarget(AdvancedRTSGameLayer layerInterface, int anotherTargetDistance)
    {
        bool isShorterThanCurrentTargetDistance = this.getCurrentTargetDistance() > anotherTargetDistance;
        bool isCurrentTargetDestroyed = this.currentTargetLayerInterfaceP != CollidableDestroyableDamageableLayer.getNullInstance() && this.currentTargetLayerInterfaceP.isDestroyed();
        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processPossibleTarget(this.associatedAdvancedRTSGameLayer, this, layerInterface, anotherTargetDistance, isShorterThanCurrentTargetDistance, isCurrentTargetDestroyed);
        if (this.isWaypointListEmptyOrOnlyTargets() && this.isInSensorRange(layerInterface, anotherTargetDistance) && (isShorterThanCurrentTargetDistance || isCurrentTargetDestroyed)) {
            this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processSetTarget(this.associatedAdvancedRTSGameLayer, this, layerInterface, anotherTargetDistance);
            this.setTarget(layerInterface, anotherTargetDistance);
        } else if (this.isCloseRange(layerInterface, anotherTargetDistance) && (isShorterThanCurrentTargetDistance || isCurrentTargetDestroyed)) {
            this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processPossibleTargetCloser(this.associatedAdvancedRTSGameLayer, this, layerInterface, anotherTargetDistance);
            this.setTarget(layerInterface, anotherTargetDistance);
        }
    }

    // throws Exception
    private void teleportIfNoProgress()
    {
        if (this.isTrackingWaypoint() || this.associatedAdvancedRTSGameLayer.getParentLayer().isDestroyed()) {
            if (this.progressTimeDelayHelper.isTimeTNT() && this.nextUnvisitedPathGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
                this.associatedAdvancedRTSGameLayer.teleportTo(this.nextUnvisitedPathGeographicMapCellPosition);
            }
            if (this.getCompleteTimeDelayHelper().isTimeTNT()) {
                GeographicMapCellPosition geographicMapCellPosition = ((GeographicMapCellPosition) this.currentGeographicMapCellHistoryP.getTracked().get(this.currentGeographicMapCellHistoryP.getSize() - 1));
                this.associatedAdvancedRTSGameLayer.teleportTo(geographicMapCellPosition);
            }
        }
    }

    // throws Exception
    private void setTarget(AdvancedRTSGameLayer layerInterface, int anotherTargetDistance)
    {
        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.setTarget(this.associatedAdvancedRTSGameLayer, this, layerInterface, anotherTargetDistance);
        this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.TARGET, BasicColorFactory.getInstance().GREEN);
        this.associatedAdvancedRTSGameLayer.setLoad(0);
        this.setCurrentTargetDistance(anotherTargetDistance);
        this.setCurrentTargetLayerInterface(layerInterface);
        this.setTrackingWaypoint(false);
        this.targetList.clear();
        if (!this.isCloseRange(layerInterface, anotherTargetDistance) && this.canInsertWaypoint(0, this.currentTargetLayerInterfaceP)) {
            GeographicMapCellPosition geographicMapCellPosition = this.associatedAdvancedRTSGameLayer.getCurrentGeographicMapCellPosition();
            PathFindingLayerInterface pathFindingLayerInterface = (((PathFindingLayerInterface) this.currentTargetLayerInterfaceP));
            WaypointBase waypoint = pathFindingLayerInterface.getWaypointBehavior().getWaypoint();
            BasicArrayList list = waypoint.getPathsListFromCacheOnly(geographicMapCellPosition);
            this.setWaypointPathsList(list);
            if (this.waypointPathsListP == null) {
                this.targetWithoutCachedPathLayerInterface = this.currentTargetLayerInterfaceP;
            } else if (this.waypointPathsListP.size() != 0) {
                this.setTargetPath();
            }
        }
    }

    // throws Exception
    private void setTargetPath()
    {
        if (this.currentTargetLayerInterfaceP != CollidableDestroyableDamageableLayer.getNullInstance()) {
            if (this.currentTargetLayerInterfaceP.isDestroyed()) {
                this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.setTargetPath(this.associatedAdvancedRTSGameLayer);
                this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.KILL, this.basicColorFactory.ORANGE);
                this.clearTarget();
                return;
            }
            if (this.currentTargetLayerInterfaceP == this.waypointPathRunnable.getTargetLayer()) {
                this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.setTargetPathIgnoreNewPath(this.associatedAdvancedRTSGameLayer, this);
                this.insertWaypoint(0, this.currentTargetLayerInterfaceP);
                this.setRandomGeographicMapCellHistory(this.waypointPathsListP);
            }
        }
    }

    // throws Exception
    public override void setGeographicMapCellHistoryPath(BasicArrayList geographicMapCellPositionBasicArrayList)
    {
        this.setCurrentPathGeographicMapCellPosition(SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION);
        this.nextUnvisitedPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        base.setGeographicMapCellHistoryPath(geographicMapCellPositionBasicArrayList);
    }

    // throws Exception
    private void processWaypoint()
    {
        int size = this.targetList.size();
        if (size > 0) {
            AdvancedRTSGameLayer targetLayer = ((AdvancedRTSGameLayer) this.targetList.get(0));
            this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processWaypoint(this.associatedAdvancedRTSGameLayer, this, targetLayer, size);
            if (targetLayer.isDestroyed()) {
                this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.WAYPOINT_DESTROYED_SHORT, this.basicColorFactory.YELLOW);
                this.removeWaypoint(targetLayer, this.unitWaypointStrings.WAYPOINT_DESTROYED);
            } else {
                GeographicMapCellPosition geographicMapCellPosition = this.associatedAdvancedRTSGameLayer.getCurrentGeographicMapCellPosition();
                if (this.isTrackingWaypoint()) {
                    this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processWaypointTracked(this.associatedAdvancedRTSGameLayer, this);
                    if (this.visitIfAtMidPoint(geographicMapCellPosition)) {
                        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processWaypointTrackedVisit(this.associatedAdvancedRTSGameLayer, geographicMapCellPosition);
                    }
                    if (this.currentGeographicMapCellHistoryP.isAllVisited2() && this.currentTargetLayerInterfaceP != CollidableDestroyableDamageableLayer.getNullInstance()) {
                        AdvancedRTSGameLayer oldWaypointLayer = ((AdvancedRTSGameLayer) this.currentTargetLayerInterfaceP);
                        oldWaypointLayer.getWaypointBehavior().getWaypoint().visit(this.associatedAdvancedRTSGameLayer);
                        this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.ALL_VISITED_SHORT, this.basicColorFactory.GREEN);
                        this.removeWaypoint(((AdvancedRTSGameLayer) this.currentTargetLayerInterfaceP), this.unitWaypointStrings.ALL_VISITED);
                    }
                } else if (this.currentTargetLayerInterfaceP == null || this.waypointOverridesAttacking) {
                    BasicArrayList list = targetLayer.getWaypointBehavior().getWaypoint().getPathsListFromCacheOnly(geographicMapCellPosition);
                    this.setWaypointPathsList(list);
                    if (this.waypointPathsListP == null) {
                        this.waitingOnWaypointPath = true;
                        this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.THINKING, this.basicColorFactory.GREEN);
                        this.runWaypointPathTask(targetLayer);
                        return;
                    }
                    this.setWaypointPath(targetLayer);
                }
            }
        }
    }

    // throws Exception
    private void wander()
    {
        if (this.currentGeographicMapCellHistoryP.isAllVisited2()) {
            this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.wander(this.associatedAdvancedRTSGameLayer);
            this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.WANDERING, this.basicColorFactory.RED);
            this.wanderPathsList.clear();
            this.wanderPathsList.add(this.associatedAdvancedRTSGameLayer.getSurroundingGeographicMapCellPositionList());
            this.setRandomGeographicMapCellHistory(this.wanderPathsList);
        }
        this.visitIfAtMidPoint(this.getCurrentPathGeographicMapCellPosition());
        this.updateCurrentPathGeographicMapCellPosition();
        this.associatedAdvancedRTSGameLayer.trackTo(this.unitWaypointStrings.NEXT_PATH_NODE);
    }

    private bool visitIfAtMidPoint(GeographicMapCellPosition geographicMapCellPosition)
    {
        UnitLayer unitLayer = this.associatedAdvancedRTSGameLayer;
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION && this.nextUnvisitedPathGeographicMapCellPosition == geographicMapCellPosition) {
            GPoint point = geographicMapCellPosition.getMidPoint();
            GPoint afterNextPoint = this.afterNextUnvisitedPathGeographicMapCellPosition.getMidPoint();
            bool beyondMidPoint = true;
            if (geographicMapCellPosition.getColumn() == this.afterNextUnvisitedPathGeographicMapCellPosition.getColumn()) {
            } else if (point.getX() < afterNextPoint.getX()) {
                if (unitLayer.getXP() + unitLayer.getHalfWidth() < point.getX()) {
                    beyondMidPoint = false;
                }
            } else {
                if (unitLayer.getXP() + unitLayer.getHalfWidth() > point.getX()) {
                    beyondMidPoint = false;
                }
            }
            if (geographicMapCellPosition.getRow() == this.afterNextUnvisitedPathGeographicMapCellPosition.getRow()) {
            } else if (point.getY() < afterNextPoint.getY()) {
                if (unitLayer.getYP() + unitLayer.getHalfHeight() < point.getY()) {
                    beyondMidPoint = false;
                }
            } else {
                if (unitLayer.getYP() + unitLayer.getHalfHeight() > point.getY()) {
                    beyondMidPoint = false;
                }
            }
            if (beyondMidPoint) {
                return this.currentGeographicMapCellHistoryP.visit(geographicMapCellPosition);
            }
        }
        return false;
    }

    // throws Exception
    private void processTargetList()
    {
        this.targetWithoutCachedPathLayerInterface = CollidableDestroyableDamageableLayer.getNullInstance();
        for (int index = this.getPossibleTargetList().size() - 1; index >= 0; index--) {
            AdvancedRTSGameLayer layerInterface = ((AdvancedRTSGameLayer) this.getPossibleTargetList().get(index));
            if (layerInterface.isDestroyed()) {
                this.getPossibleTargetList().remove(layerInterface);
            } else {
                this.onEnemyMovement(layerInterface);
            }
        }
        if (this.targetWithoutCachedPathLayerInterface != CollidableDestroyableDamageableLayer.getNullInstance()) {
            this.waitingOnTargetPath = true;
            this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.THINKING_ABOUT_TARGET, this.basicColorFactory.GREEN);
            this.runWaypointPathTask(((AdvancedRTSGameLayer) this.currentTargetLayerInterfaceP));
        }
        this.getPossibleTargetList().clear();
    }

    // throws Exception
    private void processTargeting()
    {
        if (this.currentTargetLayerInterfaceP != CollidableDestroyableDamageableLayer.getNullInstance() && (this.isInSensorRange(this.currentTargetLayerInterfaceP, this.getCurrentTargetDistance()) || this.isTrackingWaypoint())) {
            if (this.currentTargetLayerInterfaceP.isDestroyed()) {
                this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.targetDestroyed(this.associatedAdvancedRTSGameLayer);
                this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.KILL, this.basicColorFactory.ORANGE);
                this.clearTarget();
                return;
            }
            int dx = 0;
            int dy = 0;
            if (this.isTrackingWaypoint()) {
                this.updateCurrentPathGeographicMapCellPosition();
                GPoint point = this.nextUnvisitedPathGeographicMapCellPosition.getMidPoint();
                dx = this.associatedAdvancedRTSGameLayer.getXP() + this.associatedAdvancedRTSGameLayer.getHalfWidth() - point.getX();
                dy = this.associatedAdvancedRTSGameLayer.getYP() + this.associatedAdvancedRTSGameLayer.getHalfHeight() - point.getY();
                this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processTargeting(this.associatedAdvancedRTSGameLayer, dx, dy);
            } else {
                this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.processTargetingNonWayPoint(this.associatedAdvancedRTSGameLayer, dx, dy);
                dx = (this.associatedAdvancedRTSGameLayer.getXP() + this.associatedAdvancedRTSGameLayer.getHalfWidth()) - (this.currentTargetLayerInterfaceP.getXP() + this.currentTargetLayerInterfaceP.getHalfWidth());
                dy = (this.associatedAdvancedRTSGameLayer.getYP() + this.associatedAdvancedRTSGameLayer.getHalfHeight()) - (this.currentTargetLayerInterfaceP.getYP() + this.currentTargetLayerInterfaceP.getHalfHeight());
            }
            this.associatedAdvancedRTSGameLayer.trackToDXY(dx, dy);
        } else {
            if (this.associatedAdvancedRTSGameLayer.getParentLayer().isDestroyed()) {
                this.wander();
            } else {
                if (this.associatedAdvancedRTSGameLayer.showMoreCaptionStates) {
                    this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.STOP, this.basicColorFactory.YELLOW);
                }
                this.associatedAdvancedRTSGameLayer.allStop();
            }
        }
    }

    private void updateCurrentPathGeographicMapCellPosition()
    {
        this.setLastPathGeographicMapCellPosition(this.getCurrentPathGeographicMapCellPosition());
        this.setCurrentPathGeographicMapCellPosition(this.nextUnvisitedPathGeographicMapCellPosition);
        this.nextUnvisitedPathGeographicMapCellPosition = this.currentGeographicMapCellHistoryP.getFirstUnvisited();
        this.afterNextUnvisitedPathGeographicMapCellPosition = this.currentGeographicMapCellHistoryP.getAfterIfNotLast(this.nextUnvisitedPathGeographicMapCellPosition);
        if (this.getCurrentPathGeographicMapCellPosition() != this.nextUnvisitedPathGeographicMapCellPosition) {
            this.progressTimeDelayHelper.setStartTimeTNT();
        }
    }

    // throws Exception
    private void setWaypointPath(AdvancedRTSGameLayer waypointLayer)
    {
        if (this.waypointPathsListP.size() != 0) {
            this.setCurrentTargetLayerInterface(waypointLayer);
            int MAX = int.MaxValue;
            this.setCurrentTargetDistance(MAX);
            this.setRandomGeographicMapCellHistory(this.waypointPathsListP);
        } else {
            waypointLayer.getWaypointBehavior().getWaypoint().visit(this.associatedAdvancedRTSGameLayer);
            this.associatedAdvancedRTSGameLayer.getCaptionAnimationHelper().update(this.unitWaypointStrings.ALREADY_THERE_SHORT, this.basicColorFactory.YELLOW);
            this.removeWaypoint(waypointLayer, this.unitWaypointStrings.ALREADY_THERE);
        }
    }

    private static readonly BasicArrayList runningWaypointPathList = new BasicArrayListD();
    // throws Exception
    private void runWaypointPathTask(AdvancedRTSGameLayer waypointLayer)
    {
        this.setWaypointPathsList(UnitWaypointBehavior2.runningWaypointPathList);
        if (this.waypointPathRunnable.isRunning()) {
            throw new Exception("Should never be running here");
        }
        this.waypointPathRunnable.setRunning(true);
        this.waypointPathRunnable.setUnitLayer(this.associatedAdvancedRTSGameLayer);
        this.waypointPathRunnable.setTargetLayer(waypointLayer);
        this.pathFindingThreadPool.runTask(this.waypointPathRunnable);
    }

    // throws Exception
    private void removeWaypoint(RTSLayer waypointLayer, string reason)
    {
        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.removeWaypoint(this.associatedAdvancedRTSGameLayer, this, waypointLayer, reason);
        this.targetList.remove(waypointLayer);
        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.removeWaypointList(this.associatedAdvancedRTSGameLayer, this, this.targetList);
        if (this.currentTargetLayerInterfaceP == waypointLayer) {
            this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.removeWaypointClear(this.associatedAdvancedRTSGameLayer);
            this.clearTarget();
        }
    }

    // throws Exception
    public override void clearTarget()
    {
        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.clearTarget(this.associatedAdvancedRTSGameLayer);
        this.setCurrentTargetLayerInterface(CollidableDestroyableDamageableLayer.getNullInstance());
        this.setTrackingWaypoint(false);
        int MAX = int.MaxValue;
        this.setCurrentTargetDistance(MAX);
        TrackingEventHandler.getInstance().fireEvent(this.associatedAdvancedRTSGameLayer.getTrackingEvent());
    }

    public override bool isWaypointListEmptyOrOnlyTargets()
    {
        BasicArrayList list = this.targetList;
        if (list.size() == 0) {
            return true;
        }
        for (int index = list.size() - 1; index >= 0; index--) {
            AdvancedRTSGameLayer layerInterface = ((AdvancedRTSGameLayer) list.get(index));
            if (layerInterface.isWaypointListEmptyOrOnlyTargets()) {
                return false;
            }
        }
        return true;
    }

    private bool isCloseRange(AdvancedRTSGameLayer layerInterface, int targetDistance)
    {
        return targetDistance < this.closeRange + layerInterface.getHalfHeight();
    }

    public override bool isInSensorRange(CollidableDestroyableDamageableLayer layerInterface, int targetDistance)
    {
        return targetDistance < this.sensorRange + layerInterface.getHalfHeight();
    }

    private static readonly string TARGET_DISTANCE = "Target Distance";
    private static readonly string TARGET_LAYER = "Target Layer";
    public override string getCurrentTargetingStateString()
    {
        StringMaker stringBuffer = new StringMaker();
        if (this.currentTargetLayerInterfaceP != CollidableDestroyableDamageableLayer.getNullInstance()) {
            stringBuffer.append(UnitWaypointBehavior2.TARGET_LAYER);
            stringBuffer.append(this.commonSeps.SPACE);
            stringBuffer.append(this.currentTargetLayerInterfaceP.getName());
            stringBuffer.append(" with ");
            stringBuffer.append(UnitWaypointBehavior2.TARGET_DISTANCE);
            stringBuffer.append(this.commonSeps.SPACE);
            stringBuffer.appendint(((int) this.getCurrentTargetDistance()));
        }
        return stringBuffer.ToString();
    }

    // throws Exception
    public override void addWaypointFromUser(AdvancedRTSGameLayer advancedRTSGameLayer)
    {
        if (advancedRTSGameLayer.isDestroyed()) {
            throw new Exception("Trying to add a dead: " + advancedRTSGameLayer);
        }
        this.associatedAdvancedRTSGameLayer.waypoint2LogHelperP.addWaypointFromUser(this.associatedAdvancedRTSGameLayer, advancedRTSGameLayer);
        this.targetList.clear();
        this.targetList.add(advancedRTSGameLayer);
        this.clearTarget();
    }

    private class BuildingSteeringVisitor : SteeringVisitor
    {
        private readonly BasicArrayList positionList = new BasicArrayListD();
        public override object visit(object anyType)
        {
            LogUtil logUtil = LogUtil.getInstance();
            try {
                if (this.getList().size() > 0) {
                    AllBinaryLayer allbinaryLayer = ((AllBinaryLayer) this.getList().get(0));
                    GeographicMapCellPosition cellPosition = ((GeographicMapCellPosition) this.getPositionList().get(0));
                    bool clear = this.buildingChase(allbinaryLayer, cellPosition);
                    if (clear) {
                        this.getList().clear();
                        this.positionList.clear();
                        return NullUtil.getInstance().NULL_OBJECT;
                    }
                    return BooleanFactory.getInstance().FALSE;
                }
                return NullUtil.getInstance().NULL_OBJECT;
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, this, "visit", e);
                return NullUtil.getInstance().NULL_OBJECT;
            }
        }

        public virtual BasicArrayList getPositionList()
        {
            return this.positionList;
        }

    }
    private readonly BuildingSteeringVisitor buildingSteeringVisitor = new BuildingSteeringVisitor();
    // throws Exception
    public override void addBuildingChase(AllBinaryLayer allbinaryLayer, GeographicMapCellPosition cellPosition)
    {
        if (!this.buildingSteeringVisitor.getList().contains(allbinaryLayer)) {
            this.buildingSteeringVisitor.getList().add(allbinaryLayer);
            this.buildingSteeringVisitor.getPositionList().add(cellPosition);
        }
        if (!this.getSteeringVisitorList().contains(this.buildingSteeringVisitor)) {
            this.getSteeringVisitorList().add(this.buildingSteeringVisitor);
        }
    }

    // throws Exception
    private bool buildingChase(AllBinaryLayer allbinaryLayer, GeographicMapCellPosition cellPosition)
    {
        return this.associatedAdvancedRTSGameLayer.buildingChase(allbinaryLayer, cellPosition);
    }

}

