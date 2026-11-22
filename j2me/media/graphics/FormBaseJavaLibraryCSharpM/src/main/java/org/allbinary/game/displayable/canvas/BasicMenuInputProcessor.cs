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
using Canvas = javax.microedition.lcdui.Canvas;
using NullCanvas = javax.microedition.lcdui.NullCanvas;
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using BaseMotionGestureEventListener = org.allbinary.input.motion.gesture.observer.BaseMotionGestureEventListener;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.displayable.canvas;

public class BasicMenuInputProcessor : PlayerGameInput, BaseMotionGestureEventListener
{
    public readonly BasicArrayList motionGestureEventList = new BasicArrayListD();
    private Canvas canvas = NullCanvas.NULL_CANVAS;
    public BasicMenuInputProcessor(BasicArrayList gameKeyEventList, int playerInputId, Canvas gameCanvas) : base(gameKeyEventList, new BasicArrayListD(), playerInputId)
    {
        // Constructor invocation emitted in the initializer.
        this.canvas = gameCanvas;
    }

    public virtual void onMotionGestureEvent(MotionGestureEvent motionGestureEvent)
    {
        this.motionGestureEventList.add(motionGestureEvent);
    }

    public virtual void onScrolledMotionGestureEvent(MotionGestureEvent motionGestureEvent)
    {
    }

    private void setCanvas(MyCanvas canvas)
    {
        this.canvas = canvas;
    }

    public virtual MyCanvas getCanvas()
    {
        return ((MyCanvas) this.canvas);
    }

    // throws Exception
    public virtual int processInputList()
    {
        return -1;
    }

}

