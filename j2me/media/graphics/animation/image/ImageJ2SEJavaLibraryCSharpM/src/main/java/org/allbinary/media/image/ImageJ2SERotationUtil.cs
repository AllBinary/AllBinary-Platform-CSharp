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
//using Graphics2D = java.awt.Graphics2D;
//using Image = java.awt.Image;
//using BufferedImage = java.awt.image.BufferedImage;

namespace org.allbinary.media.image;

public class ImageJ2SERotationUtil
{
    private static readonly ImageJ2SERotationUtil instance = new ImageJ2SERotationUtil();
    public static ImageJ2SERotationUtil getInstance()
    {
        return ImageJ2SERotationUtil.instance;
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    private readonly ImageJ2SEUtil imageJ2SEUtil = ImageJ2SEUtil.getInstance();
    private ImageJ2SERotationUtil()
    {
    }

    public virtual BufferedImage getRotatedImage(Image bufferedImage, int totalAngle)
    {
        return this.getRotatedImageRadians(bufferedImage, TWO_PIE * ((double) totalAngle) / 360.0);
    }

    public virtual BufferedImage getRotatedImageRadians(Image bufferedImage, double radians)
    {
        BufferedImage newBufferedImage = this.imageUtil.create(bufferedImage.getWidth(null), bufferedImage.getHeight(null));
        return this.drawRotatedImageRadians(bufferedImage, newBufferedImage, newBufferedImage.createGraphics(), radians);
    }

    private BufferedImage drawRotatedImageRadians(Image bufferedImage, BufferedImage newBufferedImage, Graphics2D g, double radians)
    {
        g.rotate(radians, newBufferedImage.getWidth(null) / 2, newBufferedImage.getHeight(null) / 2);
        g.drawImage(bufferedImage, 0, 0, bufferedImage.getWidth(null), bufferedImage.getHeight(null), null);
        g.dispose();
        return newBufferedImage;
    }

    private readonly double TWO_PIE = 2 * Math.PI;
    public virtual BufferedImage rotateImage(Image bufferedImage, BufferedImage newBufferedImage, int totalAngle)
    {
        Graphics2D g = newBufferedImage.createGraphics();
        g.setBackground(this.imageJ2SEUtil.TRANSPARENT_COLOR);
        g.clearRect(0, 0, newBufferedImage.getWidth(), newBufferedImage.getHeight());
        return this.drawRotatedImageRadians(bufferedImage, newBufferedImage, g, TWO_PIE * ((double) totalAngle) / 360.0);
    }

    public virtual BufferedImage createRotatedImage(Image bufferedImage, BufferedImage newBufferedImage, int totalAngle)
    {
        Graphics2D g = newBufferedImage.createGraphics();
        return this.drawRotatedImageRadians(bufferedImage, newBufferedImage, g, TWO_PIE * ((double) totalAngle) / 360.0);
    }

    public virtual BufferedImage[] getRotatedImages(Image bufferedImage, int numberOfFrames, int totalAngle)
    {
        BufferedImage[] bufferedImageArray = new BufferedImage[numberOfFrames];
        double arc = (this.TWO_PIE) * ((double) totalAngle) / 360.0;
        int size = bufferedImageArray.Length;
        for (int index = 0; index < size; index++) {
            double radians = (arc / ((double) size)) * ((double) index);
            bufferedImageArray[index] = this.getRotatedImageRadians(bufferedImage, radians);
        }
        return bufferedImageArray;
    }

    public virtual BufferedImage createSpriteImage(BufferedImage[] bufferedImageArray)
    {
        int columns = 9;
        int rows = 0;
        int size = bufferedImageArray.Length;
        if (size < columns) {
            columns = size;
        }
        rows = (size / columns);
        if (size % columns != 0) {
            rows++;
        }
        BufferedImage firstBufferedImage = bufferedImageArray[0];
        BufferedImage bufferedImage = this.imageUtil.create(firstBufferedImage.getWidth(null) * columns, firstBufferedImage.getHeight(null) * rows);
        Graphics2D g = bufferedImage.createGraphics();
        int columnIndex = 0;
        int rowIndex = 0;
        BufferedImage nextBufferedImage = null;
        for (int index = 0; index < size; index++) {
            if (index / 9 != 0 && index % 9 == 0) {
                rowIndex++;
                columnIndex = 0;
            }
            nextBufferedImage = bufferedImageArray[index];
            g.drawImage(nextBufferedImage, nextBufferedImage.getWidth(null) * columnIndex, nextBufferedImage.getHeight(null) * rowIndex, nextBufferedImage.getWidth(null), nextBufferedImage.getHeight(null), null);
            columnIndex++;
        }
        g.dispose();
        return bufferedImage;
    }

}

