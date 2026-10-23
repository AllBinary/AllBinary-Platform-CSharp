/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
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
using GameInputStrings = org.allbinary.game.input.GameInputStrings;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GPoint = org.allbinary.graphics.GPoint;
using Rectangle = org.allbinary.graphics.Rectangle;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using RectangleCollisionUtil = org.allbinary.math.RectangleCollisionUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.displayable.canvas;

public class PopupMenuInputProcessor : BasicMenuInputProcessor
{
    private readonly RectangleCollisionUtil rectangleCollisionUtil = RectangleCollisionUtil.getInstance();
    private readonly int CLICK_DELAY = 120;
    private readonly TimeDelayHelper clickTimeHelper;
    private Rectangle rectangle;
    public PopupMenuInputProcessor(BasicArrayList gameKeyEventList, int playerInputId, MyCanvas gameCanvas, Rectangle rectangle) : base(gameKeyEventList, playerInputId, gameCanvas)
    {
        this.clickTimeHelper = new TimeDelayHelper(this.CLICK_DELAY);
        // base(gameKeyEventList, playerInputId, gameCanvas) is called from the constructor declaration
        this.rectangle = rectangle;
    }

    public virtual void init(Rectangle rectangle)
    {
        this.rectangle = rectangle;
    }

    // throws Exception
    public virtual int processInput(int key)
    {
        if (key == Canvas.KEY_STAR) {
            AllBinaryGameCanvas gameCanvas = ((AllBinaryGameCanvas) this.getCanvas());
            gameCanvas.toggleMenu();
            return 1;
        }
        return 0;
    }

    // throws Exception
    public override int processInputList()
    {
        try {
            int motionInputsIndex = this.processMotionInputs();
            BasicArrayList list = this.getGameKeyEventList();
            int size = list.size();
            int key = 0;
            GameKeyEvent gameKeyEvent = null;
            for (int index = 0; index < size; index++) {
                gameKeyEvent = ((GameKeyEvent) list.objectArray[index]);
                if (gameKeyEvent != null) {
                    key = gameKeyEvent.getKey();
                    if (this.processInput(key) == 1) {
                        break;
                    }
                }
            }
            this.clear();
            if (size > 0 || motionInputsIndex >= 0) {
                return 1;
            } else {
                return -1;
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, GameInputStrings.getInstance().PROCESS_INPUT, e);
            return -1;
        }
    }

    // throws Exception
    public virtual int processMotionInputs()
    {
        int lastIndex = this.motionGestureEventList.size() - 1;
        if (lastIndex >= 0) {
            MotionGestureEvent motionGestureEvent = ((MotionGestureEvent) this.motionGestureEventList.objectArray[lastIndex]);
            this.processMotionInput(motionGestureEvent);
        }
        this.motionGestureEventList.clear();
        return lastIndex;
    }

    // throws Exception
    public virtual void processMotionInput(MotionGestureEvent motionGestureEvent)
    {
        if (motionGestureEvent == null) {
            this.logUtil.putF("Exception: Bug", this, this.gameInputStrings.PROCESS_MOTION_INPUT);
            return;
        }
        TouchMotionGestureFactory touchMotionGestureFactory = TouchMotionGestureFactory.getInstance();
        MotionGestureInput motionGestureInput = motionGestureEvent.getMotionGesture();
        if (motionGestureInput == touchMotionGestureFactory.RELEASED) {
            GPoint point = motionGestureEvent.getCurrentPoint();
            GPoint rectPoint = this.rectangle.getPoint();
            if (this.rectangleCollisionUtil.isInside(rectPoint.getX(), rectPoint.getY(), this.rectangle.getMaxX() + 20, this.rectangle.getMaxY(), point.getX(), point.getY())) {
                if (this.clickTimeHelper.isTimeTNT()) {
                    AllBinaryGameCanvas gameCanvas = ((AllBinaryGameCanvas) this.getCanvas());
                    gameCanvas.toggleMenu();
                }
            }
        }
    }

}

