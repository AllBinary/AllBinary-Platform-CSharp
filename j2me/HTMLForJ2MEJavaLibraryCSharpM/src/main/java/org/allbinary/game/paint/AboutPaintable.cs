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
using Font = javax.microedition.lcdui.Font;
using Graphics = javax.microedition.lcdui.Graphics;
using Anchor = org.allbinary.graphics.Anchor;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.game.paint;

//HTMLForJ2ME
public class AboutPaintable : Paintable, UpdateMyFontInterface
{
    public static AboutPaintable getInstance(string[] info, string[] developers)
    {
        return new AboutPaintable(info, developers);
    }

    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private readonly string ABOUT = CanvasStrings.getInstance().ABOUT;
    private readonly string[] info;
    private readonly string[] developers;
    private readonly Paintable[] paintableArray;
    private MyFontProcessor myFontProcessor;
    private int charHeight = 0;
    private int aboutBeginWidth = 0;
    private int[] infoBeginWidth;
    private int[] developersBeginWidth;
    private int anchor = Anchor.TOP_LEFT;
    private AboutPaintable(string[] info, string[] developers)
    {
        this.paintableArray = new Paintable[] { this };
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.info = info;
        this.infoBeginWidth = new int[this.info.Length];
        this.developers = developers;
        this.developersBeginWidth = new int[this.developers.Length];
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.charHeight = font.getHeight();
        this.aboutBeginWidth = (font.stringWidth(this.ABOUT) >> 1);
        int infoSize = this.info.Length;
        for (int index_0 = 0; index_0 < infoSize; index_0++) {
            this.infoBeginWidth[index_0] = (font.stringWidth(this.info[index_0]) >> 1);
        }
        int size = this.developers.Length;
        for (int index_1 = 0; index_1 < size; index_1++) {
            this.developersBeginWidth[index_1] = (font.stringWidth(this.developers[index_1]) >> 1);
        }
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual Paintable[] getPaintableArrayInstance()
    {
        return this.paintableArray;
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        int halfWidth = this.displayInfoSingleton.getLastHalfWidth();
        graphics.drawString(this.ABOUT, halfWidth - this.aboutBeginWidth, 2 * this.charHeight, this.anchor);
        int infoSize = this.info.Length;
        for (int index_2 = 0; index_2 < infoSize; index_2++) {
            graphics.drawString(this.info[index_2], halfWidth - this.infoBeginWidth[index_2], (4 + index_2) * this.charHeight, this.anchor);
        }
        int size = this.developers.Length;
        for (int index_3 = 0; index_3 < size; index_3++) {
            graphics.drawString(this.developers[index_3], halfWidth - this.developersBeginWidth[index_3], (5 + infoSize + index_3) * this.charHeight, this.anchor);
        }
    }

}

