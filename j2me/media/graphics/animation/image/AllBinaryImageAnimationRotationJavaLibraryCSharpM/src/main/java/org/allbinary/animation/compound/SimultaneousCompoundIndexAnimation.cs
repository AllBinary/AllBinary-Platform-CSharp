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
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.compound;

public class SimultaneousCompoundIndexAnimation : IndexedAnimation
{
    private IndexedAnimation[] animationInterfaceArray;
    public SimultaneousCompoundIndexAnimation(IndexedAnimation[] animationInterfaceArray, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
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

    // throws Exception
    public override void set(GL gl)
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].set(gl);
        }
    }

    public virtual IndexedAnimation[] getAnimationInterfaceArray()
    {
        return this.animationInterfaceArray;
    }

    public virtual void setAnimationInterfaceArray(IndexedAnimation[] animationInterfaceArray)
    {
        this.animationInterfaceArray = animationInterfaceArray;
    }

}

