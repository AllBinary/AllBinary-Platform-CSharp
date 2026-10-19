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
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using IndexedAnimationBehavior = org.allbinary.animation.IndexedAnimationBehavior;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.special;

public class TitleAnimation : SpecialAnimation
{
    public readonly ABSystemWrapper systemWrapper = ABSystemWrapper.getInstance();
    public float deltaX = 0f;
    public float deltaY = 0f;
    public float deltaZ = 0f;
    public readonly BasicColor[] basicColorArray;
    public readonly int[] dxArray;
    public readonly int[] dyArray;
    public readonly int widthP;
    public readonly IndexedAnimation[] animationInterfaceArray;
    public readonly int sizeP;
    public readonly int y;
    private long lastFrameStartTime;
    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    public static TitleAnimation createAnimation(IndexedAnimation[] animationInterfaceArray, BasicColor[] basicColorArray, int[] dxArray, int[] dyArray, int y, int width)
    {
        return new TitleAnimation(animationInterfaceArray, basicColorArray, dxArray, dyArray, y, width, new IndexedAnimationBehavior(1, 250));
    }

    public TitleAnimation(IndexedAnimation[] animationInterfaceArray, BasicColor[] basicColorArray, int[] dxArray, int[] dyArray, int y, int width, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.lastFrameStartTime = this.systemWrapper.currentTimeMillis();
        this.animationInterfaceArray = animationInterfaceArray;
        this.sizeP = this.animationInterfaceArray.Length;
        this.basicColorArray = basicColorArray;
        this.dxArray = dxArray;
        this.dyArray = dyArray;
        this.y = y;
        this.widthP = width;
        this.reset();
    }

    public override void nextFrame()
    {
        long currentTime = this.systemWrapper.currentTimeMillis();
        long totalTimeElapsed = currentTime - this.lastFrameStartTime;
        IndexedAnimationBehavior indexedAnimationBehavior = ((IndexedAnimationBehavior) this.getAnimationBehavior());
        if (totalTimeElapsed > indexedAnimationBehavior.frameDelayTime) {
            this.previousFrame();
            this.lastFrameStartTime = currentTime;
        }
        if (this.animationInterfaceArray[0].getFrame() == 0) {
            indexedAnimationBehavior.loopIndex++;
        }
    }

    public override bool isComplete()
    {
        IndexedAnimationBehavior indexedAnimationBehavior = ((IndexedAnimationBehavior) this.getAnimationBehavior());
        if (indexedAnimationBehavior.loopTotal == -1 || indexedAnimationBehavior.loopIndex < indexedAnimationBehavior.loopTotal || this.getFrame() != 0) {
            return false;
        } else {
            return true;
        }
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    public override int getSize()
    {
        return this.animationInterfaceArray[0].getSize();
    }

    public override int getFrame()
    {
        return this.animationInterfaceArray[0].getFrame();
    }

    public override void setFrame(int frame)
    {
        for (int index = 0; index < this.sizeP; index++) {
            this.animationInterfaceArray[index].setFrame(frame);
        }
    }

    public override void setLastFrame()
    {
        this.setFrame(this.getSize() - 1);
    }

    public override void reset()
    {
        this.setLastFrame();
        IndexedAnimationBehavior indexedAnimationBehavior = (((IndexedAnimationBehavior) this.getAnimationBehavior()));
        indexedAnimationBehavior.reset();
    }

    public override void previousFrame()
    {
        for (int index = 0; index < this.sizeP; index++) {
            this.animationInterfaceArray[index].previousFrame();
        }
    }

    public virtual void paintFrameXY(Graphics graphics, int frame, int x, int y)
    {
        this.setFrame(frame);
        this.paintXY(graphics, x, y);
    }

    public readonly BasicColor CLEAR_COLOR = BasicColorFactory.getInstance().CLEAR_COLOR;
    public override void paintXY(Graphics graphics, int ax, int ay)
    {
        int x = 0;
        if (this.widthP != Integer.MIN_VALUE) {
            x = ((this.displayInfoSingleton.getLastWidth() - this.widthP) / 2);
        }
        int deltaX = 0;
        int deltaY = 0;
        for (int index = 0; index < this.sizeP; index++) {
            deltaX = this.dxArray[index] + x;
            deltaY = this.dyArray[index] + this.y;
            if (this.basicColorArray[index] != this.CLEAR_COLOR) {
                this.basicSetColorUtil.setBasicColorP(graphics, this.basicColorArray[index]);
            }
            this.animationInterfaceArray[index].paintXY(graphics, deltaX, deltaY);
        }
    }

}

