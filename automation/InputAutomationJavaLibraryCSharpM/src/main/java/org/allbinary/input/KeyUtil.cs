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
//using KeyEvent = java.awt.@event.KeyEvent;

namespace org.allbinary.input;

public class KeyUtil
{
    public KeyUtil()
    {
    }

    public static bool isNormallyDisplayed(int keyCode)
    {
        switch (keyCode) {
            case KeyEvent.VK_SPACE:
            case KeyEvent.VK_COMMA:
            case KeyEvent.VK_MINUS:
            case KeyEvent.VK_PERIOD:
            case KeyEvent.VK_SLASH:
            case KeyEvent.VK_0:
            case KeyEvent.VK_1:
            case KeyEvent.VK_2:
            case KeyEvent.VK_3:
            case KeyEvent.VK_4:
            case KeyEvent.VK_5:
            case KeyEvent.VK_6:
            case KeyEvent.VK_7:
            case KeyEvent.VK_8:
            case KeyEvent.VK_9:
            case KeyEvent.VK_SEMICOLON:
            case KeyEvent.VK_EQUALS:
            case KeyEvent.VK_A:
            case KeyEvent.VK_B:
            case KeyEvent.VK_C:
            case KeyEvent.VK_D:
            case KeyEvent.VK_E:
            case KeyEvent.VK_F:
            case KeyEvent.VK_G:
            case KeyEvent.VK_H:
            case KeyEvent.VK_I:
            case KeyEvent.VK_J:
            case KeyEvent.VK_K:
            case KeyEvent.VK_L:
            case KeyEvent.VK_M:
            case KeyEvent.VK_N:
            case KeyEvent.VK_O:
            case KeyEvent.VK_P:
            case KeyEvent.VK_Q:
            case KeyEvent.VK_R:
            case KeyEvent.VK_S:
            case KeyEvent.VK_T:
            case KeyEvent.VK_U:
            case KeyEvent.VK_V:
            case KeyEvent.VK_W:
            case KeyEvent.VK_X:
            case KeyEvent.VK_Y:
            case KeyEvent.VK_Z:
            case KeyEvent.VK_OPEN_BRACKET:
            case KeyEvent.VK_BACK_SLASH:
            case KeyEvent.VK_CLOSE_BRACKET:
            case KeyEvent.VK_NUMPAD0:
            case KeyEvent.VK_NUMPAD1:
            case KeyEvent.VK_NUMPAD2:
            case KeyEvent.VK_NUMPAD3:
            case KeyEvent.VK_NUMPAD4:
            case KeyEvent.VK_NUMPAD5:
            case KeyEvent.VK_NUMPAD6:
            case KeyEvent.VK_NUMPAD7:
            case KeyEvent.VK_NUMPAD8:
            case KeyEvent.VK_NUMPAD9:
            case KeyEvent.VK_MULTIPLY:
            case KeyEvent.VK_ADD:
            case KeyEvent.VK_SEPARATER:
            case KeyEvent.VK_SUBTRACT:
            case KeyEvent.VK_DECIMAL:
            case KeyEvent.VK_DIVIDE:
                return true;
            default:
                return false;
        }
    }

}

