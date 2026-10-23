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
//using OpenGLESPostLoadPlatformImage = javax.microedition.lcdui.OpenGLESPostLoadPlatformImage;
//using PostLoadImageProcessor = javax.microedition.lcdui.PostLoadImageProcessor;
using GraphicsStrings = org.allbinary.graphics.GraphicsStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;
using PlatformTextureBaseFactory = org.allbinary.platform.opengles.PlatformTextureBaseFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.image.opengles;

//OpenGLESSWTJOGLImageJavaLibrary
public class OpenGLESImage : Image, OpenGLSurfaceChangedInterface
{
    public static readonly OpenGLESImage NULL_OPENGL_IMAGE = new OpenGLESImage(NullImage.NULL_IMAGE, PlatformBitmapBaseFactory.NULL_PLATFORM_BITMAP_BASE_FACTORY, PlatformTextureBaseFactory.NULL_PLATFORM_TEXTURE_BASE_FACTORY);
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly BasicArrayList texture2dList = new BasicArrayListD();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly PlatformTextureBaseFactory textureFactory;
    public readonly PlatformBitmapBase openGLBitmap;
    public OpenGLESImageProcessor imageProcessor = OpenGLESImageProcessor.getInstance();
    public OpenGLESImageTranslate openGLESImageTranslate = OpenGLESImageTranslate.getInstance();
    public readonly OpenGLESImageProperties openGLESImageProperties = new OpenGLESImageProperties();
    public OpenGLESImage(Image image, PlatformBitmapBaseFactory bitmapFactory, PlatformTextureBaseFactory textureFactory) : base(image.getName(), PostLoadImageProcessor.NULL_POST_LOAD_IMAGE_PROCESSOR)
    {
        // base(image.getName(), PostLoadImageProcessor.NULL_POST_LOAD_IMAGE_PROCESSOR) is called from the constructor declaration
        this.openGLBitmap = bitmapFactory.createBitmap(image);
        this.textureFactory = textureFactory;
        OpenGLImageCacheFactory.getInstance().init(this);
        this.platformImage = OpenGLESPostLoadPlatformImage.getInstance();
    }

    public virtual int getHeight()
    {
        return ((int) (this.openGLBitmap.getHeight() * this.openGLESImageProperties.scaleY2));
    }

    public virtual int getWidth()
    {
        return ((int) (this.openGLBitmap.getWidth() * this.openGLESImageProperties.scaleX2));
    }

    // throws Exception
    public virtual void set(GL gl)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual bool initTexture(GL10 gl)
    {
        if (!OpenGLESImage.texture2dList.contains(this)) {
            OpenGLESImage.texture2dList.add(this);
            int[] textures = new int[1];
            gl.glEnable(GL10.GL_TEXTURE_2D);
            if (this.openGLESImageProperties.textureID != -1) {
                textures[0] = this.openGLESImageProperties.textureID;
                gl.glDeleteTextures(1, textures, 0);
            }
            gl.glGenTextures(1, textures, 0);
            this.openGLESImageProperties.textureID = textures[0];
            gl.glBindTexture(GL10.GL_TEXTURE_2D, this.openGLESImageProperties.textureID);
            gl.glTexParameterf(GL10.GL_TEXTURE_2D, GL10.GL_TEXTURE_MIN_FILTER, GL10.GL_NEAREST);
            gl.glTexParameterf(GL10.GL_TEXTURE_2D, GL10.GL_TEXTURE_WRAP_S, GL10.GL_CLAMP_TO_EDGE);
            gl.glTexParameterf(GL10.GL_TEXTURE_2D, GL10.GL_TEXTURE_WRAP_T, GL10.GL_CLAMP_TO_EDGE);
            return true;
        }
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

    public override string ToString()
    {
        GraphicsStrings graphicsStrings = GraphicsStrings.getInstance();
        return new StringMaker().append(this.getName()).append(base.ToString()).append(graphicsStrings.OPACITY).appendfloat(((float) this.openGLESImageProperties.alphaf)).ToString();
    }

}

