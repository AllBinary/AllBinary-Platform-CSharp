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
using View = android.view.View;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.canvas;

public class ProfilingRefreshHelper : AndroidGameStatistics
{
    private static readonly ProfilingRefreshHelper instance = new ProfilingRefreshHelper();
    public static AndroidGameStatistics getInstance()
    {
        return ProfilingRefreshHelper.instance;
    }

    private bool firstTime = true;
    private int bestFrameProcessingTime = 0;
    private int worstFrameProcessingTime = 0;
    private long frameProcessingTimeElapsed = 0L;
    private ProfilingRefreshHelper()
    {
    }

    public override void initView(View view)
    {
        base.initView(view);
        this.frameProcessingTimeElapsed = this.getTimeDelayHelper().getStartTime();
        this.bestFrameProcessingTime = Integer.MAX_VALUE;
        this.worstFrameProcessingTime = 0;
    }

    public override void nextFrame()
    {
        this.frameProcessingTimeElapsed = DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.frameProcessingTimeElapsed;
        if (this.firstTime != true) {
            if (this.frameProcessingTimeElapsed > ((long) this.worstFrameProcessingTime)) {
                this.worstFrameProcessingTime = ((int) this.frameProcessingTimeElapsed);
            }
            if (this.frameProcessingTimeElapsed < ((long) this.bestFrameProcessingTime)) {
                this.bestFrameProcessingTime = ((int) this.frameProcessingTimeElapsed);
            }
        } else {
            this.firstTime = false;
        }
        base.nextFrame();
    }

    public override string ToString()
    {
        return new StringMaker().append(base.ToString()).append(" Worst: ").appendint(this.worstFrameProcessingTime).append(" Best: ").appendint(this.bestFrameProcessingTime).ToString();
    }

}

