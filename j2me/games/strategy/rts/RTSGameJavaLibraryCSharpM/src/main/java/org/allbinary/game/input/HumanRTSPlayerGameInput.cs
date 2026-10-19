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
using MultiSelectPaintable = org.allbinary.game.layer.MultiSelectPaintable;
using RTSGameStrings = org.allbinary.game.layer.RTSGameStrings;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSLayerInfoPaintable = org.allbinary.game.layer.RTSLayerInfoPaintable;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using GameStateFactory = org.allbinary.game.state.GameStateFactory;
using EndLevelNoBuildingSelectedTouchButtonsBuilder = org.allbinary.input.motion.button.EndLevelNoBuildingSelectedTouchButtonsBuilder;
using EndLevelTouchButtonsBuilder = org.allbinary.input.motion.button.EndLevelTouchButtonsBuilder;
using NoBuildingSelectedTouchButtonsBuilder = org.allbinary.input.motion.button.NoBuildingSelectedTouchButtonsBuilder;
using RTSTouchButtonsBuilder = org.allbinary.input.motion.button.RTSTouchButtonsBuilder;
using SelectBuildingSound = org.allbinary.media.audio.SelectBuildingSound;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using NullInitUpdatePaintable = org.allbinary.graphics.paint.NullInitUpdatePaintable;
using TouchButtonsBuilderFactory = org.allbinary.input.motion.button.TouchButtonsBuilderFactory;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using BaseMotionGestureEventListener = org.allbinary.input.motion.gesture.observer.BaseMotionGestureEventListener;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using CommonLabels = org.allbinary.@string.CommonLabels;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using RectangleCollisionUtil = org.allbinary.math.RectangleCollisionUtil;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.input;

public class HumanRTSPlayerGameInput : RTSPlayerGameInput, BaseMotionGestureEventListener
{
    private bool isDragging = false;
    public readonly GameStateFactory gameStateFactory = GameStateFactory.getInstance();
    private readonly RectangleCollisionUtil rectangleCollisionUtil = RectangleCollisionUtil.getInstance();
    private readonly TouchMotionGestureFactory touchMotionGestureFactory = TouchMotionGestureFactory.getInstance();
    private readonly MotionGestureInput PRESSED;
    private readonly MotionGestureInput RELEASED;
    private readonly TouchButtonsBuilderFactory touchButtonsBuilderFactory;
    private readonly GameNotificationEvent notYoursGameNotificationEvent;
    private CollidableDestroyableDamageableLayer selectedRtsLayer = CollidableDestroyableDamageableLayer.getNullInstance();
    public HumanRTSPlayerGameInput(AllBinaryGameCanvas gameCanvas, BasicArrayList inputList, int playerInputId, RTSLayerInfoPaintable towerInfoPaintable, RTSPlayerLayerInterface rtsPlayerLayerInterface, LayerPositionFinderInterface layerPositionFinderInterface, SelectRTSLayerVisitorFactoryInterface selectRTSLayerVisitorFactoryInterface, TouchButtonsBuilderFactory touchButtonsBuilderFactory) : base(gameCanvas, inputList, playerInputId, towerInfoPaintable, rtsPlayerLayerInterface, layerPositionFinderInterface, selectRTSLayerVisitorFactoryInterface)
    {
        this.PRESSED = this.touchMotionGestureFactory.PRESSED;
        this.RELEASED = this.touchMotionGestureFactory.RELEASED;
        // base(gameCanvas, inputList, playerInputId, towerInfoPaintable, rtsPlayerLayerInterface, layerPositionFinderInterface, selectRTSLayerVisitorFactoryInterface) is called from the constructor declaration
        this.touchButtonsBuilderFactory = touchButtonsBuilderFactory;
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        this.notYoursGameNotificationEvent = new GameNotificationEvent(this, RTSGameStrings.getInstance().NOT_YOURS, SmallIntegerSingletonFactory.getInstance().getAt(2), basicColorFactory.PINK, BooleanFactory.getInstance().FALSE);
        BasicMotionGesturesHandler.getInstance().addListenerInterface(this);
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        this.notYoursGameNotificationEvent.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
    }

