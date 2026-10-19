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
using Color = android.graphics.Color;
using Matrix = android.graphics.Matrix;
using Paint = android.graphics.Paint;
//using Image = javax.microedition.lcdui.Image;
using AndroidImageInterface = org.microemu.android.device.AndroidImageInterface;

namespace org.allbinary.media.image;

public class AndroidImageUtil
{
    private static readonly AndroidImageUtil instance = new AndroidImageUtil();
    public static AndroidImageUtil getInstance()
    {
        return AndroidImageUtil.instance;
    }

    public virtual void paintBitmap(Bitmap bitmap, Bitmap originalBitmap, Paint paint)
    {
        bitmap.eraseColor(Color.TRANSPARENT);
        Canvas canvas = new android.graphics.Canvas();
        canvas.setBitmap(bitmap);
        canvas.drawBitmap(originalBitmap, 0.0f, 0.0f, paint);
    }

    public virtual void paint(Image image, Image originalImage, Paint paint)
    {
        AndroidImageInterface androidImage = ((AndroidImageInterface) image);
        androidImage.getBitmap().eraseColor(Color.TRANSPARENT);
        Canvas canvas = androidImage.getCanvas();
        AndroidImageInterface originalAndroidImage = ((AndroidImageInterface) originalImage);
        canvas.drawBitmap(originalAndroidImage.getBitmap(), 0.0f, 0.0f, paint);
    }

    public virtual void rotate(Image image, Image originalImage, Matrix matrix, Paint paint)
    {
        AndroidImageInterface androidImage = ((AndroidImageInterface) image);
        androidImage.getBitmap().eraseColor(Color.TRANSPARENT);
        Canvas canvas = androidImage.getCanvas();
        canvas.concat(matrix);
        AndroidImageInterface originalAndroidImage = ((AndroidImageInterface) originalImage);
        canvas.drawBitmap(originalAndroidImage.getBitmap(), 0.0f, 0.0f, paint);
    }

}

