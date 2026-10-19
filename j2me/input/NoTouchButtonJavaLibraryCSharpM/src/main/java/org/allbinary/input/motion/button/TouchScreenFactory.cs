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

namespace org.allbinary.input.motion.button;

public class TouchScreenFactory
{
    private static readonly TouchScreenFactory SINGLETON = new TouchScreenFactory();
    private bool multiTouch = false;
    private bool touch = false;
    private TouchScreenType touchScreenType = TouchScreenTypesFactory.getInstance().NOTOUCH;
    private TouchScreenFactory()
    {
    }

    public static TouchScreenFactory getInstance()
    {
        return TouchScreenFactory.SINGLETON;
    }

    public virtual bool isMultiTouch()
    {
        return this.multiTouch;
    }

    public virtual void setTouch(bool touch)
    {
    }

    public virtual bool isTouch()
    {
        return this.touch;
    }

    public virtual TouchScreenType getTouchScreenType()
    {
        return this.touchScreenType;
    }

}

