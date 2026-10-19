// Generated Code Do Not Modify

using System;
using System.Linq;
using KeyEvent = android.view.KeyEvent;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.input;

public class AndroidAPI9KeyFactory : AndroidKeyFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static AndroidAPI9KeyFactory getInstance()
    {
        if (AndroidAPI9KeyFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            AndroidAPI9KeyFactory.instance = new AndroidAPI9KeyFactory();
        }
        return ((AndroidAPI9KeyFactory) AndroidAPI9KeyFactory.instance);
    }

    protected AndroidAPI9KeyFactory()
    {
        this.KEYCODE_BUTTON_L1 = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_L1, "BUTTON L1");
        this.KEYCODE_BUTTON_R1 = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_R1, "BUTTON R1");
        this.KEYCODE_BUTTON_THUMBR = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_THUMBR, "BUTTON THUMBR");
        this.KEYCODE_BUTTON_THUMBL = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_THUMBL, "BUTTON THUMBL");
        this.KEYCODE_BUTTON_START = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_START, "BUTTON START");
        this.KEYCODE_BUTTON_MODE = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_MODE, "BUTTON MODE");
        this.KEYCODE_BUTTON_B = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_B, "BUTTON B");
        this.KEYCODE_BUTTON_A = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_A, "BUTTON A");
        this.KEYCODE_BUTTON_X = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_X, "BUTTON X");
        this.KEYCODE_BUTTON_Y = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_Y, "BUTTON Y");
        this.KEYCODE_BUTTON_L2 = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_L2, "BUTTON L2");
        this.KEYCODE_BUTTON_R2 = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_R2, "BUTTON R2");
        this.KEYCODE_BUTTON_SELECT = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_SELECT, "BUTTON SELECT");
        this.KEYCODE_BUTTON_C = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_C, "BUTTON C");
        this.KEYCODE_BUTTON_Z = new AndroidGameKey(KeyEvent.KEYCODE_BUTTON_Z, "BUTTON Z");
    }

}

