/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using ABCustomImageItem = org.allbinary.graphics.form.item.ABCustomImageItem;
using CharArrayFactory = org.allbinary.logic.java.character.CharArrayFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;

namespace org.allbinary.game.layer;

public class TechnologyRTSInterfaceImageItem : ABCustomImageItem, UpdateMyFontInterface
{
    private readonly RTSInterface rtsInterface;
    private readonly PrimitiveLongUtil primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(10000);
    private readonly string LEVEL = "Level";
    private readonly string COST = "Cost";
    private readonly string DOLLAR = "$";
    private MyFontProcessor myFontProcessor;
    private char[] costString = CharArrayFactory.getInstance().getZeroCharArray();
    private int costLength = 0;
    private char[] levelString = CharArrayFactory.getInstance().getZeroCharArray();
    private int levelLength = 0;
    private int adjustedCostLabelY = 0;
    private int adjustedCostX = 0;
    private int adjustedCostY = 0;
    private int adjustedLevelX = 0;
    private int adjustedLevelY = 0;
    public TechnologyRTSInterfaceImageItem(string label, Image img, int layout, string altText, BasicColor basicColor, RTSInterface rtsInterface) : base(label, img, layout, altText, basicColor, 0)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        // base(label, img, layout, altText, basicColor, 0) is called from the constructor declaration
        this.rtsInterface = rtsInterface;
        this.update();
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        int fontHeight = font.getHeight();
        int imageHeight = 0;
        Image image = this.getImage();
        if (image != NullImage.NULL_IMAGE) {
            imageHeight = image.getHeight();
        }
        this.adjustedCostLabelY = -this.yOffset + imageHeight - (3 * fontHeight);
        this.adjustedCostY = -this.yOffset + imageHeight - (2 * fontHeight);
        this.adjustedCostX = 2 + (this.DOLLAR.Length * (fontHeight - 1));
        this.adjustedLevelY = -this.yOffset + imageHeight - fontHeight;
        this.adjustedLevelX = 2 + (this.LEVEL.Length * (fontHeight - 1));
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual RTSInterface getRtsInterface()
    {
        return this.rtsInterface;
    }

    public virtual void update()
    {
        this.costString = this.primitiveLongUtil.getCharArray(this.getRtsInterface().getUpgradeCost());
        this.levelString = this.primitiveLongUtil.getCharArray(this.getRtsInterface().getLevel());
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.myFontProcessor.process(graphics);
        base.paintXY(graphics, x, y);
        int xa = x + 2;
        graphics.drawString(this.COST, xa, y + this.adjustedCostLabelY, 0);
        graphics.drawString(this.DOLLAR, xa, y + this.adjustedCostY, 0);
        graphics.drawChars(this.costString, 0, this.costLength, x + this.adjustedCostX, y + this.adjustedCostY, 0);
        graphics.drawString(this.LEVEL, xa, y + this.adjustedLevelY, 0);
        graphics.drawChars(this.levelString, 0, this.levelLength, x + this.adjustedLevelX, y + this.adjustedLevelY, 0);
    }

}

