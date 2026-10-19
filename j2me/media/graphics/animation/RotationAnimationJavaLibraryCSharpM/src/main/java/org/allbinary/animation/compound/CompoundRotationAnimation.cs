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
//using GL = javax.microedition.khronos.opengles.GL;
//using Graphics = javax.microedition.lcdui.Graphics;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using Direction = org.allbinary.direction.Direction;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using Angle = org.allbinary.math.Angle;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.compound;

public class CompoundRotationAnimation : RotationAnimation, CompoundAnimationInterface
{
    private RotationAnimation[] animationInterfaceArray;
    public CompoundRotationAnimation(RotationAnimation[] animationInterfaceArray, AnimationBehavior animationBehavior) : base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior)
    {
        // base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior) is called from the constructor declaration
        this.animationInterfaceArray = animationInterfaceArray;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.animationInterfaceArray.Length);
    }

    public override void setFrame(int index)
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].setFrame(index);
    }

    public override int getFrame()
    {
        return this.animationInterfaceArray[this.circularIndexUtil.getIndex()].getFrame();
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.animationInterfaceArray[this.circularIndexUtil.getIndex()].getAnimationSize();
    }

    public override int getSize()
    {
        return this.animationInterfaceArray[this.circularIndexUtil.getIndex()].getSize();
    }

    public override void previousFrame()
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].previousFrame();
    }

    // throws Exception
    public override void nextFrame()
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].nextFrame();
    }

    public override void previousRotation()
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].previousRotation();
    }

    public override void nextRotation()
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].nextRotation();
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].paintXY(graphics, x, y);
    }

    public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].paintThreedXYZ(graphics, x, y, z);
    }

    public override IndexedAnimation getCurrentAnimation()
    {
        return this.animationInterfaceArray[this.circularIndexUtil.getIndex()];
    }

    public override void nextAnimation()
    {
        int frame = this.getFrame();
        this.circularIndexUtil.next();
        this.setFrame(frame);
    }

    public override void previousAnimation()
    {
        int frame = this.getFrame();
        this.circularIndexUtil.previous();
        this.setFrame(frame);
    }

    public override void setAnimation(int index)
    {
        int frame = this.getFrame();
        this.circularIndexUtil.setIndex(index);
        this.setFrame(frame);
    }

    public override void setFrameByDirection(Direction direction)
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].setFrameByDirection(direction);
    }

    public override void setFrameToAngle(Angle angle)
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].setFrameToAngle(angle);
    }

    public override void adjustFrameToAngle(Angle newAngle)
    {
        this.adjustFrame(newAngle.getValue());
    }

    public override void adjustFrame(short angle)
    {
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].adjustFrame(angle);
    }

    public override AngleInfo getAngleInfoP()
    {
        return this.animationInterfaceArray[this.circularIndexUtil.getIndex()].getAngleInfoP();
    }

    public virtual RotationAnimation[] getAnimationInterfaceArray()
    {
        return this.animationInterfaceArray;
    }

    public virtual void setAnimationInterfaceArray(RotationAnimation[] animationInterfaceArray)
    {
        this.animationInterfaceArray = animationInterfaceArray;
    }

    // throws Exception
    public override void set(GL gl)
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].set(gl);
        }
    }

}

