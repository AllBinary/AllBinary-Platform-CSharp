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
//using Graphics = javax.microedition.lcdui.Graphics;
using AngleInfo = org.allbinary.math.AngleInfo;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using AndroidImageUtil = org.allbinary.media.image.AndroidImageUtil;
using ImageCopyUtil = org.allbinary.media.image.ImageCopyUtil;
using ImageModifierUtil = org.allbinary.media.image.ImageModifierUtil;

namespace org.allbinary.animation.image;

public class AllBinaryNoFlickerAndroidImageRotationAnimation : ImageBaseRotationAnimation
{
    private readonly ImageModifierUtil imageModifierUtil = ImageModifierUtil.getInstanceOrCreate();
    private readonly AndroidImageUtil androidImageUtil = AndroidImageUtil.getInstance();
    private readonly Matrix matrix = new Matrix();
    private readonly int halfWidth;
    private readonly int halfHeight;
    private readonly short increment;
    private readonly Image originalImage;
    private readonly Image[] twoImages = new Image[2];
    private Image imageToShow;
    private int bufferedImageIndex = 0;
    protected AllBinaryNoFlickerAndroidImageRotationAnimation(Image originalImage, Image image, AngleInfo angleInfo, short totalAngle, AnimationBehavior animationBehavior) : base(image, angleInfo, totalAngle, animationBehavior)
    {
        // base(image, angleInfo, totalAngle, animationBehavior) is called from the constructor declaration
        this.originalImage = originalImage;
        this.halfWidth = (image.getWidth() >> 1);
        this.halfHeight = (image.getHeight() >> 1);
        this.increment = ((short) (this.angleInfo.getAngleIncrementInfo().getAngleIncrement()));
        this.imageToShow = image;
        this.twoImages[0] = image;
        this.twoImages[1] = ImageCopyUtil.getInstance().createImage(image);
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getBasicColorP() == null || ((int) this.getBasicColorP()) != ((int) basicColor)) {
            this.imageModifierUtil.setColor(this.originalImage, this.imageToShow, 0, basicColor);
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
        this.imageModifierUtil.setAlpha(this.originalImage, this.imageToShow, 0, this.alphaP);
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
        this.androidImageUtil.rotate(this.twoImages[this.bufferedImageIndex], originalImage, matrix, imageModifierUtil.paint);
        this.swap();
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

    public virtual void swap()
    {
        this.imageToShow = this.twoImages[this.bufferedImageIndex];
        if (this.bufferedImageIndex == 0) {
            this.bufferedImageIndex = 1;
        } else {
            this.bufferedImageIndex = 0;
        }
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawImage(this.imageToShow, x, y, this.anchor);
    }

}

