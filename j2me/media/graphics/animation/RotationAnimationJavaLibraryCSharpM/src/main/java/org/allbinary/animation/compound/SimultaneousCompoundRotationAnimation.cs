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
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using Direction = org.allbinary.direction.Direction;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using Angle = org.allbinary.math.Angle;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.compound;

public class SimultaneousCompoundRotationAnimation : RotationAnimation
{
    private RotationAnimation[] animationInterfaceArray;
    public SimultaneousCompoundRotationAnimation(RotationAnimation[] animationInterfaceArray, AnimationBehavior animationBehavior) : base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior)
    {
        // base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior) is called from the constructor declaration
        this.animationInterfaceArray = animationInterfaceArray;
    }

    public override void setFrame(int frameIndex)
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].setFrame(frameIndex);
        }
    }

    public override int getFrame()
    {
        return this.animationInterfaceArray[0].getFrame();
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.animationInterfaceArray[0].getAnimationSize();
    }

    public override int getSize()
    {
        return this.animationInterfaceArray[0].getSize();
    }

    public override void previousFrame()
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].previousFrame();
        }
    }

    // throws Exception
    public override void nextFrame()
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].nextFrame();
        }
    }

    public override void previousRotation()
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].previousRotation();
        }
    }

    public override void nextRotation()
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].nextRotation();
        }
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
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].paintXY(graphics, x, y);
        }
    }

    public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].paintThreedXYZ(graphics, x, y, z);
        }
    }

    public override void setFrameByDirection(Direction direction)
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].setFrameByDirection(direction);
        }
    }

    public override void setFrameToAngle(Angle angle)
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].setFrameToAngle(angle);
        }
    }

    public override void adjustFrameToAngle(Angle newAngle)
    {
        this.adjustFrame(newAngle.getValue());
    }

    public override void adjustFrame(short angle)
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].adjustFrame(angle);
        }
    }

    public override AngleInfo getAngleInfoP()
    {
        return this.animationInterfaceArray[0].getAngleInfoP();
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

