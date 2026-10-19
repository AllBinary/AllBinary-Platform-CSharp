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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.input.motion.gesture;

public class TrackballMotionGestureFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static TrackballMotionGestureFactory getInstance()
    {
        if (TrackballMotionGestureFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            TrackballMotionGestureFactory.instance = new TrackballMotionGestureFactory();
        }
        return ((TrackballMotionGestureFactory) TrackballMotionGestureFactory.instance);
    }

    public readonly MotionGestureInput LEFT;
    public readonly MotionGestureInput RIGHT;
    public readonly MotionGestureInput UP;
    public readonly MotionGestureInput DOWN;
    private TrackballMotionGestureFactory()
    {
        int MAX = InputFactory.getInstance().MAX;
        this.LEFT = new MotionGestureInput(MAX - 26, "L Trackball");
        this.RIGHT = new MotionGestureInput(MAX - 27, "R Trackball");
        this.UP = new MotionGestureInput(MAX - 28, "Up Trackball");
        this.DOWN = new MotionGestureInput(MAX - 29, "D Trackball");
    }

}

