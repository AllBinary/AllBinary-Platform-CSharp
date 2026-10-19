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
using Animation = org.allbinary.animation.Animation;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.compound;

public class SimultaneousCompoundIndexedAnimation : IndexedAnimation
{
    private Animation[] animationInterfaceArray;
    public SimultaneousCompoundIndexedAnimation(Animation[] animationInterfaceArray, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.animationInterfaceArray = animationInterfaceArray;
    }

    public override void setFrame(int frameIndex)
    {
        IndexedAnimation indexedAnimation = null;
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[index]);
            indexedAnimation.setFrame(frameIndex);
        }
    }

    public override int getFrame()
    {
        IndexedAnimation indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[0]);
        return indexedAnimation.getFrame();
    }

    public override int getSize()
    {
        IndexedAnimation indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[0]);
        return indexedAnimation.getSize();
    }

    public override void previousFrame()
    {
        IndexedAnimation indexedAnimation = null;
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[index]);
            indexedAnimation.previousFrame();
        }
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    // throws Exception
    public override void nextFrame()
    {
        for (int index = this.animationInterfaceArray.Length; --index >= 0; ) {
            this.animationInterfaceArray[index].nextFrame();
        }
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        int size = this.animationInterfaceArray.Length;
        for (int index = 0; index < size; index++) {
            this.animationInterfaceArray[index].paintXY(graphics, x, y);
        }
    }

    public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
        int size = this.animationInterfaceArray.Length;
        for (int index = 0; index < size; index++) {
            this.animationInterfaceArray[index].paintThreedXYZ(graphics, x, y, z);
        }
    }

    public virtual Animation[] getAnimationInterfaceArray()
    {
        return this.animationInterfaceArray;
    }

    public virtual void setAnimationInterfaceArray(Animation[] animationInterfaceArray)
    {
        this.animationInterfaceArray = animationInterfaceArray;
    }

}

