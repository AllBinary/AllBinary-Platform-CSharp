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
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using Anchor = org.allbinary.graphics.Anchor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image;

public class ImageCopyUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageCopyUtil instance = new ImageCopyUtil();
    public static ImageCopyUtil getInstance()
    {
        return ImageCopyUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ImageCreationUtil imageCreationUtil = ImageCreationUtil.getInstance();
    private ImageCopyUtil()
    {
    }

    private int anchor = Anchor.TOP_LEFT;
    private readonly GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
    private readonly Features features = Features.getInstance();
    private readonly string NO_COPY = "J2ME does not need to copy images after initial loading";
    // throws Exception
    public virtual Image createImageForRotation(Image originalImage)
    {
        return this.createImage(originalImage);
    }

    // throws Exception
    public virtual Image createImage(Image originalImage)
    {
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.put(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR, new Exception());
            return originalImage;
        }
        Image image = this.imageCreationUtil.createImageWH(originalImage.getWidth(), originalImage.getHeight());
        if (image.isMutable()) {
            image.getGraphics().drawImage(originalImage, 0, 0, this.anchor);
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

    // throws Exception
    public virtual Image createImageScale(Image originalImage, float canvasScale, bool resize)
    {
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.put(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR, new Exception());
            return originalImage;
        }
        int newWidth = ((int) (originalImage.getWidth() * canvasScale));
        int newHeight = ((int) (originalImage.getHeight() * canvasScale));
        if (resize) {
            if (newWidth < newHeight) {
                newWidth = newHeight;
            }
            if (newHeight < newWidth) {
                newHeight = newWidth;
            }
        }
        Image image = this.imageCreationUtil.createImageWH(newWidth, newHeight);
        if (image.isMutable()) {
            int halfWidthDelta = (newWidth - originalImage.getWidth()) / 2;
            int halfHeightDelta = (newHeight - originalImage.getHeight()) / 2;
            Graphics graphics = image.getGraphics();
            graphics.drawImage(originalImage, halfWidthDelta, halfHeightDelta, this.anchor);
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

}

