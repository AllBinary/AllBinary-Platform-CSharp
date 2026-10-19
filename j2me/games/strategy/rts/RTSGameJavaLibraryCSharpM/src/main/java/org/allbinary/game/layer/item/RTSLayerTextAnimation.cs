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
//using Image = javax.microedition.lcdui.Image;
using Animation = org.allbinary.animation.Animation;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;

namespace org.allbinary.game.layer.item;

public class RTSLayerTextAnimation : Animation, UpdateMyFontInterface
{
    private readonly Image image;
    private readonly string text;
    private MyFontProcessor myFontProcessor;
    private int fontHeight = 0;
    public RTSLayerTextAnimation(string text, Image image)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.text = text;
        this.image = image;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.myFontProcessor.process(graphics);
        base.paintXY(graphics, x, y);
        int adjustedCostY = this.image.getHeight() - this.fontHeight;
        graphics.drawString(this.text, x, y + adjustedCostY, 0);
    }

}

