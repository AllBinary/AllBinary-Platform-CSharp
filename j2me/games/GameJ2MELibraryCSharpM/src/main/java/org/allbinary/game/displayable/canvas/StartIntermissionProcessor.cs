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
using Processor = org.allbinary.canvas.Processor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class StartIntermissionProcessor : Processor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private AllBinaryGameCanvas gameCanvas;
    private readonly long WAIT = 5000L;
    public StartIntermissionProcessor(AllBinaryGameCanvas gameCanvas)
    {
        this.gameCanvas = gameCanvas;
    }

    // throws Exception
    public override void process()
    {
        if (this.gameCanvas.getStartIntermissionInterface().getTimeDelayHelper().isElapsedTNT(this.WAIT)) {
            this.logUtil.putF("Intermission End", this, this.commonStrings.PROCESS);
            this.gameCanvas.getStartIntermissionInterface().setEnabled(false);
        }
    }

}

