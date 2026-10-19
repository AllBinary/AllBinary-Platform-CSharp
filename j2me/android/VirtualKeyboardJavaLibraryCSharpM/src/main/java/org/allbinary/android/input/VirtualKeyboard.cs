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
using VirtualKeyboardEvent = org.allbinary.input.@event.VirtualKeyboardEvent;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.android.input;

public class VirtualKeyboard
{
    public static readonly VirtualKeyboard NULL_VIRTUAL_KEYBOARD = new VirtualKeyboard();
    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public virtual void onVirtualKeyboardEvent(VirtualKeyboardEvent virtualKeyboardEvent)
    {
    }

    public virtual void forceHide()
    {
    }

    public virtual void hide()
    {
    }

}

