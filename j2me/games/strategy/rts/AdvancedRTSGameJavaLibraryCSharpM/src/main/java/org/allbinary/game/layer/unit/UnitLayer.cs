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
//using Canvas = javax.microedition.lcdui.Canvas;
//using Graphics = javax.microedition.lcdui.Graphics;
using J2MEUtil = org.allbinary.J2MEUtil;
using ExplosionBasicSound = org.allbinary.ag.weapon.media.audio.ExplosionBasicSound;
using Animation = org.allbinary.animation.Animation;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using NullIndexedAnimationFactory = org.allbinary.animation.NullIndexedAnimationFactory;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using CaptionAnimationHelper = org.allbinary.animation.caption.CaptionAnimationHelper;
using CaptionAnimationHelperBase = org.allbinary.animation.caption.CaptionAnimationHelperBase;
using AdjustedCircleAnimation = org.allbinary.animation.vector.AdjustedCircleAnimation;
using Direction = org.allbinary.direction.Direction;
using DamageFloaters = org.allbinary.game.combat.damage.DamageFloaters;
using PtsDamageFloaters = org.allbinary.game.combat.damage.PtsDamageFloaters;
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using Health = org.allbinary.game.health.Health;
using HealthBar = org.allbinary.game.health.HealthBar;
using HealthBarTwodAnimation = org.allbinary.game.health.HealthBarTwodAnimation;
using Group = org.allbinary.game.identification.Group;
using GroupCommonFactory = org.allbinary.game.identification.GroupCommonFactory;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using GameKeyEventUtil = org.allbinary.game.input.@event.GameKeyEventUtil;
using VisibleCellPositionsSingleton = org.allbinary.game.input.form.VisibleCellPositionsSingleton;
using WaypointRTSFormInput = org.allbinary.game.input.form.WaypointRTSFormInput;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using AdvancedRTSProperties = org.allbinary.game.layer.AdvancedRTSProperties;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using CaptionResources = org.allbinary.game.layer.CaptionResources;
using LinePathRelativeAnimation = org.allbinary.game.layer.LinePathRelativeAnimation;
using PathAnimation = org.allbinary.game.layer.PathAnimation;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using RTSLayer2LogHelper = org.allbinary.game.layer.RTSLayer2LogHelper;
using RTSLayer2SelectedLogHelper = org.allbinary.game.layer.RTSLayer2SelectedLogHelper;
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using RTSLayerHudPaintable = org.allbinary.game.layer.RTSLayerHudPaintable;
using RTSLayerLogHelper = org.allbinary.game.layer.RTSLayerLogHelper;
using RTSLayerSelectedLogHelper = org.allbinary.game.layer.RTSLayerSelectedLogHelper;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using SelectionHudPaintable = org.allbinary.game.layer.SelectionHudPaintable;
using SensorActionFactory = org.allbinary.game.layer.SensorActionFactory;
using SteeringVisitor = org.allbinary.game.layer.SteeringVisitor;
using TiledLayerUtil = org.allbinary.game.layer.TiledLayerUtil;
using VehicleFrictionProperties = org.allbinary.game.layer.VehicleFrictionProperties;
using VehicleProperties = org.allbinary.game.layer.VehicleProperties;
using WaypointBehaviorBase = org.allbinary.game.layer.WaypointBehaviorBase;
using BuildingLayer = org.allbinary.game.layer.building.BuildingLayer;
using BuildingEventHandler = org.allbinary.game.layer.building.@event.BuildingEventHandler;
using BuildingEventListenerInterface = org.allbinary.game.layer.building.@event.BuildingEventListenerInterface;
using CapitalEvent = org.allbinary.game.layer.capital.@event.CapitalEvent;
using CapitalEventHandlerFactory = org.allbinary.game.layer.capital.@event.CapitalEventHandlerFactory;
using LayerPartialCellPositionsUtil = org.allbinary.game.layer.geographic.map.LayerPartialCellPositionsUtil;
using SpecialDownGameInputProcessor = org.allbinary.game.layer.special.SpecialDownGameInputProcessor;
using SpecialFireGameInputProcessor = org.allbinary.game.layer.special.SpecialFireGameInputProcessor;
using SpecialLeftGameInputProcessor = org.allbinary.game.layer.special.SpecialLeftGameInputProcessor;
using SpecialRightGameInputProcessor = org.allbinary.game.layer.special.SpecialRightGameInputProcessor;
using SpecialUpGameInputProcessor = org.allbinary.game.layer.special.SpecialUpGameInputProcessor;
using MultipassNoCacheWaypoint = org.allbinary.game.layer.waypoint.MultipassNoCacheWaypoint;
using NoCacheWaypoint = org.allbinary.game.layer.waypoint.NoCacheWaypoint;
using WaypointBase = org.allbinary.game.layer.waypoint.WaypointBase;
using WaypointEventHandlerFactory = org.allbinary.game.layer.waypoint.@event.WaypointEventHandlerFactory;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using BasicWeaponPart = org.allbinary.game.part.weapon.BasicWeaponPart;
using SalvoInterface = org.allbinary.game.part.weapon.SalvoInterface;
using VelocityProperties = org.allbinary.game.physics.velocity.VelocityProperties;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using TrackingEventHandler = org.allbinary.game.tracking.TrackingEventHandler;
using TrackingEventListenerInterface = org.allbinary.game.tracking.TrackingEventListenerInterface;
using CellPositionFactory = org.allbinary.graphics.CellPositionFactory;
using GPoint = org.allbinary.graphics.GPoint;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using Layer = org.allbinary.layer.Layer;
using LayerInterfaceFactoryInterface = org.allbinary.layer.LayerInterfaceFactoryInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using FrameUtil = org.allbinary.math.FrameUtil;
using LayerDistanceUtil = org.allbinary.math.LayerDistanceUtil;
using NamedAngle = org.allbinary.math.NamedAngle;
using AttackSound = org.allbinary.media.audio.AttackSound;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using Sound = org.allbinary.media.audio.Sound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;
using RaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMap;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer.unit;

