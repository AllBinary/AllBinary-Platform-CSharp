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
//using Graphics = javax.microedition.lcdui.Graphics;
using ExplosionBasicSound = org.allbinary.ag.weapon.media.audio.ExplosionBasicSound;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using NullIndexedAnimationFactory = org.allbinary.animation.NullIndexedAnimationFactory;
using GroupFactory = org.allbinary.game.identification.GroupFactory;
using NullRTSFormInputFactory = org.allbinary.game.input.form.NullRTSFormInputFactory;
using RTSFormInput = org.allbinary.game.input.form.RTSFormInput;
using VisibleCellPositionsSingleton = org.allbinary.game.input.form.VisibleCellPositionsSingleton;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using AdvancedRTSPlayerLayerInterface = org.allbinary.game.layer.AdvancedRTSPlayerLayerInterface;
using AdvancedRTSProperties = org.allbinary.game.layer.AdvancedRTSProperties;
using CollidableRTSBehavior = org.allbinary.game.layer.CollidableRTSBehavior;
using RTSLayerUtil = org.allbinary.game.layer.RTSLayerUtil;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using SelectionHudPaintable = org.allbinary.game.layer.SelectionHudPaintable;
using Waypoint = org.allbinary.game.layer.waypoint.Waypoint;
using TileLayerPositionIntoViewPosition = org.allbinary.game.view.TileLayerPositionIntoViewPosition;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using RotationAnimationInterfaceCompositeInterface = org.allbinary.animation.RotationAnimationInterfaceCompositeInterface;
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using DamageFloaters = org.allbinary.game.combat.damage.DamageFloaters;
using Health = org.allbinary.game.health.Health;
using Group = org.allbinary.game.identification.Group;
using GeographicMapCellPositionAreaBase = org.allbinary.game.layer.GeographicMapCellPositionAreaBase;
using NullPathFindingLayer = org.allbinary.game.layer.NullPathFindingLayer;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using TrackingEventHandler = org.allbinary.game.tracking.TrackingEventHandler;
using TrackingEventListenerInterface = org.allbinary.game.tracking.TrackingEventListenerInterface;
using Rectangle = org.allbinary.graphics.Rectangle;
using Paintable = org.allbinary.graphics.paint.Paintable;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using SelectSound = org.allbinary.media.audio.SelectSound;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapDirectionUtil = org.allbinary.media.graphics.geography.map.GeographicMapDirectionUtil;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using org.allbinary.util;

namespace org.allbinary.game.layer.building;

public class BuildingLayer : AdvancedRTSGameLayer, RotationAnimationInterfaceCompositeInterface, TrackingEventListenerInterface
{
    // throws Exception
    public static BuildingLayer createSimulated()
    {
        AnimationInterfaceFactoryInterface nullAnimationInterfaceFactoryInterface = NullAnimationFactory.getFactoryInstance();
        AnimationInterfaceFactoryInterface nullIndexedAnimationInterfaceFactoryInterface = NullIndexedAnimationFactory.getFactoryInstance();
        return new BuildingLayer(RemoteInfo.REMOTE_INFO, SimulatedBuildingPropertiesFactory.getInstance(), AdvancedRTSProperties.createPropertiesSimulated(), GroupFactory.getInstance().NULL_GROUP_ARRAY, StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING, Health.NULL_HEALTH, NullRTSFormInputFactory.getInstance(), nullAnimationInterfaceFactoryInterface, nullIndexedAnimationInterfaceFactoryInterface, nullAnimationInterfaceFactoryInterface, nullAnimationInterfaceFactoryInterface, nullIndexedAnimationInterfaceFactoryInterface, NullIndexedAnimationFactory.getFactoryInstance(), RectangleFactory.SINGLETON, 0, 0);
    }

