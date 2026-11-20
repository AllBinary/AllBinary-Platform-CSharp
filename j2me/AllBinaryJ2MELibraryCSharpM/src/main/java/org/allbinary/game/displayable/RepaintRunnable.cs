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
using Canvas = javax.microedition.lcdui.Canvas;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ARunnable = org.allbinary.thread.ARunnable;

namespace org.allbinary.game.displayable;

public class RepaintRunnable : ARunnable
{
    private readonly Canvas canvas;
    public RepaintRunnable(Canvas canvas)
    {
        this.canvas = canvas;
    }

    public override void run()
    {
        try {
            this.canvas.repaint();
            DisplayInfoSingleton.getInstance().process();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            LogUtil logUtil = LogUtil.getInstance();
            logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

}

