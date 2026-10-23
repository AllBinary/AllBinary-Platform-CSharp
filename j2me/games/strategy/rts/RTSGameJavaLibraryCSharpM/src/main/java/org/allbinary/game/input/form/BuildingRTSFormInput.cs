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
using RTSPlayerGameInput = org.allbinary.game.input.RTSPlayerGameInput;
using DemoLockedWithCostLayerInterfaceFactoryInterface = org.allbinary.game.layer.DemoLockedWithCostLayerInterfaceFactoryInterface;
using GeographicMapCellPositionAreaBase = org.allbinary.game.layer.GeographicMapCellPositionAreaBase;
using RTSGameStrings = org.allbinary.game.layer.RTSGameStrings;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using Capital = org.allbinary.game.layer.capital.Capital;
using LayerInterfaceFactoryImageItem = org.allbinary.game.layer.item.LayerInterfaceFactoryImageItem;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using BuildingSound = org.allbinary.media.audio.BuildingSound;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using LockedFeatureNotificationUtil = org.allbinary.logic.system.security.licensing.LockedFeatureNotificationUtil;
using LockedUtil = org.allbinary.logic.system.security.licensing.LockedUtil;
using Group = org.allbinary.game.identification.Group;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using GPoint = org.allbinary.graphics.GPoint;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;
using RaceTrackGeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellTypeFactory;

namespace org.allbinary.game.input.form;

public class BuildingRTSFormInput : RTSFormInput
{
    private bool isUnitProducer;
    private readonly GameNotificationEvent buildOnPathGameNotificationEvent;
    private readonly GameNotificationEvent spotTakenGameNotificationEvent;
    private readonly GameNotificationEvent selectBuildSpotGameNotificationEvent;
    private readonly GameNotificationEvent roadCollisionGameNotificationEvent;
    private readonly GameNotificationEvent noMoneyGameNotificationEvent;
    private readonly GameNotificationEvent buildingCollisionGameNotificationEvent;
    private readonly GameNotificationEvent structureToCloseCollisionGameNotificationEvent;
    private readonly GameNotificationEvent buildingGameNotificationEvent;
    private readonly GameNotificationEvent mapEdgeGameNotificationEvent;
    private readonly DropCellPositionHistory dropCellPositionHistory = DropCellPositionHistory.getInstance();
    public BuildingRTSFormInput(Group[] groupInterface, bool isUnitProducer) : base(groupInterface)
    {
        // base(groupInterface) is called from the constructor declaration
        this.isUnitProducer = isUnitProducer;
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        this.buildOnPathGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().BUILD_ON_PATH, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.spotTakenGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().SPOT_TAKEN, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.selectBuildSpotGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().SELECT_BUILD_SPOT, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.roadCollisionGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().ROAD_COLLISION, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.noMoneyGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NO_MONEY, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.buildingCollisionGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().BUILDING_COLLISION, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.structureToCloseCollisionGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().STRUCTURE_TO_CLOSE, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.buildingGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().BUILDING, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.mapEdgeGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().MAP_EDGE, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.buildOnPathGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.spotTakenGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.selectBuildSpotGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.roadCollisionGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.noMoneyGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.buildingCollisionGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.structureToCloseCollisionGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.buildingGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.mapEdgeGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
    }