public class UnitLayer : AdvancedRTSGameLayer, BuildingEventListenerInterface, TrackingEventListenerInterface
{
    private readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    private readonly GroupCommonFactory groupCommonFactory = GroupCommonFactory.getInstance();
    private readonly LayerPartialCellPositionsUtil layerPartialCellPositionsUtil = LayerPartialCellPositionsUtil.getInstance();
    private readonly LayerDistanceUtil layerDistanceUtil = LayerDistanceUtil.getInstance();
    private readonly AngleFactory angleFactory = AngleFactory.getInstance();
    private readonly CellPositionFactory cellPositionFactory = CellPositionFactory.getInstance();
    private readonly short maxResourceLoad;
    private readonly VehicleProperties vehicleProperties;
    public BasicDecimal accelerationBasicDecimal = new BasicDecimal(1600);
    public BasicDecimal decelerationBasicDecimal = new BasicDecimal(-1000);
    private readonly TrackingEvent trackingEvent;
    private readonly DamageFloaters damageFloaters = null;
    private readonly Paintable damageFloatersPaintableInterface = null;
    private readonly Paintable healthBar = null;
    private readonly Sound moveSoundInterface;
    private readonly RotationAnimation initResourceAnimation;
    private IndexedAnimation resourceAnimation = ((IndexedAnimation) NullIndexedAnimationFactory.getFactoryInstance().getInstance(0));
    private readonly PathAnimation initPathAnimation;
    private Animation pathAnimation = NullAnimationFactory.getFactoryInstance().getInstance(0);
    private readonly CaptionAnimationHelperBase captionAnimationHelper = new CaptionAnimationHelper(FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(CaptionResources.getInstance().RESOURCE).getInstance(0), -23, -25, 6, 0);
    private readonly RotationAnimation decalAnimation;
    private readonly LayerInterfaceFactoryInterface waypointLayerInterfaceFactoryInterface;
    private static readonly BasicArrayList partialPositionList = new BasicArrayListS(4);
    private int resourceLoad = 0;
    private int weaponRange = 0;
    public RTSLayerLogHelper rtsLogHelper = RTSLayerLogHelper.getInstance();
    public RotationAnimation rotationAnimationInterfaceP;
    private NamedAngle movementAngle;
    private GeographicMapCellPosition steeringInsideGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    protected UnitLayer(RemoteInfo remoteInfo, PathFindingLayerInterface parentLayer, AdvancedRTSProperties advancedRTSProperties, Group[] groupInterface, string rootName, string name, VehicleProperties vehicleProperties, Health healthInterface, int? maxResourceLoad, Sound moveSoundInterface, LayerInterfaceFactoryInterface waypointLayerInterfaceFactoryInterface, AnimationInterfaceFactoryInterface animationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface emptyAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface baseAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface buildAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface verticleBuildAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface decalAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface resourceAnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface proceduralAnimationInterfaceFactoryInterface, Rectangle rectangle, Direction direction, int x, int y, int z, ViewPositionBase viewPosition) : base(remoteInfo, parentLayer, advancedRTSProperties, groupInterface, rootName, name, healthInterface, new WaypointRTSFormInput(groupInterface, true), animationInterfaceFactoryInterface, emptyAnimationInterfaceFactoryInterface, baseAnimationInterfaceFactoryInterface, buildAnimationInterfaceFactoryInterface, verticleBuildAnimationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, viewPosition)
    {
        this.movementAngle = this.angleFactory.NOT_ANGLE;
        this.CAPITAL_EVENT = new CapitalEvent(this);
        // base(remoteInfo, parentLayer, advancedRTSProperties, groupInterface, rootName, name, healthInterface, new WaypointRTSFormInput(groupInterface, true), animationInterfaceFactoryInterface, emptyAnimationInterfaceFactoryInterface, baseAnimationInterfaceFactoryInterface, buildAnimationInterfaceFactoryInterface, verticleBuildAnimationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, viewPosition) is called from the constructor declaration
        this.setCollidableInferface(new CollidableUnitBehavior(true));
        this.waypointLayerInterfaceFactoryInterface = waypointLayerInterfaceFactoryInterface;
        this.maxResourceLoad = ((short) maxResourceLoad);
        this.moveSoundInterface = moveSoundInterface;
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().DAMAGE_FLOATERS)) {
            this.damageFloaters = new PtsDamageFloaters(this);
            this.damageFloatersPaintableInterface = this.damageFloaters;
        } else {
            this.damageFloatersPaintableInterface = NullPaintable.getInstance();
            this.damageFloaters = new DamageFloaters();
        }
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().HEALTH_BARS)) {
            this.healthBar = new HealthBar(this, this.getHealthInterface(), new HealthBarTwodAnimation(((AllBinaryLayer) this), BasicHudFactory.getInstance().BOTTOMLEFT), -1);
        } else {
            this.healthBar = NullPaintable.getInstance();
        }
        this.decalAnimation = ((RotationAnimation) decalAnimationInterfaceFactoryInterface.getInstance(0));
        this.initResourceAnimation = ((RotationAnimation) resourceAnimationInterfaceFactoryInterface.getInstance(0));
        this.initResourceAnimation.setFrameByDirection(direction);
        this.decalAnimation.setFrameByDirection(direction);
        this.rotationAnimationInterfaceP = ((RotationAnimation) this.indexedButShouldBeRotationAnimationInterface);
        this.rotationAnimationInterfaceP.setFrameByDirection(direction);
        this.setMaxLevel(12);
        this.vehicleProperties = vehicleProperties;
        this.trackingEvent = new TrackingEvent(this);
        this.initPathAnimation = new PathAnimation(this, LinePathRelativeAnimation.getInstance());
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        this.initPathAnimation.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
    }

    // throws Exception
    public override void updateWaypointBehavior(BasicGeographicMap geographicMapInterface)
    {
        ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
        hashtable.put(this.groupCommonFactory.ID, this.getGroupInterface());
        hashtable.put(Layer.ID, this);
        hashtable.put(AllBinaryGameLayerManager.ID, this.allBinaryGameLayerManagerP);
        this.setWaypointBehavior(new UnitWaypointBehavior2(this, ((AdvancedRTSGameLayer) this.waypointLayerInterfaceFactoryInterface.getNextInstance(hashtable, this.x, this.y, this.z))));
        Features features = Features.getInstance();
        WaypointBase waypoint = (J2MEUtil.isHTML() ? new MultipassNoCacheWaypoint(this, AttackSound.getInstance()) : new NoCacheWaypoint(this, AttackSound.getInstance()));
        this.getWaypointBehavior().setWaypoint(waypoint);
        base.updateWaypointBehavior(geographicMapInterface);
        this.initRangeHack();
    }

    // throws Exception
    public override void construct(RTSPlayerLayerInterface rtsPlayerLayerInterface)
    {
        base.construct(rtsPlayerLayerInterface);
        TrackingEventHandler.getInstance().addListenerInterface(this);
        WaypointEventHandlerFactory.getInstance(this.getGroupInterface()[0]).addListenerInterface(this.getUnitWaypointBehavior());
        BuildingEventHandler.getInstance().addListenerInterface(this);
        this.getUnitWaypointBehavior().setCurrentPathGeographicMapCellPosition(this.getCurrentGeographicMapCellPosition());
        this.updateSensorGeographicMapCellPositionList();
        this.getUnitWaypointBehavior().setLastPathGeographicMapCellPosition(this.getUnitWaypointBehavior().getCurrentPathGeographicMapCellPosition());
    }

    private readonly BasicArrayList sensorGeographicMapCellPositionList = new BasicArrayListD();
    // throws Exception
    public virtual void updateSensorGeographicMapCellPositionList()
    {
        if (VisibleCellPositionsSingleton.getInstance().shouldProcess()) {
            GeographicMapCellPosition currentGeographicMapCellPosition = this.getCurrentGeographicMapCellPosition();
            this.sensorGeographicMapCellPositionList.clear();
            this.sensorGeographicMapCellPositionList.add(currentGeographicMapCellPosition);
            int sensorRange = this.weaponRange * UnitLayer.SENSOR_RANGE_MULTIPLIER;
            GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.allBinaryGameLayerManagerP);
            BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
            AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
            int totalCells = (sensorRange / tiledLayer.getCellHeight()) / 2;
            BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
            int column = currentGeographicMapCellPosition.getColumn();
            int row = currentGeographicMapCellPosition.getRow();
            int lastColumn = column + totalCells;
            int lastRow = row + totalCells;
            if (lastColumn > tiledLayer.getColumns()) {
                lastColumn = tiledLayer.getColumns();
            }
            if (lastRow > tiledLayer.getRows()) {
                lastRow = tiledLayer.getRows();
            }
            int firstColumn = column - totalCells;
            int firstRow = row - totalCells;
            if (firstColumn < 0) {
                firstColumn = 0;
            }
            if (firstRow < 0) {
                firstRow = 0;
            }
            for (int index = lastColumn - 1; index >= firstColumn; index--) {
                for (int index2 = lastRow - 1; index2 >= firstRow; index2--) {
                    GeographicMapCellPosition geographicMapCellPosition = geographicMapCellPositionFactory.getAt(index, index2);
                    if (!this.sensorGeographicMapCellPositionList.contains(geographicMapCellPosition)) {
                        this.sensorGeographicMapCellPositionList.add(geographicMapCellPosition);
                    }
                }
            }
        }
    }

    public virtual BasicArrayList getSensorGeographicMapCellPositionList()
    {
        return this.sensorGeographicMapCellPositionList;
    }

    public override void select()
    {
        this.pathAnimation = this.initPathAnimation;
        base.select();
    }

    public override void deselect()
    {
        this.pathAnimation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        base.deselect();
    }

    protected override void setSelected(bool selected)
    {
        base.setSelected(selected);
        if (selected) {
            if (this.debug) {
                this.rtsLogHelper = RTSLayerSelectedLogHelper.getInstance();
            }
            this.rtsLayer2LogHelper = RTSLayer2SelectedLogHelper.getInstance();
        } else {
            if (this.debug) {
                this.rtsLogHelper = RTSLayerLogHelper.getInstance();
            }
            this.rtsLayer2LogHelper = RTSLayer2LogHelper.getInstance();
        }
    }

    // throws Exception
    public override void setClosestGeographicMapCellHistory(BasicArrayList pathsList)
    {
        this.rtsLogHelper.setClosestGeographicMapCellHistory(this, pathsList);
        int closestIndex = -1;
        int shortestDistance = Integer.MAX_VALUE;
        int currentDistance = Integer.MAX_VALUE;
        for (int index = pathsList.size() - 1; index >= 0; index--) {
            BasicArrayList geographicMapCellPositionBasicArrayList = ((BasicArrayList) pathsList.get(index));
            GeographicMapCellPosition geographicMapCellPosition = ((GeographicMapCellPosition) geographicMapCellPositionBasicArrayList.get(geographicMapCellPositionBasicArrayList.size() - 1));
            currentDistance = this.layerDistanceUtil.getDistanceAt(this, geographicMapCellPosition.getMidPoint());
            if (currentDistance < shortestDistance) {
                shortestDistance = currentDistance;
                closestIndex = index;
            }
        }
        if (closestIndex >= 0) {
            BasicArrayList geographicMapCellPositionBasicArrayList = ((BasicArrayList) pathsList.get(closestIndex));
            GeographicMapCellPosition geographicMapCellPosition = ((GeographicMapCellPosition) geographicMapCellPositionBasicArrayList.get(0));
            this.teleportTo(geographicMapCellPosition);
        }
    }

    // throws Exception
    public override void init(GeographicMapCellHistory geographicMapCellHistory, BasicArrayList geographicMapCellPositionBasicArrayList)
    {
        geographicMapCellHistory.trackAll(geographicMapCellPositionBasicArrayList);
    }

    public override void onMovement(TrackingEvent trackingEvent)
    {
        try {
            AdvancedRTSGameLayer layerInterface = ((AdvancedRTSGameLayer) trackingEvent.getLayerInterface());
            if (layerInterface.getGroupInterface()[0] != this.getGroupInterface()[0]) {
                this.getUnitWaypointBehavior().getPossibleTargetList().add(layerInterface);
                layerInterface.onMovementFound(this.getTrackingEvent());
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onMovement", e);
        }
    }

    // throws Exception
    public override void onMovementFound(TrackingEvent trackingEvent)
    {
        AdvancedRTSGameLayer layerInterface = ((AdvancedRTSGameLayer) trackingEvent.getLayerInterface());
        if (layerInterface.getGroupInterface()[0] != this.getGroupInterface()[0]) {
            this.getUnitWaypointBehavior().getPossibleTargetList().add(layerInterface);
        }
    }

    private static readonly int SENSOR_RANGE_MULTIPLIER = 6;
    public virtual void initRangeHack()
    {
        BasicWeaponPart basicWeaponPart = ((BasicWeaponPart) this.getPartInterfaceArray()[0]);
        WeaponProperties weaponProperties = basicWeaponPart.getWeaponProperties();
        this.weaponRange = weaponProperties.getRange();
        this.initRangeAnimation = AdjustedCircleAnimation.createW(this.weaponRange, this.weaponRange, this.getWidth(), this.basicColorFactory.GREEN);
        int sensorRange = this.weaponRange * UnitLayer.SENSOR_RANGE_MULTIPLIER;
        this.initSensorRangeAnimation = AdjustedCircleAnimation.createW(sensorRange, sensorRange, this.getWidth(), this.basicColorFactory.RED);
        this.getUnitWaypointBehavior().initRange(this.weaponRange);
        this.fireTimeHelper.delay = (((int) weaponProperties.getReloadTime()));
    }

    // throws Exception
    public override void processBuiltTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (!this.getHealthInterface().isAlive()) {
            if (this.isReadyForExplosion()) {
                int currentFrame = this.destroyAnimationInterface.getFrame();
                int size = this.destroyAnimationInterface.getSize() - 1;
                if (currentFrame == size) {
                    if (!this.getHealthInterface().isAlive()) {
                        this.setDestroyed(true);
                    }
                } else {
                    this.destroyAnimationInterface.nextFrame();
                }
            } else {
                this.setAnimationInterface(this.destroyAnimationInterface);
                SecondaryPlayerQueueFactory.getInstance().add(ExplosionBasicSound.getInstance());
                this.shakeListener.onSmallShakeEvent();
                this.vibration.vibrate(this.duration, 0, 0);
                this.setReadyForExplosion(true);
            }
        } else {
            base.processBuiltTick(allBinaryLayerManager);
        }
        this.captionAnimationHelper.tick();
        this.getUnitWaypointBehavior().processTick(allBinaryLayerManager);
    }

    public override void teleportTo(GeographicMapCellPosition geographicMapCellPosition)
    {
        GPoint point = geographicMapCellPosition.getMidPoint();
        this.setPosition(point.getX() - this.getHalfWidth(), point.getY() - this.getHalfHeight(), this.z);
    }

    // throws Exception
    public override GeographicMapCellPosition getCurrentGeographicMapCellPosition()
    {
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.allBinaryGameLayerManagerP);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        GeographicMapCellPosition geographicMapCellPosition = geographicMapInterface.getCellPositionAtXY(this.x + this.getHalfWidth(), this.y + this.getHalfHeight());
        RaceTrackGeographicMap raceTrackGeographicMap = ((RaceTrackGeographicMap) geographicMapInterface);
        if (!raceTrackGeographicMap.isValid(geographicMapCellPosition)) {
            throw new Exception("Position is not really on the map: " + geographicMapCellPosition);
        }
        return geographicMapCellPosition;
    }

    // throws Exception
    public override void fire(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent)
    {
        if (this.fireTimeHelper.isTimeTNT()) {
            this.fireAll(layerManager);
        } else {
            this.reload();
        }
    }

    // throws Exception
    public override void left()
    {
        this.initResourceAnimation.previousRotation();
        this.decalAnimation.previousRotation();
        this.rotationAnimationInterfaceP.previousRotation();
    }

    // throws Exception
    public override void right()
    {
        this.initResourceAnimation.nextRotation();
        this.decalAnimation.nextRotation();
        this.rotationAnimationInterfaceP.nextRotation();
    }

    public override void down()
    {
        VelocityProperties velocityProperties = this.getVehicleProperties().getVelocityProperties();
        if (!velocityProperties.isOverXYMaxForwardVelocity()) {
            this.accelerate(this.decelerationBasicDecimal);
        }
    }

    public override void up()
    {
        VelocityProperties velocityProperties = this.getVehicleProperties().getVelocityProperties();
        if (!velocityProperties.isOverXYMaxForwardVelocity()) {
            this.accelerate(this.accelerationBasicDecimal);
        }
    }

    public override void initInputProcessors()
    {
        this.inputProcessorArray[Canvas.RIGHT] = new SpecialRightGameInputProcessor(this);
        this.inputProcessorArray[Canvas.LEFT] = new SpecialLeftGameInputProcessor(this);
        this.inputProcessorArray[Canvas.KEY_NUM0] = new SpecialFireGameInputProcessor(this);
        this.inputProcessorArray[Canvas.KEY_POUND] = this.inputProcessorArray[Canvas.KEY_NUM0];
        this.inputProcessorArray[Canvas.DOWN] = new SpecialDownGameInputProcessor(this);
        this.inputProcessorArray[Canvas.UP] = new SpecialUpGameInputProcessor(this);
        base.initInputProcessors();
    }

    // throws Exception
    public override void processInput(AllBinaryLayerManager layerManager)
    {
        BasicArrayList list = this.getGameKeyEventList();
        int size = list.size();
        for (int index = 0; index < size; index++) {
            object anyType = list.get(index);
            int key = GameKeyEventUtil.getKey(anyType);
            this.inputProcessorArray[key].processEvent(layerManager, GameKeyEvent.NONE);
        }
        list.clear();
        this.groundFriction();
        this.move();
    }

    public virtual void accelerate(BasicDecimal accelerate)
    {
        this.getVehicleProperties().getVelocityProperties().addVelocityi(accelerate.getUnscaled(), ((int) this.rotationAnimationInterfaceP.getAngleInfoP().getAngle()), 90);
    }

    // throws Exception
    protected virtual void fireAll(AllBinaryLayerManager layerManager)
    {
        AngleInfo angleInfo = this.rotationAnimationInterfaceP.getAngleInfoP();
        int angle = ((int) (angleInfo.getAngle() + this.slightAngle));
        this.hashtable.put(SmallIntegerSingletonFactory.getInstance().getAt(1), SmallIntegerSingletonFactory.getInstance().getAt(((int) AngleFactory.getInstance().getAt(angle).getValue())));
        SalvoInterface salvoInterface = ((SalvoInterface) this.getPartInterfaceArray()[0]);
        salvoInterface.process(layerManager, ((short) angle), ((short) 90));
    }

    public override void downgrade()
    {
        if (this.getLevel() > 1) {
            base.downgrade();
        }
    }

    public override void upgrade()
    {
        base.upgrade();
        this.initRangeHack();
    }

    protected virtual void groundFriction()
    {
        VehicleFrictionProperties vehicleFrictionProperties = this.getVehicleProperties().getVehicleFrictionProperties();
        this.getVehicleProperties().getVehicleFrictionProperties().friction(this.getVehicleProperties().getVelocityProperties(), vehicleFrictionProperties.getTireFrictionNominator());
    }

    // throws Exception
    public override void trackTo(string reason)
    {
        WaypointBehaviorBase waypointBehaviorBase = ((WaypointBehaviorBase) this.waypointBehaviorBase);
        GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition = waypointBehaviorBase.getNextUnvisitedPathGeographicMapCellPosition();
        GPoint point = nextUnvisitedPathGeographicMapCellPosition.getMidPoint();
        int dx = (this.getXP() + this.getHalfWidth()) - point.getX();
        int dy = (this.getYP() + this.getHalfHeight()) - point.getY();
        this.rtsLogHelper.trackTo(this, nextUnvisitedPathGeographicMapCellPosition, dx, dy, reason);
        this.trackToDXY(dx, dy);
    }

    // throws Exception
    public override void trackToDXY(int dx, int dy)
    {
        int angleOfTarget = 0;
        this.trackToDXYTargetAngle(dx, dy, angleOfTarget);
    }

    // throws Exception
    private bool turnTo(int dx, int dy, int targetAngle)
    {
        WaypointBehaviorBase waypointBehaviorBase = ((WaypointBehaviorBase) this.waypointBehaviorBase);
        GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition = waypointBehaviorBase.getNextUnvisitedPathGeographicMapCellPosition();
        bool evading = false;
        if (this.getUnitWaypointBehavior().getSensorAction() == SensorActionFactory.getInstance().EVADE) {
            this.rtsLogHelper.evade(this);
            evading = true;
            targetAngle += 180;
        }
        AngleInfo angleInfo = this.rotationAnimationInterfaceP.getAngleInfoP();
        int angle = FrameUtil.getInstance().adjustAngleToFrameAngle(angleInfo.getAngle() - 270);
        this.rtsLogHelper.turnTo(this, dx, dy, angleInfo, angle, this.movementAngle, evading, targetAngle);
        GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
        if (dx == 0 && dy == 0) {
            this.rtsLogHelper.doneMoving(this);
            return true;
        } else if ((((int) this.movementAngle.getValue())) == angle) {
            if (dx > 0 && this.movementAngle == this.angleFactory.LEFT) {
                this.rtsLogHelper.movingLeft(this);
                return false;
            }
            if (dx < 0 && this.movementAngle == this.angleFactory.RIGHT) {
                this.rtsLogHelper.movingRight(this);
                return false;
            }
            if (dy > 0 && this.movementAngle == this.angleFactory.UP) {
                this.rtsLogHelper.movingUp(this);
                return false;
            }
            if (dy < 0 && this.movementAngle == this.angleFactory.DOWN) {
                this.rtsLogHelper.movingDown(this);
                return false;
            }
            this.rtsLogHelper.currentMoveEnded(this);
            if (this.movementAngle == this.angleFactory.LEFT || this.movementAngle == this.angleFactory.RIGHT) {
                this.handleDeltalY(dx, dy);
            } else if (this.movementAngle == this.angleFactory.UP || this.movementAngle == this.angleFactory.DOWN) {
                this.handleDeltalX(dx, dy);
            }
            return true;
        } else {
            if (nextUnvisitedPathGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
                if (this.steeringInsideGeographicMapCellPosition != nextUnvisitedPathGeographicMapCellPosition) {
                    if (Math.Abs(dx) > Math.Abs(dy) && dy != 0) {
                        this.handleDeltalY(dx, dy);
                    } else if (dx != 0) {
                        this.handleDeltalX(dx, dy);
                    } else {
                        this.handleDeltalY(dx, dy);
                    }
                }
                int deltaAngle2 = this.movementAngle.getValue() - angle;
                if (deltaAngle2 > 0) {
                    this.rtsLogHelper.rotateRight(this);
                    this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.RIGHT));
                } else {
                    this.rtsLogHelper.rotateLeft(this);
                    this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.LEFT));
                }
                return true;
            } else {
                this.rtsLogHelper.noRotation(this);
            }
            return false;
        }
    }

    private void handleDeltalX(int dx, int dy)
    {
        WaypointBehaviorBase waypointBehaviorBase = ((WaypointBehaviorBase) this.waypointBehaviorBase);
        GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition = waypointBehaviorBase.getNextUnvisitedPathGeographicMapCellPosition();
        if (dx > 0) {
            this.movementAngle = this.angleFactory.LEFT;
            this.steeringInsideGeographicMapCellPosition = nextUnvisitedPathGeographicMapCellPosition;
        } else {
            this.movementAngle = this.angleFactory.RIGHT;
            this.steeringInsideGeographicMapCellPosition = nextUnvisitedPathGeographicMapCellPosition;
        }
        this.rtsLogHelper.handle(this, this.movementAngle);
    }

    private void handleDeltalY(int dx, int dy)
    {
        WaypointBehaviorBase waypointBehaviorBase = ((WaypointBehaviorBase) this.waypointBehaviorBase);
        GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition = waypointBehaviorBase.getNextUnvisitedPathGeographicMapCellPosition();
        if (dy > 0) {
            this.movementAngle = this.angleFactory.UP;
            this.steeringInsideGeographicMapCellPosition = nextUnvisitedPathGeographicMapCellPosition;
        } else {
            this.movementAngle = this.angleFactory.DOWN;
            this.steeringInsideGeographicMapCellPosition = nextUnvisitedPathGeographicMapCellPosition;
        }
        this.rtsLogHelper.handle(this, this.movementAngle);
    }

    // throws Exception
    private void trackToDXYTargetAngle(int dx, int dy, int targetAngle)
    {
        BasicArrayList list = this.getUnitWaypointBehavior().getSteeringVisitorList();
        if (list.size() > 0) {
            for (int index = list.size() - 1; index >= 0; index--) {
                SteeringVisitor steeringVisitor = ((SteeringVisitor) list.get(index));
                object anyType = steeringVisitor.visit(this);
                if (anyType == null) {
                    list.removeAt(index);
                }
            }
            this.fireOrMove();
        } else if (!this.turnTo(dx, dy, targetAngle)) {
            this.fireOrMove();
        }
    }

    private static readonly string MOVE = "Moving";
    // throws Exception
    protected virtual void fireOrMove()
    {
        GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
        if (this.getUnitWaypointBehavior().needToMove()) {
            this.rtsLayer2LogHelper.steeringUp(this);
            if (this.showMoreCaptionStates && !this.captionAnimationHelper.isShowing()) {
                this.captionAnimationHelper.update(UnitLayer.MOVE, this.basicColorFactory.GREEN);
            }
            this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.UP));
        } else {
            this.captionAnimationHelper.update(CommonPhoneStrings.getInstance().FIRE, this.basicColorFactory.RED);
            this.rtsLayer2LogHelper.steeringFireOrStop(this);
            this.allStop();
            this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.KEY_NUM0));
            TrackingEventHandler.getInstance().fireEvent(this.getTrackingEvent());
        }
    }

    public override void move()
    {
        try {
            VelocityProperties velocityProperties = this.getVehicleProperties().getVelocityProperties();
            long velocityXScaled = ((long) velocityProperties.getVelocityXBasicDecimalP().getScaled());
            long velocityYScaled = ((long) velocityProperties.getVelocityYBasicDecimalP().getScaled());
            this.getUnitWaypointBehavior().move();
            if (velocityXScaled != 0L || velocityYScaled != 0L) {
                this.getUnitWaypointBehavior().setMoving(true);
                GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.allBinaryGameLayerManagerP);
                BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
                this.layerPartialCellPositionsUtil.getAllDXY(geographicMapInterface, this, ((int) velocityXScaled), ((int) velocityYScaled), UnitLayer.getPartialpositionlist());
                GeographicMapCellPosition cellPosition = ((GeographicMapCellPosition) DropCellPositionHistory.getInstance().getCellPositionWithDrop(UnitLayer.getPartialpositionlist()));
                if (cellPosition == this.cellPositionFactory.NONE) {
                    AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
                    TiledLayerUtil tiledLayerUtil = TiledLayerUtil.getInstance();
                    int x = this.x + ((int) velocityXScaled);
                    int y = this.y + ((int) velocityYScaled);
                    x = tiledLayerUtil.keepOnMapX(tiledLayer, x, this.getWidth());
                    y = tiledLayerUtil.keepOnMapY(tiledLayer, y, this.getHeight());
                    this.setPosition(x, y, this.z);
                } else {
                    AllBinaryLayer allbinaryLayer = DropCellPositionHistory.getInstance().getLayerInterface(cellPosition);
                    this.getUnitWaypointBehavior().setMovingFromStopped(false);
                    this.getUnitWaypointBehavior().addBuildingChase(allbinaryLayer, cellPosition);
                }
            }
            if (this.getUnitWaypointBehavior().isMoving()) {
                TrackingEventHandler.getInstance().fireEvent(this.getTrackingEvent());
            } else {
                this.getUnitWaypointBehavior().setMovingFromStopped(false);
            }
            if (this.getUnitWaypointBehavior().isMovingFromStopped() && this.isVisible()) {
                SecondaryPlayerQueueFactory.getInstance().add(this.moveSoundInterface);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "move", e);
        }
    }

    public override void allStop()
    {
        VelocityProperties velocityProperties = this.getVehicleProperties().getVelocityProperties();
        velocityProperties.getVelocityXBasicDecimalP().setint(0);
        velocityProperties.getVelocityYBasicDecimalP().setint(0);
    }

    public override void paint(Graphics graphics)
    {
        if (this.isVisible()) {
            base.paint(graphics);
            ViewPositionBase viewPosition = this.getViewPosition();
            int viewX = viewPosition.getX();
            int viewY = viewPosition.getY();
            this.decalAnimation.paintXY(graphics, viewX, viewY);
            this.rangeAnimation.paintXY(graphics, viewX, viewY);
            this.sensorRangeAnimation.paintXY(graphics, viewX, viewY);
            this.damageFloatersPaintableInterface.paint(graphics);
            this.healthBar.paint(graphics);
            this.captionAnimationHelper.paintXY(graphics, viewX, viewY);
            this.pathAnimation.paintXY(graphics, viewX, viewY);
            this.resourceAnimation.paintXY(graphics, viewX, viewY);
        }
    }

    // throws Exception
    public override void onBuildingEvent(RTSLayerEvent @event)
    {
        BuildingLayer buildingLayer = ((BuildingLayer) @event.getRtsLayer());
        this.getUnitWaypointBehavior().moveAwayFromBuilding(buildingLayer);
    }

    public virtual VehicleProperties getVehicleProperties()
    {
        return this.vehicleProperties;
    }

    // throws Exception
    public override void damage(int damage, int damageType)
    {
        base.damage(damage, damageType);
        this.damageFloaters.add(damage);
        if (damage > 0) {
            this.getHealthInterface().damage(damage);
        }
    }

    // throws Exception
    public override int getDamage(int damageType)
    {
        return 0;
    }

    // throws Exception
    public override void setDestroyed(bool destroyed)
    {
        this.logUtil.putF(this.commonStrings.START, this, "setDestroyed");
        base.setDestroyed(destroyed);
        if (this.isDestroyed()) {
            WaypointEventHandlerFactory.getInstance(this.getGroupInterface()[0]).removeListener(this.getUnitWaypointBehavior());
            TrackingEventHandler.getInstance().removeListener(this);
            BuildingEventHandler.getInstance().removeListener(this);
            if (!this.getHealthInterface().isAlive()) {
                int damage = this.getHealthInterface().getMaxHealth();
                if (damage > 10) {
                    SecondaryPlayerQueueFactory.getInstance().add(ExplosionBasicSound.getInstance());
                    if (damage < 100) {
                        this.shakeListener.onSmallShakeEvent();
                        this.vibration.vibrate(this.duration, 0, 0);
                    } else if (damage < 1000) {
                        this.shakeListener.onMediumShakeEvent();
                        this.vibration.vibrate(this.duration * 2, 0, 0);
                    } else if (damage < 3000) {
                        this.shakeListener.onLargeShakeEvent();
                        this.vibration.vibrate(this.duration * 4, 0, 0);
                    }
                }
            }
        }
    }

    public virtual int getLoad()
    {
        return this.resourceLoad;
    }

    // throws Exception
    public virtual void clearResourceAnimation()
    {
        this.resourceAnimation = ((IndexedAnimation) NullIndexedAnimationFactory.getFactoryInstance().getInstance(0));
    }

    // throws Exception
    public override void setLoad(int resource)
    {
        if (resource > 0) {
            this.resourceAnimation = this.initResourceAnimation;
        } else {
            this.clearResourceAnimation();
        }
        this.resourceLoad = resource;
    }

    public virtual void addLoad(int resource)
    {
        this.resourceLoad += resource;
    }

    private readonly CapitalEvent CAPITAL_EVENT;
    // throws Exception
    public override void handleCost(PathFindingLayerInterface ownerLayer)
    {
        if (this.getLoad() > 0) {
            this.CAPITAL_EVENT.setValue(this.getLoad());
            CapitalEventHandlerFactory.getInstance(ownerLayer.getGroupInterface()[0]).fireEvent(this.CAPITAL_EVENT);
            this.setLoad(0);
        }
    }

    public override SelectionHudPaintable createHudPaintable()
    {
        RTSLayerHudPaintable rtsLayerHudPaintable = RTSLayerHudPaintable.getInstance();
        rtsLayerHudPaintable.setBasicColorP(this.allBinaryGameLayerManagerP.getForegroundBasicColor());
        rtsLayerHudPaintable.setRtsLayer(this);
        return rtsLayerHudPaintable;
    }

    public override SelectionHudPaintable getHudPaintable()
    {
        RTSLayerHudPaintable rtsLayerHudPaintable = RTSLayerHudPaintable.getInstance();
        return rtsLayerHudPaintable;
    }

    public override int getType()
    {
        return UnitLayer.getStaticType();
    }

    public static int getStaticType()
    {
        return 1;
    }

    protected virtual UnitWaypointBehavior getUnitWaypointBehavior()
    {
        return ((UnitWaypointBehavior) this.getWaypointBehavior());
    }

    public override TrackingEvent getTrackingEvent()
    {
        return this.trackingEvent;
    }

    public override CaptionAnimationHelperBase getCaptionAnimationHelper()
    {
        return this.captionAnimationHelper;
    }

    public override bool isSelfUpgradeable()
    {
        return false;
    }

    public virtual short getMaxResourceLoad()
    {
        return this.maxResourceLoad;
    }

    public static BasicArrayList getPartialpositionlist()
    {
        return UnitLayer.partialPositionList;
    }

}

