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
//using Graphics = javax.microedition.lcdui.Graphics;
using RTSFormInput = org.allbinary.game.input.form.RTSFormInput;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSLayerInfoPaintable = org.allbinary.game.layer.RTSLayerInfoPaintable;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Features = org.allbinary.game.configuration.feature.Features;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using NullRTSFormInputFactory = org.allbinary.game.input.form.NullRTSFormInputFactory;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using NullRTSLayer = org.allbinary.game.layer.NullRTSLayer;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using GPoint = org.allbinary.graphics.GPoint;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using SelectSound = org.allbinary.media.audio.SelectSound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.game.input;

public class RTSPlayerGameInput : PlayerGameInput
{
    public readonly GameInputProcessor[] inputProcessorArray = new GameInputProcessor[InputFactory.getInstance().MAX];
    public readonly GameInputProcessor[] removeInputProcessorArray = new GameInputProcessor[InputFactory.getInstance().MAX];
    private readonly BasicArrayList inputList;
    private readonly bool isSingleKeyProcessing = Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_REPEAT_PRESS) || Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_PRESS);
    private readonly AllBinaryGameCanvas gameCanvas;
    private readonly BasicArrayList motionGestureInputList = new BasicArrayListD();
    private readonly ScrollMapPlayerGameInput scrollPlayerGameInput;
    private readonly SelectedRTSLayersPlayerGameInput selectedRTSLayerPlayerGameInput;
    private readonly RTSLayerInfoPaintable towerInfoPaintable;
    private readonly RTSPlayerLayerInterface rtsPlayerLayerInterface;
    private readonly LayerPositionFinderInterface layerPositionFinderInterface;
    private RTSFormInput selectedRtsFormInput = NullRTSFormInputFactory.getInstance();
    public RTSPlayerGameInput(AllBinaryGameCanvas gameCanvas, BasicArrayList inputList, int playerInputId, RTSLayerInfoPaintable towerInfoPaintable, RTSPlayerLayerInterface rtsPlayerLayerInterface, LayerPositionFinderInterface layerPositionFinderInterface, SelectRTSLayerVisitorFactoryInterface selectRTSLayerVisitorFactoryInterface) : base(inputList, new BasicArrayListD(), playerInputId)
    {
        // base(inputList, new BasicArrayListD(), playerInputId) is called from the constructor declaration
        this.initInputProcessors();
        this.gameCanvas = gameCanvas;
        this.inputList = inputList;
        this.towerInfoPaintable = towerInfoPaintable;
        this.rtsPlayerLayerInterface = rtsPlayerLayerInterface;
        this.selectedRTSLayerPlayerGameInput = new SelectedRTSLayersPlayerGameInput(this.getRTSLayerInfoPaintable(), this.getRtsPlayerLayerInterface(), this.inputList, playerInputId, selectRTSLayerVisitorFactoryInterface);
        if (this.rtsPlayerLayerInterface != NullRTSLayer.NULL_RTS_LAYER) {
            this.setSelectedRtsFormInput(this.rtsPlayerLayerInterface.getRTSFormInput());
        }
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.gameCanvas.getLayerManager());
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.scrollPlayerGameInput = new ScrollMapPlayerGameInput(geographicMapInterface, this.inputList, playerInputId);
        this.layerPositionFinderInterface = layerPositionFinderInterface;
    }

    // throws Exception
    public virtual void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        this.selectedRTSLayerPlayerGameInput.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        if (this.selectedRtsFormInput != NullRTSFormInputFactory.getInstance()) {
            this.selectedRtsFormInput.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        }
    }

    public virtual void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "onDisplayChangeEvent");
            this.getRTSLayerInfoPaintable().update();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onDisplayChangeEvent", e);
        }
    }

    // throws Exception
    public virtual void left()
    {
        this.rtsPlayerLayerInterface.getCurrentScrollSelectionForm().processInputKey(Canvas.LEFT);
    }

    // throws Exception
    public virtual void right()
    {
        this.rtsPlayerLayerInterface.getCurrentScrollSelectionForm().processInputKey(Canvas.RIGHT);
    }

    public virtual void initInputProcessors()
    {
        this.inputProcessorArray[Canvas.LEFT] = new RTSPlayerLeftGameInputProcessor(this);
        this.inputProcessorArray[Canvas.KEY_NUM0] = this.inputProcessorArray[Canvas.LEFT];
        this.inputProcessorArray[Canvas.RIGHT] = new RTSPlayerRightGameInputProcessor(this);
        this.inputProcessorArray[Canvas.KEY_POUND] = this.inputProcessorArray[Canvas.RIGHT];
        this.removeInputProcessorArray[Canvas.KEY_NUM1] = new RTSPlayerFireGameInputProcessor(this);
        this.removeInputProcessorArray[Canvas.KEY_NUM3] = this.removeInputProcessorArray[Canvas.KEY_NUM1];
        this.removeInputProcessorArray[Canvas.KEY_NUM3] = this.removeInputProcessorArray[Canvas.KEY_NUM1];
        this.removeInputProcessorArray[Canvas.LEFT] = this.removeInputProcessorArray[Canvas.KEY_NUM1];
        this.removeInputProcessorArray[Canvas.RIGHT] = this.removeInputProcessorArray[Canvas.KEY_NUM1];
        this.removeInputProcessorArray[Canvas.KEY_NUM0] = this.removeInputProcessorArray[Canvas.KEY_NUM1];
        this.removeInputProcessorArray[Canvas.KEY_POUND] = this.removeInputProcessorArray[Canvas.KEY_NUM1];
        GameInputProcessorUtil.init(this.inputProcessorArray);
        GameInputProcessorUtil.init(this.removeInputProcessorArray);
    }

    // throws Exception
    public virtual void processInput(AllBinaryLayerManager layerManager)
    {
        try {
            this.processMotionInput(layerManager);
            int size = this.inputList.size();
            int key = 0;
            for (int index = 0; index < size; index++) {
                GameKeyEvent gameKeyEvent = ((GameKeyEvent) this.inputList.get(index));
                key = gameKeyEvent.getKey();
                this.getScrollPlayerGameInput().processInputKey(key);
                this.getSelectedBuildingPlayerGameInput().processInputKey(key);
                this.inputProcessorArray[key].processEvent(layerManager, gameKeyEvent);
                this.removeInputProcessorArray[key].processEvent(layerManager, gameKeyEvent);
            }
            if (this.isIsSingleKeyProcessing()) {
                this.clear();
            } else {
                this.update();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.PROCESS_INPUT, e);
        }
    }

    // throws Exception
    public virtual void processMotionInput(AllBinaryLayerManager layerManager)
    {
    }

    // throws Exception
    public virtual void select(MotionGestureEvent motionGestureEvent)
    {
        GPoint point = motionGestureEvent.getCurrentPoint();
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.gameCanvas.getLayerManager());
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        int x = point.getX() + allBinaryTiledLayer.getXP();
        int y = point.getY() + allBinaryTiledLayer.getYP();
        GeographicMapCellPosition geographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(x, y);
        if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            SecondaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
            AllBinaryLayer layer = this.layerPositionFinderInterface.getLayerInterface(geographicMapCellPosition);
            if (layer == AllBinaryLayer.NULL_ALLBINARY_LAYER) {
                layer = CollidableDestroyableDamageableLayer.getNullInstance();
            } else {
                geographicMapCellPosition = geographicMapInterface.getCellPositionAtXY(layer.getXP(), layer.getYP());
            }
            CollidableDestroyableDamageableLayer foundRTSLayer = ((CollidableDestroyableDamageableLayer) layer);
            this.setSelectedRTSLayer(foundRTSLayer, geographicMapCellPosition);
        } else {
            CommonLabels commonLabels = CommonLabels.getInstance();
            this.logUtil.putF(new StringMaker().append("Off Of Map -").append(commonLabels.WIDTH_LABEL).appendint(((int) allBinaryTiledLayer.getWidth())).append(commonLabels.HEIGHT_LABEL).appendint(((int) allBinaryTiledLayer.getHeight())).ToString(), this, "select");
        }
    }

    // throws Exception
    public virtual void setSelectedRTSLayer(CollidableDestroyableDamageableLayer rtsLayer, GeographicMapCellPosition geographicMapCellPosition)
    {
        this.getSelectedBuildingPlayerGameInput().setSelectedRTSLayer(rtsLayer);
    }

    public virtual void paint(Graphics graphics)
    {
        GeographicMapCellPosition geographicMapCellPosition = this.getSelectedRtsFormInput().getSelectedGeographicCellPosition();
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.gameCanvas.getLayerManager());
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        graphics.setColor(((int) BasicColorFactory.getInstance().GREEN));
        BasicArrayList list = this.getSelectedBuildingPlayerGameInput().getPaintSelectedRTSLayersList();
        int width = 0;
        int height = 0;
        if (list.size() > 0) {
            for (int index = list.size() - 1; index >= 0; index--) {
                RTSLayer rtsLayer = ((RTSLayer) list.get(index));
                width = rtsLayer.getWidth();
                height = rtsLayer.getHeight();
                graphics.drawRect(rtsLayer.getXP() - allBinaryTiledLayer.getXP(), rtsLayer.getYP() - allBinaryTiledLayer.getYP(), width, height);
            }
        } else if (geographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            GPoint point = geographicMapCellPosition.getPoint();
            width = allBinaryTiledLayer.getCellWidth();
            height = allBinaryTiledLayer.getCellHeight();
            graphics.drawRect(point.getX() - allBinaryTiledLayer.getXP(), point.getY() - allBinaryTiledLayer.getYP(), width, height);
        }
    }

    public virtual void updatePaintable()
    {
    }

    public virtual SelectedRTSLayersPlayerGameInput getSelectedBuildingPlayerGameInput()
    {
        return this.selectedRTSLayerPlayerGameInput;
    }

    public virtual RTSFormInput getSelectedRtsFormInput()
    {
        return this.selectedRtsFormInput;
    }

    public virtual void setSelectedRtsFormInput(RTSFormInput selectedRtsFormInput)
    {
        this.logUtil.putF(new StringMaker().append("RTSFormInput: ").append(StringUtil.getInstance().toString(selectedRtsFormInput)).ToString(), this, "setSelectedRtsFormInput");
        this.selectedRtsFormInput = selectedRtsFormInput;
    }

    public virtual RTSPlayerLayerInterface getRtsPlayerLayerInterface()
    {
        return this.rtsPlayerLayerInterface;
    }

    public virtual RTSLayerInfoPaintable getRTSLayerInfoPaintable()
    {
        return this.towerInfoPaintable;
    }

    public virtual BasicArrayList getMotionGestureInputList()
    {
        return this.motionGestureInputList;
    }

    public virtual AllBinaryGameCanvas getGameCanvas()
    {
        return this.gameCanvas;
    }

    public virtual bool isIsSingleKeyProcessing()
    {
        return this.isSingleKeyProcessing;
    }

    public virtual ScrollMapPlayerGameInput getScrollPlayerGameInput()
    {
        return this.scrollPlayerGameInput;
    }

}

