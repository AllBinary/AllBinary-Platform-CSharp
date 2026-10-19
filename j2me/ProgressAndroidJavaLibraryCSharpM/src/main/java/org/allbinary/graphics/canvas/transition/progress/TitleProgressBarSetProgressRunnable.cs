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
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Activity = android.app.Activity;

namespace org.allbinary.graphics.canvas.transition.progress;

public class TitleProgressBarSetProgressRunnable : ProgressRunnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TitleProgressBarSetProgressRunnable(Activity midletActivity, ProgressCanvas progressCanvas) : base(midletActivity, progressCanvas)
    {
        // base(midletActivity, progressCanvas) is called from the constructor declaration
    }

    public override void run()
    {
        try {
            this.midletActivity.onSetProgress(((int) this.progressCanvas.getValue()), this.progressCanvas.getText());
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

}

