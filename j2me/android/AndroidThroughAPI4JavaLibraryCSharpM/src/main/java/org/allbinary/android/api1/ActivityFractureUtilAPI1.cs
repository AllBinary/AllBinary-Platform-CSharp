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
using ActivityFractureUtil = org.allbinary.android.ActivityFractureUtil;
using Activity = android.app.Activity;
using WindowManager = android.view.WindowManager;

namespace org.allbinary.android.api1;

public class ActivityFractureUtilAPI1 : ActivityFractureUtil
{
    private static readonly ActivityFractureUtilAPI1 instance = new ActivityFractureUtilAPI1();
    public static ActivityFractureUtilAPI1 getInstance()
    {
        return ActivityFractureUtilAPI1.instance;
    }

    // throws Exception
    public override void process(Activity activity)
    {
    }

    public override void setFullScreen(Activity activity)
    {
        activity.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
    }

}

