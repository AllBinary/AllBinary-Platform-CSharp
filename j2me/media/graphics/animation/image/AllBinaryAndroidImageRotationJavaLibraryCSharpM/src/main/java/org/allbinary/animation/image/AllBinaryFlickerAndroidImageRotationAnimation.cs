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
using Matrix = android.graphics.Matrix;
//using Image = javax.microedition.lcdui.Image;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using AngleInfo = org.allbinary.math.AngleInfo;
using AndroidImageUtil = org.allbinary.media.image.AndroidImageUtil;
using ImageModifierUtil = org.allbinary.media.image.ImageModifierUtil;

namespace org.allbinary.animation.image;

public class AllBinaryFlickerAndroidImageRotationAnimation : ImageBaseRotationAnimation
{
    private readonly ImageModifierUtil imageModifierUtil = ImageModifierUtil.getInstanceOrCreate();
    private readonly AndroidImageUtil androidImageUtil = AndroidImageUtil.getInstance();
    private readonly Matrix matrix = new Matrix();
    private readonly int halfWidth;
    private readonly int halfHeight;
    private readonly short increment;
    private readonly Image originalImage;
    public AllBinaryFlickerAndroidImageRotationAnimation(Image originalImage, Image image, AngleInfo angleInfo, short totalAngle, AnimationBehavior animationBehavior) : base(image, angleInfo, totalAngle, animationBehavior)
    {
        // base(image, angleInfo, totalAngle, animationBehavior) is called from the constructor declaration
        this.originalImage = originalImage;
        this.halfWidth = (image.getWidth() >> 1);
        this.halfHeight = (image.getHeight() >> 1);
        this.increment = ((short) (this.angleInfo.getAngleIncrementInfo().getAngleIncrement()));
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getBasicColorP() == null || ((int) this.getBasicColorP()) != ((int) basicColor)) {
            this.imageModifierUtil.setColor(this.originalImage, this.getImage(), 0, basicColor);
            changed = true;
        }
        base.setBasicColorP(basicColor);
        if (changed) {
            this.matrix.setRotate(0.0f, ((float) this.halfWidth), ((float) this.halfHeight));
            this.updateImage();
        }
    }

    public override void changeBasicColor(BasicColor basicColor)
    {
        this.setBasicColorP(basicColor);
    }

    public override void setAlpha(int alpha)
    {
        bool changed = false;
        if (this.alphaP != alpha) {
            changed = true;
        }
        base.setAlpha(alpha);
        this.imageModifierUtil.setAlpha(this.originalImage, this.getImage(), 0, this.alphaP);
        if (changed) {
            this.matrix.setRotate(0.0f, ((float) this.halfWidth), ((float) this.halfHeight));
            this.updateImage();
        }
    }

    public override void nextRotation()
    {
        base.nextRotation();
        this.matrix.setRotate(((float) this.increment), ((float) this.halfWidth), ((float) this.halfHeight));
        this.updateImage();
    }

    public override void previousRotation()
    {
        base.previousRotation();
        this.matrix.setRotate(((float) (-this.increment)), ((float) this.halfWidth), ((float) this.halfHeight));
        this.updateImage();
    }

    private void updateImage()
    {
        this.androidImageUtil.rotate(this.getImage(), originalImage, matrix, imageModifierUtil.paint);
    }

    public override void setFrame(int index)
    {
        int currentFrame = this.circularIndexUtil.getIndex();
        this.circularIndexUtil.setIndex(index);
        int newFrame = this.circularIndexUtil.getIndex();
        this.angleInfo.adjustAngle(newFrame);
        this.matrix.setRotate(((float) (newFrame - currentFrame)) * ((float) this.increment), ((float) this.halfWidth), ((float) this.halfHeight));
        this.updateImage();
    }

}

