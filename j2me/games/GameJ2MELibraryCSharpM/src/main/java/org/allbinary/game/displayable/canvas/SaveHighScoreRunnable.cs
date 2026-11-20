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
using HighScoreTextBox = org.allbinary.game.score.displayable.HighScoreTextBox;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class SaveHighScoreRunnable : global::java.lang.Runnable
{
    private readonly ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
    private readonly bool isLast;
    private readonly HighScoreTextBox textBox;
    public SaveHighScoreRunnable(bool isLast, HighScoreTextBox textBox)
    {
        this.isLast = isLast;
        this.textBox = textBox;
    }

    public virtual void run()
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            if (this.isLast) {
                this.textBox.submit();
            } else {
                this.textBox.saveHighScore();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, this, "run", e);
            this.progressCanvas.end();
        }
    }

}

