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
//using Image = javax.microedition.lcdui.Image;
//using Sprite = javax.microedition.lcdui.game.Sprite;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorUtil = org.allbinary.graphics.color.BasicColorUtil;

namespace org.allbinary.animation.image.sprite;

public class AdjustedSpriteIndexedAnimation : SpriteIndexedAnimation
{
    private int dx;
    private int dy;
    public AdjustedSpriteIndexedAnimation(Sprite sprite, Image image, BasicColor[] basicColorArray, int dx, int dy, AnimationBehavior animationBehavior) : base(sprite, image, basicColorArray, animationBehavior)
    {
        // base(sprite, image, basicColorArray, animationBehavior) is called from the constructor declaration
        this.dx = dx;
        this.dy = dy;
    }

    public override void paintFrame(Graphics graphics, int frame, int x, int y)
    {
        this.setFrame(frame);
        this.sprite.setPosition(x + this.dx, y + this.dy);
        base.paint(graphics);
    }

    public override void paintXY(Graphics g, int x, int y)
    {
        this.sprite.setPosition(x + this.dx, y + this.dy);
        base.paint(g);
    }

    public override void paint(Graphics g)
    {
        this.sprite.setPosition(this.dx, this.dy);
        base.paint(g);
    }

}

