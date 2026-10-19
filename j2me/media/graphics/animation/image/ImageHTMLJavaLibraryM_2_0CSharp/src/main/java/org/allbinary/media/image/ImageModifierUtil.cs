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
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
using Anchor = org.allbinary.graphics.Anchor;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using PlaynImage = org.microemu.device.playn.PlaynImage;
using ResourceCallbackStrings = org.microemu.device.ResourceCallbackStrings;
using Callback = playn.core.Callback;
using Canvas = playn.core.Canvas;
using CoreImage = playn.core.CoreImage;
using ImageImpl = playn.core.ImageImpl;
using HTMLPlaynUtil = playn.html.HTMLPlaynUtil;

namespace org.allbinary.media.image;

public class ImageModifierUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static ImageModifierUtil getInstanceOrCreate()
    {
        return new ImageModifierUtil();
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ResourceCallbackStrings resourceCallbackStrings = ResourceCallbackStrings.getInstance();
    private readonly HTMLPlaynUtil playnUtil = HTMLPlaynUtil.getInstance();
    private bool[] alphaArray = null;
    public virtual void setColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
    }

    public virtual void changeColor(Image unusedOriginalImage, Image image, int imageIndex, BasicColor basicColor)
    {
    }

    public virtual void setAlpha(Image originalImage, Image image, int imageIndex, int alpha)
    {
        float alphaF = ((float) alpha);
        float alphaFloat = alphaF / 255f;
        this.setAlphaF(originalImage, image, imageIndex, alphaFloat);
    }

    public virtual void setAlphaF(Image originalImage, Image image, int imageIndex, float alpha)
    {
        if (this.alphaArray[imageIndex]) {
            this.alphaArray[imageIndex] = false;
            this.setAlpha2(originalImage, image, imageIndex, alpha);
        }
    }

    public virtual void setAlpha2(Image originalImage, Image image, int imageIndex, float alpha)
    {
        PlaynImage htmlImage = ((PlaynImage) image);
        ImageImpl canvasImage = ((ImageImpl) htmlImage.getImage());
        CoreImage originalPlaynImage = ((CoreImage) (((PlaynImage) originalImage)).getImage());
        Canvas canvas = this.playnUtil.getCanvas(canvasImage);
        canvas.clear();
        canvas.setAlpha(alpha);
        canvas.draw(originalPlaynImage, 0, 0);
    }

    public virtual void setAlpha3(Image image, float alpha)
    {
        float alphaF = alpha;
        float alphaFloat = alphaF / 255f;
        PlaynImage htmlImage = ((PlaynImage) image);
        ImageImpl canvasImage = ((ImageImpl) htmlImage.getImage());
        Canvas canvas = this.playnUtil.getCanvas(canvasImage);
        canvas.setAlpha(alphaFloat);
    }

    public virtual Image[] getImageArray(Image[] originalImageArray)
    {
        int size = originalImageArray.Length;
        this.alphaArray = new bool[size];
        Image[] imageArray = new Image[size];
        for (int index = 0; index < size; index++) {
            imageArray[index] = originalImageArray[index];
            this.handleImage(imageArray, index, originalImageArray[index]);
        }
        return imageArray;
    }

    public virtual void handleImage(Image[] imageArray, int index, Image image)
    {
        CoreImage image3 = ((CoreImage) (((PlaynImage) image)).getImage());
        if (image3 != null) {
            if (image3.isReady() || image3.width() + image3.height() <= 0 || image.getName() == this.resourceCallbackStrings.FROM_DATA) {
                this.copy(imageArray, index, image, image3);
            } else {
                Callback callback = new Callback()
#if JAVA_ANONYMOUS_CLASS_BODY
                    public virtual void onSuccess(object resource)
                    {
                        LogUtil logUtil = LogUtil.getInstance();
                        logUtil.putF(resourceCallbackStrings.DONE + image.getName(), this, resourceCallbackStrings.HANDLE_IMAGE);
                        copy(imageArray, index, image, image3);
                    }

                    public virtual void onFailure(Exception e)
                    {
                        LogUtil logUtil = LogUtil.getInstance();
                        logUtil.put(new StringMaker().append(commonStrings.EXCEPTION_LABEL).append(resourceCallbackStrings.ERROR).append(image.getName()).ToString(), this, resourceCallbackStrings.HANDLE_IMAGE, e);
                    }

#endif
;
                image3.addCallback(callback);
            }
        } else {
            this.logUtil.putF(this.resourceCallbackStrings.NULL + image.isMutable(), this, this.resourceCallbackStrings.HANDLE_IMAGE);
        }
    }

    public virtual void copy(Image[] imageArray, int index, Image image, CoreImage image3)
    {
        try {
            Image image2 = Image.createImageWH(((int) image3.width()), ((int) image3.height()));
            Graphics graphics = image2.getGraphics();
            graphics.drawImage(image, 0, 0, Anchor.TOP_LEFT);
            imageArray[index] = image2;
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION_LABEL + resourceCallbackStrings.DONE, this, resourceCallbackStrings.HANDLE_IMAGE);
        }
    }

    public virtual void reset()
    {
        int size = this.alphaArray.Length;
        for (int index = 0; index < size; index++) {
            this.alphaArray[index] = true;
        }
    }

}

