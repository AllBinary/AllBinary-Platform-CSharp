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
using VirtualKeyboard = org.allbinary.android.input.VirtualKeyboard;
using VirtualKeyboardEvent = org.allbinary.input.@event.VirtualKeyboardEvent;
using VirtualKeyboardEventHandler = org.allbinary.input.@event.VirtualKeyboardEventHandler;
using VirtualKeyboardEventListenerInterface = org.allbinary.input.@event.VirtualKeyboardEventListenerInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.android.input.api3;

public class VirtualKeyboardAPI3 : VirtualKeyboard, VirtualKeyboardEventListenerInterface
{
    public static int MAX_API = int.MaxValue;
    public static int MIN_API = 3;
    private bool virtualKeyboard = false;
    private Activity activity;
    private readonly Runnable showVirtualKeyboardRunnable;
    private readonly Runnable hideVirtualKeyboardRunnable;
    public VirtualKeyboardAPI3(Activity activity) : base()
    {
        // base() is called from the constructor declaration
        this.activity = activity;
        this.showVirtualKeyboardRunnable = new ShowVirtualKeyboardRunnable(this.activity);
        this.hideVirtualKeyboardRunnable = new HideVirtualKeyboardRunnable(this.activity);
        VirtualKeyboardEventHandler virtualKeyboardEventHandler = VirtualKeyboardEventHandler.getInstance();
        virtualKeyboardEventHandler.removeAllListeners();
        virtualKeyboardEventHandler.addListenerInterface(this);
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onVirtualKeyboardEvent(VirtualKeyboardEvent virtualKeyboardEvent)
    {
        bool? isShow = ((bool?) virtualKeyboardEvent.getSource());
        if (isShow) {
            this.showVirtualKeyboard();
        } else {
            this.hideVirtualKeyboard();
        }
    }

    public override void forceHide()
    {
        this.hideVirtualKeyboard();
    }

    public override void hide()
    {
        if (this.virtualKeyboard) {
            this.forceHide();
        }
    }

    private void showVirtualKeyboard()
    {
        this.activity.runOnUiThread(this.showVirtualKeyboardRunnable);
        this.virtualKeyboard = true;
    }

    private void hideVirtualKeyboard()
    {
        this.activity.runOnUiThread(this.hideVirtualKeyboardRunnable);
        this.virtualKeyboard = false;
    }

}

