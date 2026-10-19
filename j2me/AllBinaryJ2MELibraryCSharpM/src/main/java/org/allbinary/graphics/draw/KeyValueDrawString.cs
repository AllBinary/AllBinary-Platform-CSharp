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
//using Graphics = javax.microedition.lcdui.Graphics;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.draw;

public class KeyValueDrawString : UpdateMyFontInterface
{
    private MyFontProcessor myFontProcessor;
    private readonly string LABEL;
    private readonly int labelX;
    private int valueX = 0;
    private string value = StringUtil.getInstance().EMPTY_STRING;
    public KeyValueDrawString(string label, int x)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.LABEL = label;
        this.labelX = x;
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
        int labelWidth = graphics.getFont().stringWidth(this.LABEL) - this.LABEL.Length;
        this.valueX = labelWidth + this.labelX;
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual void paint(Graphics graphics, int y)
    {
        this.myFontProcessor.process(graphics);
        graphics.drawString(this.LABEL, this.labelX, y, 0);
        graphics.drawString(this.value, this.valueX, y, 0);
    }

    public virtual void update(string value)
    {
        if (value != null) {
            this.value = value;
        }
    }

}

