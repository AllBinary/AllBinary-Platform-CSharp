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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using RTSPlayerGameInput = org.allbinary.game.input.RTSPlayerGameInput;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using AdvancedRTSPlayerLayerInterface = org.allbinary.game.layer.AdvancedRTSPlayerLayerInterface;
using RTSGameStrings = org.allbinary.game.layer.RTSGameStrings;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using RTSLayerUtil = org.allbinary.game.layer.RTSLayerUtil;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using Capital = org.allbinary.game.layer.capital.Capital;
using WaypointCellPositionHistory = org.allbinary.game.layer.waypoint.WaypointCellPositionHistory;
using WaypointLayer = org.allbinary.game.layer.waypoint.WaypointLayer;
using WaypointEventHandlerFactory = org.allbinary.game.layer.waypoint.@event.WaypointEventHandlerFactory;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Group = org.allbinary.game.identification.Group;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using GeographicMapCellPositionAreaBase = org.allbinary.game.layer.GeographicMapCellPositionAreaBase;
using NullPathFindingLayer = org.allbinary.game.layer.NullPathFindingLayer;
using NullRTSLayer = org.allbinary.game.layer.NullRTSLayer;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using GPoint = org.allbinary.graphics.GPoint;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using Layer = org.allbinary.layer.Layer;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;
using RaceTrackGeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellTypeFactory;

namespace org.allbinary.game.input.form;

public class WaypointRTSFormInput : RTSFormInput
{
    private readonly RTSLayerEvent WAYPOINT_EVENT = new RTSLayerEvent(NullRTSLayer.NULL_RTS_LAYER);
    public readonly GameNotificationEvent dragToSpotGameNotificationEvent;
    public readonly GameNotificationEvent spotTakenGameNotificationEvent;
    public readonly GameNotificationEvent buildingCollisionGameNotificationEvent;
    public readonly GameNotificationEvent roadCollisionGameNotificationEvent;
    public readonly GameNotificationEvent newWaypointGameNotificationEvent;
    public readonly GameNotificationEvent noMoneyGameNotificationEvent;
    private bool isPrimaryWaypointCreator;
    private PathFindingLayerInterface stickyAssociatedRtsLayer = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    public WaypointRTSFormInput(Group[] groupInterface, bool isPrimaryWaypointCreator) : base(groupInterface)
    {
        // base(groupInterface) is called from the constructor declaration
        this.isPrimaryWaypointCreator = isPrimaryWaypointCreator;
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        this.dragToSpotGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().DRAG_TO_SPOT, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
        this.spotTakenGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().SPOT_TAKEN, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
        this.buildingCollisionGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().BUILDING_COLLISION, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
        this.roadCollisionGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().ROAD_COLLISION, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
        this.newWaypointGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NEW_WAYPOINT, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
        this.noMoneyGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NO_MONEY, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.dragToSpotGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.spotTakenGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.buildingCollisionGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.roadCollisionGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.newWaypointGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.noMoneyGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
    }

