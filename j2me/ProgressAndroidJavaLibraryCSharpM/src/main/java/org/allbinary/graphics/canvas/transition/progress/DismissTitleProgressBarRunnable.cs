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

public class DismissTitleProgressBarRunnable : ProgressRunnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public DismissTitleProgressBarRunnable(Activity midletActivity, ProgressCanvas progressCanvas) : base(midletActivity, progressCanvas)
    {
        // base(midletActivity, progressCanvas) is called from the constructor declaration
    }

    private readonly int[] ZOOM_OUT_AND_IN = new int[] { TransistionTypes.getInstance().ZOOM_OUT, TransistionTypes.getInstance().ZOOM_IN };
    public override void run()
    {
        try {
            this.midletActivity.onDismissProgress(this.ZOOM_OUT_AND_IN);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

}

