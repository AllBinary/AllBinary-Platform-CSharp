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
using Configuration = android.content.res.Configuration;
using CommonStrings = org.allbinary.@string.CommonStrings;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;

namespace org.allbinary.input.motion.button;

public class TouchScreenTypeFactory
{
    private static readonly TouchScreenTypeFactory instance = new TouchScreenTypeFactory();
    public static TouchScreenTypeFactory getInstance()
    {
        return TouchScreenTypeFactory.instance;
    }

    public virtual void update(Activity activity)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        TouchScreenFactory touchScreenFactory = TouchScreenFactory.getInstance();
        TouchScreenTypesFactory touchScreenTypesFactory = TouchScreenTypesFactory.getInstance();
        Configuration configuration = activity.getResources().getConfiguration();
        int touchScreen = configuration.touchscreen;
        if (touchScreen == Configuration.TOUCHSCREEN_FINGER) {
            touchScreenFactory.setTouchScreenType(touchScreenTypesFactory.FINGER);
            if (!touchScreenFactory.isTouch()) {
                PreLogUtil.put("Not Really Exception: This indicates that a touch screen does exist but is not API8 so we will try it", this, commonStrings.PROCESS);
                touchScreenFactory.setTouch(true);
            }
        } else if (touchScreen == Configuration.TOUCHSCREEN_STYLUS) {
            touchScreenFactory.setTouchScreenType(touchScreenTypesFactory.STYLUS);
            if (!touchScreenFactory.isTouch()) {
                PreLogUtil.put("Not Really Exception: This indicates that a touch screen does exist but is not API8 so we will try it", this, commonStrings.PROCESS);
                touchScreenFactory.setTouch(true);
            }
        } else if (touchScreen == Configuration.TOUCHSCREEN_NOTOUCH) {
            touchScreenFactory.setTouchScreenType(touchScreenTypesFactory.NOTOUCH);
        } else if (touchScreen == Configuration.TOUCHSCREEN_UNDEFINED) {
            touchScreenFactory.setTouchScreenType(touchScreenTypesFactory.UNDEFINED);
        }
    }

}

