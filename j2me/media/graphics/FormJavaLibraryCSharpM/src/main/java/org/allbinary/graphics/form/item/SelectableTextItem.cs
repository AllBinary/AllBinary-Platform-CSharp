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
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.graphics.form.item;

public class SelectableTextItem : ABTextItem
{
    public SelectableTextItem(string label, int layout, string altText, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(label, layout, altText, backgroundBasicColor, foregroundBasicColor)
    {
        // base(label, layout, altText, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
    }

    public override bool isFocusable()
    {
        return true;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.myFontProcessor.process(graphics);
        ABStringComponent stringComponent = this.getLabelStringComponent();
        if (stringComponent != null) {
            graphics.setColor(((int) stringComponent.getForegroundBasicColor()));
        }
        graphics.drawString(this.getLabel(), x + 2, y, 0);
    }

}

