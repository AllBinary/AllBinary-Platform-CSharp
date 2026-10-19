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
using Anchor = org.allbinary.graphics.Anchor;
using Bitmap = android.graphics.Bitmap;
using Canvas = android.graphics.Canvas;
using Matrix = android.graphics.Matrix;
using AndroidImageInterface = org.microemu.android.device.AndroidImageInterface;

namespace org.allbinary.media.image;

public class ImageRotationUtil
{
    private static readonly ImageRotationUtil instance = new ImageRotationUtil();
    public static ImageRotationUtil getInstance()
    {
        return ImageRotationUtil.instance;
    }

    private readonly Matrix matrix = new Matrix();
    private ImageRotationUtil()
    {
    }

    private int anchor = Anchor.TOP_LEFT;
    // throws Exception
    public virtual Image createRotatedImage(Image originalImage, int rotationInDegrees)
    {
        Image image = ImageCreationUtil.getInstance().createImageWH(originalImage.getWidth(), originalImage.getHeight());
        if (image.isMutable()) {
            Bitmap bitmap = (((AndroidImageInterface) image)).getBitmap();
            int width = bitmap.getWidth();
            int height = bitmap.getHeight();
            this.matrix.setRotate(((float) rotationInDegrees), ((float) (width >> 1)), ((float) (height >> 1)));
            Canvas canvas = (((AndroidImageInterface) image)).getCanvas();
            canvas.concat(this.matrix);
            image.getGraphics().drawImage(originalImage, 0, 0, this.anchor);
            return image;
        } else {
            throw new Exception("Not Mutable");
        }
    }

}