    // throws Exception
    private bool processDraggingMotionInput(AllBinaryLayerManager layerManager)
    {
        MotionGestureEvent motionGestureEvent = ((MotionGestureEvent) this.getMotionGestureInputList().get(this.getMotionGestureInputList().size() - 1));
        MotionGestureInput motionGestureInput = motionGestureEvent.getMotionGesture();
        RTSFormInput rtsFormInput = this.getSelectedRtsFormInput();
        if (motionGestureInput == this.PRESSED) {
            GPoint point = motionGestureEvent.getCurrentPoint();
            if (this.getRtsPlayerLayerInterface().getCurrentScrollSelectionForm().isInForm(point)) {
                this.isDragging = rtsFormInput.processSticky(this.getSelectedRtsLayer(), this.getRtsPlayerLayerInterface(), layerManager, point);
            }
        } else if (motionGestureInput == this.RELEASED) {
            GPoint point = motionGestureEvent.getCurrentPoint();
            if (this.getRtsPlayerLayerInterface().getCurrentScrollSelectionForm().isInForm(point)) {
                rtsFormInput.processAtPoint(this.getSelectedRtsLayer(), this.getRtsPlayerLayerInterface(), layerManager, point);
            } else if (rtsFormInput.isStickyItemSelected()) {
                RTSFormInput previousRtsFormInput = rtsFormInput;
                this.select(motionGestureEvent);
                this.getSelectedBuildingPlayerGameInput().selectAllPreselected();
                previousRtsFormInput.processAtPoint(this.getSelectedRtsLayer(), this.getRtsPlayerLayerInterface(), layerManager, point);
                this.getSelectedBuildingPlayerGameInput().deselectAllPreselected();
            } else {
                this.select(motionGestureEvent);
            }
            rtsFormInput.setStickyItemSelected(false);
            rtsFormInput.setSelectedStickyItem(ABCustomItem.getNullInstance());
            rtsFormInput.setSelectedStickyItemIndex(-1);
            return true;
        }
        return false;
    }

