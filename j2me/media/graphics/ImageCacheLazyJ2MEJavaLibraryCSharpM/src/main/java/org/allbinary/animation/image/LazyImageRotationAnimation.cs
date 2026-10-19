/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using Image = javax.microedition.lcdui.Image;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using NullRotationAnimationFactory = org.allbinary.animation.NullRotationAnimationFactory;
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using ImageCache = org.allbinary.image.ImageCache;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ScaleProperties = org.allbinary.media.ScaleProperties;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.image;

public class LazyImageRotationAnimation : RotationAnimation
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly int layoutIndex;
    public readonly int instanceId;
    public readonly BaseImageAnimationFactory animationInterfaceFactoryInterface;
    private readonly IndexedAnimation NULL_INDEX_ANIMATION;
    private IndexedAnimation animation;
    public ScaleProperties scaleProperties = ScaleProperties.instance;
    public LazyImageRotationAnimation(int layoutIndex, int instanceId, ScaleProperties scaleProperties, BaseImageAnimationFactory animationInterfaceFactoryInterface, AnimationBehavior animationBehavior) : base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior)
    {
        // base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior) is called from the constructor declaration
        this.layoutIndex = layoutIndex;
        this.instanceId = instanceId;
        this.animationInterfaceFactoryInterface = animationInterfaceFactoryInterface;
        ImageCache imageCache = ImageCacheFactory.getInstance();
        imageCache.add(this);
        this.scaleProperties = scaleProperties;
        this.NULL_INDEX_ANIMATION = ((IndexedAnimation) NullRotationAnimationFactory.getFactoryInstance().getInstance(0));
        class ActualRotationAnimation : RotationAnimation
        {
            private readonly LazyImageRotationAnimation lazyImageRotationAnimation;
            private int index = 0;
            public ActualRotationAnimation(LazyImageRotationAnimation lazyImageRotationAnimation) : base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior)
            {
                // base(AngleInfo.getInstance(AngleFactory.getInstance().QUARTER_TOTAL_ANGLE), CircularIndexUtil.createInstance(4), animationBehavior) is called from the constructor declaration
                this.lazyImageRotationAnimation = lazyImageRotationAnimation;
            }

            public override void setFrame(int index)
            {
                this.index = index;
            }

            public override int getFrame()
            {
                return this.index;
            }

            public override void paintXY(Graphics graphics, int x, int y)
            {
                try {
                    ImageCacheFactory.getInstance().insertFirst(this);
                    this.lazyImageRotationAnimation.animation = this.lazyImageRotationAnimation.NULL_INDEX_ANIMATION;
                } catch (Exception e) {
                    LogUtil logUtil = LogUtil.getInstance();
                    logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
                }
            }

            public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
            {
                try {
                    ImageCacheFactory.getInstance().insertFirst(this);
                    this.lazyImageRotationAnimation.animation = this.lazyImageRotationAnimation.NULL_INDEX_ANIMATION;
                } catch (Exception e) {
                    LogUtil logUtil = LogUtil.getInstance();
                    logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
                }
            }

        }
        this.animation = new ActualRotationAnimation(this);
    }

    private static readonly string SET_REAL_ANIMATION = "setRealAnimation";
    public virtual void setRealAnimation()
    {
        try {
            IndexedAnimation animation = this.animation;
            this.animationInterfaceFactoryInterface.setInitialScale(this.scaleProperties);
            this.animation = ((IndexedAnimation) this.animationInterfaceFactoryInterface.getInstance(this.instanceId));
            this.animation.setState(animation);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, LazyImageRotationAnimation.SET_REAL_ANIMATION, e);
        }
    }

    public override void setScale(float scaleX, float scaleY)
    {
        this.animation.setScale(scaleX, scaleY);
    }

    public override AnimationBehavior getAnimationBehavior()
    {
        return this.animation.getAnimationBehavior();
    }

    // throws Exception
    public override void set(GL gl)
    {
        this.animation.set(gl);
    }

    public override void setAlpha(int alpha)
    {
        this.animation.setAlpha(alpha);
    }

    public override void setDx(int dx)
    {
        this.animation.setDx(dx);
    }

    public override void setDy(int dy)
    {
        this.animation.setDy(dy);
    }

    public override void setMaxScale(float maxScaleX, float maxScaleY)
    {
        this.animation.setMaxScale(maxScaleX, maxScaleY);
    }

    public override void nextRotation()
    {
        RotationAnimation rotationAnimation = (((RotationAnimation) this.animation));
        rotationAnimation.nextRotation();
    }

    public override void previousRotation()
    {
        RotationAnimation rotationAnimation = (((RotationAnimation) this.animation));
        rotationAnimation.previousRotation();
    }

    public override void nextRotationX()
    {
        RotationAnimation rotationAnimation = (((RotationAnimation) this.animation));
        rotationAnimation.nextRotationX();
    }

    public override void previousRotationX()
    {
        RotationAnimation rotationAnimation = (((RotationAnimation) this.animation));
        rotationAnimation.previousRotationX();
    }

    public override void nextRotationZ()
    {
        RotationAnimation rotationAnimation = (((RotationAnimation) this.animation));
        rotationAnimation.nextRotationZ();
    }

    public override void previousRotationZ()
    {
        RotationAnimation rotationAnimation = (((RotationAnimation) this.animation));
        rotationAnimation.previousRotationZ();
    }

    public override void changeBasicColor(BasicColor basicColor)
    {
        this.animation.changeBasicColor(basicColor);
    }

    public override BasicColor getBasicColorP()
    {
        return this.animation.getBasicColorP();
    }

    public override BasicColor getChangeBasicColor()
    {
        return this.animation.getChangeBasicColor();
    }

    public override int getChangeColor()
    {
        return this.animation.getChangeColor();
    }

    public override int getColor()
    {
        return this.animation.getColor();
    }

    public override int getDx()
    {
        return this.animation.getDx();
    }

    public override int getDy()
    {
        return this.animation.getDy();
    }

    public override bool isThreed()
    {
        return this.animation.isThreed();
    }

    // throws Exception
    public override void nextFrame()
    {
        this.animation.nextFrame();
    }

    public override void reset()
    {
        this.animation.reset();
    }

    public override void setFrame(int index)
    {
        this.animation.setFrame(index);
    }

    public override int getFrame()
    {
        return this.animation.getFrame();
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.animation.getAnimationSize();
    }

    public override int getSize()
    {
        return this.animation.getSize();
    }

    public override void previousFrame()
    {
        this.animation.previousFrame();
    }

    public override bool isLastFrame()
    {
        return this.animation.isLastFrame();
    }

    public override void setSequence(int[] sequence)
    {
        this.animation.setSequence(sequence);
    }

    public override int[] getSequence()
    {
        return this.animation.getSequence();
    }

    public override int getWidth()
    {
        return this.animation.getWidth();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        try {
            this.animation.paintXY(graphics, x, y);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
        }
    }

    public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
        try {
            this.animation.paintThreedXYZ(graphics, x, y, z);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
        }
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        Image image = this.animationInterfaceFactoryInterface.getImage();
        return new StringMaker().append(base.ToString()).append(commonSeps.SPACE).append(image.getName()).append(commonSeps.SPACE).appendint(((int) image.getWidth())).append(commonSeps.SPACE).appendint(((int) image.getHeight())).ToString();
    }

}

