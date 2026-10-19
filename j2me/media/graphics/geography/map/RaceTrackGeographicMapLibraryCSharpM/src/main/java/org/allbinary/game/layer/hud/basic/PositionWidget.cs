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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicHud = org.allbinary.game.graphics.hud.BasicHud;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.game.layer.hud.basic;

//super.paint(graphics, positionString, currentPostString, offset2, offset);
public class PositionWidget : BasicHud
{
    private int position = 0;
    private string positionString = StringUtil.getInstance().EMPTY_STRING;
    public PositionWidget(int position, int location, int direction, BasicColor basicColor) : base(location, direction, 2, basicColor)
    {
        // base(location, direction, 2, basicColor) is called from the constructor declaration
        this.updateMaxHeight = 10;
        this.updateMaxWidth = 40;
    }

    public virtual int get()
    {
        return this.position;
    }

    public virtual void set(int position)
    {
        this.position = position;
        this.positionString = PositionWidget.toString(this.get());
    }

    public virtual void paint(Graphics graphics)
    {
        base.paintString(graphics, this.positionString);
    }

    public static string toString(int position)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append((position).ToString());
        if (position == 1) {
            stringBuffer.append("st");
        } else if (position == 2) {
            stringBuffer.append("nd");
        } else if (position == 3) {
            stringBuffer.append("rd");
        } else {
            stringBuffer.append("th");
        }
        return stringBuffer.ToString();
    }

}

