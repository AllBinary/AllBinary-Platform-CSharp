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
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.displayable.canvas;

public class NoMenuInputProcessor : BasicMenuInputProcessor
{
    private static readonly NoMenuInputProcessor SINGLETON = new NoMenuInputProcessor();
    public static NoMenuInputProcessor getInstance()
    {
        return NoMenuInputProcessor.SINGLETON;
    }

    private NoMenuInputProcessor() : base(BasicArrayListUtil.getInstance().getImmutableInstance(), -1, NullCanvas.NULL_CANVAS)
    {
        // base(BasicArrayListUtil.getInstance().getImmutableInstance(), -1, NullCanvas.NULL_CANVAS) is called from the constructor declaration
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onDownGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onUpGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
    }

    public override void onMotionGestureEvent(MotionGestureEvent motionGestureEvent)
    {
    }

}

