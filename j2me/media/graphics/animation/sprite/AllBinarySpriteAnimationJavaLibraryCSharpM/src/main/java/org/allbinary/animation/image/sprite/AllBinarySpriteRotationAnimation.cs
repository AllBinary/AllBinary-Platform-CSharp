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
//using Image = javax.microedition.lcdui.Image;
//using Sprite = javax.microedition.lcdui.game.Sprite;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using Direction = org.allbinary.direction.Direction;
using Angle = org.allbinary.math.Angle;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation.image.sprite;

public class AllBinarySpriteRotationAnimation : HackRotationSpriteIndexedAnimation
{
    public AllBinarySpriteRotationAnimation(Sprite sprite, Image image, AnimationBehavior animationBehavior) : base(sprite, image, AngleInfo.getInstance(((short) (AngleFactory.getInstance().TOTAL_ANGLE / sprite.getRawFrameCount()))), animationBehavior)
    {
        // base(sprite, image, AngleInfo.getInstance(((short) (AngleFactory.getInstance().TOTAL_ANGLE / sprite.getRawFrameCount()))), animationBehavior) is called from the constructor declaration
        this.angleInfo.adjustAngle(this.sprite.getFrame());
    }

    public override void nextRotation()
    {
        this.sprite.nextFrame();
        this.angleInfo.adjustAngle(this.sprite.getFrame());
    }

    public override void previousRotation()
    {
        this.sprite.prevFrame();
        this.angleInfo.adjustAngle(this.sprite.getFrame());
    }

    public override void setFrameByDirection(Direction direction)
    {
        Angle angle = this.directionUtil.getFrameAngle(direction);
        this.adjustFrameToAngle(angle);
    }

    public override void setFrameToAngle(Angle angle)
    {
        this.adjustFrameToAngle(angle);
    }

    public override void setFrame(int index)
    {
        this.sprite.setFrame(index);
        this.angleInfo.adjustAngle(this.getFrame());
    }

    public override void adjustFrameToAngle(Angle angle)
    {
        this.adjustFrame(angle.getValue());
    }

    public override void adjustFrame(short angle)
    {
        this.setFrame(this.frameUtil.getFrameForAngle(angle, ((int) this.angleInfo.getAngleIncrementInfo().getAngleIncrement())));
    }

}

