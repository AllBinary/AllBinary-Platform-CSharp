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
//using GL = javax.microedition.khronos.opengles.GL;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;
using PlatformTextureBaseFactory = org.allbinary.platform.opengles.PlatformTextureBaseFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.image.opengles;

//OpenGLESNullImageJ2MEJavaLibrary
public class OpenGLESImage : OpenGLSurfaceChangedInterface
{
    public static readonly OpenGLESImage NULL_OPENGL_IMAGE = new OpenGLESImage(NullImage.NULL_IMAGE, PlatformBitmapBaseFactory.NULL_PLATFORM_BITMAP_BASE_FACTORY, PlatformTextureBaseFactory.NULL_PLATFORM_TEXTURE_BASE_FACTORY);
    public static readonly BasicArrayList texture2dList = new BasicArrayListD();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly PlatformTextureBaseFactory textureFactory;
    public readonly PlatformBitmapBase openGLBitmap;
    public readonly OpenGLESImageProperties openGLESImageProperties = new OpenGLESImageProperties();
    public OpenGLESImage(Image image, PlatformBitmapBaseFactory bitmapFactory, PlatformTextureBaseFactory textureFactory)
    {
        this.openGLBitmap = bitmapFactory.createBitmap(image);
        this.textureFactory = textureFactory;
    }

    // throws Exception
    public virtual void set(GL gl)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    protected virtual bool initTexture(GL10 gl)
    {
        return false;
    }

    public virtual void drawRegion(GL10 gl, int viewHeight, float x_src, float y_src, float width, float height, int x, int y, int z)
    {
    }

    public virtual void draw(GL10 gl, int x, int y, int z)
    {
    }

    public static readonly int TYPE = 4;
    public virtual int getType()
    {
        return OpenGLESImage.TYPE;
    }

}

