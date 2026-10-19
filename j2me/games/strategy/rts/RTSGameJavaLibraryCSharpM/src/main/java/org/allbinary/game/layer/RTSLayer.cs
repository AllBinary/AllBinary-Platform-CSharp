/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using RTSFormInput = org.allbinary.game.input.form.RTSFormInput;
using MultiPlayerGameLayer = org.allbinary.game.multiplayer.layer.MultiPlayerGameLayer;
using Animation = org.allbinary.animation.Animation;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using NullIndexedAnimationFactory = org.allbinary.animation.NullIndexedAnimationFactory;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using CaptionAnimationHelperBase = org.allbinary.animation.caption.CaptionAnimationHelperBase;
using DestroyedLayerProcessor = org.allbinary.game.combat.destroy.DestroyedLayerProcessor;
using Health = org.allbinary.game.health.Health;
using Group = org.allbinary.game.identification.Group;
using GroupFactory = org.allbinary.game.identification.GroupFactory;
using GameInputInterface = org.allbinary.game.input.GameInputInterface;
using GameInputProcessor = org.allbinary.game.input.GameInputProcessor;
using GameInputProcessorUtil = org.allbinary.game.input.GameInputProcessorUtil;
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using InputFactory = org.allbinary.game.input.InputFactory;
using NullRTSFormInputFactory = org.allbinary.game.input.form.NullRTSFormInputFactory;
using Waypoint2LogHelper = org.allbinary.game.layer.waypoint.Waypoint2LogHelper;
using WaypointLogHelper = org.allbinary.game.layer.waypoint.WaypointLogHelper;
using WaypointRunnableLogHelper = org.allbinary.game.layer.waypoint.WaypointRunnableLogHelper;
using TickableInterface = org.allbinary.game.tick.TickableInterface;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using TileLayerPositionIntoViewPosition = org.allbinary.game.view.TileLayerPositionIntoViewPosition;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using ViewPositionEventHandler = org.allbinary.view.@event.ViewPositionEventHandler;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LayerDistanceUtil = org.allbinary.math.LayerDistanceUtil;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.layer;

public class RTSLayer : MultiPlayerGameLayer, TickableInterface, GameInputInterface, GameKeyEventSourceInterface, RTSInterface, PathFindingLayerInterface
{
    // throws Exception
    public static RTSLayer createSimulatedInstance(RemoteInfo remoteInfo)
    {
        AnimationInterfaceFactoryInterface nullAnimationInterfaceFactoryInterface = NullAnimationFactory.getFactoryInstance();
        AnimationInterfaceFactoryInterface nullIndexedAnimationInterfaceFactoryInterface = NullIndexedAnimationFactory.getFactoryInstance();
        return new RTSLayer(RemoteInfo.REMOTE_INFO, GroupFactory.getInstance().NULL_GROUP_ARRAY, StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING, Health.NULL_HEALTH, NullRTSFormInputFactory.getInstance(), nullAnimationInterfaceFactoryInterface, nullIndexedAnimationInterfaceFactoryInterface, nullAnimationInterfaceFactoryInterface, nullAnimationInterfaceFactoryInterface, nullIndexedAnimationInterfaceFactoryInterface, NullIndexedAnimationFactory.getFactoryInstance(), RectangleFactory.SINGLETON, 0, 0, new TileLayerPositionIntoViewPosition());
    }

