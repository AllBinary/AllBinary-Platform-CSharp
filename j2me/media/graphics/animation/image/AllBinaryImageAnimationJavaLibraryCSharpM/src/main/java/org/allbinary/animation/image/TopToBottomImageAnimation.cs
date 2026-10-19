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

namespace org.allbinary.animation.image;

public class TopToBottomImageAnimation : ImageSegmentAnimation
{
    private int currentHeight;
    public TopToBottomImageAnimation(Image image, int[] sequenceArray, AnimationBehavior animationBehavior) : base(image, sequenceArray, animationBehavior)
    {
        // base(image, sequenceArray, animationBehavior) is called from the constructor declaration
        this.currentHeight = 0;
        if (this.getSequence()[0] == -1) {
            this.setFrame(this.getSize() - 1);
        }
    }

    public override void nextFrame()
    {
        if (this.getSequence()[0] == -1) {
            base.previousFrame();
        } else {
            base.nextFrame();
        }
        this.update();
    }

    public override void previousFrame()
    {
        if (this.getSequence()[0] == -1) {
            base.nextFrame();
        } else {
            base.previousFrame();
        }
        this.update();
    }

    public override void setFrame(int index)
    {
        base.setFrame(index);
        this.update();
    }

    private void update()
    {
        this.currentHeight = this.getDrawHeight() * this.getFrame() / this.getSize();
    }

    private int anchor = Anchor.TOP_LEFT;
    public override void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawRegion(this.getImage(), this.getStartX(), this.getStartY(), this.getDrawWidth(), this.currentHeight, Sprite.TRANS_NONE, x, y, this.anchor);
    }

}

