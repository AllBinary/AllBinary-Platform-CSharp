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
using TouchScreenTypeFactory = org.allbinary.input.motion.button.TouchScreenTypeFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using ActivityFractureUtilAPI1 = org.allbinary.android.api1.ActivityFractureUtilAPI1;
using TouchScreenFactory = org.allbinary.input.motion.button.TouchScreenFactory;

namespace org.allbinary.android.api5;

public class ActivityFractureUtilAPI5 : ActivityFractureUtilAPI1
{
    private static readonly ActivityFractureUtilAPI5 instance5 = new ActivityFractureUtilAPI5();
    public static ActivityFractureUtilAPI5 getInstance()
    {
        return ActivityFractureUtilAPI5.instance5;
    }

    private readonly string FEATURE_TOUCHSCREEN_MULTITOUCH = "android.hardware.touchscreen.multitouch";
    private readonly string FEATURE_TOUCHSCREEN = "android.hardware.touchscreen";
    private readonly string FEATURE_TOUCHSCREEN_MULTITOUCH_DISTINCT = "android.hardware.touchscreen.multitouch.distinct";
    public override void process(Activity activity)
    {
        TouchScreenFactory touchScreenFactory = TouchScreenFactory.getInstance();
        TouchScreenTypeFactory touchScreenTypeFactory = TouchScreenTypeFactory.getInstance();
        touchScreenFactory.setTouch(this.isTouch(activity));
        touchScreenFactory.setMultiTouch(this.isMultiTouch(activity));
        touchScreenFactory.setMultiTouchDistinct(this.isMultiTouchDistinct(activity));
        touchScreenTypeFactory.update(activity);
        CommonStrings commonStrings = CommonStrings.getInstance();
        PreLogUtil.put(touchScreenFactory.ToString(), this, commonStrings.PROCESS);
    }

    private bool isTouch(Activity activity)
    {
        return this.isFeature(activity, this.FEATURE_TOUCHSCREEN);
    }

    private bool isMultiTouch(Activity activity)
    {
        return this.isFeature(activity, this.FEATURE_TOUCHSCREEN_MULTITOUCH);
    }

    private bool isMultiTouchDistinct(Activity activity)
    {
        return this.isFeature(activity, this.FEATURE_TOUCHSCREEN_MULTITOUCH_DISTINCT);
    }

    private bool isFeature(Activity activity, string property)
    {
        return activity.getPackageManager().hasSystemFeature(property);
    }

}

