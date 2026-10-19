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
using System.Runtime.CompilerServices;
using DownGameKeyEventHandler = org.allbinary.game.input.@event.DownGameKeyEventHandler;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using UpGameKeyEventHandler = org.allbinary.game.input.@event.UpGameKeyEventHandler;
using GPoint = org.allbinary.graphics.GPoint;
using Rectangle = org.allbinary.graphics.Rectangle;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using RectangleCollisionUtil = org.allbinary.math.RectangleCollisionUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.input.motion.button;

public class TouchButtonRecognizer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly RectangleCollisionUtil rectangleCollisionUtil = RectangleCollisionUtil.getInstance();
    private readonly UpGameKeyEventHandler upGameKeyEventHandler = UpGameKeyEventHandler.getInstance();
    private readonly DownGameKeyEventHandler downGameKeyEventHandler = DownGameKeyEventHandler.getInstance();
    private TouchButtonInput lastPressedTouchButtonInput = BasicTouchInputFactory.getInstance().NONE;
    private readonly CurrentlyPressedTouchButtonSingleton currentlyPressedTouchButtonSingleton = CurrentlyPressedTouchButtonSingleton.getInstance();
    //CurrentlyPressedTouchButtonSingletonDebug.getInstance();
    public class ReleaseHelper
    {
        public readonly TouchButtonRecognizer touchButtonRecognizer;
        public ReleaseHelper(TouchButtonRecognizer touchButtonRecognizer)
        {
            this.touchButtonRecognizer = touchButtonRecognizer;
        }

        // throws Exception
        public virtual void release(TouchButtonInput touchButtonInput, int deviceId)
        {
            TouchButtonInput nextTouchButtonInput = null;
            GameKeyEvent gameKeyEvent = null;
            for (int index = this.touchButtonRecognizer.currentlyPressedTouchButtonSingleton.size() - 1; index >= 0; index--) {
                nextTouchButtonInput = this.touchButtonRecognizer.currentlyPressedTouchButtonSingleton.get(index);
                gameKeyEvent = nextTouchButtonInput.getGameKeyEvent();
                this.touchButtonRecognizer.upGameKeyEventHandler.fireEvent(gameKeyEvent);
                this.touchButtonRecognizer.upGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
                this.touchButtonRecognizer.currentlyPressedTouchButtonSingleton.removeAt(index);
            }
        }

    }
    public class MultitouchReleaseHelper : ReleaseHelper
    {
        public MultitouchReleaseHelper(TouchButtonRecognizer touchButtonRecognizer) : base(touchButtonRecognizer)
        {
            // base(touchButtonRecognizer) is called from the constructor declaration
        }

        // throws Exception
        public override void release(TouchButtonInput touchButtonInput, int deviceId)
        {
            TouchButtonInput cancelTouchButtonInput = CancelTouchButtonInputFactory.getInstance().getCancel(touchButtonInput);
            TouchButtonInput nextTouchButtonInput = null;
            GameKeyEvent gameKeyEvent = null;
            for (int index = this.touchButtonRecognizer.currentlyPressedTouchButtonSingleton.size() - 1; index >= 0; index--) {
                nextTouchButtonInput = this.touchButtonRecognizer.currentlyPressedTouchButtonSingleton.get(index);
                if (cancelTouchButtonInput == nextTouchButtonInput) {
                    gameKeyEvent = nextTouchButtonInput.getGameKeyEvent();
                    this.touchButtonRecognizer.upGameKeyEventHandler.fireEvent(gameKeyEvent);
                    this.touchButtonRecognizer.upGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
                    this.touchButtonRecognizer.currentlyPressedTouchButtonSingleton.removeAt(index);
                }
            }
        }

    }
    private readonly ReleaseHelper releaseHelper = null;
    public TouchButtonRecognizer()
    {
        if (TouchScreenFactory.getInstance().isMultiTouch()) {
            this.releaseHelper = new MultitouchReleaseHelper(this);
        } else {
            this.releaseHelper = new ReleaseHelper(this);
        }
    }

    // throws Exception
    private void processRelease(TouchButtonInput touchButtonInput, int deviceId)
    {
        this.releaseHelper.release(touchButtonInput, deviceId);
        GameKeyEvent gameKeyEvent = touchButtonInput.getGameKeyEvent();
        this.upGameKeyEventHandler.fireEvent(gameKeyEvent);
        this.upGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
        this.currentlyPressedTouchButtonSingleton.remove(touchButtonInput);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool releaseTouchButtonInput(int x, int y, int deviceId)
    {
        TouchButtonInput touchButtonInput = this.lastPressedTouchButtonInput;
        if (this.currentlyPressedTouchButtonSingleton.contains(touchButtonInput)) {
            this.lastPressedTouchButtonInput = BasicTouchInputFactory.getInstance().NONE;
            this.processRelease(touchButtonInput, deviceId);
            return true;
        } else {
            BasicArrayList list = TouchButtonFactory.getInstance().getList();
            Rectangle rectangle = null;
            GPoint point = null;
            TouchButton touchButton = null;
            for (int index = list.size() - 1; index >= 0; index--) {
                touchButton = ((TouchButton) list.objectArray[index]);
                rectangle = touchButton.getRectangle();
                point = rectangle.getPoint();
                if (this.rectangleCollisionUtil.isInside(point.getX(), point.getY(), rectangle.getMaxX(), rectangle.getMaxY(), x, y)) {
                    touchButtonInput = touchButton.getTouchButtonInput();
                    this.processRelease(touchButtonInput, deviceId);
                    return true;
                }
            }
        }
        return false;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool pressTouchButtonInput(int x, int y, int deviceId)
    {
        BasicArrayList list = TouchButtonFactory.getInstance().getList();
        Rectangle rectangle = null;
        GPoint point = null;
        TouchButton touchButton = null;
        TouchButtonInput touchButtonInput = null;
        GameKeyEvent gameKeyEvent = null;
        for (int index = list.size() - 1; index >= 0; index--) {
            touchButton = ((TouchButton) list.objectArray[index]);
            rectangle = touchButton.getRectangle();
            point = rectangle.getPoint();
            if (this.rectangleCollisionUtil.isInside(point.getX(), point.getY(), rectangle.getMaxX(), rectangle.getMaxY(), x, y)) {
                touchButtonInput = touchButton.getTouchButtonInput();
                if (!this.currentlyPressedTouchButtonSingleton.contains(touchButtonInput)) {
                    this.releaseHelper.release(touchButtonInput, deviceId);
                    this.lastPressedTouchButtonInput = touchButtonInput;
                    this.currentlyPressedTouchButtonSingleton.add(touchButtonInput);
                    gameKeyEvent = touchButtonInput.getGameKeyEvent();
                    this.downGameKeyEventHandler.fireEvent(gameKeyEvent);
                    this.downGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
                }
                return true;
            }
        }
        return false;
    }

}

