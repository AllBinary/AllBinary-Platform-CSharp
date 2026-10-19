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
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AdvancedPlayerOwnedRTSLayers = org.allbinary.game.layer.AdvancedPlayerOwnedRTSLayers;
using AdvancedRTSGameLayer = org.allbinary.game.layer.AdvancedRTSGameLayer;
using AdvancedRTSPlayerLayerInterface = org.allbinary.game.layer.AdvancedRTSPlayerLayerInterface;
using RTSGameStrings = org.allbinary.game.layer.RTSGameStrings;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using Capital = org.allbinary.game.layer.capital.Capital;
using UnitLayer = org.allbinary.game.layer.unit.UnitLayer;
using WorkWaypoint = org.allbinary.game.layer.waypoint.WorkWaypoint;
using BuildingSound = org.allbinary.media.audio.BuildingSound;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Group = org.allbinary.game.identification.Group;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using GeographicMapCellPositionAreaBase = org.allbinary.game.layer.GeographicMapCellPositionAreaBase;
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
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;

namespace org.allbinary.game.input.form;

public class UnitRTSFormInput : RTSFormInput
{
    public static readonly int? DECAL_ID = SmallIntegerSingletonFactory.getInstance().getAt(23);
    public readonly GameNotificationEvent noMoneyGameNotificationEvent;
    public readonly GameNotificationEvent newUnitGameNotificationEvent;
    public UnitRTSFormInput(Group[] groupInterface) : base(groupInterface)
    {
        // base(groupInterface) is called from the constructor declaration
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        this.noMoneyGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NO_MONEY, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
        this.newUnitGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NEW_UNIT, smallIntegerSingletonFactory.getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
        this.getHashtable().put(WorkWaypoint.ID, smallIntegerSingletonFactory.getAt(50));
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.noMoneyGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.newUnitGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
    }

    // throws Exception
    public override void processGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int itemIndex)
    {
        base.process(layerManager);
        RTSLayer associatedRtsLayer2 = ((RTSLayer) associatedRtsLayer);
        GeographicMapCellPositionAreaBase geographicMapCellPositionArea = associatedRtsLayer2.geographicMapCellPositionAreaBase;
        GeographicMapCellPosition geographicMapCellPosition = geographicMapCellPositionArea.getNextSurroundingGeographicMapCellPosition();
        this.getHashtable().put(Layer.ID, associatedRtsLayer);
        this.getHashtable().put(UnitRTSFormInput.DECAL_ID, (((AdvancedRTSPlayerLayerInterface) rtsPlayerLayerInterface)).getDecalBasicColor());
        if (this.newUnconstructedRTSLayerInterfaceArray[itemIndex] == CollidableDestroyableDamageableLayer.getNullInstance()) {
            this.newUnconstructedRTSLayerInterfaceArray[itemIndex] = this.getInstance(layerManager, item, geographicMapCellPosition);
        } else {
            GPoint cellPoint = geographicMapCellPosition.getPoint();
            RTSLayer rtsLayer = ((RTSLayer) this.newUnconstructedRTSLayerInterfaceArray[itemIndex]);
            rtsLayer.setPosition(cellPoint.getX(), cellPoint.getY(), rtsLayer.getZP());
            GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) rtsLayer.allBinaryGameLayerManagerP);
            BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
            rtsLayer.geographicMapCellPositionAreaBase.update(geographicMapInterface);
        }
        GPoint cellPoint = geographicMapCellPosition.getMidPoint();
        RTSLayer rtsLayer = ((RTSLayer) this.newUnconstructedRTSLayerInterfaceArray[itemIndex]);
        rtsLayer.setPosition(cellPoint.getX() - rtsLayer.getHalfWidth(), cellPoint.getY() - rtsLayer.getHalfHeight(), rtsLayer.getZP());
        this.attemptBuild(associatedRtsLayer2, rtsPlayerLayerInterface, layerManager, ((RTSLayer) rtsLayer), itemIndex);
    }

    // throws Exception
    private void attemptBuild(RTSLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, RTSLayer layerInterface, int itemIndex)
    {
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
            rtsPlayerLayerInterface.add(BuildingSound.getInstance());
            capital.removeMoney(cost);
            AssignWaypointsUtil.getInstance().set(((UnitLayer) layerInterface), ((AdvancedRTSGameLayer) associatedRtsLayer));
            layerManager.appendAt(layerInterface, PlayersSingletonFactory.total);
            AdvancedRTSPlayerLayerInterface advancedRTSPlayerLayerInterface = ((AdvancedRTSPlayerLayerInterface) rtsPlayerLayerInterface);
            AdvancedPlayerOwnedRTSLayers advancedPlayerOwnedRTSLayers = advancedRTSPlayerLayerInterface.getAdvancedPlayerOwnedRTSLayers();
            advancedPlayerOwnedRTSLayers.addUnit(layerInterface);
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.newUnitGameNotificationEvent);
            }
        } else {
            rtsPlayerLayerInterface.add(ErrorSound.getInstance());
            if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                GameNotificationEventHandler.getInstance().fireEvent(this.noMoneyGameNotificationEvent);
            }
        }
    }

}

