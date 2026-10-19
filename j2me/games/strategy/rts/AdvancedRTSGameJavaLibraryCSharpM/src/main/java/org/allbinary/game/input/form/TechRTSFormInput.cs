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
using RTSGameStrings = org.allbinary.game.layer.RTSGameStrings;
using RTSInterface = org.allbinary.game.layer.RTSInterface;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using TechnologyRTSInterfaceImageItem = org.allbinary.game.layer.TechnologyRTSInterfaceImageItem;
using Capital = org.allbinary.game.layer.capital.Capital;
using TechEventHandler = org.allbinary.game.rts.technology.@event.TechEventHandler;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using BuildingSound = org.allbinary.media.audio.BuildingSound;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Group = org.allbinary.game.identification.Group;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;

namespace org.allbinary.game.input.form;

public class TechRTSFormInput : RTSFormInput
{
    private readonly AllBinaryEventObject EVENT;
    public readonly GameNotificationEvent noMoneyGameNotificationEvent;
    public TechRTSFormInput(Group[] groupInterface) : base(groupInterface)
    {
        this.EVENT = new AllBinaryEventObject(this);
        // base(groupInterface) is called from the constructor declaration
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        this.noMoneyGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NO_MONEY, SmallIntegerSingletonFactory.getInstance().getAt(2), basicColorFactory.WHITE, BooleanFactory.getInstance().FALSE);
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.noMoneyGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
    }

    // throws Exception
    public override void processGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int itemIndex)
    {
        base.process(layerManager);
        CommonStrings commonStrings = CommonStrings.getInstance();
        StringMaker stringMaker = new StringMaker();
        TechnologyRTSInterfaceImageItem technologyRTSInterfaceImageItem = ((TechnologyRTSInterfaceImageItem) item);
        RTSInterface rtsInterface = technologyRTSInterfaceImageItem.getRtsInterface();
        this.logUtil.putF(stringMaker.append("isUpgradeable: ").appendboolean(rtsInterface.isUpgradeable()).ToString(), this, commonStrings.PROCESS);
        if (rtsInterface.isUpgradeable()) {
            int cost = rtsInterface.getUpgradeCost();
            Capital capital = rtsPlayerLayerInterface.getCapital();
            stringMaker.delete(0, stringMaker.length());
            this.logUtil.putF(stringMaker.appendint(cost).append("<=").appendint(((int) capital.getTotalMoney())).ToString(), this, commonStrings.PROCESS);
            if (cost <= capital.getTotalMoney()) {
                rtsPlayerLayerInterface.add(BuildingSound.getInstance());
                capital.removeMoney(cost);
                rtsInterface.upgrade();
                technologyRTSInterfaceImageItem.update();
                TechEventHandler.getInstance().fireEvent(this.EVENT);
            } else {
                rtsPlayerLayerInterface.add(ErrorSound.getInstance());
                if (!rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                    GameNotificationEventHandler.getInstance().fireEvent(this.noMoneyGameNotificationEvent);
                }
            }
        }
    }

}

