// Generated Code Do Not Modify

using System;
using System.Linq;
//using Canvas = javax.microedition.lcdui.Canvas;
using KeyEvent = android.view.KeyEvent;

namespace org.allbinary.game.input;

public class AndroidNumberKeyToJ2MECanvasNumberKey
{
    private static readonly int[] androidtoJavaMicroEditionKeyMap = new int[17];
    public static void init()
    {
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_0] = Canvas.KEY_NUM0;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_1] = Canvas.KEY_NUM1;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_2] = Canvas.KEY_NUM2;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_3] = Canvas.KEY_NUM3;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_4] = Canvas.KEY_NUM4;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_5] = Canvas.KEY_NUM5;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_6] = Canvas.KEY_NUM6;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_7] = Canvas.KEY_NUM7;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_8] = Canvas.KEY_NUM8;
        AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[KeyEvent.KEYCODE_9] = Canvas.KEY_NUM9;
    }

    private AndroidNumberKeyToJ2MECanvasNumberKey()
    {
    }

    public static int getKey(int key)
    {
        if (key < AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap.Length) {
            int value = AndroidNumberKeyToJ2MECanvasNumberKey.androidtoJavaMicroEditionKeyMap[key];
            if (value != 0) {
                return value;
            }
        }
        return key;
    }

}

