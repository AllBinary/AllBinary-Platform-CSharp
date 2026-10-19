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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using AppletUtil = org.allbinary.AppletUtil;
using Anchor = org.allbinary.graphics.Anchor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using Paintable = org.allbinary.graphics.paint.Paintable;
using TouchScreenFactory = org.allbinary.input.motion.button.TouchScreenFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.game.paint;

public class PressStartMenuPaintable : Paintable, UpdateMyFontInterface
{
    private readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    private readonly string PRESS_START = "Press Screen To Start";
    private readonly string KEY_START = "Press or Click F2 To Begin";
    private readonly string MENU_START = "Press Start From The Menu To Begin";
    private MyFontProcessor myFontProcessor;
    private string startString = StringUtil.getInstance().EMPTY_STRING;
    private TimeDelayHelper timeDelayHelper = new TimeDelayHelper(1100);
    private bool flash = false;
    public PressStartMenuPaintable()
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        if (TouchScreenFactory.getInstance().isTouch()) {
            this.startString = this.PRESS_START;
        } else if (AppletUtil.isAppletLoader(this)) {
            this.startString = this.KEY_START;
        } else {
            this.startString = this.MENU_START;
        }
    }

    private int anchor = Anchor.TOP_LEFT;
    private int beginWidth = 0;
    private int line = 0;
    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.beginWidth = (graphics.getFont().stringWidth(this.startString) >> 1);
        this.line = (4 * MyFontProcessor.defaultCharWidth(font)) + (font.getHeight() >> 1);
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void paint(Graphics graphics)
    {
        if (this.timeDelayHelper.isTimeTNT()) {
            if (this.isFlash()) {
                this.setFlash(false);
            } else {
                this.setFlash(true);
            }
        }
        if (this.isFlash()) {
            this.myFontProcessor.process(graphics);
            graphics.drawString(this.startString, displayInfo.getLastHalfWidth() - beginWidth, displayInfo.getLastHeight() - line, this.anchor);
        }
    }

    private void setFlash(bool flash)
    {
        this.flash = flash;
    }

    private bool isFlash()
    {
        return this.flash;
    }

}

