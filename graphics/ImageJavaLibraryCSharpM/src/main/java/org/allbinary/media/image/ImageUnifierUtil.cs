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

public class ImageUnifierUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageUnifierUtil instance = new ImageUnifierUtil();
    public static ImageUnifierUtil getInstance()
    {
        return ImageUnifierUtil.instance;
    }

    private readonly ImageUtil imageUtil = ImageUtil.getInstance();
    private ImageUnifierUtil()
    {
    }

    public virtual GraphicsConfiguration getDefaultConfiguration()
    {
        GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
        GraphicsDevice gd = ge.getDefaultScreenDevice();
        return gd.getDefaultConfiguration();
    }

    public virtual BufferedImage getImage(BufferedImage[] bufferedImageArray, ImageUnifierProperties imageUnifierProperties)
    {
        BufferedImage newBufferedImage = this.imageUtil.create(imageUnifierProperties.getWidth(), imageUnifierProperties.getHeight());
        CommonLabels commonLabels = CommonLabels.getInstance();
        this.logUtil.putF("Setting Image - " + commonLabels.WIDTH_LABEL + newBufferedImage.getWidth() + commonLabels.HEIGHT_LABEL + newBufferedImage.getHeight(), this, "getImage");
        Graphics2D g = newBufferedImage.createGraphics();
        int columnIndex = 0;
        int rowIndex = 0;
        for (int index = 0; index < bufferedImageArray.Length; index++) {
            int x = ((int) imageUnifierProperties.getImageUnifierCell().getWidth()) * columnIndex++;
            int y = ((int) imageUnifierProperties.getImageUnifierCell().getHeight()) * rowIndex;
            this.logUtil.putF("Adding Image: " + index + " x: " + x + " y: " + y, this, "getImage");
            g.drawImage(bufferedImageArray[index], x, y, ((int) imageUnifierProperties.getImageUnifierCell().getWidth()), ((int) imageUnifierProperties.getImageUnifierCell().getHeight()), null);
            int totalColumnsMinusOne = (((int) imageUnifierProperties.getColumns()) - 1);
            if (columnIndex > totalColumnsMinusOne) {
                rowIndex++;
                columnIndex = 0;
            }
        }
        g.dispose();
        return newBufferedImage;
    }

}

