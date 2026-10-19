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
//using AffineTransform = java.awt.geom.AffineTransform;
//using AffineTransformOp = java.awt.image.AffineTransformOp;
//using BufferedImage = java.awt.image.BufferedImage;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.media.image;

public class MirrorImageUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly MirrorImageUtil instance = new MirrorImageUtil();
    public static MirrorImageUtil getInstance()
    {
        return MirrorImageUtil.instance;
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    private MirrorImageUtil()
    {
    }

    public virtual BufferedImage getImage(BufferedImage bufferedImage, bool verticle, bool horizontal)
    {
        this.logUtil.putF("Starting", this, "getImage");
        BufferedImage newBufferedImage = this.imageUtil.create(bufferedImage.getWidth(null), bufferedImage.getHeight(null));
        Graphics2D g = newBufferedImage.createGraphics();
        if (verticle) {
            AffineTransform tx = AffineTransform.getScaleInstance(1, -1);
            tx.translate(0, -bufferedImage.getHeight(null));
            AffineTransformOp op = new AffineTransformOp(tx, AffineTransformOp.TYPE_NEAREST_NEIGHBOR);
            bufferedImage = op.filter(bufferedImage, null);
        }
        if (horizontal) {
            AffineTransform tx = AffineTransform.getScaleInstance(-1, 1);
            tx.translate(-bufferedImage.getWidth(null), 0);
            AffineTransformOp op = new AffineTransformOp(tx, AffineTransformOp.TYPE_NEAREST_NEIGHBOR);
            bufferedImage = op.filter(bufferedImage, null);
        }
        g.drawImage(bufferedImage, 0, 0, bufferedImage.getWidth(null), bufferedImage.getHeight(null), null);
        g.dispose();
        return newBufferedImage;
    }

    public virtual BufferedImage[] getImages(BufferedImage bufferedImage, bool verticle, bool horizontal)
    {
        int width = bufferedImage.getWidth();
        int height = bufferedImage.getHeight();
        int cellHeight = height;
        int cellWidth = height;
        int numberOfFramesPerOrientation = width / cellWidth;
        int numberOfFrames = numberOfFramesPerOrientation;
        if (verticle) {
            numberOfFrames *= 2;
        }
        if (horizontal) {
            numberOfFrames *= 2;
        }
        this.logUtil.putF("numberOfFramesPerOrientation: " + numberOfFramesPerOrientation + " numberOfFrames: " + numberOfFrames, this, "getImages");
        BufferedImage[] bufferedImageArray = new BufferedImage[numberOfFrames];
        int y = 0;
        for (int index = 0; index < numberOfFramesPerOrientation; index++) {
            int x = index * cellWidth;
            bufferedImageArray[index] = bufferedImage.getSubimage(x, y, cellWidth, cellHeight);
        }
        for (int index = 0; index < numberOfFramesPerOrientation; index++) {
            bufferedImageArray[index + numberOfFramesPerOrientation] = this.getImage(bufferedImageArray[index], verticle, horizontal);
        }
        return bufferedImageArray;
    }

}

