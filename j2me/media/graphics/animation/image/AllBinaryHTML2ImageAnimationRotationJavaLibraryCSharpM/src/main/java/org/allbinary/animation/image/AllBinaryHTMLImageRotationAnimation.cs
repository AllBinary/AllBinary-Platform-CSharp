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
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using AngleInfo = org.allbinary.math.AngleInfo;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using ImageCopyUtil = org.allbinary.media.image.ImageCopyUtil;
using ImageModifierUtil = org.allbinary.media.image.ImageModifierUtil;
using ImageRotationUtil = org.allbinary.media.image.ImageRotationUtil;
using PlaynMutableImage = org.microemu.device.playn.PlaynMutableImage;
using Canvas = playn.core.Canvas;
using ImageImpl = playn.core.ImageImpl;
using PlayN = playn.core.PlayN;
using HtmlGraphics = playn.html.HtmlGraphics;
using HtmlImage = playn.html.HtmlImage;

namespace org.allbinary.animation.image;

public class AllBinaryHTMLImageRotationAnimation : ImageBaseRotationAnimation
{
    private readonly ImageRotationUtil imageRotationUtil = ImageRotationUtil.getInstance();
    private readonly ImageModifierUtil imageModifierUtil = ImageModifierUtil.getInstanceOrCreate();
    private readonly Image originalImage;
    private readonly Image[] twoImages = new Image[2];
    private readonly Canvas[] canvasSurfaceArray = new Canvas[2];
    private Image imageToShow;
    private int bufferedImageIndex = 0;
    private AlphaBaseProcessor alphaProcessor = AlphaBaseProcessor.getInstance();
    public AllBinaryHTMLImageRotationAnimation(Image originalImage, Image image, AngleInfo angleInfo, short totalAngle, AnimationBehavior animationBehavior) : base(image, angleInfo, totalAngle, animationBehavior)
    {
        // base(image, angleInfo, totalAngle, animationBehavior) is called from the constructor declaration
        this.originalImage = originalImage;
        this.imageToShow = image;
        this.twoImages[0] = image;
        this.twoImages[1] = ImageCopyUtil.getInstance().createImage(image);
        this.canvasSurfaceArray[0] = this.getCanvasSurface(this.twoImages[0]);
        this.canvasSurfaceArray[1] = this.getCanvasSurface(this.twoImages[1]);
    }

    public virtual Canvas getCanvasSurface(Image image)
    {
        PlaynMutableImage htmlImage = ((PlaynMutableImage) image);
        ImageImpl canvasImage = ((ImageImpl) htmlImage.getImage());
        PlayN playN = PlayN.getInstance();
        Canvas canvas = (((HtmlGraphics) playN.graphics())).get(((HtmlImage) canvasImage));
        canvas.translate(this.originalImage.getWidth() / 2, this.originalImage.getHeight() / 2);
        return canvas;
    }

    public virtual void setBasicColorP(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getBasicColorP() == null || ((int) this.getBasicColorP()) != basicColor.intValue()) {
            changed = true;
        }
        base.setBasicColorP(basicColor);
        if (changed) {
            this.updateImage();
        }
    }

    public virtual void setAlpha(int alpha)
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

    public virtual void nextRotation()
    {
        base.nextRotation();
        this.updateImage();
    }

    public virtual void previousRotation()
    {
        base.previousRotation();
        this.updateImage();
    }

    private void updateImage()
    {
        Canvas canvasSurface = this.canvasSurfaceArray[this.bufferedImageIndex];
        canvasSurface.save();
        this.imageRotationUtil.rotateImageCanvasSurfaceClear(this.originalImage, this.twoImages[this.bufferedImageIndex], canvasSurface, this.angleInfo.getAngle() + 90);
        this.alphaProcessor.setAlpha(this.imageModifierUtil, this.originalImage, this.twoImages[this.bufferedImageIndex], this.alphaP);
        this.imageRotationUtil.drawImage(this.originalImage, imageToShow, canvasSurface);
        canvasSurface.restore();
        this.swap();
    }

    public virtual void setFrame(int index)
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

    public virtual void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawImage(this.imageToShow, x, y, this.anchor);
    }

}

