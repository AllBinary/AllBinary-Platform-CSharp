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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ABRunnable = org.allbinary.thread.ABRunnable;

namespace org.allbinary.game.displayable.canvas;

public class DemoGameStartupRunnable : ABRunnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly DemoCanvas demoCanvas;
    public DemoGameStartupRunnable(DemoCanvas demoCanvas)
    {
        this.demoCanvas = demoCanvas;
    }

    public override void run()
    {
        try {
            this.setRunning(true);
            this.demoCanvas.stopGameDemo();
            this.demoCanvas.create();
            this.demoCanvas.start();
            this.setRunning(false);
        } catch (Exception e) {
            this.setRunning(false);
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

    public static readonly int TYPE = 4;
    public override int getType()
    {
        return DemoGameStartupRunnable.TYPE;
    }

}