    // throws Exception
    public override void processGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int itemIndex)
    {
        base.process(layerManager);
        this.buildFromMotionInput(rtsPlayerLayerInterface, layerManager, item, itemIndex);
    }

    public virtual bool isPositionBlocked()
    {
        return this.dropCellPositionHistory.isCellPositionWithDrop(this.getSelectedGeographicCellPosition());
    }

    private bool isDemoLocked(ABCustomItem item)
    {
        LayerInterfaceFactoryImageItem factoryItem = ((LayerInterfaceFactoryImageItem) item);
        DemoLockedWithCostLayerInterfaceFactoryInterface layerInterfaceFactoryInterface = ((DemoLockedWithCostLayerInterfaceFactoryInterface) factoryItem.getLayerInterfaceFactoryInterface());
        if (LockedUtil.getInstance().isLocked() && layerInterfaceFactoryInterface.isDemoLocked()) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual void buildFromMotionInput(RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int itemIndex)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(commonStrings.START, this, "buildFromMotionInput");
        if (layerManager == null) {
            throw new SystemException();
        }
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) layerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        if (this.isDemoLocked(item)) {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            LockedFeatureNotificationUtil.getInstance().fireWithColor(geographicMapInterface.getForegroundBasicColor());
            return;
        }
        GeographicMapCellPosition geographicMapCellPosition = this.getSelectedGeographicCellPosition();
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            if (!this.isPositionBlocked()) {
                GeographicMapCellType geographicMapCellType = geographicMapInterface.getCellTypeAt(geographicMapCellPosition);
                RaceTrackGeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = ((RaceTrackGeographicMapCellTypeFactory) geographicMapInterface.getGeographicMapCellTypeFactory());
                if (!raceTrackGeographicMapCellTypeFactory.isPath(geographicMapCellType)) {
                    if (this.newUnconstructedRTSLayerInterfaceArray[itemIndex] == CollidableDestroyableDamageableLayer.getNullInstance()) {
                        this.newUnconstructedRTSLayerInterfaceArray[itemIndex] = this.getInstance(layerManager, item, geographicMapCellPosition);
                    } else {
                        RTSLayer rtsLayer = ((RTSLayer) this.newUnconstructedRTSLayerInterfaceArray[itemIndex]);
                        GPoint cellPoint = geographicMapCellPosition.getPoint();
                        rtsLayer.setPosition(cellPoint.getX(), cellPoint.getY(), cellPoint.getZ());
                        rtsLayer.geographicMapCellPositionAreaBase.update(geographicMapInterface);
                    }
                    RTSLayer rtsLayer = ((RTSLayer) this.newUnconstructedRTSLayerInterfaceArray[itemIndex]);
                    this.attemptBuild(rtsPlayerLayerInterface, layerManager, rtsLayer, itemIndex);
                } else {
                    rtsPlayerLayerInterface.add(ErrorSound.getInstance());
                    if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                        GameNotificationEventHandler.getInstance().fireEvent(this.buildOnPathGameNotificationEvent);
                    }
                }
            } else {
                rtsPlayerLayerInterface.add(ErrorSound.getInstance());
                if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                    GameNotificationEventHandler.getInstance().fireEvent(this.spotTakenGameNotificationEvent);
                }
            }
        } else {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.selectBuildSpotGameNotificationEvent);
            }
        }
    }

    // throws Exception
    public virtual bool attemptBuild(RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, RTSLayer layerInterface, int itemIndex)
    {
        this.logUtil.putF(new StringMaker().append("Layer: ").append(StringUtil.getInstance().toString(layerInterface)).ToString(), this, "attemptBuild");
        GeographicMapCellPositionAreaBase geographicMapCellPositionArea = layerInterface.geographicMapCellPositionAreaBase;
        BasicArrayList occupyList = geographicMapCellPositionArea.getOccupyingGeographicMapCellPositionList();
        if (!this.isBuildAttemptValid(rtsPlayerLayerInterface, layerInterface)) {
            return false;
        }
        GeographicMapCellType geographicMapCellType = null;
        for (int index = occupyList.size() - 1; index >= 0; index--) {
            GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) layerManager);
            BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
            geographicMapCellType = geographicMapInterface.getCellTypeAt(((GeographicMapCellPosition) occupyList.get(index)));
            RaceTrackGeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = ((RaceTrackGeographicMapCellTypeFactory) geographicMapInterface.getGeographicMapCellTypeFactory());
            if (raceTrackGeographicMapCellTypeFactory.isPath(geographicMapCellType)) {
                rtsPlayerLayerInterface.add(ErrorSound.getInstance());
                if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                    GameNotificationEventHandler.getInstance().fireEvent(this.roadCollisionGameNotificationEvent);
                }
                return false;
            }
        }
        int cost = layerInterface.getCost();
        Capital capital = rtsPlayerLayerInterface.getCapital();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Trying to Build: ");
        stringBuffer.append(layerInterface.getName());
        stringBuffer.append(" for: $");
        stringBuffer.appendint(cost);
        stringBuffer.append(" with ");
        stringBuffer.appendint(((int) capital.getTotalMoney()));
        this.logUtil.putF(stringBuffer.ToString(), this, "attemptBuild");
        if (cost <= capital.getTotalMoney()) {
            layerInterface.construct(rtsPlayerLayerInterface);
            this.newUnconstructedRTSLayerInterfaceArray[itemIndex] = CollidableDestroyableDamageableLayer.getNullInstance();
            capital.removeMoney(cost);
            this.add(rtsPlayerLayerInterface, layerManager, layerInterface);
            return true;
        } else {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.noMoneyGameNotificationEvent);
            }
            return false;
        }
    }

    // throws Exception
    public virtual bool isBuildAttemptValid(RTSPlayerLayerInterface rtsPlayerLayerInterface, RTSLayer layerInterface)
    {
        GeographicMapCellPositionAreaBase geographicMapCellPositionArea = layerInterface.geographicMapCellPositionAreaBase;
        BasicArrayList occupyList = geographicMapCellPositionArea.getOccupyingGeographicMapCellPositionList();
        if (this.dropCellPositionHistory.anyCellPositionWithDrop(occupyList)) {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.buildingCollisionGameNotificationEvent);
            }
            return false;
        }
        if (this.isUnitProducer && this.dropCellPositionHistory.anyCellPositionWithDrop(geographicMapCellPositionArea.getSurroundingGeographicMapCellPositionList())) {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.structureToCloseCollisionGameNotificationEvent);
            }
            return false;
        } else {
            if (this.isSurroundingCellsOffMap(layerInterface)) {
                rtsPlayerLayerInterface.add(ErrorSound.getInstance());
                if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                    GameNotificationEventHandler.getInstance().fireEvent(this.mapEdgeGameNotificationEvent);
                }
                return false;
            }
        }
        return true;
    }

    // throws Exception
    public virtual void add(RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, RTSLayer layerInterface)
    {
        GeographicMapCellPositionAreaBase geographicMapCellPositionArea = layerInterface.geographicMapCellPositionAreaBase;
        BasicArrayList occupyList = geographicMapCellPositionArea.getOccupyingGeographicMapCellPositionList();
        this.dropCellPositionHistory.addAll(occupyList, layerInterface);
        RTSPlayerGameInput rtsPlayerGameInput = ((RTSPlayerGameInput) rtsPlayerLayerInterface.getPlayerGameInput());
        rtsPlayerGameInput.setSelectedRTSLayer(layerInterface, this.getSelectedGeographicCellPosition());
        layerManager.append(layerInterface);
        rtsPlayerLayerInterface.add(BuildingSound.getInstance());
        if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
            GameNotificationEventHandler.getInstance().fireEvent(this.buildingGameNotificationEvent);
        }
    }

    private bool isSurroundingCellsOffMap(RTSLayer layerInterface)
    {
        GeographicMapCellPositionAreaBase geographicMapCellPositionArea = layerInterface.geographicMapCellPositionAreaBase;
        BasicArrayList occupyList = geographicMapCellPositionArea.getOccupyingGeographicMapCellPositionList();
        BasicArrayList surroundList = geographicMapCellPositionArea.getSurroundingGeographicMapCellPositionList();
        int occupySize = occupyList.size();
        int surroundSize = surroundList.size();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("occupySize: ");
        stringBuffer.appendint(occupySize);
        stringBuffer.append(" surroundSize: ");
        stringBuffer.appendint(surroundSize);
        stringBuffer.append(" surroundList: ");
        stringBuffer.append(StringUtil.getInstance().toString(surroundList));
        this.logUtil.putF(stringBuffer.ToString(), this, "isSurroundingCellsOffMap");
        bool isSurroundOffMap = false;
        if (occupySize == 1 && surroundSize != 8) {
            isSurroundOffMap = true;
        } else if (occupySize == 4 && surroundSize != 12) {
            isSurroundOffMap = true;
        }
        if (occupySize == 0 || isSurroundOffMap) {
            return true;
        } else {
            return false;
        }
    }

}

