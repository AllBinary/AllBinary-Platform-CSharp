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
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using NullIndexedAnimationFactory = org.allbinary.animation.NullIndexedAnimationFactory;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using ShakeAnimationListener = org.allbinary.animation.transition.shake.ShakeAnimationListener;
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using GameTypeFactory = org.allbinary.game.GameTypeFactory;
using DestroyedEvent = org.allbinary.game.combat.destroy.@event.DestroyedEvent;
using DestroyedEventHandler = org.allbinary.game.combat.destroy.@event.DestroyedEventHandler;
using DestroyedEventListenerInterface = org.allbinary.game.combat.destroy.@event.DestroyedEventListenerInterface;
using Health = org.allbinary.game.health.Health;
using Group = org.allbinary.game.identification.Group;
using GroupFactory = org.allbinary.game.identification.GroupFactory;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using NullRTSFormInputFactory = org.allbinary.game.input.form.NullRTSFormInputFactory;
using RTSFormInput = org.allbinary.game.input.form.RTSFormInput;
using BuildingEventHandler = org.allbinary.game.layer.building.@event.BuildingEventHandler;
using UnitLayer = org.allbinary.game.layer.unit.UnitLayer;
using Waypoint2LogHelper = org.allbinary.game.layer.waypoint.Waypoint2LogHelper;
using Waypoint2SelectedLogHelper = org.allbinary.game.layer.waypoint.Waypoint2SelectedLogHelper;
using WaypointBase = org.allbinary.game.layer.waypoint.WaypointBase;
using WaypointLogHelper = org.allbinary.game.layer.waypoint.WaypointLogHelper;
using WaypointRunnableLogHelper = org.allbinary.game.layer.waypoint.WaypointRunnableLogHelper;
using WaypointRunnableSelectedLogHelper = org.allbinary.game.layer.waypoint.WaypointRunnableSelectedLogHelper;
using WaypointSelectedLogHelper = org.allbinary.game.layer.waypoint.WaypointSelectedLogHelper;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using NullTickable = org.allbinary.game.tick.NullTickable;
using TickableInterface = org.allbinary.game.tick.TickableInterface;
using TileLayerPositionIntoViewPosition = org.allbinary.game.view.TileLayerPositionIntoViewPosition;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AngleInfo = org.allbinary.math.AngleInfo;
using FrameUtil = org.allbinary.math.FrameUtil;
using AllBinaryVibrationME = org.allbinary.media.AllBinaryVibrationME;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using GeographicMapDirectionUtil = org.allbinary.media.graphics.geography.map.GeographicMapDirectionUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer;

public class AdvancedRTSGameLayer : RTSLayer, DestroyedEventListenerInterface
{
    // throws Exception
    public static AdvancedRTSGameLayer createSimulated()
    {
        AnimationInterfaceFactoryInterface nullAnimationInterfaceFactoryInterface = NullAnimationFactory.getFactoryInstance();
        AnimationInterfaceFactoryInterface nullIndexedAnimationInterfaceFactoryInterface = NullIndexedAnimationFactory.getFactoryInstance();
        return new AdvancedRTSGameLayer(RemoteInfo.REMOTE_INFO, NullPathFindingLayer.NULL_PATH_FINDING_LAYER, AdvancedRTSProperties.createPropertiesSimulated(), GroupFactory.getInstance().NULL_GROUP_ARRAY, StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING, Health.NULL_HEALTH, NullRTSFormInputFactory.getInstance(), nullAnimationInterfaceFactoryInterface, nullIndexedAnimationInterfaceFactoryInterface, nullAnimationInterfaceFactoryInterface, nullAnimationInterfaceFactoryInterface, nullIndexedAnimationInterfaceFactoryInterface, NullIndexedAnimationFactory.getFactoryInstance(), RectangleFactory.SINGLETON, 0, 0, new TileLayerPositionIntoViewPosition());
    }

