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
using InputFactory = org.allbinary.game.input.InputFactory;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using AllBinaryEventCircularPool = org.allbinary.logic.util.@event.AllBinaryEventCircularPool;

namespace org.allbinary.input.motion.gesture.observer;

public class MotionEventCircularPool
{
    public static MotionEventCircularPool createPool(int id)
    {
        return new MotionEventCircularPool(id);
    }

    private readonly int MIN = TouchMotionGestureFactory.getInstance().LAST_MOTION.getId();
    private AllBinaryEventCircularPool eventPool;
    private MotionEventCircularPool(int id)
    {
        this.eventPool = new AllBinaryEventCircularPool((InputFactory.getInstance().MAX - 1) - this.MIN);
        this.eventPool.initAllBinaryEventCircularPool(new MotionEventFactory(this.eventPool, id));
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual MotionGestureEvent getInstance(MotionGestureInput motionGestureInput)
    {
        return ((MotionGestureEvent) this.eventPool.getInstance(motionGestureInput.getId() - this.MIN));
    }

}

