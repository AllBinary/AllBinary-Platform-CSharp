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
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
using Processor = org.allbinary.canvas.Processor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.midlet;

public class ExitRunnable : global::java.lang.Runnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly AllBinaryMidlet midlet;
    private readonly Processor processor;
    private readonly bool isProgress;
    public ExitRunnable(AllBinaryMidlet midlet, Processor processor, bool isProgress)
    {
        this.midlet = midlet;
        this.isProgress = isProgress;
        this.processor = processor;
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START_RUNNABLE, this, this.commonStrings.RUN);
            this.midlet.destroyAppInRunnable(false, this.isProgress);
            this.midlet.setDisplay(NullCanvas.NULL_CANVAS);
            this.midlet.notifyDestroyed();
            this.logUtil.putF(this.commonStrings.END_RUNNABLE, this, this.commonStrings.RUN);
            this.processor.process();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
            try {
                this.processor.process();
            } catch (Exception e2) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
            }
        }
    }

}