    public readonly ShakeAnimationListener shakeListener;
    public readonly AllBinaryVibrationME vibration;
    public readonly int duration;
    private PathFindingLayerInterface parentLayer = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    public TickableInterface waypointBehaviorBase = NullTickable.getInstance();
    public AdvancedRTSGameLayer(RemoteInfo remoteInfo, PathFindingLayerInterface parentLayer, AdvancedRTSProperties advancedRTSProperties, Group[] groupInterface, string rootName, string name, Health healthInterface, RTSFormInput rtsFormInput, AnimationInterfaceFactoryInterface animationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface emptyAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface baseAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface buildAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface verticleBuildAnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface proceduralAnimationInterfaceFactoryInterface, Rectangle rectangle, int x, int y, ViewPositionBase viewPosition) : base(remoteInfo, groupInterface, rootName, name, healthInterface, rtsFormInput, animationInterfaceFactoryInterface, emptyAnimationInterfaceFactoryInterface, baseAnimationInterfaceFactoryInterface, buildAnimationInterfaceFactoryInterface, verticleBuildAnimationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, viewPosition)
    {
        // base(remoteInfo, groupInterface, rootName, name, healthInterface, rtsFormInput, animationInterfaceFactoryInterface, emptyAnimationInterfaceFactoryInterface, baseAnimationInterfaceFactoryInterface, buildAnimationInterfaceFactoryInterface, verticleBuildAnimationInterfaceFactoryInterface, proceduralAnimationInterfaceFactoryInterface, rectangle, x, y, viewPosition) is called from the constructor declaration
        this.setVisible(false);
        this.setWaypointBehavior(new WaypointBehaviorBase());
        this.shakeListener = advancedRTSProperties.shakeListener;
        this.vibration = advancedRTSProperties.vibration;
        this.duration = advancedRTSProperties.duration;
        this.setParentLayer(parentLayer);
    }

    // throws Exception
    public override void updateWaypointBehavior(BasicGeographicMap geographicMapInterface)
    {
        base.updateWaypointBehavior(geographicMapInterface);
        this.getWaypointBehavior().getWaypoint().setAllBinaryGameLayerManager(this.allBinaryGameLayerManagerP);
    }

    protected virtual void initVisibility(RTSPlayerLayerInterface rtsPlayerLayerInterface)
    {
        AdvancedRTSPlayerLayerInterface advancedRTSPlayerLayerInterface = ((AdvancedRTSPlayerLayerInterface) rtsPlayerLayerInterface);
        if (advancedRTSPlayerLayerInterface.isLocalPlayer() || advancedRTSPlayerLayerInterface.getGameType() == GameTypeFactory.getInstance().BOT) {
            this.setVisible(true);
        } else {
            this.setVisible(false);
        }
    }

    // throws Exception
    public override void construct(RTSPlayerLayerInterface rtsPlayerLayerInterface)
    {
        base.construct(rtsPlayerLayerInterface);
        this.initVisibility(rtsPlayerLayerInterface);
        BuildingEventHandler.getInstance().addListenerInterface(this.getWaypointBehavior().getWaypoint());
    }

    // throws Exception
    public override void setDestroyed(bool destroyed)
    {
        base.setDestroyed(destroyed);
        if (this.isDestroyed()) {
            BuildingEventHandler.getInstance().removeListener(this.getWaypointBehavior().getWaypoint());
            BuildingEventHandler.getInstance().removeListener(this);
            DestroyedEventHandler.getInstance().addListener(this);
            RTSLayerUtil.getInstance().destroyAndClear(this.getWaypointBehavior().getOwnedWaypointList());
        }
    }

    public override PathFindingLayerInterface getParentLayer()
    {
        return this.parentLayer;
    }

    public virtual void setParentLayer(PathFindingLayerInterface parentLayer)
    {
        this.parentLayer = parentLayer;
    }

    public override WaypointBehaviorBase getWaypointBehavior()
    {
        return ((WaypointBehaviorBase) this.waypointBehaviorBase);
    }

    protected virtual void setWaypointBehavior(WaypointBehaviorBase unitWaypointHelper)
    {
        this.waypointBehaviorBase = unitWaypointHelper;
    }

    public override WaypointLogHelper getWaypointLogHelper()
    {
        return this.waypointLogHelperP;
    }

    public override Waypoint2LogHelper getWaypoint2LogHelper()
    {
        return this.waypoint2LogHelperP;
    }

    public override WaypointRunnableLogHelper getWaypointRunnableLogHelper()
    {
        return this.waypointRunnableLogHelperP;
    }

    public override bool shouldAddWaypointFromBuilding()
    {
        if (this.parentLayer != NullPathFindingLayer.NULL_PATH_FINDING_LAYER) {
            AdvancedRTSGameLayer parentAdvancedRTSGameLayer = ((AdvancedRTSGameLayer) this.parentLayer);
            if (parentAdvancedRTSGameLayer.getType() != UnitLayer.getStaticType()) {
                return true;
            }
        }
        return false;
    }

