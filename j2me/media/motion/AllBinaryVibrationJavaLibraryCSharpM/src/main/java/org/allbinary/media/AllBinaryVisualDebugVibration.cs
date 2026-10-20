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
using Anchor = org.allbinary.graphics.Anchor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.media;

public class AllBinaryVisualDebugVibration : AllBinaryVibrationME, UpdateMyFontInterface
{
    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(int.MaxValue);
    private readonly string VIBRATING = "Vibrating";
    private MyFontProcessor myFontProcessor;
    private int anchor = Anchor.TOP_LEFT;
    private int width = 0;
    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.width = font.stringWidth(this.VIBRATING);
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void vibrate(int duration, int type, int volume)
    {
        this.timeDelayHelper.delay = duration;
    }

    public virtual void paint(Graphics graphics)
    {
        if (this.timeDelayHelper.isTimeTNT()) {
            this.timeDelayHelper.delay = int.MaxValue;
            this.myFontProcessor.process(graphics);
            graphics.drawString(this.VIBRATING, this.displayInfoSingleton.getLastHalfWidth() - (width >> 1), 0, this.anchor);
        }
    }

    public AllBinaryVisualDebugVibration()
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
    }

}

