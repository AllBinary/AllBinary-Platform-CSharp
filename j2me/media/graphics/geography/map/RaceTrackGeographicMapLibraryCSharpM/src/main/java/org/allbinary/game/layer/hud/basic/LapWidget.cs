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
using LapInfo = org.allbinary.game.layer.hud.LapInfo;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.game.layer.hud.basic;

public class LapWidget : BasicHud
{
    private readonly string LAP_STR = "Lap ";
    private readonly string OF_STR = " of ";
    private string @string = StringUtil.getInstance().EMPTY_STRING;
    public LapWidget(int location, int direction, BasicColor basicColor) : base(location, direction, 2, basicColor)
    {
        // base(location, direction, 2, basicColor) is called from the constructor declaration
        this.updateMaxHeight = 15;
        this.updateMaxWidth = 40;
    }

    public virtual void update(LapInfo lapInfo)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(this.LAP_STR);
        stringBuffer.appendint(((int) lapInfo.getCurrentLap()));
        stringBuffer.append(this.OF_STR);
        stringBuffer.appendint(((int) lapInfo.getTotalLaps()));
        this.@string = stringBuffer.ToString();
    }

    public virtual void paint(Graphics graphics)
    {
        base.paintString(graphics, this.@string);
    }

}