    private int buildingLevelCost = 0;
    private int productivity = 0;
    private int efficiency;
    private int efficiencyPerLevel;
    private readonly TrackingEvent trackingEvent;
    private readonly DamageFloaters damageFloaters;
    private readonly Paintable damageFloatersPaintableInterface;
    private readonly Paintable healthBar;
    private readonly ABHashtable<object, object> pathsHashtable;
    public BuildingLayer(RemoteInfo remoteInfo, BuildingPropertiesFactory buildingPropertiesFactory, AdvancedRTSProperties advancedRTSProperties, Group[] groupInterface, string rootName, string name, Health healthInterface, RTSFormInput rtsFormInput, AnimationInterfaceFactoryInterface animationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface emptyAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface baseAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface buildAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface verticleBuildAnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface proceduralAnimationInterfaceFactoryInterface, Rectangle rectangle, int x, int y) : base(remoteInfo, NullPathFindingLayer.NULL_PATH_FINDING_LAYER, advancedRTSProperties, groupInterface, rootName, name, healthInterface, rtsFormInput, animationInterfaceFactoryInterface, emptyAnimationInterfaceFactoryInterface, baseAnimationInterfaceFactoryInterface, buildAnimationInterfaceFactoryInterface, verticleBuildAnimationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, new TileLayerPositionIntoViewPosition())
    {
        // base(remoteInfo, NullPathFindingLayer.NULL_PATH_FINDING_LAYER, advancedRTSProperties, groupInterface, rootName, name, healthInterface, rtsFormInput, animationInterfaceFactoryInterface, emptyAnimationInterfaceFactoryInterface, baseAnimationInterfaceFactoryInterface, buildAnimationInterfaceFactoryInterface, verticleBuildAnimationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, new TileLayerPositionIntoViewPosition()) is called from the constructor declaration
        this.setCollidableInferface(new CollidableRTSBehavior(true));
        this.getWaypointBehavior().setWaypoint(new Waypoint(this, SelectSound.getInstance()));
        this.damageFloaters = buildingPropertiesFactory.getDamageFloaters(this);
        this.damageFloatersPaintableInterface = buildingPropertiesFactory.damageFloatersPaintableInterface;
        this.healthBar = buildingPropertiesFactory.getHealthBar(this);
        this.pathsHashtable = buildingPropertiesFactory.getHashtable();
        this.setMaxLevel(30);
        this.setProductivity(1);
        this.setEfficiency(this.calculateEfficiency());
        this.efficiencyPerLevel = buildingPropertiesFactory.getEfficiencyPerLevel(this);
        this.efficiency = this.efficiencyPerLevel;
        this.generateMoveOutOfBuildAreaPaths();
        this.trackingEvent = buildingPropertiesFactory.getTrackingEvent(this);
    }

    public bool local = false;
    protected override void initVisibility(RTSPlayerLayerInterface rtsPlayerLayerInterface)
    {
        AdvancedRTSPlayerLayerInterface advancedRTSPlayerLayerInterface = ((AdvancedRTSPlayerLayerInterface) rtsPlayerLayerInterface);
        if (advancedRTSPlayerLayerInterface.isLocalPlayer()) {
            this.local = true;
            this.addVisibility();
        } else {
            this.local = false;
        }
        base.initVisibility(rtsPlayerLayerInterface);
    }

    // throws Exception
    public override void construct(RTSPlayerLayerInterface rtsPlayerLayerInterface)
    {
        base.construct(rtsPlayerLayerInterface);
        TrackingEventHandler.getInstance().addListenerInterface(this);
    }

    public override void onMovement(TrackingEvent trackingEvent)
    {
        try {
            AdvancedRTSGameLayer layerInterface = ((AdvancedRTSGameLayer) trackingEvent.getLayerInterface());
            if (layerInterface.getGroupInterface()[0] != this.getGroupInterface()[0]) {
                layerInterface.onMovementFound(this.trackingEvent);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onMovement", e);
        }
    }

    public readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(3000);
    // throws Exception
    public override void processBuiltTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.getHealthInterface().isDamaged()) {
            this.setAnimationInterface(this.destroyAnimationInterface);
        }
        if (!this.getHealthInterface().isAlive()) {
            if (this.isReadyForExplosion()) {
                int currentFrame = this.destroyAnimationInterface.getFrame();
                int size = this.destroyAnimationInterface.getSize() - 1;
                if (currentFrame == size && !this.timeDelayHelper.isTimeTNT()) {
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
                this.timeDelayHelper.setStartTimeTNT();
                this.setReadyForExplosion(true);
            }
        } else {
            base.processBuiltTick(allBinaryLayerManager);
        }
        this.indexedButShouldBeRotationAnimationInterface.nextFrame();
    }

    private int calculateEfficiency()
    {
        return this.efficiencyPerLevel;
    }

    public override int getCost()
    {
        long total = RTSLayerUtil.getInstance().getCostExponential(((long) (this.getLevel() * this.getBuildingLevelCost())));
        return ((int) total);
    }

    public override int getDowngradeCost()
    {
        long downgradeCost = RTSLayerUtil.getInstance().getCostExponential(((long) ((this.getLevel() - 1) * this.getBuildingLevelCost())));
        this.logUtil.putF("Cost: " + downgradeCost, this, "getDowngradeCost");
        return ((int) downgradeCost) * 9 / 10;
    }

    public override int getUpgradeCost()
    {
        long upgradeCost = RTSLayerUtil.getInstance().getCostExponential(((long) ((this.getLevel() + 1) * this.getBuildingLevelCost())));
        return ((int) upgradeCost);
    }

    public override void downgrade()
    {
        base.downgrade();
        this.setProductivity(this.getProductivity() - 1);
        this.setEfficiency(this.getEfficiency() - this.calculateEfficiency());
        this.getHealthInterface().setMaxHealth(this.getHealthInterface().getMaxHealth() - ((this.getLevel() + 1) * 100));
    }

    public override void upgrade()
    {
        base.upgrade();
        this.setProductivity(this.getProductivity() + 1);
        this.setEfficiency(this.getEfficiency() + this.calculateEfficiency());
        this.getHealthInterface().setMaxHealth(this.getHealthInterface().getMaxHealth() + (this.getLevel() * 100));
    }

    private int getBuildingLevelCost()
    {
        return this.buildingLevelCost;
    }

