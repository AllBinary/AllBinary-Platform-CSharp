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
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;

namespace org.allbinary.game.displayable.canvas;

public class DemoGameRunnable : GameRunnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly DemoCanvas demoCanvas;
    public DemoGameRunnable(DemoCanvas demoCanvas)
    {
        this.demoCanvas = demoCanvas;
    }

    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    public override void run()
    {
        try {
            this.demoCanvas.getLoopTimeHelperP().setStartTime(this.gameTickTimeDelayHelper.setStartTime());
            this.demoCanvas.processGame();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

    // throws Exception
    public override void processLoopSleep()
    {
        this.demoCanvas.processLoopSleep();
    }

}

