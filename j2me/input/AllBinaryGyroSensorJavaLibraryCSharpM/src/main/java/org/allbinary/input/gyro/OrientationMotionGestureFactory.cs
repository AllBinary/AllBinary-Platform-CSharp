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
using InputFactory = org.allbinary.game.input.InputFactory;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.input.gyro;

public class OrientationMotionGestureFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static OrientationMotionGestureFactory getInstance()
    {
        if (OrientationMotionGestureFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            OrientationMotionGestureFactory.instance = new OrientationMotionGestureFactory();
        }
        return ((OrientationMotionGestureFactory) OrientationMotionGestureFactory.instance);
    }

    public readonly MotionGestureInput LEFT;
    public readonly MotionGestureInput RIGHT;
    public readonly MotionGestureInput UP;
    public readonly MotionGestureInput DOWN;
    public readonly MotionGestureInput ROLL_LEFT;
    public readonly MotionGestureInput ROLL_RIGHT;
    private OrientationMotionGestureFactory()
    {
        int MAX = InputFactory.getInstance().MAX;
        this.LEFT = new MotionGestureInput(MAX - 20, "Left Orient");
        this.RIGHT = new MotionGestureInput(MAX - 21, "Right Orient");
        this.UP = new MotionGestureInput(MAX - 22, "Up Orient");
        this.DOWN = new MotionGestureInput(MAX - 23, "Down Orient");
        this.ROLL_LEFT = new MotionGestureInput(MAX - 24, "Roll Left");
        this.ROLL_RIGHT = new MotionGestureInput(MAX - 25, "Roll Right");
    }

}

