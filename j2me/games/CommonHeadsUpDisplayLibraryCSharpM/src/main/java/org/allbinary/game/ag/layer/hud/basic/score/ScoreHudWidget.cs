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
using NumberStringHud = org.allbinary.game.ag.layer.hud.basic.NumberStringHud;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;

namespace org.allbinary.game.ag.layer.hud.basic.score;

public class ScoreHudWidget : NumberStringHud
{
    // throws Exception
    public static ScoreHudWidget getInstance(int maxscore, int location, int direction)
    {
        return new ScoreHudWidget(maxscore, location, direction, 2, BasicColorFactory.getInstance().GREY);
    }

    public ScoreHudWidget(int maxscore, int location, int direction, int bufferZone, BasicColor basicColor) : base("Pts ", maxscore, location, direction, bufferZone, basicColor)
    {
        // base("Pts ", maxscore, location, direction, bufferZone, basicColor) is called from the constructor declaration
        this.updateMaxHeight = 14;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.updateMaxWidth = font.getSize() * 5;
        base.updateMeasurement(graphics);
    }

}

