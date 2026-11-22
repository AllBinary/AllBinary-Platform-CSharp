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

extern alias OpenGLESJavaLibraryCSharp;
using System;
using System.Linq;
using Image = javax.microedition.lcdui.Image;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using OpenGLUtil = org.allbinary.graphics.opengles.OpenGLUtil;
//using OpenGLESDeviceImageTranslate = org.allbinary.image.opengles.OpenGLESDeviceImageTranslate;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using OpenGLESImageExclusionUtil = org.allbinary.image.opengles.OpenGLESImageExclusionUtil;
using OpenGLESImageProperties = org.allbinary.image.opengles.OpenGLESImageProperties;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ImageData = org.eclipse.swt.graphics.ImageData;
using SwtDeviceComponent = org.microemu.app.ui.swt.SwtDeviceComponent;
using PostLoadSwtImmutableImageProcessor = org.microemu.device.swt.PostLoadSwtImmutableImageProcessor;
using PostLoadSwtMutableImageProcessor = org.microemu.device.swt.PostLoadSwtMutableImageProcessor;
using SwtImmutableImage = org.microemu.device.swt.SwtImmutableImage;
using SwtMutableImage = org.microemu.device.swt.SwtMutableImage;

namespace org.allbinary.media.image;

public class ImageCopyUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ImageCopyUtil instance = new ImageCopyUtil();
    public static ImageCopyUtil getInstance()
    {
        return ImageCopyUtil.instance;
    }

    private ImageCopyUtil()
    {
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
    private readonly Features features = Features.getInstance();
    private readonly OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
    private readonly OpenGLUtil openGLUtil = OpenGLUtil.getInstance();
    private readonly OpenGLESImageExclusionUtil openGLESImageExclusionUtil = OpenGLESImageExclusionUtil.getInstance();
    private readonly string NO_COPY = "SWT should not copy images after initial loading as the alpha is not honored";
    private readonly string UNABLE = "Unable to scale image without dimensions";
    // throws Exception
    public virtual Image createImageForRotation(Image originalImage)
    {
        if (this.features.isFeature(this.openGLFeatureFactory.OPENGL)) {
            Image image = originalImage;
            image = SwtOpenGLESImageBridge.addImage(this.openGLUtil, image);
            return image;
        } else {
            return this.createImage(originalImage);
        }
    }

    // throws Exception
    public virtual Image createImage(Image originalImage)
    {
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.putF(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR);
            return originalImage;
        }
        Image originalImage2 = originalImage;
        if (this.features.isFeature(this.openGLFeatureFactory.OPENGL)) {
            if (originalImage.getType() >= OpenGLESImage.TYPE) {
                OpenGLESImage openGLESImage = SwtOpenGLESImageBridge.getOpenGLESImage(originalImage);
                originalImage2 = SwtOpenGLESImageBridge.getBitmapImage(openGLESImage);
            }
        }
        Image image = null;
        if (originalImage2.isMutable()) {
            SwtMutableImage originalMutableImage = ((SwtMutableImage) originalImage2);
            image = new SwtMutableImage(SwtDeviceComponent.createImage(originalMutableImage.image.getImageData()));
        } else {
            SwtImmutableImage originalImmutableImage = ((SwtImmutableImage) originalImage2);
            image = new SwtMutableImage(SwtDeviceComponent.createImage(originalImmutableImage.image.getImageData()));
        }
        image = SwtOpenGLESImageBridge.addImage(this.openGLUtil, image);
        return image;
    }

    // throws Exception
    public virtual Image createImageWH(Image originalImage, int width, int height, bool mutable)
    {
        Image originalImage2 = originalImage;
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.putF(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR);
            return originalImage;
        }
        if (this.features.isFeature(this.openGLFeatureFactory.OPENGL)) {
            if (SwtOpenGLESImageBridge.isCustomScaling(this.openGLESImageExclusionUtil, originalImage)) {
                return this.createImage2(originalImage, width, height, mutable);
            }
            if (originalImage.getType() >= OpenGLESImage.TYPE) {
                OpenGLESImage openGLESImage = SwtOpenGLESImageBridge.getOpenGLESImage(originalImage);
                originalImage2 = SwtOpenGLESImageBridge.getBitmapImage(openGLESImage);
            }
        }
        Image image = null;
        if (originalImage2.isMutable() && mutable) {
            SwtMutableImage originalMutableImage = ((SwtMutableImage) originalImage2);
            if (originalMutableImage.getImage() != null) {
                ImageData imageData2 = originalMutableImage.image.getImageData();
                ImageData imageData = imageData2.scaledTo(width, height);
                image = new SwtMutableImage(SwtDeviceComponent.createImage(imageData));
            } else {
                image = new SwtMutableImage(originalMutableImage.getName(), new PostLoadSwtMutableImageProcessor(originalMutableImage));
            }
        } else {
            SwtImmutableImage originalImmutableImage = ((SwtImmutableImage) originalImage2);
            if (originalImmutableImage.getImage() != null) {
                ImageData imageData2 = originalImmutableImage.image.getImageData();
                if (width > 0 && height > 0) {
                    ImageData imageData = imageData2.scaledTo(width, height);
                    image = new SwtImmutableImage(originalImage.getName(), SwtDeviceComponent.createImage(imageData));
                } else {
                    this.logUtil.putF(UNABLE, this, this.commonStrings.CONSTRUCTOR);
                    image = new SwtImmutableImage(originalImmutableImage.getName(), new PostLoadSwtImmutableImageProcessor(originalImmutableImage));
                }
            } else {
                image = new SwtImmutableImage(originalImmutableImage.getName(), new PostLoadSwtImmutableImageProcessor(originalImmutableImage));
            }
        }
        image = SwtOpenGLESImageBridge.addImage(this.openGLUtil, image);
        return image;
    }

    private readonly string INFORMATION = "about_";
    private readonly string LEADERBOARD = "leaderboard";
    // throws Exception
    public virtual Image createImage2(Image originalImage, int width, int height, bool mutable)
    {
        Image originalImage2 = originalImage;
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.putF(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR);
            return originalImage;
        }
        Image image = null;
        if (this.features.isFeature(this.openGLFeatureFactory.OPENGL)) {
            DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
            if (originalImage.getType() >= OpenGLESImage.TYPE) {
                OpenGLESImage openGLESImage = SwtOpenGLESImageBridge.getOpenGLESImage(originalImage);
                OpenGLESImageProperties openGLESImageProperties = openGLESImage.openGLESImageProperties;
                int openGLWidth = openGLESImage.openGLBitmap.getWidth();
                int openGLHeight = openGLESImage.openGLBitmap.getHeight();
                openGLESImageProperties.scaleX2 = ((((float) width)) / ((float) openGLWidth));
                openGLESImageProperties.scaleX = openGLESImageProperties.scaleX2;
                openGLESImageProperties.scaleY2 = ((((float) height)) / ((float) openGLHeight));
                openGLESImageProperties.scaleY = openGLESImageProperties.scaleY2;
                openGLESImageProperties.scaleX = openGLESImageProperties.scaleX * 0.75f;
                openGLESImageProperties.scaleY = openGLESImageProperties.scaleY * 0.75f;
                if (originalImage.getHeight() % 2 != 0) {
                    openGLESImageProperties.scaleX2 += 1.0f / ((float) openGLWidth);
                    openGLESImageProperties.scaleY2 += 1.0f / ((float) openGLHeight);
                }
                image = SwtOpenGLESImageBridge.asImage(openGLESImage);
            } else {
                image = originalImage;
                OpenGLESImage openGLESImage = SwtOpenGLESImageBridge.getOpenGLESImage(SwtOpenGLESImageBridge.addImage(this.openGLUtil, image));
                OpenGLESImageProperties openGLESImageProperties = openGLESImage.openGLESImageProperties;
                openGLESImageProperties.scaleX2 = ((float) ((((float) width)) / openGLESImage.getWidth()));
                openGLESImageProperties.scaleX = openGLESImageProperties.scaleX2;
                openGLESImageProperties.scaleY2 = ((float) ((((float) height)) / openGLESImage.getHeight()));
                openGLESImageProperties.scaleY = openGLESImageProperties.scaleY2;
                if (image.getName().StartsWith(this.INFORMATION)) {
                    openGLESImage.openGLESImageTranslate = new OpenGLESJavaLibraryCSharp::org.allbinary.image.opengles.OpenGLESDeviceImageTranslate();
                    OpenGLESJavaLibraryCSharp::org.allbinary.image.opengles.OpenGLESDeviceImageTranslate openGLESDeviceImageTranslate = ((OpenGLESJavaLibraryCSharp::org.allbinary.image.opengles.OpenGLESDeviceImageTranslate) openGLESImage.openGLESImageTranslate);
                    openGLESDeviceImageTranslate.translateX = displayInfoSingleton.getLastWidth() / 1.4f / openGLESImageProperties.scaleX;
                    openGLESDeviceImageTranslate.translateY = displayInfoSingleton.getLastHeight() / 4 / openGLESImageProperties.scaleY;
                    openGLESImageProperties.scaleX = openGLESImageProperties.scaleX * 0.25f;
                    openGLESImageProperties.scaleY = openGLESImageProperties.scaleY * 0.25f;
                } else {
                    openGLESImageProperties.scaleX = openGLESImageProperties.scaleX * 0.75f;
                    openGLESImageProperties.scaleY = openGLESImageProperties.scaleY * 0.75f;
                    if (image.getName().StartsWith(this.LEADERBOARD)) {
                        openGLESImage.openGLESImageTranslate = new OpenGLESJavaLibraryCSharp::org.allbinary.image.opengles.OpenGLESDeviceImageTranslate();
                        OpenGLESJavaLibraryCSharp::org.allbinary.image.opengles.OpenGLESDeviceImageTranslate openGLESDeviceImageTranslate = ((OpenGLESJavaLibraryCSharp::org.allbinary.image.opengles.OpenGLESDeviceImageTranslate) openGLESImage.openGLESImageTranslate);
                        openGLESDeviceImageTranslate.translateX = -displayInfoSingleton.getLastWidth() / 40 / openGLESImageProperties.scaleX;
                    }
                    if (image.getName().StartsWith(this.LEADERBOARD)) {
                    } else {
                        openGLESImageProperties.scaleX = 1.0f;
                        openGLESImageProperties.scaleY = 1.0f;
                    }
                }
                image = SwtOpenGLESImageBridge.asImage(openGLESImage);
            }
        } else {
            if (originalImage2.isMutable() && mutable) {
                SwtMutableImage originalMutableImage = ((SwtMutableImage) originalImage2);
                if (originalMutableImage.getImage() != null) {
                    ImageData imageData2 = originalMutableImage.image.getImageData();
                    ImageData imageData = imageData2.scaledTo(width, height);
                    image = new SwtMutableImage(SwtDeviceComponent.createImage(imageData));
                } else {
                    image = new SwtMutableImage(originalMutableImage.getName(), new PostLoadSwtMutableImageProcessor(originalMutableImage));
                }
            } else {
                SwtImmutableImage originalImmutableImage = ((SwtImmutableImage) originalImage2);
                if (originalImmutableImage.getImage() != null) {
                    ImageData imageData2 = originalImmutableImage.image.getImageData();
                    ImageData imageData = imageData2.scaledTo(width, height);
                    image = new SwtImmutableImage(originalImage.getName(), SwtDeviceComponent.createImage(imageData));
                } else {
                    image = new SwtImmutableImage(originalImmutableImage.getName(), new PostLoadSwtImmutableImageProcessor(originalImmutableImage));
                }
            }
            image = SwtOpenGLESImageBridge.addImage(this.openGLUtil, image);
        }
        return image;
    }

    // throws Exception
    public virtual Image createImageScale(Image originalImage, float canvasScale, bool resize)
    {
        if (!this.features.isFeature(this.gameFeatureFactory.POST_IMAGE_LOADING_MODIFICATION)) {
            this.logUtil.putF(this.NO_COPY, this, this.commonStrings.CONSTRUCTOR);
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
        Image image = this.createImageWH(originalImage, newWidth, newHeight, true);
        if (image.isMutable()) {
            ImageData originalImageData = (((org.eclipse.swt.graphics.Image) originalImage.getImage())).getImageData();
            SwtMutableImage mutableImage2 = ((SwtMutableImage) image);
            int halfWidthDelta = (newWidth - originalImage.getWidth()) / 2;
            int halfHeightDelta = (newHeight - originalImage.getHeight()) / 2;
            int[] originalPixelArray = new int[originalImage.getWidth() * originalImage.getHeight()];
            int[] newPixelArray = new int[image.getWidth() * image.getHeight()];
            int width = originalImage.getWidth();
            int height = originalImage.getHeight();
            for (int i_3 = 0; i_3 < height; i_3++) {
                originalImageData.getPixels(0, i_3, width, originalPixelArray, (i_3 * width));
            }
            for (int index_4 = halfWidthDelta; index_4 < width; index_4++) {
                for (int index2_4 = halfHeightDelta; index2_4 < height; index2_4++) {
                    newPixelArray[index_4 + (index2_4 * width)] = originalPixelArray[(index_4 - halfWidthDelta) + ((index2_4 - halfHeightDelta) * width)];
                }
            }
            (((org.eclipse.swt.graphics.Image) mutableImage2.getImage())).getImageData().setPixels(0, 0, image.getWidth(), newPixelArray, 0);
            return image;
        } else {
            SwtImmutableImage originalImmutableImage = ((SwtImmutableImage) image);
            ImageData originalImageData = (((org.eclipse.swt.graphics.Image) originalImage.getImage())).getImageData();
            int halfWidthDelta = (newWidth - originalImage.getWidth()) / 2;
            int halfHeightDelta = (newHeight - originalImage.getHeight()) / 2;
            int[] originalPixelArray = new int[originalImage.getWidth() * originalImage.getHeight()];
            int[] newPixelArray = new int[image.getWidth() * image.getHeight()];
            int width = originalImage.getWidth();
            int height = originalImage.getHeight();
            for (int i_0 = 0; i_0 < height; i_0++) {
                originalImageData.getPixels(0, i_0, width, originalPixelArray, (i_0 * width));
            }
            for (int index_1 = halfWidthDelta; index_1 < width; index_1++) {
                for (int index2_1 = halfHeightDelta; index2_1 < height; index2_1++) {
                    newPixelArray[index_1 + (index2_1 * width)] = originalPixelArray[(index_1 - halfWidthDelta) + ((index2_1 - halfHeightDelta) * width)];
                }
            }
            (((org.eclipse.swt.graphics.Image) originalImmutableImage.getImage())).getImageData().setPixels(0, 0, image.getWidth(), newPixelArray, 0);
            return image;
        }
    }

}

