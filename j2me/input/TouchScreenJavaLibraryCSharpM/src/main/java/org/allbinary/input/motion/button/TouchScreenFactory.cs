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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.motion.button;

public class TouchScreenFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TouchScreenFactory SINGLETON = new TouchScreenFactory();
    private bool touch = false;
    private bool multiTouch = false;
    private bool multiTouchDistinct = false;
    private TouchScreenType touchScreenType = TouchScreenTypesFactory.getInstance().NOTOUCH;
    private TouchScreenFactory()
    {
        try {
            this.setTouch(true);
            this.setMultiTouch(false);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, TouchScreenFactory.SINGLETON, commonStrings.GET_INSTANCE, e);
        }
    }

    public static TouchScreenFactory getInstance()
    {
        return TouchScreenFactory.SINGLETON;
    }

    public virtual void setMultiTouch(bool multiTouch)
    {
        this.multiTouch = multiTouch;
    }

    public virtual bool isMultiTouch()
    {
        return this.multiTouch;
    }

    public virtual void setTouch(bool touch)
    {
        this.touch = touch;
    }

    public virtual bool isTouch()
    {
        return this.touch;
    }

    public virtual void setMultiTouchDistinct(bool multiTouchDistinct)
    {
        this.multiTouchDistinct = multiTouchDistinct;
    }

    public virtual bool isMultiTouchDistinct()
    {
        return this.multiTouchDistinct;
    }

    public virtual void setTouchScreenType(TouchScreenType touchScreenType)
    {
        this.touchScreenType = touchScreenType;
    }

    public virtual TouchScreenType getTouchScreenType()
    {
        return this.touchScreenType;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("TouchScreen: ");
        stringBuffer.appendboolean(this.isTouch());
        stringBuffer.append(" MultiTouch: ");
        stringBuffer.appendboolean(this.isMultiTouch());
        stringBuffer.append(" Distinct MultiTouch: ");
        stringBuffer.appendboolean(this.isMultiTouchDistinct());
        stringBuffer.append(" TouchScreenType: ");
        stringBuffer.append(StringUtil.getInstance().toString(this.getTouchScreenType()));
        return stringBuffer.ToString();
    }

}

