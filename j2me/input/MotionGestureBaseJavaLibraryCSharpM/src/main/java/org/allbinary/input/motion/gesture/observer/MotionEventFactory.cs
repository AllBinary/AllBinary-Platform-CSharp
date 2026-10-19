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
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using AllBinaryEventObjectFactoryInterface = org.allbinary.logic.util.@event.AllBinaryEventObjectFactoryInterface;

namespace org.allbinary.input.motion.gesture.observer;

public class MotionEventFactory : AllBinaryEventObjectFactoryInterface
{
    private static int index = 0;
    private readonly object source;
    private readonly int id;
    public MotionEventFactory(object source, int id)
    {
        this.source = source;
        this.id = id;
        MotionEventFactory.index = TouchMotionGestureFactory.getInstance().LAST_MOTION.getId();
    }

    public virtual AllBinaryEventObject getInstance()
    {
        InputFactory inputFactory = InputFactory.getInstance();
        Input input = inputFactory.getInstanceById(MotionEventFactory.index++);
        if (input == inputFactory.NO_INPUT) {
            return new MotionGestureEvent(this.source, this.id, ((MotionGestureInput) TouchMotionGestureFactory.getInstance().NO_MOTION));
        } else {
            return new MotionGestureEvent(this.source, this.id, ((MotionGestureInput) input));
        }
    }

}

