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
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using DisposalUtil = org.allbinary.DisposalUtil;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using AngleInfo = org.allbinary.math.AngleInfo;
using ImageCopyUtil = org.allbinary.media.image.ImageCopyUtil;
using ImageModifierUtil = org.allbinary.media.image.ImageModifierUtil;
using ImageRotationUtil = org.allbinary.media.image.ImageRotationUtil;

namespace org.allbinary.animation.image;

public class AllBinaryJ2SEImageRotationAnimation : ImageBaseRotationAnimation
{
    private readonly ImageRotationUtil imageRotationUtil = ImageRotationUtil.getInstance();
    private readonly ImageModifierUtil imageModifierUtil = ImageModifierUtil.getInstanceOrCreate();
    private readonly Image realOriginalImage;
    private readonly Image[] originalImageArray = new Image[1];
    private readonly Image[] twoImages = new Image[2];
    private Image imageToShow;
    private int bufferedImageIndex = 0;
    private float lastScaleX = 1.0f;
    private float lastScaleY = 1.0f;
    private float scaleX = 1.0f;
    private float scaleY = 1.0f;
    private float maxScaleX = 0f;
    private float maxScaleY = 0f;
    private ModifierBaseProcessor alphaProcessor = ModifierBaseProcessor.getInstance();
    private ModifierBaseProcessor setColorProcessor = ModifierBaseProcessor.getInstance();
    private ModifierBaseProcessor changeColorProcessor = ModifierBaseProcessor.getInstance();
    private ScaleBaseProcessor scaleProcessor = ScaleProcessor.getInstance();
    public AllBinaryJ2SEImageRotationAnimation(Image originalImage, Image image, AngleInfo angleInfo, short totalAngle, AnimationBehavior animationBehavior) : base(image, angleInfo, totalAngle, animationBehavior)
    {
        // base(image, angleInfo, totalAngle, animationBehavior) is called from the constructor declaration
        this.realOriginalImage = originalImage;
        this.originalImageArray[0] = originalImage;
        this.imageToShow = image;
        this.twoImages[0] = image;
        this.twoImages[1] = ImageCopyUtil.getInstance().createImageForRotation(image);
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getBasicColorP() == null || ((int) this.getBasicColorP()) != basicColor.intValue()) {
            changed = true;
        }
        base.setBasicColorP(basicColor);
        if (changed) {
            this.setColorProcessor = SetColorProcessor.getInstance();
            this.updateImage();
        }
    }

    public override void changeBasicColor(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getChangeBasicColor() == null || ((int) this.getChangeBasicColor()) != basicColor.intValue()) {
            changed = true;
        }
        base.changeBasicColor(basicColor);
        if (changed) {
            this.changeColorProcessor = ChangeColorProcessor.getInstance();
            this.updateImage();
        }
    }

    public override void setAlpha(int alpha)
    {
        bool changed = false;
        if (this.alphaP != alpha) {
            changed = true;
        }
        base.setAlpha(alpha);
        if (changed) {
            this.alphaProcessor = AlphaProcessor.getInstance();
            this.updateImage();
        }
    }

    public override void setScale(float scaleX, float scaleY)
    {
        this.scaleX = scaleX;
        this.scaleY = scaleY;
        if (this.scaleX != this.lastScaleX || this.scaleY != this.lastScaleY) {
            this.scaleProcessor.update(this.realOriginalImage, this.originalImageArray, this.twoImages, this.bufferedImageIndex, this.scaleX, this.scaleY, this.maxScaleX, this.maxScaleY);
            this.updateImage();
        }
        this.lastScaleX = this.scaleX;
        this.lastScaleY = this.scaleY;
    }

    public override void setMaxScale(float maxScaleX, float maxScaleY)
    {
        this.maxScaleX = maxScaleX;
        this.maxScaleY = maxScaleY;
        this.scaleProcessor.update(this.realOriginalImage, this.originalImageArray, this.twoImages, this.bufferedImageIndex, this.scaleX, this.scaleY, this.maxScaleX, this.maxScaleY);
        this.updateImage();
    }

    public override void nextRotation()
    {
        base.nextRotation();
        this.updateImage();
    }

    public override void previousRotation()
    {
        base.previousRotation();
        this.updateImage();
    }

    private void updateImage()
    {
        this.imageRotationUtil.rotateImage(this.originalImageArray[0], this.twoImages[this.bufferedImageIndex], this.angleInfo.getAngle() + 90);
        this.alphaProcessor.updateAlpha(this.imageModifierUtil, NullImage.NULL_IMAGE, this.twoImages[this.bufferedImageIndex], 0, this.alphaP);
        this.setColorProcessor.updateColor(this.imageModifierUtil, NullImage.NULL_IMAGE, this.twoImages[this.bufferedImageIndex], 0, this.basicColor);
        this.changeColorProcessor.updateColor(this.imageModifierUtil, NullImage.NULL_IMAGE, this.twoImages[this.bufferedImageIndex], 0, this.changeBasicColorP);
        this.swap();
    }

    public override void setFrame(int index)
    {
        base.setFrame(index);
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

    // throws Exception
    public override void close()
    {
        base.close();
        DisposalUtil disposalUtil = DisposalUtil.getInstance();
        int size2 = this.twoImages.Length;
        for (int index = 0; index < size2; index++) {
            disposalUtil.disposeImage(this.twoImages[index]);
        }
        int size = this.originalImageArray.Length;
        for (int index = 0; index < size; index++) {
            disposalUtil.disposeImage(this.originalImageArray[index]);
        }
        disposalUtil.disposeImage(this.realOriginalImage);
        disposalUtil.disposeImage(this.imageToShow);
    }

    // throws Throwable
    public override void finalize()
    {
        base.finalize();
        DisposalUtil disposalUtil = DisposalUtil.getInstance();
        int size2 = this.twoImages.Length;
        for (int index = 0; index < size2; index++) {
            disposalUtil.disposeImage(this.twoImages[index]);
        }
        int size = this.originalImageArray.Length;
        for (int index = 0; index < size; index++) {
            disposalUtil.disposeImage(this.originalImageArray[index]);
        }
        disposalUtil.disposeImage(this.realOriginalImage);
        disposalUtil.disposeImage(this.imageToShow);
    }

}

