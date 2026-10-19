/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.layer;

public class MultiSelectPaintable : SelectionHudPaintable
{
    private readonly BasicArrayList rootNameList = new BasicArrayListD();
    private char[] totalCharArray = NullUtil.getInstance().NULL_CHAR_ARRAY;
    private string rootNamesString = StringUtil.getInstance().EMPTY_STRING;
    private readonly string TOTAL = "Total Selected: ";
    private readonly int backgroundColor = ((int) BasicColorFactory.getInstance().GREY);
    private int totalWidth = 0;
    private int textLine2Y = 0;
    public MultiSelectPaintable()
    {
    }

    public override void updateMeasurement(Graphics graphics)
    {
        base.updateMeasurement(graphics);
        Font font = graphics.getFont();
        this.totalWidth = font.stringWidth(this.TOTAL);
        this.textLine2Y = (this.y + font.getHeight());
    }

    public virtual void update(BasicArrayList list)
    {
        this.clear();
        int size = list.size();
        this.totalCharArray = this.getPrimitiveLongUtil().getCharArray(size);
        for (int index = list.size() - 1; index >= 0; index--) {
            RTSLayer rtsLayer = ((RTSLayer) list.get(index));
            if (!this.rootNameList.contains(rtsLayer.getRootName())) {
                this.rootNameList.add(rtsLayer.getRootName());
            }
        }
        string COMMA_SEP = CommonSeps.getInstance().COMMA_SEP;
        StringMaker stringBuffer = new StringMaker();
        for (int index = this.rootNameList.size() - 1; index >= 0; index--) {
            string rootName = ((string) this.rootNameList.get(index));
            stringBuffer.append(rootName);
            if (index != 0) {
                stringBuffer.append(COMMA_SEP);
            }
        }
        this.rootNamesString = stringBuffer.ToString();
    }

    private void clear()
    {
        this.rootNameList.clear();
    }

    public override void paint(Graphics graphics)
    {
        graphics.setColor(this.backgroundColor);
        graphics.drawRect(this.getX(), this.y, this.getWidth(), this.getHeight());
        graphics.setColor(this.getColor());
        graphics.drawString(this.TOTAL, this.textX, this.y, 0);
        graphics.drawChars(this.totalCharArray, 0, this.getPrimitiveLongUtil().getCurrentTotalDigits(), this.textX + this.totalWidth, this.y, 0);
        graphics.drawString(this.rootNamesString, this.textX, this.textLine2Y, 0);
    }

}

