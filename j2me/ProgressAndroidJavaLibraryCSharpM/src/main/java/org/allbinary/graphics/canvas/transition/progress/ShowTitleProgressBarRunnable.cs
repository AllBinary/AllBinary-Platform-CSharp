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
using TransistionTypes = org.allbinary.animation.transition.TransistionTypes;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Activity = android.app.Activity;

namespace org.allbinary.graphics.canvas.transition.progress;

public class ShowTitleProgressBarRunnable : ProgressRunnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public ShowTitleProgressBarRunnable(Activity midletActivity, ProgressCanvas progressCanvas) : base(midletActivity, progressCanvas)
    {
        // base(midletActivity, progressCanvas) is called from the constructor declaration
    }

    private readonly int[] FADE_IN_HALF = new int[] { TransistionTypes.getInstance().FADE_IN_TO_HALF_ALPHA, TransistionTypes.getInstance().FADE_IN_FROM_HALF_ALPHA };
    public override void run()
    {
        try {
            this.midletActivity.onShowProgress(false, this.FADE_IN_HALF);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

}

