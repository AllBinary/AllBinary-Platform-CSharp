// Generated Code Do Not Modify

using System;
using System.Linq;
using KeyEvent = android.view.KeyEvent;
using ActivityFractureUtil = org.allbinary.android.ActivityFractureUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.input;

public class AndroidKeyFactory : ActivityFractureUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly AndroidGameKey UNKNOWN = new AndroidGameKey(KeyEvent.KEYCODE_UNKNOWN, "UNKNOWN");
    public AndroidGameKey KEYCODE_BUTTON_L1;
    public AndroidGameKey KEYCODE_BUTTON_R1;
    public AndroidGameKey KEYCODE_BUTTON_THUMBR;
    public AndroidGameKey KEYCODE_BUTTON_THUMBL;
    public AndroidGameKey KEYCODE_BUTTON_START;
    public AndroidGameKey KEYCODE_BUTTON_MODE;
    public AndroidGameKey KEYCODE_BUTTON_B;
    public AndroidGameKey KEYCODE_BUTTON_A;
    public AndroidGameKey KEYCODE_BUTTON_X;
    public AndroidGameKey KEYCODE_BUTTON_Y;
    public AndroidGameKey KEYCODE_BUTTON_L2;
    public AndroidGameKey KEYCODE_BUTTON_R2;
    public AndroidGameKey KEYCODE_BUTTON_SELECT;
    public AndroidGameKey KEYCODE_BUTTON_C;
    public AndroidGameKey KEYCODE_BUTTON_Z;
    public AndroidGameKey KEYCODE_BUTTON_1;
    public AndroidGameKey KEYCODE_BUTTON_10;
    public AndroidGameKey KEYCODE_BUTTON_11;
    public AndroidGameKey KEYCODE_BUTTON_12;
    public AndroidGameKey KEYCODE_BUTTON_13;
    public AndroidGameKey KEYCODE_BUTTON_14;
    public AndroidGameKey KEYCODE_BUTTON_15;
    public AndroidGameKey KEYCODE_BUTTON_16;
    public AndroidGameKey KEYCODE_BUTTON_2;
    public AndroidGameKey KEYCODE_BUTTON_3;
    public AndroidGameKey KEYCODE_BUTTON_4;
    public AndroidGameKey KEYCODE_BUTTON_5;
    public AndroidGameKey KEYCODE_BUTTON_6;
    public AndroidGameKey KEYCODE_BUTTON_7;
    public AndroidGameKey KEYCODE_BUTTON_8;
    public AndroidGameKey KEYCODE_BUTTON_9;
    public readonly AndroidGameKey SOFT_LEFT = new AndroidGameKey(KeyEvent.KEYCODE_SOFT_LEFT, "SOFT_LEFT");
    public readonly AndroidGameKey SOFT_RIGHT = new AndroidGameKey(KeyEvent.KEYCODE_SOFT_RIGHT, "SOFT_RIGHT");
    public readonly AndroidGameKey HOME = new AndroidGameKey(KeyEvent.KEYCODE_HOME, "HOME");
    public readonly AndroidGameKey BACK = new AndroidGameKey(KeyEvent.KEYCODE_BACK, "BACK");
    public readonly AndroidGameKey CALL = new AndroidGameKey(KeyEvent.KEYCODE_CALL, "CALL");
    public readonly AndroidGameKey ENDCALL = new AndroidGameKey(KeyEvent.KEYCODE_ENDCALL, "ENDCALL");
    public readonly AndroidGameKey ZERO = new AndroidGameKey(KeyEvent.KEYCODE_0, CommonPhoneStrings.getInstance().ZERO);
    public readonly AndroidGameKey ONE = new AndroidGameKey(KeyEvent.KEYCODE_1, CommonPhoneStrings.getInstance().ONE);
    public readonly AndroidGameKey TWO = new AndroidGameKey(KeyEvent.KEYCODE_2, CommonPhoneStrings.getInstance().TWO);
    public readonly AndroidGameKey THREE = new AndroidGameKey(KeyEvent.KEYCODE_3, CommonPhoneStrings.getInstance().THREE);
    public readonly AndroidGameKey FOUR = new AndroidGameKey(KeyEvent.KEYCODE_4, CommonPhoneStrings.getInstance().FOUR);
    public readonly AndroidGameKey FIVE = new AndroidGameKey(KeyEvent.KEYCODE_5, CommonPhoneStrings.getInstance().FIVE);
    public readonly AndroidGameKey SIX = new AndroidGameKey(KeyEvent.KEYCODE_6, CommonPhoneStrings.getInstance().SIX);
    public readonly AndroidGameKey SEVEN = new AndroidGameKey(KeyEvent.KEYCODE_7, CommonPhoneStrings.getInstance().SEVEN);
    public readonly AndroidGameKey EIGHT = new AndroidGameKey(KeyEvent.KEYCODE_8, CommonPhoneStrings.getInstance().EIGHT);
    public readonly AndroidGameKey NINE = new AndroidGameKey(KeyEvent.KEYCODE_9, CommonPhoneStrings.getInstance().NINE);
    public readonly AndroidGameKey STAR = new AndroidGameKey(KeyEvent.KEYCODE_STAR, CommonPhoneStrings.getInstance().STAR);
    public readonly AndroidGameKey POUND = new AndroidGameKey(KeyEvent.KEYCODE_POUND, CommonPhoneStrings.getInstance().POUND);
    public readonly AndroidGameKey DPAD_UP = new AndroidGameKey(KeyEvent.KEYCODE_DPAD_UP, "UP");
    public readonly AndroidGameKey DPAD_DOWN = new AndroidGameKey(KeyEvent.KEYCODE_DPAD_DOWN, "DOWN");
    public readonly AndroidGameKey DPAD_LEFT = new AndroidGameKey(KeyEvent.KEYCODE_DPAD_LEFT, "LEFT");
    public readonly AndroidGameKey DPAD_RIGHT = new AndroidGameKey(KeyEvent.KEYCODE_DPAD_RIGHT, "RIGHT");
    public readonly AndroidGameKey DPAD_CENTER = new AndroidGameKey(KeyEvent.KEYCODE_DPAD_CENTER, "CENTER");
    public readonly AndroidGameKey VOLUME_UP = new AndroidGameKey(KeyEvent.KEYCODE_VOLUME_UP, "VOLUME_UP");
    public readonly AndroidGameKey VOLUME_DOWN = new AndroidGameKey(KeyEvent.KEYCODE_VOLUME_DOWN, "VOLUME_DOWN");
    public readonly AndroidGameKey POWER = new AndroidGameKey(KeyEvent.KEYCODE_POWER, "POWER");
    public readonly AndroidGameKey CAMERA = new AndroidGameKey(KeyEvent.KEYCODE_CAMERA, "CAMERA");
    public readonly AndroidGameKey CLEAR = new AndroidGameKey(KeyEvent.KEYCODE_CLEAR, "CLEAR");
    public readonly AndroidGameKey A = new AndroidGameKey(KeyEvent.KEYCODE_A, "A");
    public readonly AndroidGameKey B = new AndroidGameKey(KeyEvent.KEYCODE_B, "B");
    public readonly AndroidGameKey C = new AndroidGameKey(KeyEvent.KEYCODE_C, "C");
    public readonly AndroidGameKey D = new AndroidGameKey(KeyEvent.KEYCODE_D, "D");
    public readonly AndroidGameKey E = new AndroidGameKey(KeyEvent.KEYCODE_E, "E");
    public readonly AndroidGameKey F = new AndroidGameKey(KeyEvent.KEYCODE_F, "F");
    public readonly AndroidGameKey G = new AndroidGameKey(KeyEvent.KEYCODE_G, "G");
    public readonly AndroidGameKey H = new AndroidGameKey(KeyEvent.KEYCODE_H, "H");
    public readonly AndroidGameKey I = new AndroidGameKey(KeyEvent.KEYCODE_I, "I");
    public readonly AndroidGameKey J = new AndroidGameKey(KeyEvent.KEYCODE_J, "J");
    public readonly AndroidGameKey K = new AndroidGameKey(KeyEvent.KEYCODE_K, "K");
    public readonly AndroidGameKey L = new AndroidGameKey(KeyEvent.KEYCODE_L, "L");
    public readonly AndroidGameKey M = new AndroidGameKey(KeyEvent.KEYCODE_M, "M");
    public readonly AndroidGameKey N = new AndroidGameKey(KeyEvent.KEYCODE_N, "N");
    public readonly AndroidGameKey O = new AndroidGameKey(KeyEvent.KEYCODE_O, "O");
    public readonly AndroidGameKey P = new AndroidGameKey(KeyEvent.KEYCODE_P, "P");
    public readonly AndroidGameKey Q = new AndroidGameKey(KeyEvent.KEYCODE_Q, "Q");
    public readonly AndroidGameKey R = new AndroidGameKey(KeyEvent.KEYCODE_R, "R");
    public readonly AndroidGameKey S = new AndroidGameKey(KeyEvent.KEYCODE_S, "S");
    public readonly AndroidGameKey T = new AndroidGameKey(KeyEvent.KEYCODE_T, "T");
    public readonly AndroidGameKey U = new AndroidGameKey(KeyEvent.KEYCODE_U, "U");
    public readonly AndroidGameKey V = new AndroidGameKey(KeyEvent.KEYCODE_V, "V");
    public readonly AndroidGameKey W = new AndroidGameKey(KeyEvent.KEYCODE_W, "W");
    public readonly AndroidGameKey X = new AndroidGameKey(KeyEvent.KEYCODE_X, "X");
    public readonly AndroidGameKey Y = new AndroidGameKey(KeyEvent.KEYCODE_Y, "Y");
    public readonly AndroidGameKey Z = new AndroidGameKey(KeyEvent.KEYCODE_Z, "Z");
    public readonly AndroidGameKey COMMA = new AndroidGameKey(KeyEvent.KEYCODE_COMMA, "COMMA");
    public readonly AndroidGameKey PERIOD = new AndroidGameKey(KeyEvent.KEYCODE_PERIOD, AbPathData.getInstance().EXTENSION_SEP);
    public readonly AndroidGameKey ALT_LEFT = new AndroidGameKey(KeyEvent.KEYCODE_ALT_LEFT, "ALT_LEFT");
    public readonly AndroidGameKey ALT_RIGHT = new AndroidGameKey(KeyEvent.KEYCODE_ALT_RIGHT, "ALT_RIGHT");
    public readonly AndroidGameKey SHIFT_LEFT = new AndroidGameKey(KeyEvent.KEYCODE_SHIFT_LEFT, "SHIFT_LEFT");
    public readonly AndroidGameKey SHIFT_RIGHT = new AndroidGameKey(KeyEvent.KEYCODE_SHIFT_RIGHT, "SHIFT_RIGHT");
    public readonly AndroidGameKey TAB = new AndroidGameKey(KeyEvent.KEYCODE_TAB, "TAB");
    public readonly AndroidGameKey SPACE = new AndroidGameKey(KeyEvent.KEYCODE_SPACE, "SPACE");
    public readonly AndroidGameKey SYM = new AndroidGameKey(KeyEvent.KEYCODE_SYM, "SYM");
    public readonly AndroidGameKey EXPLORER = new AndroidGameKey(KeyEvent.KEYCODE_EXPLORER, "EXPLORER");
    public readonly AndroidGameKey ENVELOPE = new AndroidGameKey(KeyEvent.KEYCODE_ENVELOPE, "ENVELOPE");
    public readonly AndroidGameKey ENTER = new AndroidGameKey(KeyEvent.KEYCODE_ENTER, "ENTER");
    public readonly AndroidGameKey DEL = new AndroidGameKey(KeyEvent.KEYCODE_DEL, "DEL");
    public readonly AndroidGameKey GRAVE = new AndroidGameKey(KeyEvent.KEYCODE_GRAVE, "GRAVE");
    public readonly AndroidGameKey MINUS = new AndroidGameKey(KeyEvent.KEYCODE_MINUS, "MINUS");
    public readonly AndroidGameKey EQUALS = new AndroidGameKey(KeyEvent.KEYCODE_EQUALS, "EQUALS");
    public readonly AndroidGameKey LEFT_BRACKET = new AndroidGameKey(KeyEvent.KEYCODE_LEFT_BRACKET, "LEFT_BRACKET");
    public readonly AndroidGameKey RIGHT_BRACKET = new AndroidGameKey(KeyEvent.KEYCODE_RIGHT_BRACKET, "RIGHT_BRACKET");
    public readonly AndroidGameKey BACKSLASH = new AndroidGameKey(KeyEvent.KEYCODE_BACKSLASH, "BACKSLASH");
    public readonly AndroidGameKey SEMICOLON = new AndroidGameKey(KeyEvent.KEYCODE_SEMICOLON, "SEMICOLON");
    public readonly AndroidGameKey APOSTROPHE = new AndroidGameKey(KeyEvent.KEYCODE_APOSTROPHE, "APOSTROPHE");
    public readonly AndroidGameKey SLASH = new AndroidGameKey(KeyEvent.KEYCODE_SLASH, "SLASH");
    public readonly AndroidGameKey AT = new AndroidGameKey(KeyEvent.KEYCODE_AT, "AT");
    public readonly AndroidGameKey NUM = new AndroidGameKey(KeyEvent.KEYCODE_NUM, "NUM");
    public readonly AndroidGameKey HEADSETHOOK = new AndroidGameKey(KeyEvent.KEYCODE_HEADSETHOOK, "HEADSETHOOK");
    public readonly AndroidGameKey FOCUS = new AndroidGameKey(KeyEvent.KEYCODE_FOCUS, "FOCUS");
    public readonly AndroidGameKey PLUS = new AndroidGameKey(KeyEvent.KEYCODE_PLUS, "PLUS");
    public readonly AndroidGameKey MENU = new AndroidGameKey(KeyEvent.KEYCODE_MENU, "MENU");
    public readonly AndroidGameKey NOTIFICATION = new AndroidGameKey(KeyEvent.KEYCODE_NOTIFICATION, "NOTIFICATION");
    public readonly AndroidGameKey SEARCH = new AndroidGameKey(KeyEvent.KEYCODE_SEARCH, "SEARCH");
    public virtual void init()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF("Start/End", this, commonStrings.INIT);
    }

    public virtual bool isSubmission(Input input)
    {
        if (input == this.ENTER) {
            return true;
        } else if (input == this.DPAD_CENTER) {
            return true;
        }
        return false;
    }

    public virtual bool isDelete(Input input)
    {
        return false;
    }

    public virtual bool isBackSpace(Input input)
    {
        if (input == this.DEL) {
            return true;
        }
        return false;
    }

    public virtual bool isLeft(Input input)
    {
        if (input == this.DPAD_LEFT) {
            return true;
        }
        return false;
    }

    public virtual bool isRight(Input input)
    {
        if (input == this.DPAD_RIGHT) {
            return true;
        }
        return false;
    }

    public virtual bool isUp(Input input)
    {
        if (input == this.DPAD_UP) {
            return true;
        }
        return false;
    }

    public virtual bool isDown(Input input)
    {
        if (input == this.DPAD_DOWN) {
            return true;
        }
        return false;
    }

    public virtual bool isEnter(Input input)
    {
        if (input == this.DPAD_CENTER) {
            return true;
        } else if (input == this.ENTER) {
            return true;
        } else if (input == this.CALL) {
            return true;
        }
        return false;
    }

    public AndroidKeyFactory()
    {
        this.KEYCODE_BUTTON_L1 = this.UNKNOWN;
        this.KEYCODE_BUTTON_R1 = this.UNKNOWN;
        this.KEYCODE_BUTTON_THUMBR = this.UNKNOWN;
        this.KEYCODE_BUTTON_THUMBL = this.UNKNOWN;
        this.KEYCODE_BUTTON_START = this.UNKNOWN;
        this.KEYCODE_BUTTON_MODE = this.UNKNOWN;
        this.KEYCODE_BUTTON_B = this.UNKNOWN;
        this.KEYCODE_BUTTON_A = this.UNKNOWN;
        this.KEYCODE_BUTTON_X = this.UNKNOWN;
        this.KEYCODE_BUTTON_Y = this.UNKNOWN;
        this.KEYCODE_BUTTON_L2 = this.UNKNOWN;
        this.KEYCODE_BUTTON_R2 = this.UNKNOWN;
        this.KEYCODE_BUTTON_SELECT = this.UNKNOWN;
        this.KEYCODE_BUTTON_C = this.UNKNOWN;
        this.KEYCODE_BUTTON_Z = this.UNKNOWN;
        this.KEYCODE_BUTTON_1 = this.UNKNOWN;
        this.KEYCODE_BUTTON_10 = this.UNKNOWN;
        this.KEYCODE_BUTTON_11 = this.UNKNOWN;
        this.KEYCODE_BUTTON_12 = this.UNKNOWN;
        this.KEYCODE_BUTTON_13 = this.UNKNOWN;
        this.KEYCODE_BUTTON_14 = this.UNKNOWN;
        this.KEYCODE_BUTTON_15 = this.UNKNOWN;
        this.KEYCODE_BUTTON_16 = this.UNKNOWN;
        this.KEYCODE_BUTTON_2 = this.UNKNOWN;
        this.KEYCODE_BUTTON_3 = this.UNKNOWN;
        this.KEYCODE_BUTTON_4 = this.UNKNOWN;
        this.KEYCODE_BUTTON_5 = this.UNKNOWN;
        this.KEYCODE_BUTTON_6 = this.UNKNOWN;
        this.KEYCODE_BUTTON_7 = this.UNKNOWN;
        this.KEYCODE_BUTTON_8 = this.UNKNOWN;
        this.KEYCODE_BUTTON_9 = this.UNKNOWN;
    }

}

