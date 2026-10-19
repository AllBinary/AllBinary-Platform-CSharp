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
using AndroidInfoFactory = org.allbinary.android.AndroidInfoFactory;
using VirtualKeyboardAPI1 = org.allbinary.android.input.api1.VirtualKeyboardAPI1;
using VirtualKeyboardAPI3 = org.allbinary.android.input.api3.VirtualKeyboardAPI3;
using Activity = android.app.Activity;

namespace org.allbinary.android.input;

public class VirtualKeyboardFactory
{
    private static VirtualKeyboard virtualKeyboard = VirtualKeyboard.NULL_VIRTUAL_KEYBOARD;
    public static void init(Activity activity)
    {
        int SDK_VERSION = AndroidInfoFactory.getInstance().getVersion();
        if (SDK_VERSION <= 2) {
            VirtualKeyboardFactory.virtualKeyboard = new VirtualKeyboardAPI1(activity);
        } else {
            VirtualKeyboardFactory.virtualKeyboard = new VirtualKeyboardAPI3(activity);
        }
    }

    public static VirtualKeyboard getInstance()
    {
        return VirtualKeyboardFactory.virtualKeyboard;
    }

}

