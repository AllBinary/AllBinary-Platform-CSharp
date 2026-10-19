/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using ImageCache = org.allbinary.image.ImageCache;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.thread;

public class ConcurrentImageLoadingProcessor : BaseImageLoadingProcessor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public class ImageCacheRunnable : ABRunnable
    {
        private readonly ImageCache imageCache;
        public ImageCacheRunnable(ImageCache imageCache)
        {
            this.imageCache = imageCache;
        }

        public override void run()
        {
            LogUtil logUtil = LogUtil.getInstance();
            try {
                this.setRunning(true);
                this.imageCache.waitForLoadNow();
                this.imageCache.loadImages();
                this.imageCache.loadRemainingAnimations();
                this.setRunning(false);
                ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
                if (!progressCanvas.inProgress) {
                    progressCanvas.endFromInitialLazyLoadingComplete();
                }
            } catch (Exception e) {
                this.setRunning(false);
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

    }
    private readonly ABRunnable runnable;
    public ConcurrentImageLoadingProcessor(ImageCache imageCache)
    {
        this.runnable = new ImageCacheRunnable(imageCache);
    }

    public override void runTask()
    {
        if (!this.runnable.isRunning()) {
            ImageThreadPool.getInstance().runTask(this.runnable);
        }
    }

}

