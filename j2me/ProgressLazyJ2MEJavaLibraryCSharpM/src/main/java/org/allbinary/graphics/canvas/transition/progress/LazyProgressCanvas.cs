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
using Processor = org.allbinary.canvas.Processor;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;

namespace org.allbinary.graphics.canvas.transition.progress;

public class LazyProgressCanvas : ProgressCanvas
{
    public LazyProgressCanvas(string title, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, backgroundBasicColor, foregroundBasicColor)
    {
        // base(title, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
    }

    public override void start()
    {
        base.start();
        this.hasPainted = false;
    }

    public override void end()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.END_METHOD_NAME);
            this.endActual();
            this.paintable = this.GAUGE_PAINTABLE;
            ImageCacheFactory.getInstance().runTask();
            ImageCacheFactory.getInstance().progressEnded();
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION, this, this.commonStrings.END_METHOD_NAME);
        }
    }

    public override void inGame()
    {
        this.inGameProcessor = Processor.getInstance();
    }

    public override void endFromInitialLazyLoadingComplete()
    {
        base.endFromInitialLazyLoadingComplete();
        this.paintable = NullPaintable.getInstance();
    }

    public override void endIfPaintedSinceStart()
    {
        if (this.paintable == this.GAUGE_PAINTABLE && this.hasPainted) {
            this.endFromInitialLazyLoadingComplete();
        }
    }

}

