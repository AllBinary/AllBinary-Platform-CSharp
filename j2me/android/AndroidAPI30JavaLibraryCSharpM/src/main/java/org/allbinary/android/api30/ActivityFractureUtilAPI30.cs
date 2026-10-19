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
using Window = android.view.Window;
using WindowCompat = androidx.core.view.WindowCompat;
using WindowInsetsCompat = androidx.core.view.WindowInsetsCompat;
using WindowInsetsControllerCompat = androidx.core.view.WindowInsetsControllerCompat;
using ActivityFractureUtilAPI5 = org.allbinary.android.api5.ActivityFractureUtilAPI5;

namespace org.allbinary.android.api30;

public class ActivityFractureUtilAPI30 : ActivityFractureUtilAPI5
{
    private static readonly ActivityFractureUtilAPI30 instance30 = new ActivityFractureUtilAPI30();
    public static ActivityFractureUtilAPI30 getInstance()
    {
        return ActivityFractureUtilAPI30.instance30;
    }

    public override void setFullScreen(Activity activity)
    {
        Window window = activity.getWindow();
        WindowInsetsControllerCompat windowInsetsController = WindowCompat.getInsetsController(window, window.getDecorView());
        windowInsetsController.hide(WindowInsetsCompat.Type.systemBars());
        windowInsetsController.setSystemBarsBehavior(WindowInsetsControllerCompat.BEHAVIOR_SHOW_TRANSIENT_BARS_BY_SWIPE);
    }

}

