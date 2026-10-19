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
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.media.image;

public class ImagesRatioUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImagesRatioUtil instance = new ImagesRatioUtil();
    public static ImagesRatioUtil getInstance()
    {
        return ImagesRatioUtil.instance;
    }

    private ImagesRatioUtil()
    {
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    public virtual bool isEqual(BufferedImage[] bufferedImageArray, int totalImages)
    {
        int end = totalImages;
        if (bufferedImageArray.Length < totalImages) {
            end = bufferedImageArray.Length;
        }
        double ratio = (((double) bufferedImageArray[0].getWidth()) / bufferedImageArray[0].getHeight());
        for (int index = 1; index < end; index++) {
            if (ratio != (((double) bufferedImageArray[index].getWidth()) / bufferedImageArray[index].getHeight())) {
                return false;
            }
        }
        return true;
    }

    public virtual double getAverage(BufferedImage[] bufferedImageArray, int totalImages)
    {
        double ratio = 0.0;
        int end = totalImages;
        if (bufferedImageArray.Length < totalImages) {
            end = bufferedImageArray.Length;
        }
        for (int index = 0; index < end; index++) {
            ratio += (((double) bufferedImageArray[index].getWidth()) / bufferedImageArray[index].getHeight());
        }
        return (ratio / ((double) end));
    }

    // throws Exception
    public virtual BufferedImage fudge(BufferedImage bufferedImage, double ratio)
    {
        double imageRatio = (((double) bufferedImage.getWidth()) / bufferedImage.getHeight());
        Point point = new Point();
        int newHeight = bufferedImage.getHeight();
        int newWidth = bufferedImage.getWidth();
        if (ratio > imageRatio) {
            newWidth = ((int) (((double) bufferedImage.getHeight()) * ratio));
            point.x = (newWidth - bufferedImage.getWidth()) / 2;
        } else {
            newHeight = ((int) (((double) bufferedImage.getWidth()) / ratio));
            point.y = (newHeight - bufferedImage.getHeight()) / 2;
        }
        CommonLabels commonLabels = CommonLabels.getInstance();
        this.logUtil.putF(commonLabels.WIDTH_LABEL + bufferedImage.getWidth() + " newWidth: " + newWidth + commonLabels.HEIGHT_LABEL + bufferedImage.getHeight() + " newHeight: " + newHeight + " needed ratio: " + (((double) newWidth) / ((double) newHeight)), this, "fudge");
        BufferedImage newBufferedImage = this.imageUtil.create(newWidth, newHeight);
        Graphics2D g = newBufferedImage.createGraphics();
        if (point.x > 0) {
            BufferedImage firstColumnBufferedImage = bufferedImage.getSubimage(0, 0, 1, bufferedImage.getHeight());
            BufferedImage lastColumnBufferedImage = bufferedImage.getSubimage(bufferedImage.getWidth() - 1, 0, 1, bufferedImage.getHeight());
            this.logUtil.putF("Draw some columns to fill in gap", this, "fudge");
            for (int index = 0; index < point.x; index++) {
                g.drawImage(firstColumnBufferedImage, index, 0, null);
                g.drawImage(lastColumnBufferedImage, newWidth - index, 0, null);
            }
        }
        if (point.y > 0) {
            BufferedImage firstRowBufferedImage = bufferedImage.getSubimage(0, 0, bufferedImage.getWidth(), 1);
            BufferedImage lastRowBufferedImage = bufferedImage.getSubimage(0, bufferedImage.getHeight() - 1, bufferedImage.getWidth(), 1);
            this.logUtil.putF("Draw some rows to fill in gap", this, "fudge");
            for (int index = 0; index < point.y; index++) {
                g.drawImage(firstRowBufferedImage, 0, index, null);
                g.drawImage(lastRowBufferedImage, 0, newHeight - index, null);
            }
        }
        g.drawImage(bufferedImage, point.x, point.y, bufferedImage.getWidth(), bufferedImage.getHeight(), null);
        return newBufferedImage;
    }

    // throws Exception
    public virtual BufferedImage[] fudge(BufferedImage[] bufferedImageArray, int totalImages, double ratio)
    {
        int end = totalImages;
        if (bufferedImageArray.Length < totalImages) {
            end = bufferedImageArray.Length;
        }
        BufferedImage[] fudgedBufferedImageArray = new BufferedImage[end];
        for (int index = 0; index < end; index++) {
            fudgedBufferedImageArray[index] = fudge(bufferedImageArray[index], ratio);
        }
        return fudgedBufferedImageArray;
    }

}

