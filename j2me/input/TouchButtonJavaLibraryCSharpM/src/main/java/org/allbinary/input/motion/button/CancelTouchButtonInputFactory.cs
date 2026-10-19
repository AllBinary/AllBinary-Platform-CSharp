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

namespace org.allbinary.input.motion.button;

public class CancelTouchButtonInputFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static CancelTouchButtonInputFactory getInstance()
    {
        if (CancelTouchButtonInputFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            CancelTouchButtonInputFactory.instance = new CancelTouchButtonInputFactory();
        }
        return ((CancelTouchButtonInputFactory) CancelTouchButtonInputFactory.instance);
    }

    private readonly TouchButtonInput[] cancelInputArray = new TouchButtonInput[InputFactory.getInstance().MAX];
    private CancelTouchButtonInputFactory()
    {
        BasicTouchInputFactory basicTouchInputFactory = BasicTouchInputFactory.getInstance();
        for (int index = this.cancelInputArray.Length - 1; index >= 0; index--) {
            this.cancelInputArray[index] = basicTouchInputFactory.NONE;
        }
        this.cancelInputArray[basicTouchInputFactory.UP.getSourceId()] = basicTouchInputFactory.DOWN;
        this.cancelInputArray[basicTouchInputFactory.DOWN.getSourceId()] = basicTouchInputFactory.UP;
        this.cancelInputArray[basicTouchInputFactory.LEFT.getSourceId()] = basicTouchInputFactory.RIGHT;
        this.cancelInputArray[basicTouchInputFactory.RIGHT.getSourceId()] = basicTouchInputFactory.LEFT;
    }

    public virtual TouchButtonInput getCancel(TouchButtonInput touchButtonInput)
    {
        return this.cancelInputArray[touchButtonInput.getSourceId()];
    }

}

