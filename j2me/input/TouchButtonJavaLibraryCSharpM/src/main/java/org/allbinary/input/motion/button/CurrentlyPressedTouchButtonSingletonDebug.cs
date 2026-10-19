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
using GPoint = org.allbinary.graphics.GPoint;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.input.motion.button;

public class CurrentlyPressedTouchButtonSingletonDebug : CurrentlyPressedTouchButtonSingleton
{
    private static readonly CurrentlyPressedTouchButtonSingletonDebug instanceC = new CurrentlyPressedTouchButtonSingletonDebug();
    public static CurrentlyPressedTouchButtonSingleton getInstance()
    {
        return CurrentlyPressedTouchButtonSingletonDebug.instanceC;
    }

    private string @string = StringUtil.getInstance().EMPTY_STRING;
    private string listString = StringUtil.getInstance().EMPTY_STRING;
    private string append = StringUtil.getInstance().EMPTY_STRING;
    private readonly string PRESSED_AND_FIRED = "pressed & fired";
    private readonly string PRESSED_AND_NOT_FIRED = "pressed in button but not fired";
    private readonly string ASSOCIATED_RELEASED_AND_FIRED = "assoc. rel & fired";
    private readonly string RELEASED_AND_FIRED = "rel & fired 1";
    private readonly string RELEASED_AND_FIRED_2 = "rel & fired 2";
    private readonly string RELEASED_AND_NOT_FIRED = "rel & not fired";
    private void appendTouchButtonInput(string append, TouchButtonInput touchButtonInput)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(touchButtonInput.ToString());
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(append);
        this.append = stringBuffer.ToString();
        this.@string = new StringMaker().append(this.listString).append(this.append).ToString();
    }

    private void append(string append)
    {
        this.append = new StringMaker().append(this.append).append(append).ToString();
        this.@string = new StringMaker().append(this.listString).append(this.append).ToString();
    }

    public virtual void clearLog(int x, int y)
    {
        this.append = new StringMaker().append(GPoint.toStringStatic(x, y, 0)).append(CommonSeps.getInstance().SPACE).ToString();
        this.@string = new StringMaker().append(this.listString).append(this.append).ToString();
    }

    public virtual void releaseAndNotFired()
    {
        this.append(this.RELEASED_AND_NOT_FIRED);
    }

    public virtual void releaseAndFired(TouchButtonInput touchButtonInput)
    {
        this.appendTouchButtonInput(this.RELEASED_AND_FIRED, touchButtonInput);
    }

    public virtual void releaseAndFired2(TouchButtonInput touchButtonInput)
    {
        this.appendTouchButtonInput(this.RELEASED_AND_FIRED_2, touchButtonInput);
    }

    public virtual void releaseAndFiredAssociated(TouchButtonInput touchButtonInput)
    {
        this.appendTouchButtonInput(this.ASSOCIATED_RELEASED_AND_FIRED, touchButtonInput);
    }

    public virtual void pressedAndFired(TouchButtonInput touchButtonInput)
    {
        this.appendTouchButtonInput(this.PRESSED_AND_FIRED, touchButtonInput);
    }

    public virtual void pressedAndNotFired(TouchButtonInput touchButtonInput)
    {
        this.appendTouchButtonInput(this.PRESSED_AND_NOT_FIRED, touchButtonInput);
    }

    public override TouchButtonInput removeAt(int index)
    {
        TouchButtonInput touchButtonInput = base.removeAt(index);
        this.listString = this.list.ToString();
        this.@string = new StringMaker().append(this.listString).append(this.append).ToString();
        return touchButtonInput;
    }

    public override bool remove(TouchButtonInput touchButtonInput)
    {
        bool isRemoved = base.remove(touchButtonInput);
        this.listString = this.list.ToString();
        this.@string = new StringMaker().append(this.listString).append(this.append).ToString();
        return isRemoved;
    }

    public override void add(TouchButtonInput touchButtonInput)
    {
        base.add(touchButtonInput);
        this.listString = this.list.ToString();
        this.@string = new StringMaker().append(this.listString).append(this.append).ToString();
    }

    public override string ToString()
    {
        return this.@string;
    }

}