    public readonly bool debug = true;
    public readonly bool showMoreCaptionStates;
    public readonly GameInputProcessor[] inputProcessorArray = new GameInputProcessor[InputFactory.getInstance().MAX];
    public RTSLayer2LogHelper rtsLayer2LogHelper = RTSLayer2LogHelper.getInstance();
    public WaypointLogHelper waypointLogHelperP = WaypointLogHelper.getInstance();
    public Waypoint2LogHelper waypoint2LogHelperP = Waypoint2LogHelper.getInstance();
    public WaypointRunnableLogHelper waypointRunnableLogHelperP = WaypointRunnableLogHelper.getInstance();
    private readonly RTSFormInput rtsFormInput;
    private IndexedAnimation verticleBuildAnimationInterface;
    public Animation rangeAnimation;
    public Animation initRangeAnimation;
    public Animation sensorRangeAnimation;
    public Animation initSensorRangeAnimation;
    public readonly Animation baseAnimationInterface;
    private readonly TimeDelayHelper buildFrameTimeHelper = new TimeDelayHelper(50);
    private readonly Animation buildAnimationInterface;
    private Animation animationInterface;
    public readonly IndexedAnimation initAnimationInterface;
    public IndexedAnimation indexedButShouldBeRotationAnimationInterface;
    public readonly IndexedAnimation emptyAnimationInterface;
    public readonly IndexedAnimation destroyAnimationInterface;
    public readonly TimeDelayHelper fireTimeHelper = new TimeDelayHelper(700);
    private readonly string rootName;
    public readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private readonly int BUILD_VALUE = 63;
    public readonly GeographicMapCellPositionAreaBase geographicMapCellPositionAreaBase;
    private Health healthInterface = Health.NULL_HEALTH;
    private static readonly int id = 0;
    private int level = 1;
    private int maxLevel = 1;
    private int hackVerticleBuild;
    public int slightAngle = 0;
    public static readonly int MAIN_INDEX = 0;
    public static readonly int SECONDARY_INDEX = 1;
    public int percentCompleteP = 0;
    private bool destroyed = false;
    private bool selected = false;
    protected RTSLayer(RemoteInfo remoteInfo, Group[] groupInterface, string rootName, string name, Health healthInterface, RTSFormInput rtsFormInput, AnimationInterfaceFactoryInterface animationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface emptyAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface baseAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface buildAnimationInterfaceFactoryInterface, AnimationInterfaceFactoryInterface verticleBuildAnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface proceduralAnimationInterfaceFactoryInterface, Rectangle rectangle, int x, int y, ViewPositionBase viewPosition) : base(remoteInfo, groupInterface, name, rectangle, viewPosition)
    {
        this.showMoreCaptionStates = this.debug;
        this.hackVerticleBuild = this.BUILD_VALUE;
        // base(remoteInfo, groupInterface, name, rectangle, viewPosition) is called from the constructor declaration
        this.initInputProcessors();
        this.rootName = rootName;
        this.healthInterface = healthInterface;
        this.rtsFormInput = rtsFormInput;
        this.setPosition(x, y, this.z);
        this.verticleBuildAnimationInterface = ((IndexedAnimation) verticleBuildAnimationInterfaceFactoryInterface.getInstance(0));
        this.buildAnimationInterface = buildAnimationInterfaceFactoryInterface.getInstance(0);
        this.baseAnimationInterface = baseAnimationInterfaceFactoryInterface.getInstance(0);
        this.emptyAnimationInterface = ((IndexedAnimation) emptyAnimationInterfaceFactoryInterface.getInstance(0));
        this.indexedButShouldBeRotationAnimationInterface = ((IndexedAnimation) animationInterfaceFactoryInterface.getInstance(0));
        this.initAnimationInterface = this.indexedButShouldBeRotationAnimationInterface;
        this.destroyAnimationInterface = ((IndexedAnimation) proceduralAnimationInterfaceFactoryInterface.getInstanceAnimation(this.indexedButShouldBeRotationAnimationInterface));
        Animation animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        this.rangeAnimation = animation;
        this.initRangeAnimation = animation;
        this.sensorRangeAnimation = animation;
        this.initSensorRangeAnimation = animation;
        this.animationInterface = this.initAnimationInterface;
        this.geographicMapCellPositionAreaBase = new GeographicMapCellPositionArea(this);
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.allBinaryGameLayerManagerP);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        TileLayerPositionIntoViewPosition viewPosition2 = ((TileLayerPositionIntoViewPosition) this.getViewPosition());
        viewPosition2.setTiledLayer(tiledLayer);
        this.updateWaypointBehavior(geographicMapInterface);
    }

    // throws Exception
    public virtual void updateWaypointBehavior(BasicGeographicMap geographicMapInterface)
    {
        this.geographicMapCellPositionAreaBase.update(geographicMapInterface);
    }

    // throws Exception
    public virtual void construct(RTSPlayerLayerInterface rtsPlayerLayerInterface)
    {
        ViewPositionEventHandler.getInstance().addListener(((AllBinaryLayer) this));
        this.animationInterface = this.buildAnimationInterface;
        this.hackVerticleBuild = 0;
    }

    public virtual void select()
    {
        this.rangeAnimation = this.initRangeAnimation;
        this.sensorRangeAnimation = this.initSensorRangeAnimation;
        this.setSelected(true);
    }

    public virtual void deselect()
    {
        Animation animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        this.rangeAnimation = animation;
        this.sensorRangeAnimation = animation;
        this.setSelected(false);
    }

    protected virtual void setSelected(bool selected)
    {
        this.selected = selected;
    }

    public override bool isSelected()
    {
        return this.selected;
    }

    public override int getPercentComplete()
    {
        return this.percentCompleteP;
    }

    public virtual ScrollSelectionForm getScrollSelectionForm()
    {
        return ScrollSelectionForm.getNullScrollSelectionForm();
    }

    public override void initInputProcessors()
    {
        GameInputProcessorUtil.init(this.inputProcessorArray);
    }

    // throws Exception
    public virtual void processBuiltTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        this.animationInterface = this.indexedButShouldBeRotationAnimationInterface;
    }

    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        try {
            if (this.isCompleted()) {
                this.processBuiltTick(allBinaryLayerManager);
            } else {
                this.build();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "processTick", e);
        }
    }

    // throws Exception
    public override void processInput(AllBinaryLayerManager layerManager)
    {
    }

    protected virtual void reload()
    {
    }

    public virtual void onMovement(TrackingEvent trackingEvent)
    {
    }

    // throws Exception
    public virtual void onMovementFound(TrackingEvent trackingEvent)
    {
    }

    public override void paint(Graphics graphics)
    {
        base.paintFirst(graphics);
        ViewPositionBase viewPosition = this.getViewPosition();
        int viewX = viewPosition.getX();
        int viewY = viewPosition.getY();
        this.getAnimationInterface().paintXY(graphics, viewX, viewY);
    }

    // throws Exception
    public override void damage(int damage, int damageType)
    {
    }

    public override int getSourceId()
    {
        return RTSLayer.id;
    }

    private readonly RTSLayerUtil rtsLayerUtil = RTSLayerUtil.getInstance();
    public override void downgrade()
    {
        this.rtsLayerUtil.downgrade(this);
    }

    public override void upgrade()
    {
        this.rtsLayerUtil.upgrade(this);
    }

    public override bool isCompleted()
    {
        if (this.hackVerticleBuild < this.BUILD_VALUE) {
            return false;
        } else {
            return true;
        }
    }

    // throws Exception
    private void build()
    {
        if (this.buildFrameTimeHelper.isTimeTNT()) {
            this.animationInterface = this.buildAnimationInterface;
            this.verticleBuildAnimationInterface.nextFrame();
            this.hackVerticleBuild++;
        }
        this.percentCompleteP = 100 * this.hackVerticleBuild / this.BUILD_VALUE;
        this.getHudPaintable().updateInfo();
    }

    public override bool isSelfUpgradeable()
    {
        return true;
    }

    public override int getCost()
    {
        return this.rtsLayerUtil.getCost(this);
    }

    public override int getDowngradeCost()
    {
        return this.rtsLayerUtil.getDowngradeCost(this);
    }

    public override int getUpgradeCost()
    {
        return this.rtsLayerUtil.getUpgradeCost(this);
    }

    public override bool isUpgradeable()
    {
        if (this.getLevel() < this.getMaxLevel()) {
            return true;
        } else {
            return false;
        }
    }

    public override bool isDowngradeable()
    {
        if (this.getLevel() > 1) {
            return true;
        } else {
            return false;
        }
    }

    public override int getLevel()
    {
        return this.level;
    }

    public virtual void setLevel(int level)
    {
        this.level = level;
    }

    public virtual Animation getVerticleBuildAnimationInterface()
    {
        return this.verticleBuildAnimationInterface;
    }

    public virtual Animation getAnimationInterface()
    {
        return this.animationInterface;
    }

    public virtual void setAnimationInterface(Animation animationInterface)
    {
        this.animationInterface = animationInterface;
    }

    private readonly LayerDistanceUtil layerDistanceUtil = LayerDistanceUtil.getInstance();
    // throws Exception
    public override void setTarget(PathFindingLayerInterface targetGameLayer)
    {
        int anotherTargetDistance = this.layerDistanceUtil.getDistance(((AllBinaryLayer) this), ((AllBinaryLayer) targetGameLayer));
        WaypointBehaviorBase waypointBehaviorBase = this.getWaypointBehavior();
        waypointBehaviorBase.setTargetWithDistance(((PathFindingLayerInterface) targetGameLayer), anotherTargetDistance);
    }

    public virtual SelectionHudPaintable createHudPaintable()
    {
        throw new SystemException();
    }

    public override SelectionHudPaintable getHudPaintable()
    {
        throw new SystemException();
    }

    public override int getMaxLevel()
    {
        return this.maxLevel;
    }

    public virtual void setMaxLevel(int maxLevel)
    {
        this.maxLevel = maxLevel;
    }

    public virtual Health getHealthInterface()
    {
        return this.healthInterface;
    }

    public virtual void setHealthInterface(Health healthInterface)
    {
        this.healthInterface = healthInterface;
    }

    public virtual RTSFormInput getRTSFormInput()
    {
        return this.rtsFormInput;
    }

    // throws Exception
    public override bool isDestroyed()
    {
        return this.destroyed;
    }

    // throws Exception
    public virtual void setDestroyed(bool destroyed)
    {
        this.destroyed = destroyed;
        if (this.isDestroyed()) {
            DestroyedLayerProcessor.getInstance().add(this);
            ViewPositionEventHandler.getInstance().removeListener(this);
        }
    }

    public override BasicArrayList getEndGeographicMapCellPositionList()
    {
        return this.geographicMapCellPositionAreaBase.getOccupyingGeographicMapCellPositionList();
    }

    public override GeographicMapCellPositionAreaBase getGeographicMapCellPositionArea()
    {
        return this.geographicMapCellPositionAreaBase;
    }

    public override bool shouldHandleStartSameAsEnd()
    {
        return true;
    }

    // throws Exception
    public override void handleCost(PathFindingLayerInterface ownerLayer)
    {
    }

    public override WaypointBehaviorBase getWaypointBehavior()
    {
        throw new SystemException();
    }

    public override PathFindingLayerInterface getParentLayer()
    {
        throw new SystemException();
    }

    public override RTSLayer2LogHelper getRTSLayer2LogHelper()
    {
        return this.rtsLayer2LogHelper;
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
        return false;
    }

    public override CaptionAnimationHelperBase getCaptionAnimationHelper()
    {
        throw new SystemException();
    }

    public override bool isShowMoreCaptionStates()
    {
        return this.showMoreCaptionStates;
    }

    // throws Exception
    public override void init(GeographicMapCellHistory geographicMapCellHistory, BasicArrayList geographicMapCellPositionBasicArrayList)
    {
    }

    // throws Exception
    public override GeographicMapCellPosition getCurrentGeographicMapCellPosition()
    {
        throw new SystemException();
    }

    // throws Exception
    public override GeographicMapCellPosition getTopLeftGeographicMapCellPosition()
    {
        throw new SystemException();
    }

    public override BasicArrayList getMoveOutOfBuildAreaPath(GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

    // throws Exception
    public override void setClosestGeographicMapCellHistory(BasicArrayList pathsList)
    {
    }

    public override void teleportTo(GeographicMapCellPosition geographicMapCellPosition)
    {
    }

    // throws Exception
    public override void setLoad(int resource)
    {
    }

    // throws Exception
    public override BasicArrayList getSurroundingGeographicMapCellPositionList()
    {
        throw new SystemException();
    }

    // throws Exception
    public override void trackTo(string reason)
    {
    }

    // throws Exception
    public override void trackToDXY(int dx, int dy)
    {
    }

    public override bool isWaypointListEmptyOrOnlyTargets()
    {
        return false;
    }

    public override TrackingEvent getTrackingEvent()
    {
        throw new SystemException();
    }

    // throws Exception
    public override bool buildingChase(AllBinaryLayer allbinaryLayer, GeographicMapCellPosition cellPosition)
    {
        return false;
    }

    public override void allStop()
    {
    }

    public static int getMinStaticType()
    {
        return 1;
    }

    public static int getMaxStaticType()
    {
        return 4;
    }

    public static bool isRTSLayer(AllBinaryLayer layerInterface)
    {
        if (layerInterface.getType() >= RTSLayer.getMinStaticType() && layerInterface.getType() <= RTSLayer.getMaxStaticType()) {
            return true;
        }
        return false;
    }

    public override bool implmentsTickableInterface()
    {
        return true;
    }

    public override bool implmentsGameInputInterface()
    {
        return true;
    }

    public virtual string getRootName()
    {
        return this.rootName;
    }

    public virtual RotationAnimation getRotationAnimationInterface()
    {
        return ((RotationAnimation) this.indexedButShouldBeRotationAnimationInterface);
    }

    public virtual void setFrame(int index)
    {
        this.getRotationAnimationInterface().setFrame(index);
    }

    public virtual void setRotationAnimationInterface(RotationAnimation rotationAnimationInterface)
    {
        this.indexedButShouldBeRotationAnimationInterface = rotationAnimationInterface;
    }

}

