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
using VirtualKeyboard = org.allbinary.android.input.VirtualKeyboard;
using VirtualKeyboardEventListenerInterface = org.allbinary.input.@event.VirtualKeyboardEventListenerInterface;
using Activity = android.app.Activity;

namespace org.allbinary.android.input.api1;

public class VirtualKeyboardAPI1 : VirtualKeyboard, VirtualKeyboardEventListenerInterface
{
    public static int MIN_API = 1;
    public static int MAX_API = 2;
    public VirtualKeyboardAPI1(Activity activity)
    {
    }

}