    private GPoint startPoint = PointFactory.getInstance().ZERO_ZERO;
    private GPoint endPoint = PointFactory.getInstance().ZERO_ZERO;
    public readonly string POSSIBLE = "Possible: ";
    public readonly string AT = "At: ";
    public readonly string METHOD = "makeSelection";
    public readonly string ADDING = "Adding: ";
    public readonly string SPACE = CommonSeps.getInstance().SPACE;
    private void makeSelection()
    {
        BasicArrayList rtsLayerList = this.getRtsPlayerLayerInterface().getPlayerOwnedRTSLayers().rtsLayerList;
        int rectX1 = this.startPoint.getX();
        int rectY1 = this.startPoint.getY();
        int rectX2 = this.endPoint.getX();
        int rectY2 = this.endPoint.getY();
        if (rectX1 > rectX2) {
            rectX2 = rectX1;
            rectX1 = this.endPoint.getX();
        }
        if (rectY1 > rectY2) {
            rectY2 = rectY1;
            rectY1 = this.endPoint.getY();
        }
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.AT);
        stringBuffer.appendint(rectX1);
        stringBuffer.append(this.SPACE);
        stringBuffer.appendint(rectY1);
        stringBuffer.append(this.SPACE);
        stringBuffer.appendint(rectX2);
        stringBuffer.append(this.SPACE);
        stringBuffer.appendint(rectY2);
        this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD);
        RTSLayer rtsLayer = null;
        for (int index = rtsLayerList.size() - 1; index >= 0; index--) {
            rtsLayer = ((RTSLayer) rtsLayerList.get(index));
            stringBuffer.delete(0, stringBuffer.length());
            ViewPositionBase viewPosition = rtsLayer.getViewPosition();
            stringBuffer.append(this.POSSIBLE);
            stringBuffer.append(rtsLayer.getName());
            stringBuffer.append(this.SPACE);
            stringBuffer.append(this.AT);
            stringBuffer.appendint(((int) (viewPosition.getX() + rtsLayer.getHalfWidth())));
            stringBuffer.append(this.SPACE);
            stringBuffer.appendint(((int) (viewPosition.getY() + rtsLayer.getHalfHeight())));
            this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD);
            if (this.rectangleCollisionUtil.isInside(rectX1, rectY1, rectX2, rectY2, viewPosition.getX() + rtsLayer.getHalfWidth(), viewPosition.getY() + rtsLayer.getHalfHeight())) {
                this.logUtil.putF(new StringMaker().append(this.ADDING).append(rtsLayer.getName()).ToString(), this, this.METHOD);
                rtsLayer.select();
                this.getSelectedBuildingPlayerGameInput().addSelectedRTSLayer(rtsLayer);
            }
        }
        CollidableDestroyableDamageableLayer gameLayer = this.getSelectedBuildingPlayerGameInput().getLastSelectedRtsLayer();
        if (gameLayer != CollidableDestroyableDamageableLayer.getNullInstance()) {
            RTSLayer lastRTSLayer = ((RTSLayer) gameLayer);
            if (lastRTSLayer.getScrollSelectionForm() != ScrollSelectionForm.getNullScrollSelectionForm()) {
                this.updateForm(lastRTSLayer.getScrollSelectionForm(), lastRTSLayer.getRTSFormInput());
                this.setSelectedRtsLayer(lastRTSLayer);
            }
        }
        this.updatePaintable();
    }

    // throws Exception
    private void processSelectionBoxMotionInput(AllBinaryLayerManager layerManager)
    {
        for (int index = this.getMotionGestureInputList().size() - 1; index >= 0; index--) {
            MotionGestureEvent motionGestureEvent = ((MotionGestureEvent) this.getMotionGestureInputList().get(index));
            MotionGestureInput motionGestureInput = motionGestureEvent.getMotionGesture();
            GPoint point = motionGestureEvent.getCurrentPoint();
            if (motionGestureInput == this.touchMotionGestureFactory.PRESSED) {
                this.startPoint = point;
                this.endPoint = point;
            } else if (motionGestureInput == this.touchMotionGestureFactory.RELEASED) {
                this.endPoint = point;
                this.makeSelection();
                this.startPoint = PointFactory.getInstance().ZERO_ZERO;
                this.endPoint = PointFactory.getInstance().ZERO_ZERO;
            } else {
                this.endPoint = point;
            }
        }
    }

    // throws Exception
    public override void processMotionInput(AllBinaryLayerManager layerManager)
    {
        if (this.getMotionGestureInputList().size() > 0) {
            bool endDrag = this.processDraggingMotionInput(layerManager);
            if (!this.isDragging) {
                this.processSelectionBoxMotionInput(layerManager);
            }
            if (endDrag) {
                this.isDragging = false;
            }
        }
        this.getMotionGestureInputList().clear();
    }

    public override void setSelectedRtsFormInput(RTSFormInput selectedRtsFormInput)
    {
        LogUtil logUtil = LogUtil.getInstance();
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START).append(StringUtil.getInstance().toString(selectedRtsFormInput)).ToString(), this, "setSelectedRtsFormInput");
        base.setSelectedRtsFormInput(selectedRtsFormInput);
        this.setSelectedRtsLayer(CollidableDestroyableDamageableLayer.getNullInstance());
    }

    private void updateFormForLayer(RTSLayer rtsLayer)
    {
        ScrollSelectionForm scrollSelectionForm = rtsLayer.getScrollSelectionForm();
        if (scrollSelectionForm != ScrollSelectionForm.getNullScrollSelectionForm() && this.getRtsPlayerLayerInterface().getGroupInterface()[0] == rtsLayer.getGroupInterface()[0]) {
            this.updateForm(scrollSelectionForm, rtsLayer.getRTSFormInput());
            this.getSelectedBuildingPlayerGameInput().setSelectedRTSLayer(CollidableDestroyableDamageableLayer.getNullInstance());
            this.setSelectedRtsLayer(rtsLayer);
        } else {
            this.getRtsPlayerLayerInterface().setCurrentScrollSelectionForm(this.getRtsPlayerLayerInterface().getBuildingScrollSelectionForm());
            this.setSelectedRtsFormInput(this.getRtsPlayerLayerInterface().getRTSFormInput());
            this.getSelectedBuildingPlayerGameInput().setSelectedRTSLayer(CollidableDestroyableDamageableLayer.getNullInstance());
        }
    }

    private void updateForm(ScrollSelectionForm scrollSelectionForm, RTSFormInput rtfFormInput)
    {
        this.getRtsPlayerLayerInterface().setCurrentScrollSelectionForm(scrollSelectionForm);
        this.setSelectedRtsFormInput(rtfFormInput);
    }

    // throws Exception
    public override void setSelectedRTSLayer(CollidableDestroyableDamageableLayer rtSLayer, GeographicMapCellPosition geographicMapCellPosition)
    {
        if (rtSLayer != CollidableDestroyableDamageableLayer.getNullInstance() && this.getRtsPlayerLayerInterface().getGroupInterface()[0] != rtSLayer.getGroupInterface()[0]) {
            this.getRtsPlayerLayerInterface().add(ErrorSound.getInstance());
            GameNotificationEventHandler.getInstance().fireEvent(this.notYoursGameNotificationEvent);
            return;
        }
        AllBinaryGameCanvas gameCanvas = this.getGameCanvas();
        if (rtSLayer != CollidableDestroyableDamageableLayer.getNullInstance()) {
            this.getRtsPlayerLayerInterface().add(SelectBuildingSound.getInstance());
            RTSLayer rtsLayer = ((RTSLayer) rtSLayer);
            rtsLayer.select();
            this.updateFormForLayer(rtsLayer);
            if (gameCanvas.getGameState() == this.gameStateFactory.PLAYING_GAME_STATE) {
                if (rtsLayer.isSelfUpgradeable()) {
                    gameCanvas.updateCurrentTouchInputFactory(new RTSTouchButtonsBuilder());
                } else {
                    gameCanvas.updateCurrentTouchInputFactory(new NoBuildingSelectedTouchButtonsBuilder());
                }
            } else {
                EndLevelTouchButtonsBuilder endLevelTouchButtonsBuilder = new EndLevelTouchButtonsBuilder();
                if (this.touchButtonsBuilderFactory != null) {
                    endLevelTouchButtonsBuilder.add(this.touchButtonsBuilderFactory.getInstance());
                }
                gameCanvas.updateCurrentTouchInputFactory(endLevelTouchButtonsBuilder);
            }
        } else {
            this.logUtil.putF("Set Player Default Form", this, "setSelectedRTSLayer");
            this.getRtsPlayerLayerInterface().setCurrentScrollSelectionForm(this.getRtsPlayerLayerInterface().getBuildingScrollSelectionForm());
            this.setSelectedRtsFormInput(this.getRtsPlayerLayerInterface().getRTSFormInput());
            this.getSelectedBuildingPlayerGameInput().setSelectedRTSLayer(CollidableDestroyableDamageableLayer.getNullInstance());
            if (gameCanvas.getGameState() == this.gameStateFactory.PLAYING_GAME_STATE) {
                gameCanvas.updateCurrentTouchInputFactory(new NoBuildingSelectedTouchButtonsBuilder());
            } else {
                EndLevelNoBuildingSelectedTouchButtonsBuilder endLevelNoBuildingSelectedTouchButtonsBuilder = new EndLevelNoBuildingSelectedTouchButtonsBuilder();
                if (this.touchButtonsBuilderFactory != null) {
                    endLevelNoBuildingSelectedTouchButtonsBuilder.add(this.touchButtonsBuilderFactory.getInstance());
                }
                gameCanvas.updateCurrentTouchInputFactory(endLevelNoBuildingSelectedTouchButtonsBuilder);
            }
        }
        this.getSelectedRtsFormInput().setSelectedGeographicCellPosition(geographicMapCellPosition);
        this.getSelectedBuildingPlayerGameInput().setSelectedRTSLayer(rtSLayer);
        this.updatePaintable();
    }

    private readonly MultiSelectPaintable multiSelectPaintable = new MultiSelectPaintable();
    public override void updatePaintable()
    {
        BasicArrayList list = this.getSelectedBuildingPlayerGameInput().getSelectedBasicArrayList();
        if (list.size() > 1) {
            GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) this.getGameCanvas());
            BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
            this.multiSelectPaintable.setBasicColorP(geographicMapInterface.getForegroundBasicColor());
            this.multiSelectPaintable.update(list);
            this.getRTSLayerInfoPaintable().updateRTSLayerInfoSelection(this.multiSelectPaintable);
        } else if (list.size() == 1) {
            RTSLayer rtsLayer = ((RTSLayer) list.get(0));
            this.getRTSLayerInfoPaintable().updateRTSLayerInfoSelection(rtsLayer.createHudPaintable());
        } else {
            this.getRTSLayerInfoPaintable().updateRTSLayerInfoInit(NullInitUpdatePaintable.getInstance());
        }
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
        if (this.startPoint != PointFactory.getInstance().ZERO_ZERO && this.endPoint != PointFactory.getInstance().ZERO_ZERO) {
            graphics.setColor(((int) BasicColorFactory.getInstance().RED));
            int rectX1 = this.startPoint.getX();
            int rectY1 = this.startPoint.getY();
            int rectX2 = this.endPoint.getX();
            int rectY2 = this.endPoint.getY();
            if (rectX1 > rectX2) {
                rectX2 = rectX1;
                rectX1 = this.endPoint.getX();
            }
            if (rectY1 > rectY2) {
                rectY2 = rectY1;
                rectY1 = this.endPoint.getY();
            }
            graphics.drawRect(rectX1, rectY1, rectX2 - rectX1, rectY2 - rectY1);
        }
    }

    public override void onMotionGestureEvent(MotionGestureEvent motionGestureEvent)
    {
        this.getMotionGestureInputList().add(motionGestureEvent);
    }

    public override void onScrolledMotionGestureEvent(MotionGestureEvent motionGestureEvent)
    {
    }

    private CollidableDestroyableDamageableLayer getSelectedRtsLayer()
    {
        return this.selectedRtsLayer;
    }

    private void setSelectedRtsLayer(CollidableDestroyableDamageableLayer selectedRtsLayer)
    {
        this.selectedRtsLayer = selectedRtsLayer;
    }

}

