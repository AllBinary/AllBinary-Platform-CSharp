/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2026 AllBinary
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
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class InitGameProcessor : Processor
{
    private AllBinaryGameCanvas gameCanvas;
    public InitGameProcessor(AllBinaryGameCanvas gameCanvas)
    {
        this.gameCanvas = gameCanvas;
    }

    // throws Exception
    public override void process()
    {
        if (ProgressCanvasFactory.getInstance().isInGame()) {
            this.gameCanvas.setProcessGameProcessorInit();
        }
    }

}

