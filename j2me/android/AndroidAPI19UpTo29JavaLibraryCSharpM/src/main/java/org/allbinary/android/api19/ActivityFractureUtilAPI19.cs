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
using View = android.view.View;
using ActivityFractureUtilAPI5 = org.allbinary.android.api5.ActivityFractureUtilAPI5;

namespace org.allbinary.android.api19;

public class ActivityFractureUtilAPI19 : ActivityFractureUtilAPI5
{
    private static readonly ActivityFractureUtilAPI19 instance19 = new ActivityFractureUtilAPI19();
    public static ActivityFractureUtilAPI19 getInstance()
    {
        return ActivityFractureUtilAPI19.instance19;
    }

    public override void setFullScreen(Activity activity)
    {
        View decorView = activity.getWindow().getDecorView();
        int visibility = View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION | View.SYSTEM_UI_FLAG_FULLSCREEN;
        decorView.setSystemUiVisibility(visibility);
    }

}

