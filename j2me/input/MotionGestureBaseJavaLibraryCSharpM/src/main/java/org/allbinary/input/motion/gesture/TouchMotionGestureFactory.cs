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

public class TouchMotionGestureFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static TouchMotionGestureFactory getInstance()
    {
        if (TouchMotionGestureFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            TouchMotionGestureFactory.instance = new TouchMotionGestureFactory();
        }
        return ((TouchMotionGestureFactory) TouchMotionGestureFactory.instance);
    }

    public readonly MotionGestureInput LEFT;
    public readonly MotionGestureInput RIGHT;
    public readonly MotionGestureInput UP;
    public readonly MotionGestureInput DOWN;
    public readonly MotionGestureInput PRESSED;
    public readonly MotionGestureInput RELEASED;
    public readonly MotionGestureInput DIAGONAL_DOWN_RIGHT;
    public readonly MotionGestureInput DIAGONAL_DOWN_LEFT;
    public readonly MotionGestureInput DIAGONAL_UP_RIGHT;
    public readonly MotionGestureInput DIAGONAL_UP_LEFT;
    public readonly MotionGestureInput SCROLL_UP;
    public readonly MotionGestureInput SCROLL_DOWN;
    public readonly MotionGestureInput NO_MOTION;
    public readonly MotionGestureInput LAST_MOTION;
    public TouchMotionGestureFactory()
    {
        int MAX = InputFactory.getInstance().MAX;
        this.LEFT = new MotionGestureInput(MAX - 3, "Left Touch");
        this.RIGHT = new MotionGestureInput(MAX - 4, "Right Touch");
        this.UP = new MotionGestureInput(MAX - 5, "Up Touch");
        this.DOWN = new MotionGestureInput(MAX - 6, "Down Touch");
        this.PRESSED = new MotionGestureInput(MAX - 7, "Screen Press");
        this.RELEASED = new MotionGestureInput(MAX - 8, "Released");
        this.DIAGONAL_DOWN_RIGHT = new MotionGestureInput(MAX - 9, "Diagonal Dn R");
        this.DIAGONAL_DOWN_LEFT = new MotionGestureInput(MAX - 10, "Diagonal Dn L");
        this.DIAGONAL_UP_RIGHT = new MotionGestureInput(MAX - 11, "Diagonal Up R");
        this.DIAGONAL_UP_LEFT = new MotionGestureInput(MAX - 12, "Diagonal Up L");
        this.SCROLL_UP = new MotionGestureInput(MAX - 13, "Scroll Up");
        this.SCROLL_DOWN = new MotionGestureInput(MAX - 14, "Scroll Down");
        this.NO_MOTION = new MotionGestureInput(MAX - 2, "No Motion");
        this.LAST_MOTION = new MotionGestureInput(MAX - 19, "Last Motion");
    }

}

