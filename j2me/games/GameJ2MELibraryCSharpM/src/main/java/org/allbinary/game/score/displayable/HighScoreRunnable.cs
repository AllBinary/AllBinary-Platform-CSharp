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
using J2MEUtil = org.allbinary.J2MEUtil;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ARunnable = org.allbinary.thread.ARunnable;

namespace org.allbinary.game.score.displayable;

public class HighScoreRunnable : ARunnable
{
    public readonly HighScoresCanvas highScoresCanvas;
    public HighScoreRunnable(HighScoresCanvas highScoresCanvas)
    {
        this.highScoresCanvas = highScoresCanvas;
    }

    public override void run()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        LogUtil logUtil = LogUtil.getInstance();
        HighScoresCanvas highScoresCanvas = this.highScoresCanvas;
        try {
            bool isHTML = J2MEUtil.isHTML();
            if (!isHTML) {
                while (!highScoresCanvas.hasPainted) {
                }
                highScoresCanvas.hasPainted = false;
            }
            StringMaker stringMaker = new StringMaker();
            ABSystemWrapper systemWrapper = ABSystemWrapper.getInstance();
            long currentTimeMillis = systemWrapper.currentTimeMillis();
            logUtil.putF(stringMaker.append("HighScoresCanvas - Request repaint to be sure: ").appendlong(currentTimeMillis).ToString(), this, commonStrings.RUN);
            highScoresCanvas.repaintBehavior.onChangeRepaint(highScoresCanvas);
            if (!isHTML) {
                while (!highScoresCanvas.hasPainted) {
                }
            }
            stringMaker.delete(0, stringMaker.length());
            logUtil.putF(stringMaker.append("HighScoresCanvas - Now that the canvas has completed repaint go ahead and fetch the scores: ").appendlong(currentTimeMillis).ToString(), this, commonStrings.RUN);
            highScoresCanvas.executeUpdate();
        } catch (Exception e) {
            logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

}

