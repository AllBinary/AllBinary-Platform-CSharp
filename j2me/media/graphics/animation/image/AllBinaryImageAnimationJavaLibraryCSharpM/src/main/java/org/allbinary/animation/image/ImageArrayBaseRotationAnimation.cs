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
using Graphics = javax.microedition.lcdui.Graphics;
using Image = javax.microedition.lcdui.Image;
using NullImage = javax.microedition.lcdui.NullImage;
using DisposalUtil = org.allbinary.DisposalUtil;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using Anchor = org.allbinary.graphics.Anchor;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AngleInfo = org.allbinary.math.AngleInfo;
using ImageModifierUtil = org.allbinary.media.image.ImageModifierUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.image;

public class ImageArrayBaseRotationAnimation : RotationAnimation
{
    private readonly ImageModifierUtil imageModifierUtil = ImageModifierUtil.getInstanceOrCreate();
    private readonly Image[] originalImageArray;
    private Image[] imageArray = NullImage.NULL_IMAGE_ARRAY;
    private Image currentImage;
    private int totalFrames = 0;
    public ImageArrayBaseRotationAnimation(Image[] originalImageArray, AngleInfo angleInfo, AnimationBehavior animationBehavior) : base(angleInfo, CircularIndexUtil.createInstance(360 / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior)
    {
        // Constructor invocation emitted in the initializer.
        this.originalImageArray = originalImageArray;
        this.setImageArray(this.imageModifierUtil.getImageArray(originalImageArray));
        this.currentImage = this.imageArray[this.circularIndexUtil.getIndex()];
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
    }

    public override void setAlpha(int alpha)
    {
        if (this.alphaP != alpha) {
            base.setAlpha(alpha);
            this.imageModifierUtil.reset();
            int index = this.circularIndexUtil.getIndex();
            this.imageModifierUtil.setAlpha(this.originalImageArray[index], this.imageArray[index], index, this.alphaP);
        }
    }

    public override void nextRotation()
    {
        base.nextRotation();
        int index = this.circularIndexUtil.getIndex();
        this.imageModifierUtil.setAlpha(this.originalImageArray[index], this.imageArray[index], index, this.alphaP);
        this.currentImage = this.imageArray[index];
    }

    public override void previousRotation()
    {
        base.previousRotation();
        int index = this.circularIndexUtil.getIndex();
        this.imageModifierUtil.setAlpha(this.originalImageArray[index], this.imageArray[index], index, this.alphaP);
        this.currentImage = this.imageArray[index];
    }

    public override void setFrame(int index2)
    {
        base.setFrame(index2);
        int index = this.circularIndexUtil.getIndex();
        this.imageModifierUtil.setAlpha(this.originalImageArray[index], this.imageArray[index], index, this.alphaP);
        this.currentImage = this.imageArray[index];
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    public virtual void setImageArray(Image[] imageArray)
    {
        this.imageArray = imageArray;
        this.totalFrames = imageArray.Length;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.totalFrames);
    }

    private int anchor = Anchor.TOP_LEFT;
    public override void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawImage(this.currentImage, x, y, this.anchor);
    }

    // throws Exception
    public virtual void close()
    {
        DisposalUtil disposalUtil = DisposalUtil.getInstance();
        int size2 = this.imageArray.Length;
        for (int index_0 = 0; index_0 < size2; index_0++) {
            disposalUtil.disposeImage(this.imageArray[index_0]);
        }
        int size = this.originalImageArray.Length;
        for (int index_1 = 0; index_1 < size; index_1++) {
            disposalUtil.disposeImage(this.originalImageArray[index_1]);
        }
        disposalUtil.disposeImage(this.currentImage);
    }

    // throws Throwable
    public virtual void finalize()
    {
        DisposalUtil disposalUtil = DisposalUtil.getInstance();
        int size2 = this.imageArray.Length;
        for (int index_2 = 0; index_2 < size2; index_2++) {
            disposalUtil.disposeImage(this.imageArray[index_2]);
        }
        int size = this.originalImageArray.Length;
        for (int index_3 = 0; index_3 < size; index_3++) {
            disposalUtil.disposeImage(this.originalImageArray[index_3]);
        }
        disposalUtil.disposeImage(this.currentImage);
    }

}

