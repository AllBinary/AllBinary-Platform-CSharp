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
using Context = android.content.Context;
using IBinder = android.os.IBinder;
using View = android.view.View;
using InputMethodManager = android.view.inputmethod.InputMethodManager;
using ViewCompositeInterface = org.allbinary.android.activity.ViewCompositeInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.android.input.api3;

public class HideVirtualKeyboardRunnable : Runnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly Activity activity;
    public HideVirtualKeyboardRunnable(Activity activity)
    {
        this.activity = activity;
    }

    public virtual void run()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            InputMethodManager inputMethodManager = ((InputMethodManager) this.activity.getSystemService(Context.INPUT_METHOD_SERVICE));
            ViewCompositeInterface viewCompositeInterface = ((ViewCompositeInterface) this.activity);
            if (viewCompositeInterface == null) {
                ForcedLogUtil.log("Activity Null", this);
            }
            View view = viewCompositeInterface.getView();
            if (view.getWindowToken() == null) {
                this.logUtil.putF("Unable to hide virtual keyboard as window token is null - This usually happens during loading when the view is not attached to a window", this, commonStrings.RUN);
                return;
            }
            IBinder token = view.getWindowToken();
            inputMethodManager.hideSoftInputFromWindow(token, 0);
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

}