    // throws Exception
    public override void processAtPoint(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, GPoint point)
    {
        base.process(layerManager);
        if (this.isStickyItemSelected() || associatedRtsLayer == CollidableDestroyableDamageableLayer.getNullInstance()) {
            if (this.isStickyItemSelected() && associatedRtsLayer == CollidableDestroyableDamageableLayer.getNullInstance()) {
                GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) layerManager);
                BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
                AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
                int x = point.getX() + allBinaryTiledLayer.getXP();
                int y = point.getY() + allBinaryTiledLayer.getYP();
                GeographicMapCellPosition geographicMapCellPosition = geographicMapInterface.getCellPositionAtXY(x, y);
                this.processCellPosition(rtsPlayerLayerInterface, layerManager, geographicMapCellPosition);
            } else {
                if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                    GameNotificationEventHandler.getInstance().fireEvent(this.dragToSpotGameNotificationEvent);
                }
            }
        } else {
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.spotTakenGameNotificationEvent);
            }
        }
    }

    // throws Exception
    private void processCellPosition(RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, GeographicMapCellPosition geographicMapCellPosition)
    {
        int itemIndex = this.getSelectedStickyItemIndex();
        if (this.newUnconstructedRTSLayerInterfaceArray[itemIndex] == CollidableDestroyableDamageableLayer.getNullInstance()) {
            this.newUnconstructedRTSLayerInterfaceArray[itemIndex] = this.getInstance(layerManager, this.getSelectedStickyItem(), geographicMapCellPosition);
        } else {
            GPoint cellPoint = geographicMapCellPosition.getPoint();
            RTSLayer rtsLayer = ((RTSLayer) this.newUnconstructedRTSLayerInterfaceArray[itemIndex]);
            rtsLayer.setPosition(cellPoint.getX(), cellPoint.getY(), rtsLayer.getZP());
            GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) rtsLayer.allBinaryGameLayerManagerP);
            BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
            rtsLayer.geographicMapCellPositionAreaBase.update(geographicMapInterface);
        }
        this.attemptBuild(rtsPlayerLayerInterface, layerManager, ((RTSLayer) this.newUnconstructedRTSLayerInterfaceArray[itemIndex]), itemIndex);
    }

    // throws Exception
    public override void processStickyGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int index)
    {
        this.logUtil.putF("Set Sticking Item: " + item, this, "processSticky");
        this.setSelectedStickyItem(item);
        this.setSelectedStickyItemIndex(index);
        this.setStickyItemSelected(true);
        this.stickyAssociatedRtsLayer = ((RTSLayer) associatedRtsLayer);
        this.getHashtable().put(Layer.ID, associatedRtsLayer);
    }

    // throws Exception
    public virtual bool attemptBuild(RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, RTSLayer layerInterface, int itemIndex)
    {
        this.logUtil.putF("Layer: " + layerInterface, this, "attemptBuild");
        if (layerInterface == null) {
            this.logUtil.put("Layer was null", this, "attemptBuild", new Exception());
            return false;
        }
        GeographicMapCellPositionAreaBase geographicMapCellPositionArea = layerInterface.geographicMapCellPositionAreaBase;
        BasicArrayList list = geographicMapCellPositionArea.getOccupyingGeographicMapCellPositionList();
        if (DropCellPositionHistory.getInstance().anyCellPositionWithDrop(list) || WaypointCellPositionHistory.getInstance().anyCellPositionWithDrop(list)) {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.buildingCollisionGameNotificationEvent);
            }
            return false;
        }
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) layerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        RaceTrackGeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = ((RaceTrackGeographicMapCellTypeFactory) geographicMapInterface.getGeographicMapCellTypeFactory());
        GeographicMapCellType geographicMapCellType = null;
        for (int index = list.size(); --index >= 0; ) {
            geographicMapCellType = geographicMapInterface.getCellTypeAt(((GeographicMapCellPosition) list.get(index)));
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
            WaypointCellPositionHistory.getInstance().addList(list, layerInterface);
            GeographicMapCellPosition geographicMapCellPosition = geographicMapInterface.getCellPositionAtXY(layerInterface.getXP(), layerInterface.getYP());
            WaypointLayer waypointLayer = ((WaypointLayer) layerInterface);
            this.addWayPoint(waypointLayer);
            RTSPlayerGameInput rtsPlayerGameInput = ((RTSPlayerGameInput) rtsPlayerLayerInterface.getPlayerGameInput());
            rtsPlayerGameInput.setSelectedRTSLayer(layerInterface, geographicMapCellPosition);
            AdvancedRTSPlayerLayerInterface advancedRTSPlayerLayerInterface = ((AdvancedRTSPlayerLayerInterface) rtsPlayerLayerInterface);
            advancedRTSPlayerLayerInterface.getAdvancedPlayerOwnedRTSLayers().addWaypoint(layerInterface);
            layerManager.append(layerInterface);
            AdvancedRTSGameLayer waypointAvancedRTSGameLayer = ((AdvancedRTSGameLayer) waypointLayer);
            rtsPlayerLayerInterface.add(waypointAvancedRTSGameLayer.getWaypointBehavior().getWaypoint().getSound());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.newWaypointGameNotificationEvent);
            }
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
    private void addWayPoint(WaypointLayer layerInterface)
    {
        AdvancedRTSGameLayer stickyAssociatedAdvandedRtsLayer = ((AdvancedRTSGameLayer) this.stickyAssociatedRtsLayer);
        BasicArrayList list = stickyAssociatedAdvandedRtsLayer.getWaypointBehavior().getOwnedWaypointList();
        RTSLayerUtil.getInstance().destroyAndClear(list);
        list.add(layerInterface);
        if (this.isPrimaryWaypointCreator) {
            PrimaryWaypointHelper.getInstance().setWaypointLayer(layerInterface);
        }
        this.WAYPOINT_EVENT.setRtsLayer(layerInterface);
        WaypointEventHandlerFactory.getInstance(layerInterface.getGroupInterface()[0]).fireEvent(this.WAYPOINT_EVENT);
    }

}

