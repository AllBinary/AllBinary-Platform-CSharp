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
//using Canvas = javax.microedition.lcdui.Canvas;
using RTSGameStrings = org.allbinary.game.layer.RTSGameStrings;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSLayerInfoPaintable = org.allbinary.game.layer.RTSLayerInfoPaintable;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using Capital = org.allbinary.game.layer.capital.Capital;
using DowngradeSound = org.allbinary.media.audio.DowngradeSound;
using UpgradeSound = org.allbinary.media.audio.UpgradeSound;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using Features = org.allbinary.game.configuration.feature.Features;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;

namespace org.allbinary.game.input;

public class SelectedRTSLayersPlayerGameInput : PlayerGameInput
{
    public readonly GameInputProcessor[] inputProcessorArray = new GameInputProcessor[InputFactory.getInstance().MAX];
    private readonly BasicArrayList list;
    public readonly bool isSingleKeyProcessing = Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_REPEAT_PRESS) || Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_PRESS);
    private BasicArrayList selectedRTSLayersList = new BasicArrayListD();
    private BasicArrayList preSelectedRTSLayersList = new BasicArrayListD();
    private BasicArrayList paintSelectedRTSLayersList = BasicArrayListUtil.getInstance().getImmutableInstance();
    private RTSPlayerLayerInterface rtsPlayerLayerInterface;
    private readonly Visitor selectRTSLayerVisitorInterface;
    private readonly GameNotificationEvent upgradeGameNotificationEvent;
    private readonly GameNotificationEvent noMoneyGameNotificationEvent;
    private readonly GameNotificationEvent downgradeGameNotificationEvent;
    public SelectedRTSLayersPlayerGameInput(RTSLayerInfoPaintable towerInfoPaintable, RTSPlayerLayerInterface rtsPlayerLayerInterface, BasicArrayList list, int playerInputId, SelectRTSLayerVisitorFactoryInterface selectRTSLayerVisitorFactoryInterface) : base(list, new BasicArrayListD(), playerInputId)
    {
        // base(list, new BasicArrayListD(), playerInputId) is called from the constructor declaration
        this.initInputProcessors();
        this.rtsPlayerLayerInterface = rtsPlayerLayerInterface;
        this.list = list;
        this.selectRTSLayerVisitorInterface = selectRTSLayerVisitorFactoryInterface.create(this);
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        this.upgradeGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().UPGRADE, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.noMoneyGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NO_MONEY, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        this.downgradeGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().DOWNGRADE, smallIntegerSingletonFactory.getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
    }

    // throws Exception
    public virtual void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.upgradeGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.noMoneyGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
        this.downgradeGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
    }

    public virtual bool isSelected(RTSLayer rtsLayer)
    {
        if (this.selectedRTSLayersList.contains(rtsLayer)) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual void upgrade()
    {
        bool anyChanged = false;
        for (int index = this.selectedRTSLayersList.size() - 1; index >= 0; index--) {
            RTSLayer rtsLayer = ((RTSLayer) this.selectedRTSLayersList.get(index));
            if (rtsLayer.isUpgradeable()) {
                Capital capital = this.rtsPlayerLayerInterface.getCapital();
                int upgradeCost = rtsLayer.getUpgradeCost();
                if (upgradeCost <= capital.getTotalMoney()) {
                    anyChanged = true;
                    this.rtsPlayerLayerInterface.add(UpgradeSound.getInstance());
                    rtsLayer.upgrade();
                    capital.removeMoney(upgradeCost);
                    if (!this.rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                        GameNotificationEventHandler.getInstance().fireEvent(this.upgradeGameNotificationEvent);
                    }
                } else {
                    this.rtsPlayerLayerInterface.add(ErrorSound.getInstance());
                    if (!this.rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                        GameNotificationEventHandler.getInstance().fireEvent(this.noMoneyGameNotificationEvent);
                    }
                }
            }
        }
        if (anyChanged) {
            RTSPlayerGameInput rtsPlayerGameInput = (((RTSPlayerGameInput) this.rtsPlayerLayerInterface.getPlayerGameInput()));
            rtsPlayerGameInput.updatePaintable();
        }
    }

    // throws Exception
    public virtual void downgrade()
    {
        bool anyChanged = false;
        for (int index = this.selectedRTSLayersList.size(); --index >= 0; ) {
            RTSLayer rtsLayer = ((RTSLayer) this.selectedRTSLayersList.get(index));
            if (rtsLayer.isDowngradeable()) {
                anyChanged = true;
                this.rtsPlayerLayerInterface.add(DowngradeSound.getInstance());
                int downgradeCost = rtsLayer.getDowngradeCost();
                rtsLayer.downgrade();
                Capital capital = this.rtsPlayerLayerInterface.getCapital();
                capital.addMoney(downgradeCost);
                if (!this.rtsPlayerLayerInterface.implmentsArtificialIntelligenceCompositeInterface()) {
                    GameNotificationEventHandler.getInstance().fireEvent(this.downgradeGameNotificationEvent);
                }
            }
        }
        if (anyChanged) {
            RTSPlayerGameInput rtsPlayerGameInput = (((RTSPlayerGameInput) this.rtsPlayerLayerInterface.getPlayerGameInput()));
            rtsPlayerGameInput.updatePaintable();
        }
    }

    public virtual void initInputProcessors()
    {
        this.inputProcessorArray[Canvas.KEY_NUM1] = new SelectedRTSLayersPlayerUpgradeGameInputProcessor(this);
        this.inputProcessorArray[Canvas.KEY_NUM3] = new SelectedRTSLayersPlayerDowngradeGameInputProcessor(this);
        GameInputProcessorUtil.init(this.inputProcessorArray);
    }

    // throws Exception
    public virtual void processInputKey(int key)
    {
        if (this.selectedRTSLayersList != null) {
            this.inputProcessorArray[key].processEvent(AllBinaryGameLayerManager.getNullInstance(), GameKeyEvent.NONE);
        }
    }

    // throws Exception
    public virtual void processInput(AllBinaryLayerManager layerManager)
    {
        try {
            int size = this.list.size();
            int key = 0;
            for (int index = 0; index < size; index++) {
                GameKeyEvent gameKeyEvent = ((GameKeyEvent) this.list.get(index));
                key = gameKeyEvent.getKey();
                this.processInputKey(key);
            }
            if (this.isSingleKeyProcessing) {
                this.clear();
            } else {
                this.update();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.PROCESS_INPUT, e);
        }
    }

    public virtual BasicArrayList getSelectedBasicArrayList()
    {
        return this.selectedRTSLayersList;
    }

    public virtual void addSelectedRTSLayer(RTSLayer selectedLayer)
    {
        this.paintSelectedRTSLayersList = BasicArrayListUtil.getInstance().getImmutableInstance();
        if (selectedLayer == CollidableDestroyableDamageableLayer.getNullInstance()) {
            this.deselectAll();
            this.selectedRTSLayersList.clear();
        } else {
            if (!this.selectedRTSLayersList.contains(selectedLayer)) {
                this.selectedRTSLayersList.add(selectedLayer);
            }
        }
        this.paintSelectedRTSLayersList = this.selectedRTSLayersList;
    }

    public virtual void setSelectedRTSLayer(CollidableDestroyableDamageableLayer selectedLayer)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Selected Layer: ");
        if (selectedLayer != null) {
            stringBuffer.append(selectedLayer.getName());
        }
        this.logUtil.putF(stringBuffer.ToString(), this, "setSelectedRTSLayer");
        this.paintSelectedRTSLayersList = BasicArrayListUtil.getInstance().getImmutableInstance();
        this.selectRTSLayerVisitorInterface.visit(selectedLayer);
        this.deselectAll();
        if (this.selectedRTSLayersList.size() > 0) {
            this.getPreSelectedRTSLayersList().clear();
            BasicArrayList tempList = this.getPreSelectedRTSLayersList();
            this.preSelectedRTSLayersList = this.selectedRTSLayersList;
            this.selectedRTSLayersList = tempList;
            this.logUtil.putF(new StringMaker().append("Preselected: ").append(this.preSelectedRTSLayersList.ToString()).ToString(), this, "setSelectedRTSLayer");
        }
        if (selectedLayer != CollidableDestroyableDamageableLayer.getNullInstance()) {
            this.selectedRTSLayersList.add(selectedLayer);
        }
        this.paintSelectedRTSLayersList = this.selectedRTSLayersList;
    }

    public virtual CollidableDestroyableDamageableLayer getLastSelectedRtsLayer()
    {
        if (this.isAnyRTSLayerSelected()) {
            return ((CollidableDestroyableDamageableLayer) this.selectedRTSLayersList.get(this.selectedRTSLayersList.size() - 1));
        } else {
            return CollidableDestroyableDamageableLayer.getNullInstance();
        }
    }

    public virtual void selectAllPreselected()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Select all Preselected: ");
        stringBuffer.append(this.preSelectedRTSLayersList.ToString());
        this.logUtil.putF(stringBuffer.ToString(), this, "selectAllPreselected");
        for (int index = this.preSelectedRTSLayersList.size() - 1; index >= 0; index--) {
            RTSLayer rtsLayer = ((RTSLayer) this.preSelectedRTSLayersList.get(index));
            rtsLayer.select();
        }
    }

    public virtual void deselectAllPreselected()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Deselect all Preselected: ");
        stringBuffer.append(this.preSelectedRTSLayersList.ToString());
        this.logUtil.putF(stringBuffer.ToString(), this, "deselectAllPreselected");
        for (int index = this.preSelectedRTSLayersList.size() - 1; index >= 0; index--) {
            RTSLayer rtsLayer = ((RTSLayer) this.preSelectedRTSLayersList.get(index));
            rtsLayer.deselect();
        }
        this.preSelectedRTSLayersList.clear();
    }

    public virtual void deselectAll()
    {
        for (int index = this.selectedRTSLayersList.size() - 1; index >= 0; index--) {
            RTSLayer rtsLayer = ((RTSLayer) this.selectedRTSLayersList.get(index));
            rtsLayer.deselect();
        }
    }

    public virtual bool isAnyRTSLayerSelected()
    {
        if (this.selectedRTSLayersList.size() == 0) {
            return false;
        }
        return true;
    }

    public virtual BasicArrayList getPaintSelectedRTSLayersList()
    {
        return this.paintSelectedRTSLayersList;
    }

    public virtual BasicArrayList getPreSelectedRTSLayersList()
    {
        return this.preSelectedRTSLayersList;
    }

}

