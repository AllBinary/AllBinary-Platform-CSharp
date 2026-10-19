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
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Display = javax.microedition.lcdui.Display;
//using Displayable = javax.microedition.lcdui.Displayable;
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
//using MIDlet = javax.microedition.midlet.MIDlet;
//using MIDletStateChangeException = javax.microedition.midlet.MIDletStateChangeException;
using StdUtil = org.allbinary.logic.StdUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Memory = org.allbinary.system.Memory;
using NullUtil = org.allbinary.logic.NullUtil;
using org.allbinary.util;

namespace org.allbinary.midlet;

public class AllBinaryMidlet : MIDlet, CommandListener
{
    private static object NULL_ALLBINARY_MIDLET = NullUtil.getInstance().NULL_OBJECT;
    public static AllBinaryMidlet getNullInstance()
    {
        if (AllBinaryMidlet.NULL_ALLBINARY_MIDLET == NullUtil.getInstance().NULL_OBJECT) {
            AllBinaryMidlet.NULL_ALLBINARY_MIDLET = new AllBinaryMidlet();
        }
        return ((AllBinaryMidlet) AllBinaryMidlet.NULL_ALLBINARY_MIDLET);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string SET_DISPLAY = "setDisplay";
    private readonly string SETTING_ = "Setting: ";
    private readonly string _DISPLAY_ = " Display: ";
    private readonly string SETTING_NO_TITLE = "Setting: No Title, Display: ";
    private ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private bool midletDestroyed = false;
    public AllBinaryMidlet()
    {
        this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, "AllBinaryMidlet::AllBinaryMidlet");
    }

    protected virtual void setDisplay(Displayable newDisplay)
    {
        string title = StringUtil.getInstance().EMPTY_STRING;
        if (newDisplay != NullCanvas.NULL_CANVAS) {
            title = newDisplay.getTitle();
            if (title != null) {
                this.logUtil.putF(new StringMaker().append(this.SETTING_).append(title).append(this._DISPLAY_).append(StringUtil.getInstance().toString(newDisplay)).ToString(), this, this.SET_DISPLAY);
            } else {
                this.logUtil.putF(new StringMaker().append(this.SETTING_NO_TITLE).append(StringUtil.getInstance().toString(newDisplay)).ToString(), this, this.SET_DISPLAY);
            }
        }
        Display display = this.getDisplay();
        display.setCurrent(newDisplay);
    }

    public virtual Display getDisplay()
    {
        return Display.getDisplay(this);
    }

    protected virtual Displayable getCurrentDisplayable()
    {
        return Display.getDisplay(this).getCurrent();
    }

    public virtual void setDestroyed(bool destroyed)
    {
        this.midletDestroyed = destroyed;
    }

    public virtual bool isDestroyed()
    {
        return this.midletDestroyed;
    }

    // throws MIDletStateChangeException
    protected override void startApp()
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    protected override void pauseApp()
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    protected virtual void destroyAppInRunnable(bool unconditional, bool isProgress)
    {
    }

    protected override void destroyApp(bool unconditional)
    {
        string METHOD_NAME = "AllBinaryMidlet::destroyApp";
        try {
            this.logUtil.putF(this.commonStrings.START, this, METHOD_NAME);
            PreLogUtil.put(Memory.getInfo(), this, METHOD_NAME);
            this.setDestroyed(true);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, METHOD_NAME, e);
        }
    }

    // throws Exception
    public virtual void setStartStateHashtable(ABHashtable<object, object> hashtable)
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append(StringUtil.getInstance().toString(hashtable)).ToString(), this, "setStartStateHashtable");
        this.hashtable = hashtable;
    }

    // throws Exception
    public virtual ABHashtable<object, object> getStartStateHashtable()
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append(StringUtil.getInstance().toString(this.hashtable)).ToString(), this, "getStartStateHashtable");
        return this.hashtable;
    }

    // throws Exception
    public virtual ABHashtable<object, object> getCurrentStateHashtable()
    {
        this.logUtil.putF(this.commonStrings.START, this, "getStateHashtable");
        return StdUtil.getInstance().NULL_TABLE;
    }

    public override void commandAction(Command command, Displayable displayable)
    {
    }

}

