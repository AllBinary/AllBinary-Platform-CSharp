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
//using InputStream = java.io.InputStream;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using NullGL10 = org.allbinary.device.NullGL10;
using AllBinaryRendererBase3 = org.allbinary.graphics.opengles.renderer.AllBinaryRendererBase3;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ImageCache = org.allbinary.image.ImageCache;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;
using PreResourceImageUtil = org.allbinary.image.PreResourceImageUtil;
using SynchObject = org.allbinary.thread.SynchObject;

namespace org.allbinary.image.opengles;

//ImageCacheOpenGLESJavaLibrary
public class OpenGLImageCache : ImageCache
{
    private readonly ImageCache imageCache = ImageCacheFactory.getInstance();
    private readonly PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
    private GL10 gl = NullGL10.NULL_GL10;
    private readonly SynchObject @lock = new SynchObject();
    private readonly BasicArrayList list = new BasicArrayListD();
    private AllBinaryRendererBase3 renderer = new AllBinaryRendererBase3();
    public OpenGLImageCache()
    {
    }

    public override void addListener(object renderer)
    {
        this.renderer = ((AllBinaryRendererBase3) renderer);
    }

    // throws Exception
    public virtual void update(GL10 gl)
    {
        this.gl = gl;
        lock (this.@lock) {
            for (int index = this.list.size() - 1; index >= 0; index--) {
                OpenGLESImage openGLESImage = (((OpenGLESImage) this.list.objectArray[index]));
                if (openGLESImage != OpenGLESImage.NULL_OPENGL_IMAGE) {
                    openGLESImage.set(gl);
                }
            }
        }
    }

    // throws Exception
    protected override Image createImage(string caller, int width, int height)
    {
        int textureSize = width;
        if (height > width) {
            textureSize = height;
        }
        while ((textureSize % 4) != 0) {
            textureSize++;
        }
        width = textureSize;
        height = textureSize;
        Image image2 = this.imageCache.get(caller, width, height);
        Image image = this.preResourceImageUtil.encapsulate(image2);
        lock (this.@lock) {
            if (image != NullImage.NULL_IMAGE) {
                this.list.add(image);
            }
        }
        return image;
    }

    // throws Exception
    protected override Image createImageFromInputStream(object key, InputStream inputStream)
    {
        Image cachedImage = this.imageCache.getWithKey(key);
        Image image = this.preResourceImageUtil.encapsulate(cachedImage);
        lock (this.@lock) {
            if (image != NullImage.NULL_IMAGE) {
                this.list.add(image);
            }
        }
        return image;
    }

    public virtual GL10 getGlP()
    {
        return this.gl;
    }

    public override void init(Image image)
    {
        try {
            lock (this.@lock) {
                if (this.list.contains(image)) {
                    throw new SystemException();
                }
                this.list.add(image);
            }
            this.renderer.add(image);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
        }
    }

}