    protected virtual void setBuildingLevelCost(int buildingLevelCost)
    {
        this.buildingLevelCost = buildingLevelCost;
    }

    public virtual int getProductivity()
    {
        return this.productivity;
    }

    public virtual void setProductivity(int productivity)
    {
        this.productivity = productivity;
    }

    public virtual int getEfficiency()
    {
        return this.efficiency;
    }

    public virtual void setEfficiency(int efficiency)
    {
        this.efficiency = efficiency;
    }

    // throws Exception
    private void generateMoveOutOfBuildAreaPaths()
    {
        BasicArrayList occupyList = this.geographicMapCellPositionAreaBase.getOccupyingGeographicMapCellPositionList();
        BasicArrayList surroundList = this.geographicMapCellPositionAreaBase.getSurroundingGeographicMapCellPositionList();
        Direction NO_DIRECTION = DirectionFactory.getInstance().NO_DIRECTION;
        GeographicMapDirectionUtil geographicMapDirectionUtil = GeographicMapDirectionUtil.getInstance();
        BasicArrayList pathsList = null;
        GeographicMapCellPosition occupyGeographicMapCellPosition = null;
        GeographicMapCellPosition surroundGeographicMapCellPosition = null;
        BasicArrayList list = null;
        for (int index2 = occupyList.size() - 1; index2 >= 0; index2--) {
            pathsList = new BasicArrayListD();
            occupyGeographicMapCellPosition = ((GeographicMapCellPosition) occupyList.get(index2));
            for (int index = surroundList.size() - 1; index >= 0; index--) {
                surroundGeographicMapCellPosition = ((GeographicMapCellPosition) surroundList.get(index));
                if (geographicMapDirectionUtil.getEightDirectionFromCellPositionToAdjacentCellPosition(surroundGeographicMapCellPosition, occupyGeographicMapCellPosition) != NO_DIRECTION) {
                    list = new BasicArrayListS(1);
                    list.add(surroundGeographicMapCellPosition);
                    pathsList.add(list);
                }
            }
            this.pathsHashtable.put(occupyGeographicMapCellPosition, pathsList);
        }
    }

    public override BasicArrayList getMoveOutOfBuildAreaPath(GeographicMapCellPosition geographicMapCellPosition)
    {
        BasicArrayList pathsList = ((BasicArrayList) this.pathsHashtable.get(geographicMapCellPosition));
        return pathsList;
    }

    public override BasicArrayList getEndGeographicMapCellPositionList()
    {
        return this.geographicMapCellPositionAreaBase.getSurroundingGeographicMapCellPositionList();
    }

    public override bool shouldHandleStartSameAsEnd()
    {
        return false;
    }

    public override void paint(Graphics graphics)
    {
        if (this.isVisible()) {
            base.paint(graphics);
            this.damageFloatersPaintableInterface.paint(graphics);
            this.healthBar.paint(graphics);
        }
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

    public virtual void addVisibility()
    {
        GeographicMapCellPositionAreaBase geographicMapCellPositionArea = this.geographicMapCellPositionAreaBase;
        BasicArrayList occupyList = geographicMapCellPositionArea.getOccupyingGeographicMapCellPositionList();
        VisibleCellPositionsSingleton.getInstance().addStationaryCellPositions(occupyList);
        BasicArrayList surroundList = geographicMapCellPositionArea.getSurroundingGeographicMapCellPositionList();
        VisibleCellPositionsSingleton.getInstance().addStationaryCellPositions(surroundList);
    }

    public virtual void removeVisibility()
    {
        BasicArrayList occupyList = this.geographicMapCellPositionAreaBase.getOccupyingGeographicMapCellPositionList();
        VisibleCellPositionsSingleton.getInstance().removeStationaryCellPositions(occupyList);
        BasicArrayList surroundList = this.geographicMapCellPositionAreaBase.getSurroundingGeographicMapCellPositionList();
        VisibleCellPositionsSingleton.getInstance().removeStationaryCellPositions(surroundList);
    }

    // throws Exception
    public override void setDestroyed(bool destroyed)
    {
        base.setDestroyed(destroyed);
        if (this.isDestroyed()) {
            DropCellPositionHistory.getInstance().removeAll(this);
            TrackingEventHandler.getInstance().removeListener(this);
            if (this.local) {
                this.removeVisibility();
            }
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

    public override SelectionHudPaintable createHudPaintable()
    {
        BuildingInfoHudPaintable buildingInfoHudPaintable = BuildingInfoHudPaintable.getInstance();
        buildingInfoHudPaintable.setBasicColorP(this.allBinaryGameLayerManagerP.getForegroundBasicColor());
        buildingInfoHudPaintable.setRtsLayer(this);
        return buildingInfoHudPaintable;
    }

    public override SelectionHudPaintable getHudPaintable()
    {
        BuildingInfoHudPaintable buildingInfoHudPaintable = BuildingInfoHudPaintable.getInstance();
        return buildingInfoHudPaintable;
    }

    public override int getType()
    {
        return BuildingLayer.getStaticType();
    }

    public static int getStaticType()
    {
        return 2;
    }

}

