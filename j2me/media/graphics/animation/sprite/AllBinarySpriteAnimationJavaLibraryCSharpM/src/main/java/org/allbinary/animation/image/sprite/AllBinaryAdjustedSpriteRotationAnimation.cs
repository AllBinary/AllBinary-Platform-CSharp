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

namespace org.allbinary.animation.image.sprite;

public class AllBinaryAdjustedSpriteRotationAnimation : AllBinarySpriteRotationAnimation
{
    private int dx;
    private int dy;
    public AllBinaryAdjustedSpriteRotationAnimation(Sprite sprite, Image image, int dx, int dy, AnimationBehavior animationBehavior) : base(sprite, image, animationBehavior)
    {
        // base(sprite, image, animationBehavior) is called from the constructor declaration
        this.dx = dx;
        this.dy = dy;
    }

    public override void paintXY(Graphics g, int x, int y)
    {
        this.sprite.setPosition(x + this.dx, y + this.dy);
        this.paint(g);
    }

}

