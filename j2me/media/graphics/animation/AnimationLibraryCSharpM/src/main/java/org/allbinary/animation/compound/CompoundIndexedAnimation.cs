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
using Animation = org.allbinary.animation.Animation;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.compound;

public class CompoundIndexedAnimation : IndexedAnimation, CompoundAnimationInterface
{
    private CircularIndexUtil circularIndexUtil;
    private Animation[] animationInterfaceArray;
    public CompoundIndexedAnimation(Animation[] animationInterfaceArray, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.animationInterfaceArray = animationInterfaceArray;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.animationInterfaceArray.Length);
    }

    public override void setFrame(int index)
    {
        IndexedAnimation indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[this.circularIndexUtil.getIndex()]);
        indexedAnimation.setFrame(index);
    }

    public override int getFrame()
    {
        IndexedAnimation indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[this.circularIndexUtil.getIndex()]);
        return indexedAnimation.getFrame();
    }

    public override int getSize()
    {
        IndexedAnimation indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[this.circularIndexUtil.getIndex()]);
        return indexedAnimation.getSize();
    }

    public override void previousFrame()
    {
        IndexedAnimation indexedAnimation = ((IndexedAnimation) this.animationInterfaceArray[this.circularIndexUtil.getIndex()]);
        indexedAnimation.previousFrame();
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
        this.animationInterfaceArray[this.circularIndexUtil.getIndex()].nextFrame();
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
        return ((IndexedAnimation) this.animationInterfaceArray[this.circularIndexUtil.getIndex()]);
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

    public virtual Animation[] getAnimationInterfaceArray()
    {
        return this.animationInterfaceArray;
    }

    public virtual void setAnimationInterfaceArray(Animation[] animationInterfaceArray)
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

