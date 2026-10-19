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
using Anchor = org.allbinary.graphics.Anchor;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.image;

public class BottomToTopImageAnimation : ImageSegmentAnimation
{
    private int startHeight = 0;
    private int currentHeight = 0;
    public BottomToTopImageAnimation(Image image, AnimationBehavior animationBehavior) : base(image, PrimitiveIntUtil.getArrayInstance(), animationBehavior)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), animationBehavior) is called from the constructor declaration
        this.setFrame(this.getSize() - 1);
    }

    public override void nextFrame()
    {
        base.previousFrame();
        this.update();
    }

    public override void previousFrame()
    {
        base.nextFrame();
        this.update();
    }

    public override void setFrame(int index)
    {
        base.setFrame(index);
        this.update();
    }

    private void update()
    {
        this.startHeight = this.getDrawHeight() * this.getFrame() / this.getSize();
        this.currentHeight = this.getDrawHeight() - this.startHeight;
    }

    private int anchor = Anchor.TOP_LEFT;
    public override void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawRegion(this.getImage(), this.getStartX(), this.startHeight, this.getDrawWidth(), this.currentHeight, Sprite.TRANS_NONE, x, y + this.startHeight, this.anchor);
    }

}