    public override bool isWaypointListEmptyOrOnlyTargets()
    {
        if (this.getType() != UnitLayer.getStaticType()) {
            return true;
        }
        return false;
    }

    // throws Exception
    public override bool buildingChase(AllBinaryLayer allbinaryLayer, GeographicMapCellPosition cellPosition)
    {
        GeographicMapCellPosition geographicMapCellPosition = this.getCurrentGeographicMapCellPosition();
        Direction buildingDirection = GeographicMapDirectionUtil.getInstance().getDirectionFromCellPositionToAdjacentCellPosition(geographicMapCellPosition, cellPosition);
        AngleInfo angleInfo = this.getRotationAnimationInterface().getAngleInfoP();
        int angle = FrameUtil.getInstance().adjustAngleToFrameAngle(angleInfo.getAngle() + 90);
        GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
        if (buildingDirection == DirectionFactory.getInstance().UP) {
            this.rtsLayer2LogHelper.buildingAbove(this);
            if (angle > 180 && angle < 360) {
                this.rtsLayer2LogHelper.buildingChaseLeft(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.LEFT));
                if (angle <= 190) {
                    return true;
                }
            } else {
                this.rtsLayer2LogHelper.buildingChaseRight(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.RIGHT));
                if (angle >= 170) {
                    return true;
                }
            }
        } else if (buildingDirection == DirectionFactory.getInstance().DOWN) {
            this.rtsLayer2LogHelper.buildingDown(this);
            if (angle > 180 && angle < 360) {
                this.rtsLayer2LogHelper.buildingChaseLeft(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.RIGHT));
                if (angle > 315) {
                    return true;
                }
            } else {
                this.rtsLayer2LogHelper.buildingChaseRight(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.LEFT));
                if (angle < 45) {
                    return true;
                }
            }
        } else if (buildingDirection == DirectionFactory.getInstance().LEFT) {
            this.rtsLayer2LogHelper.buildingLeft();
            if (angle > 90 && angle < 270) {
                this.rtsLayer2LogHelper.buildingChaseDown(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.LEFT));
                if (angle < 135) {
                    return true;
                }
            } else {
                this.rtsLayer2LogHelper.buildingChaseUp(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.RIGHT));
                if (angle > 45) {
                    return true;
                }
            }
        } else if (buildingDirection == DirectionFactory.getInstance().RIGHT) {
            this.rtsLayer2LogHelper.buildingRight();
            if (angle > 90 && angle < 270) {
                this.rtsLayer2LogHelper.buildingChaseDown(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.RIGHT));
                if (angle > 225) {
                    return true;
                }
            } else {
                this.rtsLayer2LogHelper.buildingChaseUp(this, angle);
                this.getGameKeyEventList().add(gameKeyEventFactory.getInstanceForKey(this, Canvas.LEFT));
                if (angle < 315 && angle > 180) {
                    return true;
                }
            }
        } else {
            return true;
        }
        return false;
    }

    // throws Exception
    public override BasicArrayList getSurroundingGeographicMapCellPositionList()
    {
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.allBinaryGameLayerManagerP);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.geographicMapCellPositionAreaBase.update(geographicMapInterface);
        return this.geographicMapCellPositionAreaBase.getSurroundingGeographicMapCellPositionList();
    }

    protected override void setSelected(bool selected)
    {
        base.setSelected(selected);
        if (this.debug) {
            if (selected) {
                this.waypointLogHelperP = WaypointSelectedLogHelper.getInstance();
                this.waypoint2LogHelperP = Waypoint2SelectedLogHelper.getInstance();
                this.waypointRunnableLogHelperP = WaypointRunnableSelectedLogHelper.getInstance();
            } else {
                this.waypointLogHelperP = WaypointLogHelper.getInstance();
                this.waypoint2LogHelperP = Waypoint2LogHelper.getInstance();
                this.waypointRunnableLogHelperP = WaypointRunnableLogHelper.getInstance();
            }
        }
    }

    public override void onDestroyed(DestroyedEvent destroyedEvent)
    {
        try {
            AllBinaryLayer layerInterface = destroyedEvent.getLayerInterface();
            if (layerInterface == this) {
                DestroyedEventHandler.getInstance().removeListener(this);
                WaypointBase waypoint = ((WaypointBase) this.getWaypointBehavior().getWaypoint());
                waypoint.reset();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onDestroyed", e);
        }
    }

}

