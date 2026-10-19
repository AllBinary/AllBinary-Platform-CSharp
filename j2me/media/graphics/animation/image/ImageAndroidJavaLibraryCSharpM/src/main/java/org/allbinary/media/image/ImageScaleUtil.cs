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
using Bitmap = android.graphics.Bitmap;
using Canvas = android.graphics.Canvas;
using Matrix = android.graphics.Matrix;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using Anchor = org.allbinary.graphics.Anchor;
using ImageCache = org.allbinary.image.ImageCache;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using AndroidImageInterface = org.microemu.android.device.AndroidImageInterface;

namespace org.allbinary.media.image;

public class ImageScaleUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageScaleUtil instance = new ImageScaleUtil();
    public static ImageScaleUtil getInstance()
    {
        return ImageScaleUtil.instance;
    }

    private ImageScaleUtil()
    {
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private int anchor = Anchor.TOP_LEFT;
    private readonly BasicArrayList imageBasicArrayList = new BasicArrayListD();
    private readonly BasicArrayList scaledImageBasicArrayList = new BasicArrayListD();
    private readonly BasicArrayList scaleXBasicArrayList = new BasicArrayListD();
    private readonly BasicArrayList scaleYBasicArrayList = new BasicArrayListD();
    // throws Exception
    public virtual Image createImage2(ImageCache imageCache, Image originalImage, float scaleNominatorX, float scaleDenominatorX, float scaleNominatorY, float scaleDenominatorY, bool cached)
    {
        return this.createImage3(imageCache, originalImage, scaleNominatorX, scaleDenominatorX, scaleNominatorY, scaleDenominatorY, cached, true);
    }

    // throws Exception
    public virtual Image createImage3(ImageCache imageCache, Image originalImage, float scaleNominatorX, float scaleDenominatorX, float scaleNominatorY, float scaleDenominatorY, bool cached, bool mutable)
    {
        float scaleX = scaleNominatorX / scaleDenominatorX;
        float scaleY = scaleNominatorY / scaleDenominatorY;
        return this.createImage(imageCache, originalImage, scaleX, scaleY, cached);
    }

    // throws Exception
    public virtual Image createImage(ImageCache imageCache, Image originalImage, float scaleX, float scaleY, bool cached)
    {
        AndroidImageInterface originalAndroidImage = ((AndroidImageInterface) originalImage);
        Bitmap originalBitmap = originalAndroidImage.getBitmap();
        int width = ((int) (originalBitmap.getWidth() * scaleX));
        int height = ((int) (originalBitmap.getHeight() * scaleY));
        int index = this.imageBasicArrayList.indexOf(originalImage);
        bool alreadyAvailable = false;
        if (index >= 0) {
            float? scaleX2Float = ((float?) this.scaleXBasicArrayList.get(index));
            float scaleX2 = ((float) scaleX2Float);
            float? scaleY2Float = ((float?) this.scaleYBasicArrayList.get(index));
            float scaleY2 = ((float) scaleY2Float);
            if (scaleX2 == scaleX && scaleY2 == scaleY) {
                alreadyAvailable = true;
            }
        }
        if (alreadyAvailable) {
            return ((Image) this.scaledImageBasicArrayList.get(index));
        } else {
            Image scaledImage = this.getScaledImage(imageCache, originalImage, scaleX, scaleY, width, height, cached);
            this.imageBasicArrayList.add(originalImage);
            this.scaledImageBasicArrayList.add(scaledImage);
            this.scaleXBasicArrayList.add(scaleX);
            this.scaleYBasicArrayList.add(scaleY);
            return scaledImage;
        }
    }

    // throws Exception
    private Image getScaledImage(ImageCache imageCache, Image originalImage, float scaleX, float scaleY, int width, int height, bool cached)
    {
        Image image = NullImage.NULL_IMAGE;
        if (cached) {
            image = imageCache.get(this.GetType().FullName, width, height);
        } else {
            image = imageCache.get(this.commonStrings.CREATE_IMAGE, width, height);
        }
        if (image.isMutable()) {
            Matrix matrix = new Matrix();
            this.scale(image, matrix, scaleX, scaleY);
            image.getGraphics().drawImage(originalImage, 0, 0, this.anchor);
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

    private void scale(Image image, Matrix matrix, float scaleX, float scaleY)
    {
        matrix.setScale(scaleX, scaleY);
        Canvas canvas = (((AndroidImageInterface) image)).getCanvas();
        canvas.concat(matrix);
    }

}

