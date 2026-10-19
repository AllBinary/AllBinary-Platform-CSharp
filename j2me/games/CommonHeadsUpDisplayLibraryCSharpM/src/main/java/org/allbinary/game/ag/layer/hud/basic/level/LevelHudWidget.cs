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
using BasicHud = org.allbinary.game.graphics.hud.BasicHud;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using NullUtil = org.allbinary.logic.NullUtil;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;

namespace org.allbinary.game.ag.layer.hud.basic.level;

public class LevelHudWidget : BasicHud, PaintableInterface
{
    // throws Exception
    public static LevelHudWidget createHud(int maxlevel, int location, int direction)
    {
        return new LevelHudWidget(maxlevel, location, direction);
    }

    private int level;
    private int maxlevel;
    private readonly char[] levelString;
    private char[] levelNumberCharArray = NullUtil.getInstance().NULL_CHAR_ARRAY;
    private int levelNumberTotalDigits = 0;
    private int offset = 0;
    private readonly PrimitiveLongUtil primitiveLongUtil;
    public LevelHudWidget(int maxlevel, int location, int direction) : base(location, direction, 2, BasicColorFactory.getInstance().GREY)
    {
        // base(location, direction, 2, BasicColorFactory.getInstance().GREY) is called from the constructor declaration
        this.primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(1000);
        string LEVEL = "Lv ";
        this.levelString = LEVEL.ToCharArray();
        this.maxlevel = maxlevel;
        this.level = maxlevel;
        this.update();
        this.updateMaxHeight = 14;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.updateMaxWidth = font.getSize() * 4;
        this.offset = font.charsWidth(this.levelString, 0, this.levelString.Length) + font.getSize();
        base.updateMeasurement(graphics);
    }

    private void update()
    {
        this.levelNumberCharArray = this.primitiveLongUtil.getCharArray(this.level);
        this.levelNumberTotalDigits = this.primitiveLongUtil.getCurrentTotalDigits();
    }

    public virtual void setLevel(int level)
    {
        this.level = level;
        this.update();
    }

    public virtual void nextLevel()
    {
        this.level++;
        this.update();
    }

    public virtual void previousLevel()
    {
        this.level--;
        if (this.level < 0) {
            this.level = 0;
        }
        this.update();
    }

    public virtual bool isComplete()
    {
        if (this.level <= this.maxlevel) {
            return false;
        } else {
            return true;
        }
    }

    public override void paint(Graphics graphics)
    {
        base.paintDX(graphics, this.levelString, 0, this.levelString.Length, this.levelNumberCharArray, 0, this.levelNumberTotalDigits, this.offset);
    }

    public override void paintThreed(Graphics graphics)
    {
    }

}

