/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using AdvancedPlayerOwnedRTSLayers = org.allbinary.game.layer.AdvancedPlayerOwnedRTSLayers;
using AdvancedRTSPlayerLayerInterface = org.allbinary.game.layer.AdvancedRTSPlayerLayerInterface;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSLayerEvent = org.allbinary.game.layer.RTSLayerEvent;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using BuildingEventHandler = org.allbinary.game.layer.building.@event.BuildingEventHandler;
using LocalPlayerBuildingEventHandler = org.allbinary.game.layer.building.@event.LocalPlayerBuildingEventHandler;
using WaypointCellPositionHistory = org.allbinary.game.layer.waypoint.WaypointCellPositionHistory;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Group = org.allbinary.game.identification.Group;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using NullPathFindingLayer = org.allbinary.game.layer.NullPathFindingLayer;
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;

namespace org.allbinary.game.input.form;

public class BuildingAdvancedRTSFormInput : BuildingRTSFormInput
{
    public readonly GameNotificationEvent atLeastOneHouseGameNotificationEvent;
    public BuildingAdvancedRTSFormInput(Group[] groupInterface, bool isUnitProducer) : base(groupInterface, isUnitProducer)
    {
        // base(groupInterface, isUnitProducer) is called from the constructor declaration
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        this.atLeastOneHouseGameNotificationEvent = new GameNotificationEvent(this, "Build At Least One House First", SmallIntegerSingletonFactory.getInstance().getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.atLeastOneHouseGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
    }

    public override bool isPositionBlocked()
    {
        if (DropCellPositionHistory.getInstance().isCellPositionWithDrop(this.getSelectedGeographicCellPosition()) || WaypointCellPositionHistory.getInstance().isCellPositionWithDrop(this.getSelectedGeographicCellPosition())) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public override bool isBuildAttemptValid(RTSPlayerLayerInterface rtsPlayerLayerInterface, RTSLayer layerInterface)
    {
        AdvancedRTSPlayerLayerInterface advancedRTSPlayerLayerInterface = ((AdvancedRTSPlayerLayerInterface) rtsPlayerLayerInterface);
        AdvancedPlayerOwnedRTSLayers advancedPlayerOwnedRTSLayers = advancedRTSPlayerLayerInterface.getAdvancedPlayerOwnedRTSLayers();
        int totalHouses = advancedPlayerOwnedRTSLayers.getHouseList().size();
        if (totalHouses < 1 && layerInterface.getName().IndexOf(" House") < 0) {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.atLeastOneHouseGameNotificationEvent);
            }
            return false;
        }
        return base.isBuildAttemptValid(rtsPlayerLayerInterface, layerInterface);
    }

    private readonly RTSLayerEvent BUILD_BUILDING_RTS_LAYER_EVENT = new RTSLayerEvent(NullPathFindingLayer.NULL_PATH_FINDING_LAYER);
    // throws Exception
    public override void add(RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, RTSLayer layerInterface)
    {
        this.BUILD_BUILDING_RTS_LAYER_EVENT.setRtsLayer(layerInterface);
        BuildingEventHandler.getInstance().fireEvent(this.BUILD_BUILDING_RTS_LAYER_EVENT);
        if ((((AdvancedRTSPlayerLayerInterface) rtsPlayerLayerInterface)).isLocalPlayer()) {
            LocalPlayerBuildingEventHandler.getInstance().fireEvent(this.BUILD_BUILDING_RTS_LAYER_EVENT);
        }
        base.add(rtsPlayerLayerInterface, layerManager, layerInterface);
    }

}

