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
using Activity = android.app.Activity;
using MidletActivityBase = org.allbinary.android.activity.MidletActivityBase;
using SimpleProgressActivityInterface = org.allbinary.android.activity.SimpleProgressActivityInterface;
using ARunnable = org.allbinary.thread.ARunnable;

namespace org.allbinary.graphics.canvas.transition.progress;

public class ProgressRunnable : ARunnable
{
    public readonly SimpleProgressActivityInterface midletActivity;
    public readonly ProgressCanvas progressCanvas;
    public ProgressRunnable(Activity midletActivity, ProgressCanvas progressCanvas)
    {
        MidletActivityBase midletActivity2 = ((MidletActivityBase) midletActivity);
        this.midletActivity = ((SimpleProgressActivityInterface) midletActivity2);
        this.progressCanvas = progressCanvas;
    }

    public override void run()
    {
    }

}

