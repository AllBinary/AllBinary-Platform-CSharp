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
//using Image = javax.microedition.lcdui.Image;
using Features = org.allbinary.game.configuration.feature.Features;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using GC = org.eclipse.swt.graphics.GC;
using SwtImmutableImage = org.microemu.device.swt.SwtImmutableImage;
using SwtMutableImage = org.microemu.device.swt.SwtMutableImage;

namespace org.allbinary.media.image;

public class ImageRotationUtil
{
    private static readonly ImageRotationUtil instance = new ImageRotationUtil();
    public static ImageRotationUtil getInstance()
    {
        return ImageRotationUtil.instance;
    }

    private readonly ImageSwtRotationUtil imageSwtRotationUtil = ImageSwtRotationUtil.getInstance();
    private ImageRotationUtil()
    {
    }

    private readonly Features features = Features.getInstance();
    public virtual void rotateImage(Image originalImage, Image image, int totalAngle)
    {
        Image originalImage2 = originalImage;
        if (this.features.isFeature(OpenGLFeatureFactory.getInstance().OPENGL)) {
            if (image.getType() >= OpenGLESImage.TYPE) {
                OpenGLESImage openGLESImage = (((OpenGLESImage) image));
                openGLESImage.openGLESImageProperties.angle = totalAngle;
                return;
            } else {
                PreLogUtil.put("OpenGL but image is: " + image + " type: " + image.getType(), this, "rotateImage");
            }
        }
        org.eclipse.swt.graphics.Image originalSwtImage = (((org.eclipse.swt.graphics.Image) originalImage2.getImage()));
        GC gc = null;
        org.eclipse.swt.graphics.Image copySwtImage = null;
        if (image.isMutable()) {
            SwtMutableImage swtImage = ((SwtMutableImage) image);
            copySwtImage = ((org.eclipse.swt.graphics.Image) swtImage.getImage());
            gc = swtImage.getGc();
            this.imageSwtRotationUtil.rotateImage(originalSwtImage, copySwtImage, gc, totalAngle);
        } else {
            PreLogUtil.put("No rotation for: " + image.ToString(), this, "rotateImage");
        }
    }

    // throws Exception
    public virtual Image createRotatedImage(Image originalImage, int rotationInDegrees)
    {
        return originalImage;
    }

}

