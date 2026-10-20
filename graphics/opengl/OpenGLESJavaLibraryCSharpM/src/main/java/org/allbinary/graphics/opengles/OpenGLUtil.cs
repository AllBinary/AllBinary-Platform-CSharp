// Generated Code Do Not Modify

using System;
using System.Linq;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using LoadTextures = org.allbinary.device.LoadTextures;
using OpenGLESGraphics = org.allbinary.device.OpenGLESGraphics;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using RendererStrings = org.allbinary.graphics.opengles.renderer.RendererStrings;
using PreResourceImageUtil = org.allbinary.image.PreResourceImageUtil;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;
using OpenGLImageCache = org.allbinary.image.opengles.OpenGLImageCache;
using OpenGLImageCacheFactory = org.allbinary.image.opengles.OpenGLImageCacheFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using SynchObject = org.allbinary.thread.SynchObject;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.opengles;

public class OpenGLUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly OpenGLUtil instance = new OpenGLUtil();
    public static OpenGLUtil getInstance()
    {
        return OpenGLUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly RendererStrings renderStrings = RendererStrings.getInstance();
    public readonly CanvasStrings canvasStrings = CanvasStrings.getInstance();
    public readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private readonly PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
    private readonly SynchObject lockObject = new SynchObject();
    private readonly SynchObject anyType = new SynchObject();
    private readonly BasicArrayList list = new BasicArrayListD();
    public readonly BasicArrayList runnableList = new BasicArrayListD();
    private bool created = false;
    public virtual void onSurfaceCreated(GL10 gl)
    {
        try {
            if (!this.created) {
                this.created = true;
                PreLogUtil.put(CommonLabels.getInstance().START_LABEL + OpenGLCapabilities.getInstance().ToString(), this, this.renderStrings.ON_SURFACE_CREATED);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.renderStrings.ON_SURFACE_CREATED, e);
        }
    }

    public virtual void onSurfaceCreated(GL10 gl, LoadTextures loadTextures)
    {
        try {
            loadTextures.load(gl);
            OpenGLLogUtil.getInstance().logError(gl);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.renderStrings.ON_SURFACE_CREATED, e);
        }
    }

    private bool surfaceCreatedAndInitialized = false;
    // throws Exception
    public virtual void onSurfaceChanged(GL10 gl, OpenGLESGraphics graphics)
    {
        if (!this.surfaceCreatedAndInitialized) {
            graphics.init();
            this.surfaceCreatedAndInitialized = true;
        }
        graphics.update();
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.update(graphics);
        (((OpenGLImageCache) OpenGLImageCacheFactory.getInstance())).update(gl);
        this.processRunnables();
        this.set(gl);
    }

    public virtual Image addImage(Image image)
    {
        Image encapsulateImage = this.preResourceImageUtil.encapsulate(image);
        if (encapsulateImage != image) {
            lock (this.anyType) {
                this.list.add(encapsulateImage);
            }
            return encapsulateImage;
        }
        return image;
    }

    public virtual void clear()
    {
        lock (this.anyType) {
            this.list.clear();
        }
    }

    public virtual void addRunnable(global::java.lang.Runnable runnable)
    {
        lock (this.lockObject) {
            if (!this.runnableList.contains(runnable)) {
                this.runnableList.add(runnable);
                this.displayInfoSingleton.add(this.canvasStrings.SCALED_IMAGES);
            }
        }
    }

    private void processRunnables()
    {
        lock (this.lockObject) {
            global::java.lang.Runnable runnable = null;
            int size = this.runnableList.size();
            for (int index = 0; index < size; index++) {
                runnable = ((global::java.lang.Runnable) this.runnableList.get(index));
                runnable.run();
            }
            this.runnableList.clear();
        }
    }

    // throws Exception
    private void set(GL10 gl)
    {
        int size = this.list.size();
        OpenGLESImage image = null;
        for (int index2 = 0; index2 < size; index2++) {
            image = ((OpenGLESImage) this.list.get(index2));
            image.set(gl);
        }
    }

}

