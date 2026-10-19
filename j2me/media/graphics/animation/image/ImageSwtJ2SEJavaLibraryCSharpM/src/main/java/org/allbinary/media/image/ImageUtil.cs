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
using SWT = org.eclipse.swt.SWT;
using Canvas = org.eclipse.swt.widgets.Canvas;
using Composite = org.eclipse.swt.widgets.Composite;
using GC = org.eclipse.swt.graphics.GC;
using ImageData = org.eclipse.swt.graphics.ImageData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using PaintEvent = org.eclipse.swt.events.PaintEvent;
using PaintListener = org.eclipse.swt.events.PaintListener;
using Transform = org.eclipse.swt.graphics.Transform;
using Display = org.eclipse.swt.widgets.Display;
using BareMain = org.microemu.app.BareMain;

namespace org.allbinary.media.image;

public class ImageUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageUtil instance = new ImageUtil();
    public static ImageUtil getInstance()
    {
        return ImageUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private string IIOIMAGE_POOL_NAME = "IIOIMAGE_POOL_NAME";
    private readonly string CREATE_BUFFERED_IMAGE = "createBufferedImage";
    private ImageUtil()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
    }

    public virtual org.eclipse.swt.graphics.Image create(int width, int height)
    {
        Display display = BareMain.shell.getDisplay();
        return new org.eclipse.swt.graphics.Image(display, width, height);
    }

    // throws Exception
    public virtual org.eclipse.swt.graphics.Image[] createBufferedImage(org.eclipse.swt.graphics.Image[] bufferedImageArray, int percent, bool scale)
    {
        int size = bufferedImageArray.Length;
        org.eclipse.swt.graphics.Image[] scaledBufferedImageArray = new org.eclipse.swt.graphics.Image[size];
        org.eclipse.swt.graphics.Image bufferedImage = null;
        ImageData imageData = null;
        for (int index = 0; index < size; index++) {
            bufferedImage = bufferedImageArray[index];
            imageData = bufferedImage.getImageData();
            int newWidth = ((int) (imageData.width * percent / 100));
            int newHeight = ((int) (imageData.height * percent / 100));
            scaledBufferedImageArray[index] = this.createBufferedImage5(bufferedImage, newWidth, newHeight, scale);
        }
        return scaledBufferedImageArray;
    }

    // throws Exception
    public virtual org.eclipse.swt.graphics.Image[] createBufferedImage2(org.eclipse.swt.graphics.Image[] bufferedImageArray, float percent, bool scale)
    {
        int size = bufferedImageArray.Length;
        org.eclipse.swt.graphics.Image[] scaledBufferedImageArray = new org.eclipse.swt.graphics.Image[size];
        org.eclipse.swt.graphics.Image bufferedImage = null;
        ImageData imageData = null;
        for (int index = 0; index < size; index++) {
            bufferedImage = bufferedImageArray[index];
            imageData = bufferedImage.getImageData();
            int newWidth = ((int) (imageData.width * percent));
            int newHeight = ((int) (imageData.height * percent));
            scaledBufferedImageArray[index] = this.createBufferedImage5(bufferedImage, newWidth, newHeight, scale);
        }
        return scaledBufferedImageArray;
    }

    // throws Exception
    public virtual org.eclipse.swt.graphics.Image[] createBufferedImage3(org.eclipse.swt.graphics.Image[] bufferedImageArray, int width, int height, bool scale)
    {
        int size = bufferedImageArray.Length;
        org.eclipse.swt.graphics.Image[] scaledBufferedImageArray = new org.eclipse.swt.graphics.Image[size];
        for (int index = 0; index < size; index++) {
            scaledBufferedImageArray[index] = this.createBufferedImage5(bufferedImageArray[index], width, height, scale);
        }
        return scaledBufferedImageArray;
    }

    // throws Exception
    public virtual org.eclipse.swt.graphics.Image createBufferedImage4(org.eclipse.swt.graphics.Image bufferedImage, int newWidth, int newHeight)
    {
        return this.createBufferedImage5(bufferedImage, newWidth, newHeight, true);
    }

    // throws Exception
    public virtual org.eclipse.swt.graphics.Image createBufferedImage5(org.eclipse.swt.graphics.Image bufferedImage, int newWidth, int newHeight, bool scale)
    {
        return this.createBufferedImage6(bufferedImage, newWidth, newHeight, scale, false);
    }

    // throws Exception
    public virtual org.eclipse.swt.graphics.Image createBufferedImage6(org.eclipse.swt.graphics.Image bufferedImage, int newWidth, int newHeight, bool scale, bool allowTranslate)
    {
        ImageData imageData = bufferedImage.getImageData();
        float width = imageData.width;
        float height = imageData.height;
        float d_newWidth = ((float) newWidth);
        float d_newHeight = ((float) newHeight);
        float widthRatio = d_newWidth / width;
        float heightRatio = d_newHeight / height;
        float ratioX = 1.0f;
        float ratioY = 1.0f;
        if (scale) {
            ratioX = widthRatio;
            ratioY = heightRatio;
        }
        this.logUtil.putF(new StringMaker().appendfloat(width).append(this.commonSeps.FORWARD_SLASH).appendfloat(height).append(this.commonSeps.COLON).appendint(newWidth).append(this.commonSeps.FORWARD_SLASH).appendint(newHeight).append(this.commonSeps.COLON).appendfloat(widthRatio).append(this.commonSeps.FORWARD_SLASH).appendfloat(heightRatio).ToString(), this, this.CREATE_BUFFERED_IMAGE);
        float dx = 0f;
        float dy = 0f;
        if (!scale && allowTranslate) {
            dx = (((float) newWidth) - width) / 2f;
            dy = (((float) newHeight) - height) / 2f;
            this.logUtil.putF(new StringMaker().append("Translate dx: ").appendfloat(dx).append(" dy: ").appendfloat(dy).ToString(), this, this.CREATE_BUFFERED_IMAGE);
        }
        org.eclipse.swt.graphics.Image newBufferedImage = new org.eclipse.swt.graphics.Image(BareMain.shell.getDisplay(), newWidth, newHeight);
        GC gc = new GC(newBufferedImage);
        Transform affineTransform = new Transform(gc.getDevice());
        affineTransform.scale(ratioX, ratioY);
        affineTransform.translate(dx, dy);
        gc.setTransform(affineTransform);
        gc.setAntialias(SWT.ON);
        gc.setInterpolation(SWT.HIGH);
        gc.drawImage(bufferedImage, 0, 0, bufferedImage.getBounds().width, bufferedImage.getBounds().height, 0, 0, newWidth, newHeight);
        gc.dispose();
        return newBufferedImage;
    }

    public virtual Canvas drawTransformedImage(org.eclipse.swt.graphics.Image image, Composite parent, int dx, int dy, int width, int height)
    {
        Canvas imageCanvas = new Canvas(parent, SWT.NONE);
        imageCanvas.addPaintListener(new PaintListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void paintControl(PaintEvent @event)
            {
                GC gc = @event.gc;
                Transform affineTransform = new Transform(gc.getDevice());
                affineTransform.translate(dx, dy);
                gc.setAntialias(SWT.ON);
                gc.setInterpolation(SWT.HIGH);
                gc.drawImage(image, 0, 0, image.getBounds().width, image.getBounds().height, 0, 0, width, height);
            }

#endif
);
        return imageCanvas;
    }

    public virtual string toString(org.eclipse.swt.graphics.Image bufferedImage)
    {
        CommonLabels commonLabels = CommonLabels.getInstance();
        StringMaker stringBuffer = new StringMaker();
        ImageData imageData = bufferedImage.getImageData();
        stringBuffer.append(" org.eclipse.swt.graphics.Image: ");
        stringBuffer.append(commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(((int) imageData.width));
        stringBuffer.append(commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(((int) imageData.height));
        stringBuffer.append(" Type: ");
        stringBuffer.appendint(((int) imageData.type));
        return stringBuffer.ToString();
    }

}

